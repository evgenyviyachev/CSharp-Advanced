using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_03
{
    class WordCount
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int counter = 1;            
            string textPath = "";
            string wordsPath = "";
            do
            {
                textPath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\04_WordCount\text" + counter + ".txt";
                wordsPath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\04_WordCount\words" + counter + ".txt";
                string outputPath = @"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\04_WordCount\result" + counter + ".txt";
                Dictionary<string, int> wordsCount = new Dictionary<string, int>();
                string[] words = File.ReadAllText(wordsPath).Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    wordsCount.Add(words[i], 0);
                }
                Regex rgx = new Regex("\\W+");
                string text = rgx.Replace(File.ReadAllText(textPath), " ");
                string[] wordsInText = text.Trim().Split(null);
                for (int i = 0; i < wordsInText.Length; i++)
                {
                    string wordInText = wordsInText[i];
                    if (wordsCount.ContainsKey(wordInText))
                    {
                        wordsCount[wordInText]++;
                    }
                }
                var sortedDictionary = wordsCount.Keys.OrderByDescending(x => wordsCount[x]).Select(x => x);
                
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (var word in sortedDictionary)
                    {
                        writer.Write(word + " - " + wordsCount[word] + Environment.NewLine);
                    }
                }
                counter++;
            } while (File.Exists(@"C:\SoftUni\#1 Programming Fundamentals\C# Advanced\3. Files and Directories\FilesAndDirectoriesTests\Streams Tests\04_WordCount\text" + counter + ".txt"));
        }
    }
}