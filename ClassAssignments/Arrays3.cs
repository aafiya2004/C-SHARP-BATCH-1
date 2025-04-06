using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    internal class Arrays3
    {
        static void Main()
        {
            //3.Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)

            int[] arr = { 1, 2, 3, 4, 5, 6 };
            int[] copy = new int[arr.Length];
            Console.WriteLine("The original array is:");
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
                Console.Write(arr[i]+ " ");

            }

            Console.WriteLine("\nThe copied array is:");
            for (int i = 0; i < copy.Length; i++) { 
                Console.Write(copy[i]+ " ");
            }

        }
    }
}
