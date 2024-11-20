using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Test1
{
    internal class Cricket
    {
        public void PointCalculator(int matches)
        {
            int[] score = new int[matches];
            int sum = 0;
            for (int i = 0; i < matches; i++)
            {
                Console.WriteLine($"enter the Score of match {i + 1}:");
                score[i] = Convert.ToInt32(Console.ReadLine());
                sum += score[i];
            }
            double avg = (double)sum / matches;
            Console.WriteLine("sum of Scores is:" + sum);
            Console.WriteLine($"Average Score is :{avg:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the total number of matches played:");
            int n = Convert.ToInt32(Console.ReadLine());

            Cricket ckt = new Cricket();
            ckt.PointCalculator(n);
            Console.ReadLine();
        }
    }
}

