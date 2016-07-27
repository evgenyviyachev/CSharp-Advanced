using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_04
{
    class SortStudents
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
            var studentsSorted = students
                .OrderBy(x => x.LastName)
                .ThenByDescending(x => x.FirstName)
                .Select(x => x.FirstName + " " + x.LastName)
                .ToList();

            foreach (var studentS in studentsSorted)
            {
                Console.WriteLine(studentS);
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}