using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Entity;

namespace PetPals.Exceptions
{
    internal class ExceptionMain
    {
        static void Main(string[] args)
        {
            try
            {
                Pet pet = new Pet("Rocky", -3, "Labrador");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid age exception" +ex);
            }

            try
            {
                Donation donation = new CashDonation("John Doe", 5, DateTime.Now);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Insufficient funds exception: " + ex.Message);
            }
        }
    }
}
