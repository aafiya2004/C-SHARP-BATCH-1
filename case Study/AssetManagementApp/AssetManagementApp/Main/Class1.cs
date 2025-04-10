using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagementApp.DAO;
using AssetManagementApp.Entity;
using AssetManagementApp.Utility;
using Microsoft.Data.SqlClient;
namespace AssetManagementApp.Main
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            AssetManagementServiceImpl service = new AssetManagementServiceImpl();


            Asset asset = new Asset(1, "Laptop", "Electronics", "SN0126", DateTime.Now, "Office", "Decommissioned", 1);
            service.AddAsset(asset);

           // Asset asset1 = new Asset(1, "MacBook", "Electronics", "SO1589", DateTime.Now, "Office", "In Use", 2);

            //service.UpdateAsset(asset1);
            //service.DeleteAsset(1);

           
        }
    }
    }

