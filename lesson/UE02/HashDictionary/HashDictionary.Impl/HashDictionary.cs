using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HashDictionary.Impl
{
    public class HashDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region Private Fields

        private const int INITIAL_TABLE_SIZE = 8;
        private Node[] hashTable = new Node[INITIAL_TABLE_SIZE];

        #endregion

        #region Public Properties

        public int Count { get; private set; }

        public bool IsReadOnly => throw new System.NotImplementedException();

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = new List<TKey>();
                foreach (var item in this)
                {
                    keys.Add(item.Key);
                }
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = new List<TValue>();
                foreach (var item in this)
                {
                    values.Add(item.Value);
                }
                return values;
            }
        }

        #endregion

        #region Public Indexers

        public TValue this[TKey key]
        {
            get => (FindNode(key) ?? throw new KeyNotFoundException()).Value;
            set
            {
                if (!Add(key, value, out Node node))
                {
                    node.Value = value;
                }
            }
        }

        #endregion

        #region Private Methods

        private bool Add(TKey key, TValue value, out Node node)
        {
            node = FindNode(key);

            if (node is not null) // Key already exists
            {
                return false;
            }

            int index = IndexFor(key);
            node = hashTable[index] = new Node(key, value, hashTable[index]); // prepend
            Count++;
            return true;
        }

        private Node FindNode(TKey key)
        {
            Node node = hashTable[IndexFor(key)];

            for (; node is not null; node = node.Next)
            {
                if (node.Key.Equals(key))
                {
                    return node;
                }
            }
            return null;
        }

        private int IndexFor(TKey key) => Math.Abs(key.GetHashCode()) % hashTable.Length;

        #endregion

        #region Public Methods

        public void Add(TKey key, TValue value)
        {
            if (!Add(key, value, out _))
            {
                throw new ArgumentException("Item already in collection");
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                hashTable[i] = null;
            }
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) => ContainsKey(item.Key);

        public bool ContainsKey(TKey key)
        {
            return FindNode(key) is not null;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                for (Node node = hashTable[i]; node is not null; node = node.Next)
                {
                    yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool Remove(TKey key)
        {
            var node = FindNode(key);

            if(node is not null)
            {
                hashTable[IndexFor(key)] = node.Next;
                return true;
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var node = FindNode(key);
            value = node is not null ? node.Value : default;
            return node is not null;
        }

        #endregion

        #region Private Classes

        private class Node
        {
            #region Public Constructors

            public Node(TKey key, TValue value, Node next = null)
            {
                Key = key;
                Value = value;
                Next = next;
            }

            #endregion

            #region Public Properties

            public TKey Key { get; init; }
            public Node Next { get; set; }
            public TValue Value { get; set; }

            #endregion
        }

        #endregion
    }
}