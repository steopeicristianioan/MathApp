using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathApp.model
{
    class Operation : IComparable<Operation>
    {
        private string username;
        private int type;
        private int n;
        private int k;
        private List<int> values;
        private long result;
        private DateTime time;

        public string Username { get => this.username; }
        public int Type { get => this.type; }
        public int N { get => this.n; }
        public int K { get => this.k; }
        public long Result { get => this.result; }
        public List<int> Values { get => this.values; }
        public DateTime Time { get => this.time; }

        public Operation(int type, int n, int k, string username, long result, List<int> values, DateTime time)
        {
            this.type = type;
            this.n = n;
            this.k = k;
            this.values = values;
            this.result = result;
            this.username = username;
            this.time = time;
        }

        public override string ToString()
        {
            string date = this.time.Year + "|" + this.time.Month + "|" + this.time.Day + "|" + this.time.Hour + "|" + this.time.Minute + "|" + this.time.Second;
            string v = string.Empty;
            if(values.Count != 0)
            {
                foreach (int value in values)
                    v += value.ToString() + ",";
                v = v.Remove(v.Length - 1, 1);
            }
            return this.username + "|" + this.type.ToString() + "|" + this.n.ToString() + "|" + this.k.ToString() + "|" + result.ToString() + "|" + v + "|" + date;
        }
        public int CompareTo(Operation other)
        {
            return 1;
        }
    }
}
