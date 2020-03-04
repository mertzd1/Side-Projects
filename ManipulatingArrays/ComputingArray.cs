using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatingArrays
{
    class ComputingArray
    {
        private int[] CountSumMean = new int[] { 0, 2, 4, 6, 8, 10 };
        private double sum;
        private double average;
        private double Total;
        
        public ComputingArray()
        {
            
        }

        public ComputingArray(int[]CountSumMean)
        {
            this.CountSumMean = CountSumMean;
        }
        public double CalculateSum()
        {
            foreach (Object obj in CountSumMean)
            {
                if (obj is int)
                {
                    sum += Convert.ToDouble(obj);   
                }
                else if(obj is double)
                {
                    sum += (double)obj;
                }
                else if(obj is string)
                {
                    sum += Convert.ToDouble(obj);
                }

            }
            return sum;

        }
        public double AverageSum()
        {
            average = CalculateSum() / CountSumMean.Length;
            return average;
            
        }

        public double CountArray()
        {
            foreach(object obj in CountSumMean)
            {
               Total = CountSumMean.Count();
            }
            return Total;
        }

        
            
    }
}
