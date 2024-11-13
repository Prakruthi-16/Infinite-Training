using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Test3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine( "Enter an integer:");
                int num = int.Parse(Console.ReadLine());
                CheckifNegative(num);
                Console.WriteLine( "The number enterd is positive.");

            }
            catch(ArgumentException e)
            {
                Console.WriteLine( $"Error:{ e.Message}");
            }
            catch(FormatException )
            {
                Console.WriteLine( $"Error: checked and enter a valid Integer.");

            }
            Console.Read();
        }
        static void CheckifNegative(int number)
        {
            if(number<0)
            {
                throw new ArgumentException("The number entered is Negative.");
            }
        }
    }
}
