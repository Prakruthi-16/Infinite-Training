using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string samp1 = "abcd";
            string output1 = ExchangeCharacter(samp1);
            Console.WriteLine($"Sample1: \"{samp1}\"");
            Console.WriteLine($"Output: {output1}");
            string samp2 = "abcd";
            string output2 = ExchangeCharacter(samp2);
            Console.WriteLine($"Sample2: \"{samp2}\"");
            Console.WriteLine($"Output: {output2}");
            string samp3 = "abcd";
            string output3 = ExchangeCharacter(samp3);
            Console.WriteLine($"Sample3: \"{samp3}\"");
            Console.WriteLine($"Output: {output3}");
            Console.ReadLine();

        }
        static string ExchangeCharacter(string word)
        {
            if (word.Length <= 1)
            {
                return word;
            }

            char firstChar = word[0];
            char lastChar = word[word.Length - 1];

            return lastChar + word.Substring(1, word.Length - 2) + firstChar;
        }
    }
}
