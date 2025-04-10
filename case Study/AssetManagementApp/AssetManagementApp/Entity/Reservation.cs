using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    internal class Reservation
    {
        public int ReservationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string status { get; set; } 

        
  
        public Reservation(int reservationId, int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate, string status)
        {
            this.ReservationId = reservationId;
            this.AssetId = assetId;
            this.EmployeeId = employeeId;
            this.ReservationDate = reservationDate;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.status = status;
        }

        public Reservation(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate, string status)
        {
     
            this.AssetId = assetId;
            this.EmployeeId = employeeId;
            this.ReservationDate = reservationDate;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.status = status;
        }
    }
}
