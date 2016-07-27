using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class StudentsByGroup
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
                    Group = int.Parse(currentStudentData[2])
                });
                student = Console.ReadLine();
            }
            var studentsFromGroup2 = students.Where(x => x.Group == 2)
                .OrderBy(x => x.FirstName)
                .Select(x => x.FirstName + " " + x.LastName)
                .ToList();

            foreach (var studentFromGroup2 in studentsFromGroup2)
            {
                Console.WriteLine(studentFromGroup2);
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Group { get; set; }
        }
    }
}