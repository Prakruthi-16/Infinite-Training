using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketConcession;

namespace Assignment_4
{
    class CallLibrary

    {
        public const double TotalFare = 500.0;
        public string Name { get; set; }
        public int Age { get; set; }

        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            TicketConcession.TicketConcession concession = new TicketConcession.TicketConcession();
            concession.CalculateConcession(age);
            Console.ReadKey();
        }
    }
}