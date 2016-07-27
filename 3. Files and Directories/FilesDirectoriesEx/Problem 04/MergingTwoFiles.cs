using System;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Problem_04
{
    class MergingTwoFiles
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int counter = 1;
            string textOnePath = "";
            string textTwoPath = "";
            do
            {
                textOnePath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\05_MergingFiles\0" + counter + "_FileOne.txt";
                textTwoPath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\05_MergingFiles\0" + counter + "_FileTwo.txt";
                string outputPath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\05_MergingFiles\0" + counter + "_Result.txt";
                string[] linesOne = File.ReadAllLines(textOnePath);
                string[] linesTwo = File.ReadAllLines(textTwoPath);
                int biggerNum = Math.Max(linesOne.Length, linesTwo.Length);
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    for (int i = 0; i < biggerNum; i++)
                    {
                        if (i < linesOne.Length)
                        {
                            writer.WriteLine(linesOne[i]);
                        }
                        if (i < linesTwo.Length)
                        {
                            writer.WriteLine(linesTwo[i]);
                        }
                    }
                }
                counter++;
            } while (File.Exists(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\05_MergingFiles\0" + counter + "_FileOne.txt"));

        }
    }
}