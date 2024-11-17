using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    internal class NumberSquare
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter numbers separated by spaces:");
            string input = Console.ReadLine();

            string[] inputArray = input.Split(' ');
            foreach (string item in inputArray)
            {
                int number;
                if (int.TryParse(item, out number))
                {
                    numbers.Add(number);
                }
            }

            List<string> result = new List<string>();

            foreach (int number in numbers)
            {
                int square = number * number;
                if (square > 20)
                {
                    result.Add(number + " - " + square);
                }
            }

            Console.WriteLine("Numbers and their squares greater than 20:");
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}