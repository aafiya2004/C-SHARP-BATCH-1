using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagementApp.DAO;
using NUnit.Framework;
using AssetManagementApp.Entity;
using static AssetManagementApp.Exceptions.CustomExceptions;


namespace AssetManagement.Tests
{
    [TestFixture]
    public class ExceptionTest
    {
        private AssetManagementServiceImpl service;

        [SetUp]
        public void Setup()
        {
            service = new AssetManagementServiceImpl();
        }
        [Test]
        public void DeleteAsset_ShouldThrow_AssetNotFoundException_WhenAssetDoesNotExist()
        {
            
            int assetId = 0; 
          
            var ex = Assert.Throws<AssetNotFoundException>(() => service.DeleteAsset(assetId));
            TestContext.Out.WriteLine("Caught Exception Message: " + ex.Message);
            Assert.That(ex.Message, Is.EqualTo("Failed to delete asset."));

        }

    }
}
