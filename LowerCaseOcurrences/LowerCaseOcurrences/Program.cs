using System;
using System.Collections.Generic;
using System.Linq;

namespace LowerCaseOcurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please introduce a phrase: ");
            var input = Console.ReadLine();

            Console.WriteLine(LowerCaseCount(input));
        }

        /// <summary>
        /// Create a program – your program should have a function that will take a sentence, in the form of a string, and determine which lowercase character occurred the most.
        /// The return value for your function should be both the character that occurred the most and the number of times it occurred.
        /// NOTES:
        /// This requirements never defines what happens if there are more than one
        /// lowercase with the same occurrences.
        /// To avoid false positives, I assume that I should print ALL 
        /// the lower case character that has the most occurrence.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string LowerCaseCount(string sentence)
        {
            var charList = new Dictionary<char, int>();
            // We want to only use valid characters
            var validChars = "abcdefghijklmnopqrstuvwxyz";

            foreach (var theChar in sentence)
            {
                if (validChars.Contains(theChar.ToString().ToLower()))
                {
                    if (charList.ContainsKey(theChar))
                    {
                        charList[theChar]++;
                    }
                    else
                    {
                        charList[theChar] = 1;
                    }
                }
            }

            var maxLowerChars = charList
                .Where(x => x.Value == charList.Values.Max())
                .ToList();

            var output = string.Empty;

            foreach (var lowerChar in maxLowerChars)
            {
                var letter = lowerChar.Key.ToString();
                var value = (lowerChar.Value > 0) ? lowerChar.Value.ToString() : string.Empty;

                output += $"Letter: '{letter}', Count: {value}\r\n";
            }
            
            return output;
        }
    }
}
