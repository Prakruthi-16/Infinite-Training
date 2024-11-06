using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word1 = "Python";
            int position1 = 1;
            string output1 = RemoveCharAtIndex(word1, position1);
            Console.WriteLine(output1);
            string word2 = "Python";
            int position2 = 0;
            string output2 = RemoveCharAtIndex(word2, position2);
            Console.WriteLine(output2);
            string word3 = "Python";
            int position3 = 4;
            string output3 = RemoveCharAtIndex(word3, position1);
            Console.WriteLine(output3);
            Console.ReadLine();
        }
        static string RemoveCharAtIndex(string str, int index)
        {
            if (index < 0 || index >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            return str.Remove(index, 1);

        }
    }
}
