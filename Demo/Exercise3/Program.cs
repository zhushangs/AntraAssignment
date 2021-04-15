using System;

namespace Exercise3
{
    public class Reverse
    {
        string str;
        public void GetString()
        {
            Console.WriteLine("Enter your sentence: ");
            str = Console.ReadLine();
        }
        public void ReveseString()
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine("Reversed sentence: " + new string(charArray));
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Reverse rev = new Reverse();
            rev.GetString();
            rev.ReveseString();
            Console.ReadKey();

        }
    }
}
