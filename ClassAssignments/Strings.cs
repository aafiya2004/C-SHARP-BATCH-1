using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    internal class Strings
    {
        static void Main()
        {
            //1.Write a program in C# to accept a word from the user and display the length of it.

            Console.WriteLine("Enter Name: ");
            string name=Console.ReadLine();
            Console.WriteLine("The Length is: "+ name.Length);


            //2.Write a program in C# to accept a word from the user and display the reverse of it.
            Console.WriteLine("Enter Name: ");
            string n = Console.ReadLine();
            string reversed = "";
            for (int i = n.Length-1; i >=0; i--)
            {
                   reversed += n[i];
            }
            Console.WriteLine(reversed);

            //checking if two strings are equal
            Console.WriteLine("Enter first name: ");
            string first = Console.ReadLine();
            Console.WriteLine("Enter second name: ");
            string second = Console.ReadLine();

            bool result= strings3.check(first,second);
            Console.WriteLine(result);


        }
    }
}
