using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagementApp.Entity;
using AssetManagementApp.Utility;
using Microsoft.Data.SqlClient;
using AssetManagementApp.Exceptions;
using static AssetManagementApp.Exceptions.CustomExceptions;
using System.Collections;

namespace AssetManagementApp.DAO
{
    internal class AssetManagementServiceImpl : IAssetManagementService
    {
        //Adding an Asset
        public bool AddAsset(Asset asset)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Assets (name, type, serial_number, purchase_date, location, status, owner_id) " +
                               "VALUES (@name, @type, @serial_number, @purchase_date, @location, @status, @owner_id)";

                SqlCommand cmd = new SqlCommand(query, conn);


                cmd.Parameters.AddWithValue("@name", asset.Name);
                cmd.Parameters.AddWithValue("@type", asset.Type);
                cmd.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                cmd.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                cmd.Parameters.AddWithValue("@location", asset.Location);
                cmd.Parameters.AddWithValue("@status", asset.Status);
                cmd.Parameters.AddWithValue("@owner_id", asset.OwnerId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Asset added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add asset.");
                }

                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15} {5,-20} {6,-18} {7,-10}",
    "ID", "Name", "Type", "Serial Number", "Purchase Date", "Location", "Status", "Owner ID");

                Console.WriteLine(new string('-', 125));
                string selectQuery = "Select * from Assets";
                SqlCommand selectcmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = selectcmd.ExecuteReader();

                while (reader.Read())
                {
                    int assetId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    string serialNumber = reader.GetString(3);
                    DateTime purchaseDate = reader.GetDateTime(4);
                    string location = reader.GetString(5);
                    string status = reader.GetString(6);
                    int ownerId = reader.GetInt32(7);
                    Asset newAsset = new Asset(assetId, name, type, serialNumber, purchaseDate, location, status, ownerId);
                    Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15:dd-MM-yyyy} {5,-20} {6,-18} {7,-10}",
         assetId, name, type, serialNumber, purchaseDate, location, status, ownerId);
                }
                reader.Close();
                return true;
            }
        }
        //Updating an Asset
        public bool UpdateAsset(Asset asset)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())

            {
                conn.Open();

                string query = "UPDATE Assets SET name = @name, type = @type, serial_number = @serial_number, " +
                               "purchase_date = @purchase_date, location = @location, status = @status, owner_id = @owner_id " +
                               "WHERE asset_id = @asset_id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@asset_id", asset.AssetId);
                cmd.Parameters.AddWithValue("@name", asset.Name);
                cmd.Parameters.AddWithValue("@type", asset.Type);
                cmd.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                cmd.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                cmd.Parameters.AddWithValue("@location", asset.Location);
                cmd.Parameters.AddWithValue("@status", asset.Status);
                cmd.Parameters.AddWithValue("@owner_id", asset.OwnerId);


                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Asset updated successfully.");

                }
                else
                {
                    throw new AssetNotFoundException(" Failed to update asset.");
                }
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15} {5,-20} {6,-18} {7,-10}",
    "ID", "Name", "Type", "Serial Number", "Purchase Date", "Location", "Status", "Owner ID");

                Console.WriteLine(new string('-', 125));
                string UpdateQuery = "Select * from Assets";
                SqlCommand selectcmd = new SqlCommand(UpdateQuery, conn);
                SqlDataReader reader = selectcmd.ExecuteReader();
                while (reader.Read())
                {
                    int assetId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    string serialNumber = reader.GetString(3);
                    DateTime purchaseDate = reader.GetDateTime(4);
                    string location = reader.GetString(5);
                    string status = reader.GetString(6);
                    int ownerId = reader.GetInt32(7);
                    Asset newAsset = new Asset(assetId, name, type, serialNumber,
                        purchaseDate, location, status, ownerId);
                    Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15:dd-MM-yyyy} {5,-20} {6,-18} {7,-10}",
         assetId, name, type, serialNumber, purchaseDate, location, status, ownerId);
                }
                reader.Close();
                return true;
            }

        }
        //Deleting an Asset
        public bool DeleteAsset(int assetId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Assets WHERE asset_id = @asset_id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@asset_id", assetId);


                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Asset deleted successfully.");
                }
                else
                {
                    throw new AssetNotFoundException("Failed to delete asset.");

                }
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15} {5,-20} {6,-18} {7,-10}",
    "ID", "Name", "Type", "Serial Number", "Purchase Date", "Location", "Status", "Owner ID");
                Console.WriteLine(new string('-', 125));


                string deleteQuery = "Select * from Assets";
                SqlCommand selectcmd = new SqlCommand(deleteQuery, conn);
                SqlDataReader reader = selectcmd.ExecuteReader();
                while (reader.Read())
                {
                    int assetId1 = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    string serialNumber = reader.GetString(3);
                    DateTime purchaseDate = reader.GetDateTime(4);
                    string location = reader.GetString(5);
                    string status = reader.GetString(6);
                    int ownerId = reader.GetInt32(7);
                    Asset newAsset = new Asset(assetId1, name, type, serialNumber, purchaseDate, location, status, ownerId);
                    Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15:dd-MM-yyyy} {5,-20} {6,-18} {7,-10}",
         assetId1, name, type, serialNumber, purchaseDate, location, status, ownerId);

                }
                reader.Close();
                return true;
            }
        }
        //Allocating an Asset
        public bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();

                string insertQuery = @"INSERT INTO asset_allocations (asset_id, employee_id, allocation_date, return_date) 
                               VALUES (@asset_id, @employee_id, @allocation_date, NULL)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@asset_id", assetId);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);
                    cmd.Parameters.AddWithValue("@allocation_date", allocationDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected > 0 ? "Asset allocated successfully." : "Failed to allocate asset.");
                }

                Console.WriteLine("{0,-10} {1,-15} {2,-20:dd-MM-yyyy} {3,-15} {4,-20}",
                    "Asset ID", "Employee ID", "Allocation Date", "Return Date", "Allocation ID");
                Console.WriteLine(new string('-', 125));

                string selectQuery = "SELECT asset_id, employee_id, allocation_date, " +
                    "allocation_id, return_date FROM asset_allocations";
                using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                using (SqlDataReader reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int assetIdOut = reader.GetInt32(0);
                        int empIdOut = reader.GetInt32(1);
                        DateTime allocDateOut = reader.GetDateTime(2);
                        int allocId = reader.GetInt32(3);
                        string returnDateOut = reader.IsDBNull(4)
                            ? "Not Returned"
                            : reader.GetDateTime(4).ToString("dd-MM-yyyy");

                        Console.WriteLine("{0,-10} {1,-15} {2,-20:dd-MM-yyyy} {3,-15} {4,-20}",
                  assetIdOut, empIdOut, allocDateOut, returnDateOut, allocId);
                    }
                }
                return true;
            }
        }

        //Deallocating an Asset
        public bool DeallocateAsset(int assetId, int employeeId, DateTime returnDate)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = @"UPDATE asset_allocations 
                         SET return_date = @return_date 
                         WHERE asset_id = @asset_id 
                         AND employee_id = @employee_id 
                         AND return_date IS NULL";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", assetId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);
                cmd.Parameters.AddWithValue("@return_date", returnDate);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Asset deallocated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to deallocate asset.");
                }

                Console.WriteLine("{0,-10} {1,-15} {2,-20} {3,-20}", "Asset ID", "Employee ID", "Allocation Date", "Return Date");
                Console.WriteLine(new string('-', 125));

                string selectQuery = "SELECT asset_id, employee_id, allocation_date, return_date FROM asset_allocations";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = selectCmd.ExecuteReader();

                while (reader.Read())
                {
                    int assetIdOut = reader.GetInt32(0);
                    int empIdOut = reader.GetInt32(1);
                    DateTime allocDateOut = reader.GetDateTime(2);
                    string returnDateOut = reader.IsDBNull(3)
                        ? "Not Returned"
                        : reader.GetDateTime(3).ToString("dd-MM-yyyy");

                    Console.WriteLine("{0,-10} {1,-15} {2,-20:dd-MM-yyyy} {3,-20}", assetIdOut, empIdOut, allocDateOut, returnDateOut);
                }

                reader.Close();
                return true;
            }
        }

        //To perform maintenance on an Asset
        public bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {

                string query = @"INSERT INTO maintenance_records 
                         (asset_id, maintenance_date, description, cost) 
                         VALUES (@asset_id, @maintenance_date, @description, @cost)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", assetId);
                cmd.Parameters.AddWithValue("@maintenance_date", maintenanceDate);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@cost", cost);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Maintenance record added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add maintenance record.");
                }


                Console.WriteLine("{0,-15} {1,-10} {2,-20:dd-MM-yyyy} {3,-25} {4,-10}",
                    "Maintenance ID", "Asset ID ", "Maintenance Date", "Description", "Cost");
                Console.WriteLine(new string('-', 125));


                string selectQuery = "SELECT * FROM maintenance_records";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = selectCmd.ExecuteReader();

                while (reader.Read())
                {
                    int maintenanceId = reader.GetInt32(0);
                    int assetIdOut = reader.GetInt32(1);
                    DateTime maintenanceDateOut = reader.GetDateTime(2);
                    string descriptionOut = reader.GetString(3);
                    decimal costOut = reader.GetDecimal(4);

                    Console.WriteLine("{0,-15} {1,-10} {2,-20:dd-MM-yyyy} {3,-25} {4,-10}",
                        maintenanceId, assetIdOut, maintenanceDateOut, descriptionOut, costOut);
                }



                reader.Close();
                return true;
            }
        }

        //Checking the maintenance dates of an Asset
        public void CheckMaintenanceDates(int assetId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "SELECT Max(maintenance_date) FROM maintenance_records WHERE asset_id = @asset_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", assetId);
                conn.Open();
                object result = cmd.ExecuteScalar();


                if (result != DBNull.Value)
                {
                    DateTime lastMaintenanceDate = Convert.ToDateTime(result);
                    if ((DateTime.Now - lastMaintenanceDate).TotalDays > 730)
                    {
                        throw new AssetNotMaintainException($"Asset ID {assetId} has not been maintained in the last 2 years.");
                    }
                    else
                    {
                        Console.WriteLine("Asset is maintained within 2 years.");
                    }
                }
                else
                {
                    throw new AssetNotMaintainException($"No maintenance records found for Asset ID {assetId}.");
                }

            }
        }


        //To reserve an Asset
        public bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate, string status)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "INSERT INTO Reservations (asset_id, employee_id, reservation_date, start_date, end_date,status) " +
                               "VALUES (@asset_id, @employee_id, @reservation_date, @start_date, @end_date, @status)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@asset_id", assetId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);
                cmd.Parameters.AddWithValue("@reservation_date", reservationDate);
                cmd.Parameters.AddWithValue("@start_date", startDate);
                cmd.Parameters.AddWithValue("@end_date", endDate);
                cmd.Parameters.AddWithValue("@status", status);


                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("This Asset is reserved from: " + startDate + " to " + endDate);
                }
                else
                {
                    Console.WriteLine("Failed to reserve asset.");
                }

                Console.WriteLine("{0,-20} {1,-15} {2,-18} {3,-20:dd-MM-yyyy} {4,-20:dd-MM-yyyy} {5,-20:dd-MM-yyyy}" +
                    "{6,-25}", "Reservation ID", "Asset ID", "Employee ID", "Reservation Date", "Start Date",
                    "End date", "Status");

                Console.WriteLine(new string('-', 125));

                string selectQuery = "Select * from Reservations";
                SqlCommand selectcmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = selectcmd.ExecuteReader();
                if (reader.Read())
                {
                    int ReservationId = reader.GetInt32(0);
                    int AssetId = reader.GetInt32(1);
                    int EmployeeId = reader.GetInt32(2);
                    DateTime ReservationDate = reader.GetDateTime(3);
                    DateTime StartDate = reader.GetDateTime(4);
                    DateTime EndDate = reader.GetDateTime(5);
                    string Status = reader.GetString(6);
                    Reservation newReservation = new Reservation(assetId, employeeId, ReservationDate, startDate, endDate, status);
                    Console.WriteLine("{0,-20} {1,-15} {2,-18} {3,-20:dd-MM-yyyy} {4,-20:dd-MM-yyyy} {5,-20:dd-MM-yyyy}" +
                    "{6,-25}",
                    ReservationId, AssetId, EmployeeId, ReservationDate, StartDate, EndDate, Status);

                }
                reader.Close();
                return true;
            }

        }
        //Withdrawing a Reservation
        public bool WithdrawReservation(int reservationId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "UPDATE Reservations SET Status = 'canceled' WHERE reservation_id = @reservation_id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@reservation_id", reservationId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Reservation withdrawn successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to withdraw reservation.");
                }
                Console.WriteLine("{0,-20} {1,-15} {2,-18} {3,-20:dd-MM-yyyy} {4,-20:dd-MM-yyyy} {5,-20:dd-MM-yyyy}" +
                    "{6,-25}", "Reservation ID", "Asset ID", "Employee ID", "Reservation Date", "Start Date",
                    "End date", "Status");

                Console.WriteLine(new string('-', 125));

                string selectQuery = "Select * from Reservations";
                SqlCommand selectcmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = selectcmd.ExecuteReader();
                if (reader.Read())
                {
                    int ReservationId = reader.GetInt32(0);
                    int AssetId = reader.GetInt32(1);
                    int EmployeeId = reader.GetInt32(2);
                    DateTime ReservationDate = reader.GetDateTime(3);
                    DateTime StartDate = reader.GetDateTime(4);
                    DateTime EndDate = reader.GetDateTime(5);
                    string Status = reader.GetString(6);

                    Reservation WithdrawRes = new Reservation(AssetId, EmployeeId, ReservationDate, StartDate, EndDate, Status);
                    Console.WriteLine("{0,-20} {1,-15} {2,-18} {3,-20:dd-MM-yyyy} {4,-20:dd-MM-yyyy} {5,-20:dd-MM-yyyy}" +
                    "{6,-25}",
                    ReservationId, AssetId, EmployeeId, ReservationDate, StartDate, EndDate, Status);

                }
                reader.Close();
                return true;
            }

        }

        //Getting asset records
        public List<Asset> GetAllAssets()
        {
            List<Asset> assets = new List<Asset>();
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15} {5,-20} {6,-18} {7,-10}",
   "ID", "Name", "Type", "Serial Number", "Purchase Date", "Location", "Status", "Owner ID");

                Console.WriteLine(new string('-', 125));
                string query = "SELECT * FROM Assets";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int assetId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    string serialNumber = reader.GetString(3);
                    DateTime purchaseDate = reader.GetDateTime(4);
                    string location = reader.GetString(5);
                    string status = reader.GetString(6);
                    int ownerId = reader.GetInt32(7);
                    Asset asset = new Asset(assetId, name, type, serialNumber, purchaseDate, location, status, ownerId);
                    assets.Add(asset);
                    Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-18} {4,-15:dd-MM-yyyy} {5,-20} {6,-18} {7,-10}",
         assetId, name, type, serialNumber, purchaseDate, location, status, ownerId);
                }
                reader.Close();
            }
            return assets;
        }
        
    }

}
    

