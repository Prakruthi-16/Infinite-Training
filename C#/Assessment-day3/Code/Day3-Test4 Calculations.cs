using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Test4
{
    internal class Program
    {
        delegate int CalculationDelegate(int a1, int a2);
        static void Main(string[] args)
        {
            CalculationDelegate Additions = Add;
            CalculationDelegate Subtraction = Sub;
            CalculationDelegate Multiplication = Multi;
            Console.WriteLine( "Enter the First Number is:");
            int a1 = int.Parse(Console.ReadLine());
            Console.WriteLine( "enter the Second Number is:");
            int a2 = int.Parse(Console.ReadLine());
            Console.WriteLine( $"Addition is : {Additions(a1,a2)}");
            Console.WriteLine( $"Subtraction is : {Subtraction(a1,a2)}");
            Console.WriteLine( $"Multiplications is :{Multiplication(a1,a2)}");
            Console.ReadLine();


        }
        static int Add(int a1,int a2)
        {
            return a1 + a2;
        }
        static int Sub(int a1,int a2)
        {
            return a1 - a2;
        }
        static int Multi(int a1,int a2)
        {
            return a1 * a2;
        }
    }
}
