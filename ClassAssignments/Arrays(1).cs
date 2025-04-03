using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    internal class Arrays
    {
        static void Main()
        {
            //1.Write a Program to assign integer values to an array and then print the following
            int[] n = new int [6];
            for (int i = 1; i <= 5; i++)
            {
                n[i] = i;
                Console.WriteLine(n[i]);
            }

            //a.Average value of Array elements
            int[] arr = { 10, 67, 45, 90, 20, 89 };
            int add = 0;
            int len= arr.Length;
            for(int i = 0; i < len; i++)
            {
                add += arr[i];
              
            }
            Console.WriteLine("The average is: " + add / len);


            //b.Minimum and Maximum value in an array
            int max = int.MinValue;
            int min= int.MaxValue;
            for(int i = 0;i < len; i++)
            {
                max= Math.Max(max, arr[i]);
                min= Math.Min(min, arr[i]);
               
            }
            Console.WriteLine("The maximum number is: " + max);
            Console.WriteLine("The minimum number is: " + min);

        }

    }
}
