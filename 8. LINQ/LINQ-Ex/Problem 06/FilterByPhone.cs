using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_06
{
    class FilterByPhone
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
                    PhoneNumber = currentStudentData[2]
                });
                student = Console.ReadLine();
            }
            var studentsPhoneNum = students
                .Where(x => x.PhoneNumber.StartsWith("02") || x.PhoneNumber.StartsWith("+3592"))
                .Select(x => x.FirstName + " " + x.LastName)
                .ToList();

            foreach (var studentPN in studentsPhoneNum)
            {
                Console.WriteLine(studentPN);
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}