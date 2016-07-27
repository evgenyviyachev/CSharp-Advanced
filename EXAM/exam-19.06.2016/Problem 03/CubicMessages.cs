using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_03
{
    class CubicMessages
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            Dictionary<string, string> messageCode = new Dictionary<string, string>();
            
            while (inputLine != "Over!")
            {
                int validLength = int.Parse(Console.ReadLine());
                Regex validation = new Regex(@"^([0-9]+)([a-zA-Z]{" + validLength + @"})([^a-zA-Z]*)$");

                if (validation.IsMatch(inputLine))
                {
                    Match match = validation.Match(inputLine);
                    string firstDigits = match.Groups[1].Value;
                    string message = match.Groups[2].Value;
                    string lastChars = match.Groups[3].Value;

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < firstDigits.Length; i++)
                    {
                        int digit = Convert.ToInt32(firstDigits[i].ToString());
                        if (digit < message.Length)
                        {
                            sb.Append(message[digit]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    for (int i = 0; i < lastChars.Length; i++)
                    {
                        if (char.IsDigit(lastChars[i]))
                        {
                            int digit = Convert.ToInt32(lastChars[i].ToString());
                            if (digit < message.Length)
                            {
                                sb.Append(message[digit]);
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                        }
                    }

                    string verificationCode = sb.ToString();
                    messageCode.Add(message, verificationCode);
                    //Console.WriteLine(message + " == " + verificationCode);
                }
                
                inputLine = Console.ReadLine();
            }

            var output = messageCode.Select(x => x.Key + " == " + x.Value).ToList();
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}