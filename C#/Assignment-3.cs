using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------String Assignment--------------------");
            Console.Write("Enter the a word:");
            string word = Console.ReadLine();
            int length = word.Length;
            Console.WriteLine("The Length of the word is:" + length); */
           Console.WriteLine("-----------2nd program---------------");
            Console.Write("Enter the a word:");
            string word = Console.ReadLine();
            string reverse = new string(word.Reverse().ToArray());
            Console.WriteLine("The Reverse of the word:" + reverse);
            Console.WriteLine("-----------------3rd Program---------------");
            Console.Write("Enter the a word:");
            string word1 = Console.ReadLine();
            Console.Write("Enter the a word:");
            string word2 = Console.ReadLine();
            if(word1.ToLower()==word2.ToLower())
            {
                Console.WriteLine("The Words are the same.");
            }
            else
            {
                Console.WriteLine("The Words are the different.");
            }

        }
    }
}
