﻿using System.Diagnostics;

namespace BashSoft
{
    public static class CommandInterpreter
    {
        public static void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolutely(input, data);
                    break;
                case "readDB":
                    TryReadDataBaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "download":
                    TryDownloadRequestedFile(input, data);
                    break;
                case "downloadAsync":
                    TryDownloadRequestedFileAsync(input, data);
                    break;
                default:
                    DisplayInvalidCommandsMessage(input);
                    break;
            }
        }

        public static void DisplayInvalidCommandsMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid.");
        }

        public static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IOManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumberExceptionMessage);
                }
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                Tester.CompareContents(firstPath, secondPath);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryChangePathAbsolutely(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                StudentsRepository.InitializeData(fileName);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryGetHelp(string input, string[] data)
        {
            if (data.Length == 1)
            {
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdRel:relative path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdAbs: absolute path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteEmptyLine();
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                StudentsRepository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        public static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameterExceptionMessage);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommandExceptionMessage);
            }
        }

        public static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string comparison = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameterExceptionMessage);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommandExceptionMessage);
            }
        }

        private static void TryDownloadRequestedFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.Download(url);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryDownloadRequestedFileAsync(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.DownloadAsync(url);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }
    }
}