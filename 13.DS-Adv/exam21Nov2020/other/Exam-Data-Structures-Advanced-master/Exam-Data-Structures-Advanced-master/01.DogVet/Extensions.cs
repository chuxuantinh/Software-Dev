using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.DogVet
{
    public static class Extensions
    {
        public static void AddValueToKey<TKey, TKey1, TValue, TCollection>(
       this IDictionary<TKey, IDictionary<TKey1, TCollection>> dictionary, TKey key, TKey1 key1, TValue value)
       where TCollection : ICollection<TValue>, new()
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary[key] = new SortedDictionary<TKey1, TCollection>();
            }

            if (!dictionary[key].ContainsKey(key1))
            {
                dictionary[key][key1] = new TCollection();
            }

            dictionary[key][key1].Add(value);
        }

        public static void AddValueToKey<TKey, TValue, TCollection>(
            this IDictionary<TKey, TCollection> dictionary, TKey key, TValue value)
            where TCollection : ICollection<TValue>, new()
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary[key] = new TCollection();
            }

            dictionary[key].Add(value);
        }

        public static void RemoveValueFromKey<TKey, TKey1, TValue, TCollection>(
            this IDictionary<TKey, IDictionary<TKey1, TCollection>> dictionary, TKey key, TKey1 key1, TValue value)
            where TCollection : ICollection<TValue>, new()
        {
            if (dictionary.ContainsKey(key))
            {
                if (dictionary[key].ContainsKey(key1))
                {
                    dictionary[key][key1].Remove(value);
                }

                if (!dictionary[key][key1].Any())
                {
                    dictionary[key].Remove(key1);

                    if (!dictionary[key].Any())
                    {
                        dictionary.Remove(key);
                    }
                }
            }
        }

        public static void RemoveValueFromKey<TKey, TValue, TCollection>(
            this IDictionary<TKey, TCollection> dictionary, TKey key, TValue value)
            where TCollection : ICollection<TValue>, new()
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Remove(value);

                if (!dictionary[key].Any())
                {
                    dictionary.Remove(key);
                }
            }
        }
    }
}
