using System;

namespace ManipulatingArrays
{
    class Program
    {
        

        static void Main(string[] args)
        {
            ComputingArray Sum = new ComputingArray();
            Console.WriteLine($"The sum of the array is {Sum.CalculateSum()}");

            ComputingArray Average = new ComputingArray();
            Console.WriteLine($"The mean of the array is {Average.AverageSum()}");

            ComputingArray Total = new ComputingArray();
            Console.WriteLine($"The total number of objects in the array is {Total.CountArray()}");

            ReversingArrays A = new ReversingArrays();
            Console.WriteLine($"The reverse of the entered array is {A.Reverse1()}");

            ReversingArrays B = new ReversingArrays();
            Console.WriteLine($"The reverse of the entered array is {B.Reverse()}");

            ReversingArrays C = new ReversingArrays();
            Console.WriteLine($"The reverse of the entered array is {C.Reverse2()}");

            RotatingArray A_2 = new RotatingArray();
            Console.WriteLine($"The rotations of the entered array is {A_2.Rotate()}");

            SortArrays Sorter = new SortArrays();
            Console.WriteLine($"Here is the sorted array {Sorter.Sort()}");
        }
    }
}
