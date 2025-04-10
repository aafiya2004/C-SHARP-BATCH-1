using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    internal class AssetAllocation
    {
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AllocationDate { get; set; }
        public DateTime ReturnDate { get; set; }
       
        public AssetAllocation(int assetId, int employeeId, DateTime allocationDate, DateTime returnDate)
        {
 
            AssetId = assetId;
            EmployeeId = employeeId;
            AllocationDate = allocationDate;
            ReturnDate = returnDate;
        }

    }
}
