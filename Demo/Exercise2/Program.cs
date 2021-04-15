using System;

namespace Exercise2
{
    class Arithmetic
    {
        int a;
        int b;

        public void GetData()
        {
            Console.WriteLine("Enter first number");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            b = Convert.ToInt32(Console.ReadLine());
        }

        public void getSum()
        {
            int sum = a + b;
            Console.WriteLine("Answer for addition: " + sum );
        }
        public void getSub()
        {
            int sum = a - b;
            Console.WriteLine("Answer for subtraction: " + sum);
        }
        public void getProd()
        {
            int sum = a * b;
            Console.WriteLine("Answer for multiplication: " + sum);
        }
        public void getDiv()
        {
            int sum = a / b;
            Console.WriteLine("Answer for division: " + sum);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Arithmetic arth = new Arithmetic();
            arth.GetData();
            arth.getSum();
            arth.getSub();
            arth.getProd();
            arth.getDiv();
        }
    }
}
