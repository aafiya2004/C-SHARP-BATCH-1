internal class Program
{
    private static void Main(string[] args)
    {
      //Assignment 1
      //1)
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


        //2) 
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


      //3)
        int x = 20;
        int y = 12;
        Console.WriteLine(x + y);
        Console.WriteLine(x - y);
        Console.WriteLine(x * y);
        Console.WriteLine(x / y);


        //4)
        int m = 5;
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine(m + "x" + i + "=" + (m * i));
        }


        //5)
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