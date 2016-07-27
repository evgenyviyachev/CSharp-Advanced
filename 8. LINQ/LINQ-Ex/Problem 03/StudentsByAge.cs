using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_03
{
    class StudentsByAge
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
                    LastName = currentStudentData[1],
                    Age = int.Parse(currentStudentData[2])
                });
                student = Console.ReadLine();
            }
            var studentsYoung = students
                .Where(x => x.Age >= 18 && x.Age <= 24)
                .Select(x => x.FirstName + " " + x.LastName + " " + x.Age)
                .ToList();

            foreach (var studentY in studentsYoung)
            {
                Console.WriteLine(studentY);
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}