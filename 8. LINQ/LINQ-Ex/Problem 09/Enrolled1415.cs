using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_09
{
    class Enrolled1415
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
                    FacultyNumber = currentStudentData[0],
                    Marks = currentStudentData.Skip(1).Select(int.Parse).ToList()
                });
                student = Console.ReadLine();
            }
            var students1415Marks = students
                .Where(x => x.FacultyNumber.EndsWith("14") || x.FacultyNumber.EndsWith("15"))
                .Select(x => x.Marks);

            foreach (var studentMarks in students1415Marks)
            {
                Console.WriteLine(string.Join(" ", studentMarks));
            }
        }

        public class Student
        {
            public string FacultyNumber { get; set; }
            public List<int> Marks { get; set; }
        }
    }
}