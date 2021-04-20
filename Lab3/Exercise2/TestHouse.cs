using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class TestHouse
    {
        static void Main()
        {
            bool debug = true;

            SmallApartment mySmallApartament = new SmallApartment();
            Person myPerson = new Person();

            myPerson.Name = "Kishore";
            myPerson.House = mySmallApartament;
            myPerson.ShowData();

            if (debug)
                Console.ReadLine();
        }

    }
}
