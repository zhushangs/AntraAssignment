using System;

namespace Exercise5
{
    class BinaryTriangle
    {
        int row;

        public void getRow()
        {
            Console.WriteLine("Enter row");
            row = Convert.ToInt32(Console.ReadLine());
        }

        public void printTriangle()
        {
            int p, lastInt=0;
            for (int i = 1; i <= row; i++)
            {
                for (p = 1; p <= i; p++)
                {
                    if (lastInt == 1)
                    {
                        Console.Write("0");
                        lastInt = 0;
                    }
                    else if (lastInt == 0)
                    {
                        Console.Write("1");
                        lastInt = 1;
                    }
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTriangle bTriangle = new BinaryTriangle();
            bTriangle.getRow();
            bTriangle.printTriangle();
        }
    }
}
