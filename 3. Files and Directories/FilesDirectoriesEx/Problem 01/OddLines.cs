using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Problem_01
{
    public class OddLines
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int counter = 1;
            List<string> oddLines = new List<string>();
            string filePath = "";
            do
            {
                filePath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\0" + counter + "_OddLinesIn.txt";
                string outputPath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\0" + counter + "_OddLinesResult.txt";
                string[] input = File.ReadAllLines(filePath);
                for (int i = 1; i < input.Length; i += 2)
                {
                    string currentOddLine = input[i];
                    oddLines.Add(currentOddLine);
                }
                File.WriteAllLines(outputPath, oddLines);
                oddLines.Clear();
                counter++;
            } while (File.Exists(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\02_OddLines\0" + counter + "_OddLinesIn.txt"));
        }
    }
}