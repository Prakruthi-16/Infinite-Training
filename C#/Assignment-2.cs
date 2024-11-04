using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nBefore Swapping: num1 = {num1}, num2 = {num2}");


            int temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine($"After Swapping: num1 = {num1}, num2 = {num2}");
            Console.ReadLine();

            Console.WriteLine("---------------2nd Program-------------");
            Console.Write("Enter a digit: ");
            int number = int.Parse(Console.ReadLine());


            Console.WriteLine("{0} {0} {0} {0}", number);
            Console.WriteLine("{0}{0}{0}{0}", number);
            Console.WriteLine("{0} {0} {0} {0}", number);
            Console.WriteLine("{0}{0}{0}{0}", number);
            Console.ReadLine();

            Console.WriteLine("--------------3rd Program--------------");

            Console.Write("Enter a day number (1 for Monday, 2 for Tuesday, ..., 7 for Sunday): ");
            int dayNumber = int.Parse(Console.ReadLine());


            string dayName;

            switch (dayNumber)
            {
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                case 7:
                    dayName = "Sunday";
                    break;
                default:
                    dayName = "Invalid day number";
                    break;
            }


            Console.WriteLine($"The day is: {dayName}");
            Console.ReadLine();

            Console.WriteLine("---------------4th Program-----------------------");
            int[] numbers = { 12,13,10,36,99};

            double average = numbers.Average();

            int minValue = numbers.Min();
            int maxValue = numbers.Max();


            Console.WriteLine($"Average value of array elements: {average}");
            Console.WriteLine($"Minimum value in the array: {minValue}");
            Console.WriteLine($"Maximum value in the array: {maxValue}");
            Console.ReadLine();

            Console.WriteLine("--------------------------------5th Program----------------------");
            int[] marks = new int[10];

            Console.WriteLine("Enter 10 marks:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Mark {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            int total = marks.Sum();

            double avg = marks.Average();

            int minMarks = marks.Min();
            int maxMarks = marks.Max();

            Console.WriteLine($"\nTotal marks: {total}");
            Console.WriteLine($"Average marks: {avg}");
            Console.WriteLine($"Minimum marks: {minMarks}");
            Console.WriteLine($"Maximum marks: {maxMarks}");

            Console.WriteLine("\nMarks in ascending order:");
            Array.Sort(marks);
            foreach (int mark in marks)
            {
                Console.Write(mark + " ");
            }

            Console.WriteLine("\n\nMarks in descending order:");
            Array.Reverse(marks);
            foreach (int mark in marks)
            {
                Console.Write(mark + " ");
            }
            Console.ReadLine();

            Console.WriteLine("_--------------6th Program---------------");

            int[] sourceArray = { 1, 2, 3, 4, 5 };

            int[] targetArray = new int[sourceArray.Length];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                targetArray[i] = sourceArray[i];
            }

            Console.WriteLine("Elements in the target array:");
            for (int i = 0; i < targetArray.Length; i++)
            {
                Console.Write(targetArray[i] + " ");
            }
            Console.ReadLine();


        }
    }
}
