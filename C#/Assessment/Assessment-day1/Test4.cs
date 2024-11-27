using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "OOPs Programing";
            int repeat = Count(word);
            Console.WriteLine($"{word}: {repeat}");
        }
        static int Count(string word)
        {
            int rep = 0;
            word = word.ToLower();
            for (int i = 0; i < word.Length; i++)
            {
                char cur = word[i];
                if (char.IsLetter(cur))
                    continue;
                bool iscount = false;
                for (int k = 0; k < i; k++)
                {
                    if (word[k] == cur)
                    {
                        iscount = true;
                        break;
                    }
                }
                if (iscount)
                    continue;
                int count = 0;
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == cur)
                    {
                        count++;

                    }
                }
                if (count > 1)
                {
                    rep++;
                }
            }
            return rep;
        }
    }
}