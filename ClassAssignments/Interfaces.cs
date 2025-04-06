using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace helloworld
{
    internal class Interfaces
    {
        interface IStudent
        {
            int StudentId { get; set; }
            string Name { get; set; }
            double Fees { get; set; }
            void ShowDetails();
        }
        class DayScholar : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public double Fees { get; set; }

            public DayScholar(int id, string name, double fees)
            {
                StudentId = id;
                Name = name;
                Fees = fees;
            }
            public void ShowDetails()
            {
                Console.WriteLine("Day Scholar Details:");
                Console.WriteLine($"ID: {StudentId}, Name: {Name}, Fees: {Fees}");
            }
        }
        class Resident : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public double Fees { get; set; }
            public double HostelFees { get; set; }

            public Resident(int id, string name, double baseFees, double hostelFees)
            {
                StudentId = id;
                Name = name;
                HostelFees = hostelFees;
                Fees = baseFees + HostelFees;
            }
            public void ShowDetails()
            {
                Console.WriteLine("Resident Student Details:");
                Console.WriteLine($"ID: {StudentId}, Name: {Name}, Tuition Fees: {Fees - HostelFees}, Accommodation Fees: {HostelFees}, Total Fees: {Fees}");
            }
            
                static void Main(string[] args)
                {
                    IStudent ds = new DayScholar(101, "Alice", 25000);
                    IStudent res = new Resident(102, "Bob", 30000, 10000);

                    ds.ShowDetails();
                    Console.WriteLine();
                    res.ShowDetails();
                }

            }
    }
}
