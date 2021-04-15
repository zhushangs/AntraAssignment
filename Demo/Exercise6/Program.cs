using System;

namespace Exercise6
{
    class Diamond
    {
        int row;

        public void getRow()
        {
            Console.WriteLine("Enter row");
            row = Convert.ToInt32(Console.ReadLine());
        }

        public void printDiamond()
        {

            for (int i = 0; i <= row; i++)
            {
                for (int j = 1; j <= row - i; j++)
                    Console.Write(" ");
                for (int j = 1;  j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }

            for (int i = row - 1; i >= 1; i--)
            {
                for (int j  = 1; j <= row - i; j++)
                    Console.Write(" ");
                for (int j  = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Diamond diamond = new Diamond();
            diamond.getRow();
            diamond.printDiamond();
        }
    }
}
