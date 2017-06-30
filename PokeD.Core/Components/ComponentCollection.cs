using System;
using System.Collections.ObjectModel;

namespace PokeD.Core.Components
{
    public class ComponentCollectionEventArgs : EventArgs
    {
        public IComponent Component { get; }

        public ComponentCollectionEventArgs(IComponent component) { Component = component; }
    }

    public class ComponentCollection : Collection<IComponent>
    {
        public event EventHandler<ComponentCollectionEventArgs> ComponentAdded;
        public event EventHandler<ComponentCollectionEventArgs> ComponentRemoved;

        private void OnComponentAdded(ComponentCollectionEventArgs eventArgs) => ComponentAdded?.Invoke(this, eventArgs);
        private void OnComponentRemoved(ComponentCollectionEventArgs eventArgs) => ComponentRemoved?.Invoke(this, eventArgs);

        protected override void InsertItem(int index, IComponent item)
        {
            if (IndexOf(item) != -1)
                throw new ArgumentException("Cannot Add Same Component Multiple Times");

            base.InsertItem(index, item);

            if (item != null)
                OnComponentAdded(new ComponentCollectionEventArgs(item));
        }
        protected override void SetItem(int index, IComponent item) => throw new NotSupportedException();
        protected override void RemoveItem(int index)
        {
            var component = base[index];

            base.RemoveItem(index);

            if (component != null)
                OnComponentRemoved(new ComponentCollectionEventArgs(component));
        }

        protected override void ClearItems()
        {
            for (var i = 0; i < Count; i++)
                OnComponentRemoved(new ComponentCollectionEventArgs(base[i]));

            base.ClearItems();
        }
    }
}