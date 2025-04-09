using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.DAO;
using PetPals.Entity;
using Microsoft.Data.SqlClient;

namespace PetPals
{
    internal class DonationMain
    {
        static void Main(string[] args)
        {
            try
            {
                DonationService donationService = new DonationService();

                Console.WriteLine("Add a New Donation");
                Console.Write("Enter donor name: ");
                string name = Console.ReadLine();

                Console.Write("Enter donation amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                donationService.AddDonation(name, amount);


                donationService.GetAllDonations();

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for donation amount");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }
    }
}


