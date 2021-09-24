using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathApp.control
{
    interface IControl<K, V>
    {
        void read();
        void log();
        void write();
        void add(K key, V value);
        void remove(K key, V value);
    }
}
