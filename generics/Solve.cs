using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathApp
{
    static class Solve
    {
        public static long getNFromComb(int k, long res)
        {
            long f = fact(k);
            long aux = f*res;
            for (int i = 1; i <= res; i++)
            {
                if (check(k, i, aux))
                    return i;
            }
            return -1;
        }
        public static long getNFromAranj(int k, long res)
        {
            long r = fact(k) * res;
            for (int i = 1; i <= res; i++)
                if (fact(i) == r)
                    return i;
            return -1;
        }
        public static long getKFromComb(int n, long res)
        {
            long r = fact(n) / res;
            for (int i = 1; i <= n; i++)
                if (fact(i) * fact((n - i)) == r)
                    return i;
            return -1;
        }
        public static long getKFromAranj(int n, long res)
        {
            long r = fact(n) / res;
            for (int i = 1; i <= n; i++)
                if (fact(i) == r)
                    return i;
            return -1;
        }
        private static long fact(int n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
                f *= i;
            return f;
        }
        private static bool check(int k, int number, long r)
        {
            long res = 1;
            for (int i = k - 1; i >= 0; i--)
                res *= (number - i);
            return res == r;
        }

    }
}
