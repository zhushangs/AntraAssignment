using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class Teacher : Person
    {
        private string subject;

        public void Explain()
        {
            Console.WriteLine("Explanation begins");
        }
    }
}
