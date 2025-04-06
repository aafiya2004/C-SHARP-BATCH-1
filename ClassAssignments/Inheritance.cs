using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    /*1. Create a class called student which has data members like rollno, name, class, Semester, 
       branch, int [] marks=new int marks [5](marks of 5 subjects )
       -Pass the details of student like rollno, name, class, SEM, branch in constructor
       -For marks write a method called GetMarks() and give marks for all 5 subjects
       -Write a method called displayresult, which should calculate the average marks
       -If marks of any one subject is less than 35 print result as failed
       -If marks of all subject is >35,but average is < 50 then also print result as failed
       -If avg > 50 then print result as passed.
       -Write a DisplayData() method to display all object members values.*/
    internal class Student
    {
        
        int id;
        string name;
        int year;
        int semester;
        string branch;
        int[] marks = new int[5];

        //Constructor
        public Student(int id, string name, int year, int semester, string branch, int[] marks)
        {
            this.id = id;
            this.name = name;
            this.year = year;
            this.semester = semester;
            this.branch = branch;
            this.marks = marks;
        }

        public void getMarks()
        {
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write(marks[i] + " ");
            }

        }
        public void displayresult()

        {
            int sum = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] < 35)
                {
                    Console.WriteLine("\nFailed!");
                    return;
                }
                sum += marks[i];
            }
            int avg = sum / marks.Length;
            Console.WriteLine("The average: " + avg);
            if (avg < 50)
            {
                Console.WriteLine("\nFailed");
            }
            else
            {
                Console.WriteLine("\nPassed");
            }
            }
        

        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine("Roll No: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + year);
            Console.WriteLine("Semester: " + semester);
            Console.WriteLine("Branch: " + branch);
        }
       
            public static void Main(string[] args)
            {
                int[] marks = { 90, 85, 97, 82, 74 };
                Student stud1 = new Student(1, "Aafiya Farheen", 3, 7, "CSE", marks);
                stud1.getMarks();
                stud1.displayresult();
                stud1.DisplayData();

            }

        }
    }

