using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10
{
    class GroupByGroup
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
            var studentsGroupped = students
                .GroupBy(st => st.Group)
                .OrderBy(st => st.Key);

            foreach (var group in studentsGroupped)
            {
                Console.Write(group.Key + " - ");
                string delim = "";
                foreach (var studentInGroup in group)
                {
                    Console.Write(delim + studentInGroup.FirstName + " " + studentInGroup.LastName);
                    delim = ", ";
                }
                Console.WriteLine();
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