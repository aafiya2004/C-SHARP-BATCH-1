using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AssetManagementApp.DAO;
using AssetManagementApp.Entity;
using static AssetManagementApp.Exceptions.CustomExceptions;

namespace AssetManagementApp.Main
{
    internal class AssetManagementApp
    {
       static void Main(string[] args)
        {
            AssetManagementServiceImpl service=new AssetManagementServiceImpl();
            while (true)
            {
                Console.WriteLine("\n====== Asset Management System ======");
                Console.WriteLine("\n1.Add Asset: ");
                Console.WriteLine("\n2.Update Asset: ");
                Console.WriteLine("\n3.Delete Asset: ");
                Console.WriteLine("\n4.Allocate Asset: ");
                Console.WriteLine("\n5.Deallocate Asset: ");
                Console.WriteLine("\n6.Perform Maintenance: ");
                Console.WriteLine("\n7.Reserve Asset: ");
                Console.WriteLine("\n8.Withdraw Reservation: ");
                Console.WriteLine("\n9.Check Maintenance Date: ");
                Console.WriteLine("\n10.Get All Assets: ");
                Console.WriteLine("\n11.Exit: ");
                Console.WriteLine("Enter your choice:");

                int choice=Convert.ToInt32(Console.ReadLine());

                try {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Type: ");
                            string type = Console.ReadLine();
                            Console.Write("Serial Number: ");
                            string serial = Console.ReadLine();
                            Console.Write("Purchase Date (yyyy-MM-dd): ");
                            DateTime purchaseDate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Location: ");
                            string location = Console.ReadLine();
                            Console.Write("Status: (In use/Decommissioned/Under Maintenance) ");
                            string status = Console.ReadLine();
                            Console.Write("Owner ID: ");
                            int ownerId = Convert.ToInt32(Console.ReadLine());

                            Asset asset = new Asset(name, type, serial, purchaseDate, location, status, ownerId);
                            service.AddAsset(asset);
                             
                            
                            break;

                        case 2:
                            Console.Write("Asset ID to update: ");
                            int upAssetId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Type: ");
                            type = Console.ReadLine();
                            Console.Write("Serial Number: ");
                            serial = Console.ReadLine();
                            Console.Write("Purchase Date (yyyy-MM-dd): ");
                            purchaseDate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Location: ");
                            location = Console.ReadLine();
                            Console.Write("Status: (In use/Decommissioned/Under Maintenance) ");
                            status = Console.ReadLine();
                            Console.Write("Owner ID: ");
                            ownerId = Convert.ToInt32(Console.ReadLine());

                            asset = new Asset(upAssetId, name, type, serial, purchaseDate, location, status, ownerId);
                            service.UpdateAsset(asset);

                            break;

                        case 3:
                            Console.Write("Asset ID to delete: ");
                            int delId = Convert.ToInt32(Console.ReadLine());
                            service.DeleteAsset(delId);
                            break;

                        case 4:
                            Console.Write("Asset ID to allocate: ");
                            int allocAssetId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Employee ID: ");
                            int empId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Allocation Date (yyyy-MM-dd): ");
                            DateTime allocDate = Convert.ToDateTime(Console.ReadLine());
                            service.AllocateAsset(allocAssetId, empId, allocDate);
                              
                            
                            break;

                        case 5:
                            Console.WriteLine("Asset ID to deallocate: ");
                            int deallocassetId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Employee ID: ");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Return date (yyyy-MM-dd): ");
                            DateTime returnDate = Convert.ToDateTime(Console.ReadLine());
                            service.DeallocateAsset(deallocassetId, employeeId, returnDate);
                        
                            break;

                        case 6:
                            Console.WriteLine("Asset ID : ");
                            int maintainAssetID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Date to perform maintenance (yyyy-MM-dd): ");
                            DateTime maintenanceDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter the description: ");
                            string description = Console.ReadLine();
                            Console.WriteLine("Enter the amount: ");
                            double cost = Convert.ToDouble(Console.ReadLine());


                            service.PerformMaintenance(maintainAssetID, maintenanceDate, description, cost);
                             
                            break;

                        case 7:
                            Console.WriteLine("Enter Asset ID for reservation: ");
                            int reserveId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Employee ID: ");
                            int EmployeeId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Reservation Date (yyyy-MM-dd): ");
                            DateTime ReservationDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("From (yyyy-MM-dd): ");
                            DateTime StartDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("To (yyyy-MM-dd): ");
                            DateTime EndDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Status: (Pending/Approved/Cancelled)");
                            string Status = Console.ReadLine();
                            service.ReserveAsset(reserveId, EmployeeId, ReservationDate, StartDate, EndDate,Status);
                                
                            break;

                        case 8:
                            Console.Write("Reservation ID to withdraw: ");
                            int resId = Convert.ToInt32(Console.ReadLine());

                            service.WithdrawReservation(resId);
                               
                            break;

                        case 9:
                            Console.WriteLine("Enter Asset ID: ");
                            int AssetId = Convert.ToInt32(Console.ReadLine());
                            service.CheckMaintenanceDates(AssetId);
                            break;

                        case 10:
                            List<Asset> assets = service.GetAllAssets();

                            break;

                        case 11:
                            Console.WriteLine("Exiting the application.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;

                    }
                }
                catch (AssetNotMaintainException ex)
                {
                    Console.WriteLine($"Maintenance Exception: {ex.Message}");
                }
                catch (AssetNotFoundException ex)
                {
                    Console.WriteLine($"Asset Not Found Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }
            }
        }
    }
}
