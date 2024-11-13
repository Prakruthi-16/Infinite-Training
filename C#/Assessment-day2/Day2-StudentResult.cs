using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2_Test1
{
    abstract class StudentResult
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public abstract bool Ispassed(double grade);
    }
     
    class UnderGraduate : StudentResult
    {
        public override bool Ispassed(double grade)
        {
            if (grade > 70.0)
                return true;
            else
                return false;
        }
    }
    class Graduate:StudentResult
    {
        public override bool Ispassed(double grade)
        {
            if (grade > 80.0)
                return true;
            else
                return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)

        {
            UnderGraduate ug = new UnderGraduate();
            ug.Name = "Prakruthi";
            ug.StudentId = 65;
            ug.Grade = 77.7;
            Console.WriteLine( "Undergraduate Result:");
            Console.WriteLine( "Name:"+ug.Name);
            Console.WriteLine( "Student Id:"+ug.StudentId);
            Console.WriteLine( "Grade:"+ug.Grade);
            Console.WriteLine( "Passed:"+ug.Ispassed(ug.Grade));
            Console.WriteLine( );

            Graduate grad = new Graduate();
            grad.Name = "Prakruthi";
            grad.StudentId = 6789;
            grad.Grade = 87.9;

            Console.WriteLine( "Graduate Result:");
            Console.WriteLine( "Name:"+grad.Name);
            Console.WriteLine( "StudentId:"+grad.StudentId);
            Console.WriteLine( "Grdae:"+grad.Grade);
            Console.WriteLine( "Passed:"+grad.Ispassed(grad.Grade));
            Console.ReadLine();
        }
    }
}
