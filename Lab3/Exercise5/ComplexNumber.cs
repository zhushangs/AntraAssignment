using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class ComplexNumber
    {
        public double a;
        public double b;
        public ComplexNumber(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double GetReal()
        {
            return a;
        }


        public void SetReal(double a)
        {
            this.a = a;
        }


        public double GetImaginary()
        {
            return b;
        }


        public void SetImaginary(double b)
        {
            this.b = b;
        }

        public new string ToString()
        {
            return "(" + a + "," + b + ")";
        }

        public double GetMagnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        public void Add(ComplexNumber complex)
        {
            a += complex.GetReal();
            b += complex.GetImaginary();
        }
    }
}
