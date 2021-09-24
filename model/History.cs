using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathApp.model
{
    class History : IComparable<History>
    {
        private string username;
        private ChainedHashtable<string, Operation> operations;

        public string Username { get => this.username; }
        public ChainedHashtable<string, Operation> Operations { get => this.operations; }

        public History(string name, ChainedHashtable<string, Operation> operations)
        {
            this.username = name;
            this.operations = operations;
        }

        public void log()
        {
            Lista<Operation> values = this.operations.getAllValues(this.username);
            Console.WriteLine(this.username);
            Node<Operation> head = values.First;
            while(head != null)
            {
                Console.WriteLine(head.Data.ToString());
                head = head.Next;
            }
        }
        public Lista<Operation> allOperations()
        {
            Lista<Operation> values = this.operations.getAllValues(this.username);
            return values;
        }

        public int CompareTo(History other)
        {
            return 1;
        }
        public override string ToString()
        {
            return this.username;
        }
    }
}
