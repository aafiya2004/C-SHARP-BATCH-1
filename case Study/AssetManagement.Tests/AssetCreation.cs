using NUnit.Framework;
using AssetManagementApp.DAO;
using AssetManagementApp.Entity;
using AssetManagementApp.Utility;

namespace AssetManagement.Tests
{
    

    namespace AssetManagementApp.Tests
    {
        [TestFixture]
        public class AssetService_Tests
        {
            private AssetManagementServiceImpl service;

            [SetUp]
            public void Setup()
            {
                service = new AssetManagementServiceImpl();
            }

            [Test]
            public void AddAsset_ShouldReturn_True_WhenInserted()
            {

                Asset asset = new Asset(
                    name: "TestAsset",
                    type: "TestType",
                    serialNumber: "TT14789",
                    purchaseDate: DateTime.Now,
                    location: "TestLocation",
                    status: "In Use",
                    ownerId: 1
                );


                bool result = service.AddAsset(asset);


                Assert.That(result, Is.True);
            }
        }
    }
}
