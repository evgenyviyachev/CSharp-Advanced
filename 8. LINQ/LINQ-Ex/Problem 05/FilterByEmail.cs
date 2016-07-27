using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_05
{
    class FilterByEmail
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
                    Email = currentStudentData[2]
                });
                student = Console.ReadLine();
            }
            var studentsEmail = students
                .Where(x => x.Email.EndsWith("gmail.com"))
                .Select(x => x.FirstName + " " + x.LastName)
                .ToList();

            foreach (var studentE in studentsEmail)
            {
                Console.WriteLine(studentE);
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    }
}