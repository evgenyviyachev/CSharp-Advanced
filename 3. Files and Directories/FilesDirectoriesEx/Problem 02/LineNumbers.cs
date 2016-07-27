using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem_02
{
    class LineNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int counter = 1;
            List<string> lines = new List<string>();
            string filePath = "";
            do
            {
                filePath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\0" + counter + "_LinesIn.txt";
                string outputPath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\0" + counter + "_LinesResult.txt";
                string[] input = File.ReadAllLines(filePath);
                for (int i = 0; i < input.Length; i++)
                {
                    int lineNumber = i + 1;
                    string currentLine = lineNumber + ". " + input[i];
                    lines.Add(currentLine);
                }
                File.WriteAllLines(outputPath, lines);
                lines.Clear();
                counter++;
            } while (File.Exists(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\03_LineNumbers\0" + counter + "_LinesIn.txt"));
        }
    }
}