using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeD.Core.Event
{
    public sealed class WeakReferenceEventHandler<TEventArgs> : BaseEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly struct DelegateWithWeakReference
        {
            public Type ObjectType { get; }
            private WeakReference<object> ObjectWeakReference { get; }
            public object Object => ObjectWeakReference.TryGetTarget(out var @object) ? @object : null;
            public EventHandler<TEventArgs> Delegate { get; }

            public DelegateWithWeakReference(object @object, EventHandler<TEventArgs> @delegate)
            {
                ObjectType = @object.GetType();
                ObjectWeakReference = new WeakReference<object>(@object);
                Delegate = @delegate;
            }
            public DelegateWithWeakReference((object Object, EventHandler<TEventArgs> Delegate) tuple)
            {
                ObjectType = tuple.Object.GetType();
                ObjectWeakReference = new WeakReference<object>(tuple.Object);
                Delegate = tuple.Delegate;
            }
            internal DelegateWithWeakReference(EventHandler<TEventArgs> @delegate)
            {
                ObjectType = null;
                ObjectWeakReference = null;
                Delegate = @delegate;
            }


            private bool Equals(in DelegateWithWeakReference x, in DelegateWithWeakReference y) => x.Delegate.Equals(y.Delegate);
            public override bool Equals(object obj) => obj is DelegateWithWeakReference storage && Equals(in this, in storage);

            private int GetHashCode(in DelegateWithWeakReference storage) => storage.Object.GetHashCode() ^ storage.Delegate.GetHashCode();
            public override int GetHashCode() => GetHashCode(in this);
        }
        private List<DelegateWithWeakReference> Subscribers { get; } = new List<DelegateWithWeakReference>();

        private bool IsDisposed { get; set; }

        public override BaseEventHandler<TEventArgs> Subscribe(object @object, EventHandler<TEventArgs> @delegate) { lock (Subscribers) { Subscribers.Add(new DelegateWithWeakReference(@object, @delegate)); return this; } }
        public override BaseEventHandler<TEventArgs> Subscribe((object Object, EventHandler<TEventArgs> Delegate) tuple) { lock (Subscribers) { Subscribers.Add(new DelegateWithWeakReference(tuple)); return this; } }
        public override BaseEventHandler<TEventArgs> Subscribe(EventHandler<TEventArgs> @delegate) { lock (Subscribers) { Subscribers.Add(new DelegateWithWeakReference(@delegate)); return this; } }
        public override BaseEventHandler<TEventArgs> Unsubscribe(EventHandler<TEventArgs> @delegate) { lock (Subscribers) { Subscribers.Remove(new DelegateWithWeakReference(@delegate)); return this; } }

        protected override void Invoke(object sender, TEventArgs e)
        {
            lock (Subscribers)
            {
                foreach (var subscriber in Subscribers)
                    subscriber.Delegate?.Invoke(sender, e);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    lock (Subscribers)
                    {
                        if (Subscribers.Any())
                        {
                            Logger.Log(LogType.Debug, "Leaking events!");
                            foreach (var storage in Subscribers)
                                Logger.Log(LogType.Debug, storage.Object != null ? $"Object {storage.ObjectType} forgot to unsubscribe" : $"Object of type {storage.ObjectType} was disposed but forgot to unsubscribe!");
#if DEBUG
                            System.Diagnostics.Debugger.Break();
#endif
                        }
                    }
                    Subscribers.Clear();
                }

                IsDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}