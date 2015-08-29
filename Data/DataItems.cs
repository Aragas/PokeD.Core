using System;
using System.Collections.Generic;

namespace PokeD.Core.Data
{
    public class DataItems
    {
        private string[] _dataItems;

        public DataItems()
        {
        }

        public DataItems(string dataItem)
        {
            _dataItems = new []{ dataItem  };
        }

        public DataItems(string[] dataItems)
        {
            _dataItems = dataItems;
        }

        public DataItems(List<string> dataItems)
        {
            _dataItems = dataItems.ToArray();
        }

        public string this[int index]
        {
            get
            {
                if(_dataItems == null)
                    _dataItems = new string[index + 1];

                if (_dataItems.Length < index + 1)
                    Array.Resize(ref _dataItems, index + 1);

                return _dataItems[index];
            }

            set
            {
                if (_dataItems == null)
                    _dataItems = new string[index + 1];

                if (_dataItems.Length < index + 1)
                    Array.Resize(ref _dataItems, index + 1);

                _dataItems[index] = value;
            }
        }

        public List<string> ToList()
        {
            return new List<string>(_dataItems);
        }

        public void Add(string s)
        {
            List<string> list;
            if (_dataItems != null)
                list = new List<string>(_dataItems) {s};
            else
                list = new List<string>() { s };
            
            _dataItems = list.ToArray();
        }
    }
}