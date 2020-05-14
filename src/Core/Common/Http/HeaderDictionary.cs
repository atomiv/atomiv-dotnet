using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Atomiv.Core.Common.Http
{
    public class HeaderDictionary : ICollection<KeyValuePair<string, StringValues>>,
        IDictionary<string, StringValues>,
        IEnumerable<KeyValuePair<string, StringValues>>
    {
        private Dictionary<string, StringValues> _headers;

        public HeaderDictionary(Dictionary<string, StringValues> headers)
        {
            _headers = headers;
        }

        public HeaderDictionary(IEnumerable<KeyValuePair<string, StringValues>> headers)
            : this(headers.ToDictionary(e => e.Key, e => e.Value))
        {
        }

        public HeaderDictionary(params KeyValuePair<string, StringValues>[] headers)
            : this(headers.ToDictionary(e => e.Key, e => e.Value))
        {
        }

        public HeaderDictionary(params (string, StringValues)[] headers)
            : this(headers.ToDictionary(e => e.Item1, e => e.Item2))
        {
        }

        public HeaderDictionary()
            : this(new Dictionary<string, StringValues>())
        {

        }

        public ICollection<string> Keys => _headers.Keys;

        public ICollection<StringValues> Values => _headers.Values;

        public int Count => _headers.Count;

        public bool IsReadOnly => false; // TODO: VC: Check _map.IsReadOnly;

        public StringValues this[string key]
        {
            get
            {
                return _headers[key];
            } 
            set
            {
                _headers[key] = value;
            }
        }

        public HeaderDictionary Union(HeaderDictionary other)
        {
            // throw new NotImplementedException();

            var otherHeaders = other._headers;

            var resultHeaders = new Dictionary<string, StringValues>();

            foreach(var otherHeader in otherHeaders)
            {
                if(_headers.ContainsKey(otherHeader.Key))
                {
                    var array = _headers[otherHeader.Key]
                        .Union(otherHeader.Value)
                        .ToArray();

                    resultHeaders[otherHeader.Key] = new StringValues(array);
                }
                else
                {
                    resultHeaders.Add(otherHeader.Key, otherHeader.Value);
                }
            }

            return new HeaderDictionary(resultHeaders);
        }

        public void Add(string key, StringValues value)
        {
            _headers.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _headers.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _headers.Remove(key);
        }

        public bool TryGetValue(string key, out StringValues value)
        {
            return _headers.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, StringValues> item)
        {
            _headers.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _headers.Clear();
        }

        public bool Contains(KeyValuePair<string, StringValues> item)
        {
            return _headers.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex)
        {
            // TODO: VC: Check how to implement
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, StringValues> item)
        {
            return _headers.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator()
        {
            return _headers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _headers.GetEnumerator();
        }
    }
}
