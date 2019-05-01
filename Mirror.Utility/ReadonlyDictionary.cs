using System.Collections;
using System.Collections.Generic;

namespace Mirror.Utility
{
    public class ReadonlyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        protected readonly IDictionary<TKey, TValue> SourceDictionary;
        public ReadonlyDictionary(out IDictionary<TKey, TValue> sourceDictionary)
        {
            sourceDictionary = new Dictionary<TKey, TValue>();
            SourceDictionary = sourceDictionary;
        }

        public TValue this[TKey key] { get => SourceDictionary[key]; }

        public ICollection<TKey> Keys => SourceDictionary.Keys;

        public ICollection<TValue> Values => SourceDictionary.Values;

        public int Count => SourceDictionary.Count;
        public bool IsReadOnly => true;

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return SourceDictionary.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return SourceDictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            SourceDictionary.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return SourceDictionary.GetEnumerator();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return SourceDictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SourceDictionary.GetEnumerator();
        }
    }
}
