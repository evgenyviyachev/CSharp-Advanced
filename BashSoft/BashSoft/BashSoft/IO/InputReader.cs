using System;

namespace BashSoft
{
    public static class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessageOnNewLine($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();

            while (input != endCommand)
            {
                CommandInterpreter.InterpretCommand(input);
                OutputWriter.WriteMessageOnNewLine($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}