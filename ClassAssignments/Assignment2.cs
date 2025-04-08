using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace helloworld
{
    internal class Assignment2
    {
        static void Main()
        {
            //1. Write a C# Sharp program to swap two numbers.
            int a = 10;
            int b = 20;
            Console.WriteLine("Before swapping: " + "a = " + a + " b = " + b);

            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swapping: " + "a = " + a + " b = " + b);

            /*2. Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), 
             and then four times in the next row, with no separation. You should do it twice: 
            Use the console. Write and use {0}.
            Test Data:
            Enter a digit: 25
            Expected Output:
            25 25 25 25
            25252525
            25 25 25 25
            25252525 */
            Console.WriteLine("Enter a digit: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0}{1}{2}{3}", num, num, num, num);
            Console.WriteLine("{0} {1} {2} {3}", num, num, num, num);


            /*3. Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

            Test Data / input: 2

            Expected Output :
            Tuesday */
            Console.WriteLine("Enter the day number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 0:
                    Console.WriteLine("Sunday");
                    break;
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }

        }
    }
}

