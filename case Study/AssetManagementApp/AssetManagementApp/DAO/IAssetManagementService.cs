using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagementApp.Entity;

namespace AssetManagementApp.DAO
{
    internal interface IAssetManagementService
    {
        bool AddAsset(Asset asset);
        bool UpdateAsset(Asset asset);
        bool DeleteAsset(int assetId);

        bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate);
        bool DeallocateAsset(int assetId, int employeeId, DateTime returnDate);

        bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost);

        bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate, string status);
        bool WithdrawReservation(int reservationId);
    }
}
