using System;
using System.Collections.Generic;

namespace PokeD.Core.Data
{
    public class DataItems
    {
        public int Count => _dataItems.Length + 1;

        private string[] _dataItems;


        public DataItems()
        {
            
        }

        public DataItems(string dataItem)
        {
            _dataItems = new []{ dataItem };
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
                if (_dataItems == null)
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


        public void Add(string data)
        {
            List<string> list;
            if (_dataItems != null)
            {
                list = new List<string>(_dataItems);
                list.Add(data);
            }
            else
                list = new List<string> {data};

            _dataItems = list.ToArray();
        }


        public List<string> ToList()
        {
            return _dataItems != null ? new List<string>(_dataItems) : new List<string>();
        }

        public string[] ToArray()
        {
            return _dataItems;
        }
    }
}