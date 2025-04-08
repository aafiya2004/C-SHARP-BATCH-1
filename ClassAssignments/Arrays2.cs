using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    internal class Arrays2
    {
        static void Main()
        {
            //2.Write a program in C# to accept ten marks and display the following
      
            int[] arr = new int[10];
            Console.WriteLine("Enter the marks: ");
            for (int i = 0; i < 10; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            // a.	Total
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("The Total marks is: " + sum);

            //  b.Average
            int len = arr.Length;
            Console.WriteLine("The average is: " + sum / len);


            // c.Minimum marks
            int min = int.MaxValue;
            for (int i = 0; i < len; i++)
            {
                min = Math.Min(min, arr[i]);

            }
            Console.WriteLine("The minimum number is: " + min);

            // d.Maximum marks
            int max = int.MinValue;
            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            Console.WriteLine("The maximum number is: " + max);

            //  e.Display marks in ascending order
            Array.Sort(arr);
            Console.WriteLine("The ascending order: ");
            for(int i = 0; i < len; i++)
            {
                Console.Write(arr[i] + " ");
            }

            // f.Display marks in descending order
            Console.WriteLine("The descending order: \n");
            Array.Reverse(arr);
            for (int i = 0; i < len; i++)
            {
                Console.Write(arr[i] + " ");
            }


        }
    }
    }
