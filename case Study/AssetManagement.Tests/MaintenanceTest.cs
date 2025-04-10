using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AssetManagementApp.DAO;
using AssetManagementApp.Entity;
using AssetManagementApp.Utility;


namespace AssetManagement.Tests
{
        [TestFixture]
        public class MaintenanceRecordTests
        {
            private AssetManagementServiceImpl service;

            [SetUp]
            public void Setup()
            {
                service = new AssetManagementServiceImpl();
            }

            [Test]
            public void AddMaintenanceRecord_ShouldReturn_True_WhenInserted()
            {
            int assetId = 8; 
            DateTime maintenanceDate = DateTime.Now;
            string description = "Test maintenance";
            double cost = 100.0;

            bool result = service.PerformMaintenance(assetId,maintenanceDate,description,cost);
                Assert.That(result, Is.True);
            }
        }
    }
