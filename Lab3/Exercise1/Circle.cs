using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    class Circle:Shape1
    {
        public void getData()
        {
            Console.Write("Enter Radius : ");
            R = float.Parse(Console.ReadLine());

        }

        public override float Area()
        {
            float pi = (float) 3.14;
            return R * R * pi;
        }

        public override float Circumference()
        {
            float pi = (float)3.14;
            return 2 * pi * R;
        }
    }
}
