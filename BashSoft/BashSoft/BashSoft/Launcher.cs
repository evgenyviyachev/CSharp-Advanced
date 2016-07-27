using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            //Traverse a folder:
            //IOManager.TraverseDirectory(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\BashSoft");
            //Console.WriteLine();

            //Test query first method:
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");
            //Console.WriteLine();

            //Test query second method:
            //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");

            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\BashSoft\BashSoft\SimpleJudge\bin\Debug\test1.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\BashSoft\BashSoft\SimpleJudge\bin\Debug\test3.txt");

            //Creating a folder in bin\Debug:
            //IOManager.CreateDirectoryInCurrentFolder("pesho");

            //Trying the new functionality - changing the directory and then returning the initial one:
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //Console.WriteLine(SessionData.currentPath);
            //IOManager.ChangeCurrentDirectoryRelative("Debug");
            //Console.WriteLine(SessionData.currentPath);

            //Traverse the current folder -> SessionData.currentPath:
            //IOManager.TraverseDirectory(0);

            //Files and Directories:
            //Problem 01
            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\01_OddLinesResult.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\01_OddLinesOut.txt");
            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\02_OddLinesResult.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\02_OddLinesOut.txt");
            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\03_OddLinesResult.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\03_OddLinesOut.txt");

            //Problem 02
            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\01_LinesResult.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\01_LinesOut.txt");
            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\02_LinesResult.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\02_LinesOut.txt");
            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\03_LinesResult.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\03_LinesOut.txt");

            //Exception handling:
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);

            //Files with different length:
            //Tester.CompareContents(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\BashSoft\4. Advanced-CSharp-Exception-Handling-Lab\actual.txt",
            //    @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\BashSoft\4. Advanced-CSharp-Exception-Handling-Lab\expected.txt");

            //Creating files with forbidden symbols in their name:
            //IOManager.CreateDirectoryInCurrentFolder("*2");

            //The path has whitespaces -> the TryChangePathAbsolutely method is not working correctly -> should find a way to improve it
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\BashSoft\6. Advanced-CSharp-Regular-Expressions-Lab");
            //Trying the TryReadDataBaseFromFile -> readDB {fileName}
            InputReader.StartReadingCommands();

            //Asynchronous programming functionality ADDED!
        }
    }
}