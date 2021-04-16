using System;

namespace Exercise4
{
    class Spiral
    {
        public void sprial(int[,] a)
        {
            int i, k = 0, l = 0;
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            while (k < m && l < n)
            {

                for (i = l; i < n; ++i)
                {
                    Console.Write(a[k, i] + " ");
                }
                k++;
                for (i = k; i < m; ++i)
                {
                    Console.Write(a[i, n - 1] + " ");
                }
                n--;
                if (k < m)
                {
                    for (i = n - 1; i >= l; --i)
                    {
                        Console.Write(a[m - 1, i] + " ");
                    }
                    m--;
                }
                if (l < n)
                {
                    for (i = m - 1; i >= k; --i)
                    {
                        Console.Write(a[i, l] + " ");
                    }
                    l++;
                }
            }
        }
    }
}
