
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    internal class WordFilter
    {
        static void Main()
        {
            List<string> words = new List<string>();
            Console.WriteLine("Enter words separated by spaces:");
            string input = Console.ReadLine();

            string[] inputArray = input.Split(' ');
            foreach (string word in inputArray)
            {
                words.Add(word);
            }

            List<string> result = new List<string>();

            foreach (string word in words)
            {
                if (word.StartsWith("a") && word.EndsWith("m"))
                {
                    result.Add(word);
                }
            }

            Console.WriteLine("Words starting with 'a' and ending with 'm':");
            foreach (string word in result)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
        }
    }
}
