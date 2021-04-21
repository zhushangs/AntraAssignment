using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class Student : Person
    {
        public void GoToClasses()
        {
            Console.WriteLine("I'am going to class");
        }
        public void ShowAge()
        {
            Console.WriteLine("My age is " + age + " years old");
        }
    }
}
