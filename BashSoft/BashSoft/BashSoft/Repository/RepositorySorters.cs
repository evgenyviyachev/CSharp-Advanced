using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositorySorters
    {
        //private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        //{
        //    int totalOfFirstMarks = 0;
        //    foreach (var mark in firstValue.Value)
        //    {
        //        totalOfFirstMarks += mark;
        //    }

        //    int totalOfSecondMarks = 0;
        //    foreach (var mark in secondValue.Value)
        //    {
        //        totalOfSecondMarks += mark;
        //    }

        //    return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
        //}

        //private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        //{
        //    int totalOfFirstMarks = 0;
        //    foreach (var mark in firstValue.Value)
        //    {
        //        totalOfFirstMarks += mark;
        //    }

        //    int totalOfSecondMarks = 0;
        //    foreach (var mark in secondValue.Value)
        //    {
        //        totalOfSecondMarks += mark;
        //    }

        //    return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
        //}

        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudent(wantedData
                    .OrderBy(x => x.Value.Sum())
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudent(wantedData
                    .OrderByDescending(x => x.Value.Sum())
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
            }
        }

        private static void PrintStudent(Dictionary<string,List<int>> studentsSorted)
        {
            foreach (var student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }

//        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
//        {
//            Dictionary<string, List<int>> studentsSorted = GetSortedStudents(wantedData, studentsToTake, comparisonFunc);
//            foreach (var student in studentsSorted)
//            {
//                OutputWriter.PrintStudent(student);
//            }
//        }

//        private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string,List<int>> studentsWanted, int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
//        {
//            int valuesTaken = 0;
//            Dictionary<string, List<int>> studentsSorted = new Dictionary<string, List<int>>();
//            KeyValuePair<string, List<int>> nextInOrder = new KeyValuePair<string, List<int>>();
//            bool isSorted = false;

//            while (true)
//            {
//                if (valuesTaken == takeCount)
//                {
//                    break;
//                }

//                isSorted = true;
//                foreach (var studentWithScore in studentsWanted)
//                {
//                    if (!string.IsNullOrEmpty(nextInOrder.Key))
//                    {
//                        int comparisonResult = comparisonFunc(studentWithScore, nextInOrder);
//                        if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentWithScore.Key))
//                        {
//                            nextInOrder = studentWithScore;
//                            isSorted = false;
//                        }
//                    }
//                    else
//                    {
//                        if (!studentsSorted.ContainsKey(studentWithScore.Key))
//                        {
//                            nextInOrder = studentWithScore;
//                            isSorted = false;
//                        }
//                    }
//                }

//                if (!isSorted)
//                {
//                    studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
//                    valuesTaken++;
//                    nextInOrder = new KeyValuePair<string, List<int>>();
//                }
//            }

//            return studentsSorted;
//        }
    }
}