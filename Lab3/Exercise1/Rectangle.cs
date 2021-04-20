using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    class Rectangle : Shape1
    {

        public void getData()
        {
            Console.Write("Enter Length : ");
            L = float.Parse(Console.ReadLine());

            Console.Write("Enter Breadth : ");
            B = float.Parse(Console.ReadLine());
        }

        public override float Area()
        {
            return L * B;
        }

        public override float Circumference()
        {
            return (2 * (L + B));
        }
    }
}
