using System;
using System.Collections.Generic;
using System.Text;

namespace ManipulatingArrays
{
    class RotatingArray
    {
        private int[] ArrayB = new int[] { 1, 3, 5, 7, 9 };
        private int[] ArrayA = new int[] { 0, 2, 4, 6, 8, 10 };
        private int[] ArrayC = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };        
        private string Out;
        private string Out2;

        public RotatingArray()
        {

        }

        public RotatingArray(int[]ArrayA, int[] ArrayB, int [] ArrayC)
        {
            this.ArrayB = ArrayB;
            this.ArrayA = ArrayA;
            this.ArrayC = ArrayC;
        }

        public string Rotate()
        {
            string userInput;
            int intInput;
                        
            Console.WriteLine("Enter R to move the array to the right or L to ove the array to the left");
            
            userInput = Console.ReadLine();

            Console.WriteLine("Enter the amount of indexes to move");
            intInput = int.Parse(Console.ReadLine());

            if(userInput =="R")
            {
                for (int i = ArrayA.Length - 1; i > ArrayA.Length - ((intInput +1) % ArrayA.Length); i--)
                {

                    Out += ArrayA[i];
                }
                for (int j = 0; j < ArrayA.Length - (intInput % ArrayA.Length); j++)
                {
                    Out2 += ArrayA[j];
                }

            }
            

            else if (userInput =="L")
            {

                for (int i = (intInput % ArrayA.Length); i < ArrayB.Length; i++)
                {
                    Out += ArrayB[i];
                }

                for (int j = 0; j < (intInput % ArrayA.Length); j++)
                {

                    Out2 += ArrayB[j];
                }
               


            }
            return Out += Out2;
        }
    }
}
