using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class StudentAndTeacherTest
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Hello();

            Student student = new Student();
            student.SetAge(21);
            student.Hello();
            student.ShowAge();

            Teacher teacher = new Teacher();
            teacher.SetAge(30);
            teacher.Hello();
            teacher.Explain();

        }
    }
}
