using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Test2
{
    internal class BoxArea
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public BoxArea(double len, double breadth)
        {
            Length = len;
            Breadth = breadth;
        }
        public BoxArea Add(BoxArea box)
        {
            double newLength = this.Length + box.Length;
            double newBreadth = this.Breadth + box.Breadth;
            return new BoxArea(newLength, newBreadth);
        }
        public void DisplayAll()
        {
            Console.WriteLine($"Box Area size are ->> Length is : {Length} || Breadth is:{Breadth}");

        }
    }
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine( "enter the Length for Box1:");
            double len1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine( "enter the breadth for box1:");
            double breadth1 = Convert.ToDouble(Console.ReadLine());
            BoxArea box1 = new BoxArea(len1, breadth1);
            Console.WriteLine( "enter the length for Box2:");
            double len2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine( "enter the breadth for box2:");
            double breadth2 = Convert.ToDouble(Console.ReadLine());
            BoxArea box2 = new BoxArea(len2, breadth2);

            BoxArea box3 = box1.Add(box2);
            box3.DisplayAll();
            Console.ReadLine();
        }
    }
}
