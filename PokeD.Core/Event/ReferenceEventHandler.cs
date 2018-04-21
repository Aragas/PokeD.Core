using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeD.Core.Event
{
    public sealed class ReferenceEventHandler<TEventArgs> : BaseEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly struct DelegateWithReference
        {
            public Type ObjectType { get; }
            public object Object { get; }
            public EventHandler<TEventArgs> Delegate { get; }

            public DelegateWithReference(object @object, EventHandler<TEventArgs> @delegate)
            {
                ObjectType = @object.GetType();
                Object = @object;
                Delegate = @delegate;
            }
            public DelegateWithReference((object Object, EventHandler<TEventArgs> Delegate) tuple)
            {
                ObjectType = tuple.Object.GetType();
                Object = tuple.Object;
                Delegate = tuple.Delegate;
            }
            internal DelegateWithReference(EventHandler<TEventArgs> @delegate)
            {
                ObjectType = null;
                Object = null;
                Delegate = @delegate;
            }


            private bool Equals(in DelegateWithReference x, in DelegateWithReference y) => x.Delegate.Equals(y.Delegate);
            public override bool Equals(object obj) => obj is DelegateWithReference storage && Equals(in this, in storage);

            private int GetHashCode(in DelegateWithReference storage) => storage.Object.GetHashCode() ^ storage.Delegate.GetHashCode();
            public override int GetHashCode() => GetHashCode(in this);
        }
        private List<DelegateWithReference> Subscribers { get; } = new List<DelegateWithReference>();

        public override BaseEventHandler<TEventArgs> Subscribe(object @object, EventHandler<TEventArgs> @delegate) { lock (Subscribers) { Subscribers.Add(new DelegateWithReference(@object, @delegate)); return this; } }
        public override BaseEventHandler<TEventArgs> Subscribe((object Object, EventHandler<TEventArgs> Delegate) tuple) { lock (Subscribers) { Subscribers.Add(new DelegateWithReference(tuple)); return this; } }
        public override BaseEventHandler<TEventArgs> Subscribe(EventHandler<TEventArgs> @delegate) { lock (Subscribers) { Subscribers.Add(new DelegateWithReference(@delegate)); return this; } }
        public override BaseEventHandler<TEventArgs> Unsubscribe(EventHandler<TEventArgs> @delegate) { lock (Subscribers) { Subscribers.Remove(new DelegateWithReference(@delegate)); return this; } }

        protected override void Invoke(object sender, TEventArgs e)
        {
            lock (Subscribers)
            {
                foreach (var subscriber in Subscribers)
                    subscriber.Delegate?.Invoke(sender, e);
            }
        }

        private bool _disposed;
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
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
                            System.Diagnostics.Debugger.Debugger.Break();
#endif
                        }
                    }

                    Subscribers.Clear();
                }

                _disposed = true;
            }
            base.Dispose(disposing);
        }
    }
}