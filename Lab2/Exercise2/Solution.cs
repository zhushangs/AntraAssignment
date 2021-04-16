using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class Solution
    {
        
        public int solution(int[] A)
        {
            int length = A.Length;
            Array.Sort(A);
            int max = 1, count = 1, ans = A[0];
            for (int i = 1; i < length; i++)
            {
                if(A[i] == A[i - 1])
                {
                    count++;
                }
                else
                {
                    if(count > max)
                    {
                        max = count;
                        ans = A[i - 1];
                    }
                    count = 1;
                }
            }
            if (count > max)
            {
                max = count;
                ans = A[length - 1];
            }
            return ans;
        }
    }
}
