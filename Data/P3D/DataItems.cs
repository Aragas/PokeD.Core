using System;

namespace PokeD.Core.Data.P3D
{
    public class DataItems
    {
        public int Length => _dataItems.Length;

        private string[] _dataItems;

        public DataItems(params string[] dataItems)
        {
            if(dataItems == null)
                dataItems = new string[0];
            
            _dataItems = dataItems;
        }


        public string this[int index]
        {
            get
            {
                if (_dataItems.Length < index + 1)
                    return string.Empty;

                // if string is null, make it empty.
                if (_dataItems[index] == null)
                    _dataItems[index] = string.Empty;

                return _dataItems[index];
            }

            set
            {
                if (_dataItems.Length < index + 1)
                    Array.Resize(ref _dataItems, index + 1);

                // if string is null, make it empty.
                if (value == null)
                    value = string.Empty;
                
                _dataItems[index] = value;
            }
        }


        public void AddToEnd(string data)
        {
            var index = _dataItems.Length;

            if (_dataItems.Length < index + 1)
                Array.Resize(ref _dataItems, index + 1);

            _dataItems[index] = data;
        }


        public string[] ToArray()
        {
            return _dataItems;
        }

        public override string ToString()
        {
            return string.Join("*", _dataItems);
        }
    }
}