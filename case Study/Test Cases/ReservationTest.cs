using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagementApp.DAO;
using NUnit.Framework;
using AssetManagementApp.Entity;

namespace AssetManagement.Tests
{
    [TestFixture]
    public class ReservationTests
    {
        private AssetManagementServiceImpl service;

    

         [SetUp]
            public void Setup()
        {
            service = new AssetManagementServiceImpl();
        }
        [Test]
        public void ReserveAsset_ShouldReturn_True_WhenInserted()
        {

            int assetId = 14;
            int employeeId = 5;
            DateTime ReservationDate = DateTime.Now;
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(7);
            String status = "Pending";
            
            bool result = service.ReserveAsset(assetId,employeeId,ReservationDate,startDate,endDate,status);
            Assert.That(result, Is.True);
        }
    }
}

