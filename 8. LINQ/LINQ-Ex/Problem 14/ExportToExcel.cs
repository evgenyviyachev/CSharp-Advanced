using ExcelLibrary.SpreadSheet;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace Problem_14
{
    class ExportToExcel
    {
        static void Main()
        {
            string file = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\8. LINQ\StudentData.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("data");

            worksheet.Cells.FirstRowIndex = 0;
            worksheet.Cells.LastRowIndex = 101;
            worksheet.Cells.FirstColIndex = 0;
            worksheet.Cells.LastColIndex = 11;

            Regex rgx = new Regex(@"\s+");
            string[] lines = File.ReadAllLines(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\8. LINQ\StudentData.txt");

            string[] firstLineInit = rgx.Replace(lines[0], " ").Trim().Split();
            List<string> firstLine = new List<string>();
            firstLine.Add(firstLineInit[0]);
            firstLine.Add(firstLineInit[1] + " " + firstLineInit[2]);
            firstLine.Add(firstLineInit[3] + " " + firstLineInit[4]);
            firstLine.Add(firstLineInit[5]);
            firstLine.Add(firstLineInit[6]);
            firstLine.Add(firstLineInit[7]);
            firstLine.Add(firstLineInit[8]);
            firstLine.Add(firstLineInit[9]);
            firstLine.Add(firstLineInit[10]);
            firstLine.Add(firstLineInit[11]);
            firstLine.Add(firstLineInit[12]);

            for (int j = worksheet.Cells.FirstColIndex; j < worksheet.Cells.LastColIndex; j++)
            {
                worksheet.Cells[0, j] = new Cell(firstLine[j]);
            }
            
            for (int i = worksheet.Cells.FirstRowIndex + 1; i < worksheet.Cells.LastRowIndex; i++)
            {
                string[] currentLine = rgx.Replace(lines[i], " ").Trim().Split();

                for (int j = worksheet.Cells.FirstColIndex; j < worksheet.Cells.LastColIndex; j++)
                {
                    worksheet.Cells[i, j] = new Cell(currentLine[j]);
                }
            }

            workbook.Worksheets.Add(worksheet);
            workbook.Save(file);
        }
    }
}