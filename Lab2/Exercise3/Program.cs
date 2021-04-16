using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int ans = sol.solution(4, 17);
            Console.WriteLine($"Perfect Square: {ans}");
        }
    }
}
