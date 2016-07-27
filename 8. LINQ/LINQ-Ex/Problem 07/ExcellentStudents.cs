using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_07
{
    class ExcellentStudents
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
                    Marks = currentStudentData.Skip(2).Select(int.Parse).ToList()
                });
                student = Console.ReadLine();
            }
            var studentsExcellent = students
                .Where(x => x.Marks.Contains(6))
                .Select(x => x.FirstName + " " + x.LastName)
                .ToList();

            foreach (var studentExc in studentsExcellent)
            {
                Console.WriteLine(studentExc);
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<int> Marks { get; set; }
        }
    }
}