using System;

namespace PokeD.Core.Data
{
    public class DataItems
    {
        public int Count => _dataItems.Length;

        private string[] _dataItems;


        public DataItems()
        {
            
        }

        public DataItems(params string[] dataItems)
        {
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
                if (_dataItems == null)
                    _dataItems = new string[index + 1];

                if (_dataItems.Length < index + 1)
                    Array.Resize(ref _dataItems, index + 1);

                // if string is null, make it empty.
                if (value == null)
                    value = string.Empty;
                
                _dataItems[index] = value;
            }
        }


        public void Add(string data)
        {
            if (_dataItems == null)
                _dataItems = new string[0];

            var index = _dataItems.Length;
            if (_dataItems.Length < index + 1)
                Array.Resize(ref _dataItems, index + 1);

            _dataItems[index] = data;
        }


        public string[] ToArray()
        {
            return _dataItems;
        }
    }
}