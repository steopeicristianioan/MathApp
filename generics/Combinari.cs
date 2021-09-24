using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace mathApp
{
    class Combinari<T> where T : IComparable<T>
    {
        protected int[] s;
        protected List<T> values;

        protected int k;
        protected int n;

        protected int[] f;

        private string allResults;
        public string AllResults { get => this.allResults; }

        public Combinari(int k)
        {
            this.k = k;
            this.s = new int[k];
        }
        public Combinari(List<T> values, int n, int k)
        {
            this.values = values;

            s = new int[k + 1];
            f = new int[k + 1];
            this.k = k;
            this.n = n;
        }
        public Combinari(int n, int k)
        {
            this.k = k;
            this.n = n;
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
            for (int i = 1; i <= k; i++)
            {
                Console.Write(values[s[i]] + "  ");
                aux += values[s[i]].ToString() + ",";
            }
            allResults += aux.Remove(aux.Length - 1, 1) + "\n";
            Console.WriteLine();
        }
        protected virtual bool valid(int index)
        {
            for (int i = 1; i <= index; i++)
                if (s[i] == s[index])
                    return false;
            return true;
        }
        protected virtual bool solutie(int index)
        {
            return index == k;
        }
        public virtual void back(int index)
        {
            for (int val = s[index-1] + 1; val < values.Count; val++)
            {
                s[index] = val;
                if (f[index] == 0)
                {
                    f[index] = 1;
                    if (solutie(index))
                    {
                        tipar();
                    }
                    else
                    {
                        back(index + 1);
                    }
                    f[index] = 0;
                }
            }
        }

        public long result()
        {
            int v = 0, flag = 0;
            if (k > (n - k))
                v = k + 1;
            else
            {
                v = (n - k) + 1;
                flag = 1;
            }
            long r = 1;
            for (int i = v; i <= n; i++)
                r *= i;
            if(flag == 0)
                return r / fact(n - k);
            return r / fact(k);
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
            foreach(string line in allResults.Split('\n'))
            {
                if(line != string.Empty)
                {
                    Label label = new Label();
                    label.Parent = panel;
                    label.Size = title.Size;
                    label.Font = title.Font;
                    label.Location = new System.Drawing.Point(25, y);
                    label.Text = line;
                    label.TextAlign = title.TextAlign;
                    //label.BorderStyle = BorderStyle.FixedSingle;
                    y += 40;
                }
            }
        }
    }
}
