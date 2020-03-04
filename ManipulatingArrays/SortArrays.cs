using System;
using System.Collections.Generic;
using System.Text;

namespace ManipulatingArrays
{
    class SortArrays
    {
        private int[] ArrayB = new int[] { 1, 3, 5, 7, 9 };
        private int[] ArrayA = new int[] { 0, 2, 4, 6, 8, 10 };
        private int[] ArrayC = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
       

        public SortArrays()
        {

        }

        public SortArrays(int[] ArrayA, int[] ArrayB, int[] ArrayC)
        {
            this.ArrayB = ArrayB;
            this.ArrayA = ArrayA;
            this.ArrayC = ArrayC;
        }

        public int [] Sort()
        {
           

            for (int i = 0; i <ArrayC.Length; i++)
            {
                for (int j = i + 1; j < ArrayC.Length; j++)
                {

                    if (ArrayC[i] > ArrayC[j])

                    {
                       int firstIndex = ArrayC[i];
                        ArrayC[i] = ArrayC[j];
                        ArrayC[j] = firstIndex;
                           
                    }
                    
                }
               
            }
            //code below is to display the elements
            string ouput = "";
            foreach(int n in ArrayC)
            {
                ouput += n.ToString();
            }
            Console.WriteLine(ouput);
            
            
            return ArrayC;
        


        }
    }
}
