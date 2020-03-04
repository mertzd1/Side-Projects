using System;
using System.Collections.Generic;
using System.Text;

namespace ManipulatingArrays
{
    class ReversingArrays
    {
        private int[] ArrayB = new int[] { 1, 3, 5, 7, 9 };
        private int[] ArrayA = new int[] { 0, 2, 4, 6, 8, 10 };
        private int[] ArrayC = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
        private string Out;

        public ReversingArrays()
        {

        }

        public ReversingArrays(int[] ArrayB, int[] ArrayA, int[] ArrayC)
        {
            this.ArrayB = ArrayB;
            this.ArrayA = ArrayA;
            this.ArrayC = ArrayC;
        }

        public string Reverse()
        {
            for (int i = ArrayB.Length - 1; i > -1; i--)
            {
                Out += ArrayB[i];
            }
            return Out;
        }
        public string Reverse1()
        {
            for (int i = ArrayA.Length - 1; i > -1; i--)
            {
                Out += ArrayA[i];
            }
            return Out;
        }
        public string Reverse2()
        {
            for (int i = ArrayC.Length - 1; i > -1; i--)
            {
                Out += ArrayC[i];
            }
            return Out;
        }

    }
}
