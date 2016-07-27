using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        //private static bool ExcellentFilter(double mark)
        //{
        //    return mark >= 5.00;
        //}

        //private static bool AverageFilter(double mark)
        //{
        //    return mark < 5.00 && mark >= 3.50;
        //}

        //private static bool PoorFilter(double mark)
        //{
        //    return mark < 3.50;
        //}

        //private static double Average(List<int> scoresOnTasks)
        //{
        //    int totalScore = 0;
        //    foreach (var scoreOnTask in scoresOnTasks)
        //    {
        //        totalScore += scoreOnTask;
        //    }

        //    double percentageOfAll = (double)totalScore / (scoresOnTasks.Count * 100);
        //    double mark = percentageOfAll * 4 + 2;

        //    return mark;
        //}

        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilterExceptionMessage);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                double averageScore = userName_Points.Value.Average();
                double percentageOfFulfillment = averageScore / 100;
                double mark = percentageOfFulfillment * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }
    }
}