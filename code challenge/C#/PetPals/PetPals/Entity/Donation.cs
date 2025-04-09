using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Entity
{
    public abstract class Donation
    {
         
        public string DonorName { get; set; }
        public decimal Amount { get; set; }

        public Donation(string donorName, decimal amount)
        {
            DonorName = donorName;
            Amount = amount;
        }
        public abstract void RecordDonation();
    }

    public class CashDonation : Donation
    {
        public DateTime DonationDate { get; set; }
        public CashDonation(string donorName, decimal amount, DateTime DonationDate) : base(donorName, amount)
        {
            this.DonationDate = DonationDate;
        }
        public override void RecordDonation()
        {
            Console.WriteLine($"Cash donation of {Amount:C} received from {DonorName}.");
        }
    }

    public class ItemDonation : Donation
    {
        public string ItemType { get; set; }

        public ItemDonation(string donorName, decimal amount, string itemType) : base(donorName, amount)
        {
            this.ItemType = itemType;
        }
        public override void RecordDonation()
        {
            Console.WriteLine($"Item donation of {ItemType} received from {DonorName}.");
        }
    }
}