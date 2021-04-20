using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class Person
    {
        protected int age;

        public virtual void Hello() 
        {
            Console.WriteLine("Hello");
        }

        public void SetAge(int n) 
        {
            this.age = n;
        }
        public void ShowAge()
        {
            Console.WriteLine("My age is " + age + " years old");
        }
    }
}
