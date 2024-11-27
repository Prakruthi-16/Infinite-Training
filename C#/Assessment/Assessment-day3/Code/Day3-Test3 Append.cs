using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_4
{
    internal class AppendText
    {
        static void Main(string[] args)
        {
            string filePath = "Prakruthi.txt";

            try
            {

                Console.WriteLine("Enter the text to append:");
                string textToAppend = Console.ReadLine();


                if (File.Exists(filePath))
                {

                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {

                        writer.WriteLine(textToAppend);
                    }
                }
                else
                {

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {

                        writer.WriteLine(textToAppend);
                    }
                }

                Console.WriteLine("Text appended successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ReadKey();
            }
            Console.ReadLine();
        }
    }
}