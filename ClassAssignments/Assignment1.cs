internal class Assignment1
{
    private static void Main(string[] args)
    {
/*1. Write a C# Sharp program to accept two integers and check whether they are equal or not. 

Test Data :
Input 1st number: 5
Input 2nd number: 5
Expected Output :
5 and 5 are equal*/
  int n1 = 5;
  int n2 = 5;
  if (n1 == n2)
  {
      Console.WriteLine(n1 + " and " + n2 + " are equal");
  }
  else
  {
      Console.WriteLine("not equal");
  }


/*2. Write a C# Sharp program to check whether a given number is positive or negative. 
 Test Data : 14
 Expected Output :
 14 is a positive number */
        int n = 14;
        if (n > 0)
        {
            Console.WriteLine(n + " is a positive number");
        }
        else if (n < 0)
        {
            Console.WriteLine(n + " is a negative number");
        }
        else
        {
            Console.WriteLine(n + " is neither positive nor negative");
        }


        /* 3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 

        Test Data
        Input first number: 20
        Input operation: -
        Input second number: 12
        Expected Output :
        20 - 12 = 8 */
        int x = 20;
        int y = 12;
        Console.WriteLine(x + y);
        Console.WriteLine(x - y);
        Console.WriteLine(x * y);
        Console.WriteLine(x / y);


        /* 
      4. Write a C# Sharp program that prints the multiplication table of a number as input.

      Test Data:
      Enter the number: 5
      Expected Output:
      5 * 0 = 0
      5 * 1 = 5
      5 * 2 = 10
      5 * 3 = 15
      ....
      5 * 10 = 50 */

        int m = 5;
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine(m + "x" + i + "=" + (m * i));
        }


        /* 5.  Write a C# program to compute the sum of two given integers. 
         If two values are the same, return the triple of their sum.*/

        int num1 = 10;
        int num2 = 20;
        if(num1 == num2)
      {
        int ans = (num1+num2) * 3;
        Console.WriteLine(ans);
      }
        else
        {
            int sum = num1 + num2;
            Console.WriteLine(sum);
        }
    }
}