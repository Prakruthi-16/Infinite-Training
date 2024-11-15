using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5_file
{
    public class Program
    {
        public static void Main()
        {
            string[] stringArray = new string[] {
         "one",
         "two",
         "three"
      };
            File.WriteAllLines("hello everyone.txt", stringArray);
            using (StreamReader sr = new StreamReader("hello everyone.txt"))
            {
                string res = sr.ReadToEnd();
                Console.WriteLine(res);
            }
        }
    }

    
}
