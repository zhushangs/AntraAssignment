using System;

namespace Exercise4
{
    class Armstrong
    {
        int first;
        int second;

        public void GetData()
        {
            Console.WriteLine("Enter first number");
            first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            second = Convert.ToInt32(Console.ReadLine());
        }

        public void CalData()
        {
            int temp, sum, r, i;

            Console.Write("Armstrong numbers in given range are: ");
            for (i = first; i <= second; i++)
            {
                temp = i;
                sum = 0;

                while(temp != 0)
                {
                    r = temp % 10;
                    temp /= 10;
                    sum = sum + (r * r * r);
                }
                if(sum == i)
                {
                    Console.Write("{0} ", i);
                }
            }
            Console.Write("\n");
        }

    }
        class Program
    {
        static void Main(string[] args)
        {
            Armstrong arm = new Armstrong();
            arm.GetData();
            arm.CalData();
        }
    }
}
