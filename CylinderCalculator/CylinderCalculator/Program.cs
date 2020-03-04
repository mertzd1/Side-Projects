using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CylinderCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print a greeting message.
            Console.WriteLine("Welcome to Cylinder Calculator!");

            //Read cylinder's height supplied by the user
            Console.Write("Enter the cylinder's radius");
            string radiusAsAString = Console.ReadLine();
            double radius = Convert.ToDouble(radiusAsAString);
           
            //Read cylinder's height supplied by the user 
            Console.WriteLine("Enter the cylinder's height");
            string heightAsAString = Console.ReadLine();
            double height = Convert.ToDouble(heightAsAString);
            double pi = 3.1415926536;//We'll look at a different way to do PI later on
           
            //These are the standard formulas for cylinder volume and surface area.
            double volume = pi * radius * radius * height;
            double surfaceArea = 2 * pi * radius * (radius + height);

            //Now the results can be output

            Console.WriteLine("The cylinder's volume is:" + volume + " cubic units.");
            Console.WriteLine("The cylinder's surface area is:" + surfaceArea+"squared units.");

            //Before you close, wait for a response from the user...
            Console.ReadKey();

        }
    }
}
