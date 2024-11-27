using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three integers:");
            int val1 = Convert.ToInt32(Console.ReadLine());
            int val2 = Convert.ToInt32(Console.ReadLine());
            int val3 = Convert.ToInt32(Console.ReadLine());

            int largestNumber = LargestNumber(val1,val2,val3);
            Console.WriteLine($"The largest number is: {largestNumber}");
            Console.ReadKey();
        }

        static int LargestNumber(int Numb1, int Numb2, int Numb3)
        {
            int large = Numb1;

            if (Numb2 > large)
            {
                large = Numb2;
            }

            if (Numb3 > large)
            {
                large = Numb3;
            }

            return large;
        }
    }
}
