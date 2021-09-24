using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace mathApp
{
    class Stored<K,V>  : IComparable<Stored<K,V>>
    {
        private K key;
        private V value;

        public K Key { get => this.key; set => this.key = value; }
        public V Value { get => this.value; set => this.value = value; }

        public Stored(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public int CompareTo(Stored<K, V> other)
        {
            throw new NotImplementedException();
        }
    }
}
