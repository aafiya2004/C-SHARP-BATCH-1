using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    internal class MaintenanceRecord
    {
        public int MaintenanceId { get; set; }
        public int AssetId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

       

     
        public MaintenanceRecord(int maintenanceId, int assetId, DateTime maintenanceDate, string description, double cost)
        {
            MaintenanceId = maintenanceId;
            AssetId = assetId;
            MaintenanceDate = maintenanceDate;
            Description = description;
            Cost = cost;
        }

        public MaintenanceRecord(int assetId, DateTime maintenanceDate, string description, double cost)
        {
            AssetId = assetId;
            MaintenanceDate = maintenanceDate;
            Description = description;
            Cost = cost;
        }
    }
}
