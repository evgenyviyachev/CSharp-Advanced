using System;
using System.Collections.Generic;

namespace Problem_02
{
    class FirstLastName
    {
        static void Main()
        {
            string student = Console.ReadLine();
            List<Student> students = new List<Student>();
            while (student != "END")
            {
                string[] currentStudentData = student.Split();
                students.Add(new Student()
                {
                    FirstName = currentStudentData[0],
                    LastName = currentStudentData[1]
                });
                student = Console.ReadLine();
            }
            var studentFirstLast = students.RemoveAll(x => x.FirstName.CompareTo(x.LastName) == 1);

            foreach (var studentF in students)
            {
                Console.WriteLine(studentF.FirstName + " " + studentF.LastName);
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}