using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace mathApp
{
    class Aranjamente<T> where T : IComparable<T>
    {
        protected int[] s;
        protected int k;
        protected int n;

        private string allResults;
        public string AllResults { get => this.allResults; }

        protected List<T> values;

        public Aranjamente(int k)
        {
            this.k = k;
            this.s = new int[k];
        }
        public Aranjamente(List<T> values, int k)
        {
            this.values = values;

            s = new int[k];
            this.k = k;
        }
        public Aranjamente(int n, int k) 
        {
            this.n = n;
            this.k = k;
        }

        private long fact(int number)
        {
            long p = 1;
            for (int i = 1; i <= number; i++)
                p *= i;
            return p;
        }
        protected virtual void tipar()
        {
            string aux = string.Empty;
            for (int i = 0; i < k; i++)
                aux += values[s[i]].ToString() + ",";
            allResults += aux.Remove(aux.Length - 1, 1) + "\n";
        }
        protected virtual bool valid(int k)
        {
            for (int i = 0; i < k; i++)
                if (s[k] == s[i])
                    return false;
            return true;
        }
        protected virtual bool solutie(int index)
        {
            return index == k - 1;
        }
        public virtual void back(int index)
        {
            for (int val = 0; val < values.Count; val++)
            {
                s[index] = val;
                if (valid(index))
                {
                    if (solutie(index))
                    {
                        tipar();
                    }
                    else
                    {
                        back(index+1);
                    }
                }
            }
        }
        public long result()
        {
            int v = k + 1;
            long r = 1;
            for (int i = v; i <= n; i++)
                r *= i;
            return r;
        }
        public void loadResults(Panel panel)
        {
            Label title = new Label();
            title.Parent = panel;
            title.Location = new System.Drawing.Point(30, 5);
            title.Size = new System.Drawing.Size(220, 30);
            title.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            title.Text = "Rezultatele";
            int y = 40;
            foreach (string line in allResults.Split('\n'))
            {
                if (line != string.Empty)
                {
                    Label label = new Label();
                    label.Parent = panel;
                    label.Size = title.Size;
                    label.Font = title.Font;
                    label.Location = new System.Drawing.Point(25, y);
                    label.Text = line;
                    label.TextAlign = title.TextAlign;
                    y += 40;
                }
            }
        }
        public long resultPerm()
        {
            return fact(n);
        }
    }
}
