using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Entity;

namespace PetPals.DAO
{
    public interface IDonationDAO
    {
        void RecordDonation(Donation donation);
    }
}
