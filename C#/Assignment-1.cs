using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Data:");
            Console.WriteLine("Input 1st Number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input 2nd NUmber:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and  {num2} are equal");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} are not equal");
            }
            Console.WriteLine("--------------------2nd Program-------------------------");
            Console.WriteLine("Test Data:");
            int num3 = Convert.ToInt32(Console.ReadLine());
            if (num3 > 0)
            {
                Console.WriteLine($"{num3} is a Positive Number");
            }
            else
            {
                Console.WriteLine($"{num3} is not Positive Number");
            }
            Console.WriteLine("---------------------------3rd Program-----------------------------");
            Console.WriteLine("Input Number 1 is:");
            double num4 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Opration");
            char operation = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Input Number 2 is:");
            double num5 = Convert.ToDouble(Console.ReadLine());
            double res = 0;
            bool ValidOpertion = true;
            switch (operation)
            {
                case '+':
                    res = num4 + num5;
                    break;
                case '-':
                    res = num4 - num5;
                    break;
                case '*':
                    res = num4 * num5;
                    break;
                case '/':
                    if (num4 != 0)
                    {
                        res = num4 / num5;
                    }
                    else
                    {
                        Console.WriteLine("Divisopn by  zero is not allowed.");
                    }
                    ValidOpertion = false;
                    break;
            }
            if (ValidOpertion)
            {
                Console.WriteLine($"{num4} {operation} {num5} = {res}");
            }
            Console.WriteLine("---------------------4th Program------------------------");
            Console.WriteLine("Enter the number6");
            int num6 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                int result = num6 * i;
                Console.WriteLine($"{num6} * {i} = {result}");
            }
            Console.WriteLine("---------------------5th Program--------------------");
            Console.WriteLine("enter the num7:");
            int num7 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the num8:");
            int num8 = Convert.ToInt32(Console.ReadLine());
            int sum = num7 + num8;
            if (num7 == num8)
            {
                int triple = 3 * sum;

                Console.WriteLine($"{num7} ,{num8} sum is {triple}");
            }
            else
            {
                sum = num7 + num8;
                Console.WriteLine($"{num7} ,{num8} sum is {sum}");

            }
        }
    }
}
