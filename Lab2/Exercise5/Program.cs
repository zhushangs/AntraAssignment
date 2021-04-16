using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box();
            Box box2 = new Box();
            Box box3 = new Box();

            double volume = 0.0;

            box1.setBreadth(4.4);
            box1.setHeight(1.1);
            box1.setLength(2.2);
            
            volume = box1.getVolume();
            Console.WriteLine("Volumne of Box1:{0}", volume);

           
            box2.setBreadth(4.4);
            box2.setHeight(1.1);
            box2.setLength(2.2);
            volume = box2.getVolume();
            Console.WriteLine("Volumne of Box2:{0}", volume);


            box3 = box1 + box2;
            volume = box3.getVolume();
            Console.WriteLine("Volumne of Box3:{0}", volume);

        }
    }
}
