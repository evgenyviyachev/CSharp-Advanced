using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11
{
    class StudentsSpecialties
    {
        static void Main()
        {
            var specialtyNumber = new List<StudentSpecialty>();
            var numberStudent = new List<Student>();
            string input = Console.ReadLine();
            while (input != "Students:")
            {
                string[] currentSpecialtyNumber = input.Split();
                string specialty = currentSpecialtyNumber[0] + " " + currentSpecialtyNumber[1];
                int facultyNum = int.Parse(currentSpecialtyNumber[2]);
                specialtyNumber.Add(new StudentSpecialty
                {
                    SpecialtyName = specialty,
                    FacultyNumber = facultyNum
                });
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                string[] currentNumberStudent = input.Split();
                string studentFullName = currentNumberStudent[1] + " " + currentNumberStudent[2];
                int facultyNum = int.Parse(currentNumberStudent[0]);
                numberStudent.Add(new Student
                {
                    StudentName = studentFullName,
                    FacultyNumber = facultyNum
                });
                input = Console.ReadLine();
            }

            var joined = from Item1 in specialtyNumber
                         join Item2 in numberStudent
                         on Item1.FacultyNumber equals Item2.FacultyNumber
                         orderby Item2.StudentName
                         select new { Item1, Item2 };

            var joined2 = specialtyNumber
                          .Join(numberStudent,
                          sn => sn.FacultyNumber,
                          ns => ns.FacultyNumber,
                          (sn, ns) => new { sn.SpecialtyName, ns.StudentName, ns.FacultyNumber })
                          .OrderBy(x => x.StudentName);


            foreach (var item in joined)
            {
                Console.WriteLine(item.Item2.StudentName + " " + item.Item2.FacultyNumber + " " + item.Item1.SpecialtyName);
            }

            Console.WriteLine();

            foreach (var item in joined2)
            {
                Console.WriteLine(item.StudentName + " " + item.FacultyNumber + " " + item.SpecialtyName);
            }
        }

        public class StudentSpecialty
        {
            public string SpecialtyName { get; set; }
            public int FacultyNumber { get; set; }
        }

        public class Student
        {
            public string StudentName { get; set; }
            public int FacultyNumber { get; set; }
        }
    }
}