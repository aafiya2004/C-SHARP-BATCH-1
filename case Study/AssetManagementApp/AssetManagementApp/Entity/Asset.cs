using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagementApp.Exceptions;
using static AssetManagementApp.Exceptions.CustomExceptions;

namespace AssetManagementApp.Entity
{
    internal class Asset
    {
        public int AssetId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int OwnerId { get; set; }

        

        public Asset(int assetId, string name, string type, string serialNumber, DateTime purchaseDate, string location, string status, int ownerId)
        {
            if (assetId <= 0)
            {
                throw new AssetNotFoundException("Invalid Asset ID");
            }
            AssetId = assetId;
            Name = name;
            Type = type;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            Location = location;
            Status = status;
            OwnerId = ownerId;
        }
        public Asset(string name, string type, string serialNumber, DateTime purchaseDate, string location, string status, int ownerId)
        {
            Name = name;
            Type = type;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            Location = location;
            Status = status;
            OwnerId = ownerId;
        }
    }
}


    