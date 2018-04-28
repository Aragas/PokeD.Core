﻿using System;
using System.Diagnostics;
using System.Linq;

namespace PokeD.Core.Event
{
    /// <summary>
    /// Based on EventHandler, it does not stores the object reference that subscribed.
    /// </summary>
    public sealed class BasicEventHandler<TEventArgs> : BaseEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private event EventHandler<TEventArgs> EventHandler;

        private bool IsDisposed { get; set; }

        public override BaseEventHandler<TEventArgs> Subscribe(object @object, EventHandler<TEventArgs> @delegate) { EventHandler += @delegate; return this; }
        public override BaseEventHandler<TEventArgs> Subscribe((object Object, EventHandler<TEventArgs> Delegate) tuple) { EventHandler += tuple.Delegate; return this; }
        public override BaseEventHandler<TEventArgs> Subscribe(EventHandler<TEventArgs> @delegate) { EventHandler += @delegate; return this; }
        public override BaseEventHandler<TEventArgs> Unsubscribe(EventHandler<TEventArgs> @delegate) { EventHandler -= @delegate; return this; }

        protected override void Invoke(object sender, TEventArgs e) { EventHandler?.Invoke(sender, e); }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    if (EventHandler?.GetInvocationList().Any() == true)
                    {
                        Logger.Log(LogType.Debug, "Leaking events!");
#if DEBUG
                        Debugger.Break();
#endif
                    }
                }

                IsDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}