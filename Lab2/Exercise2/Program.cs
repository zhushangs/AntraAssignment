using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] arr = { 10, 20, 30, 40, 10 };
            int occur = sol.solution(arr);
            Console.WriteLine($"Most often number in array is: {occur}");

        }
    }
}
