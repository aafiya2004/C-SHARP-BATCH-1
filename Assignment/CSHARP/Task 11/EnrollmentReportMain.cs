using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.DAO;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem.Main
{
    internal class EnrollmentReportMain
    {
        static void Main(string[] args)
        {
            EnrollmentReport enrollmentReport = new EnrollmentReport();
            enrollmentReport.GenerateEnrollmentReport("Introduction to Programming");
            enrollmentReport.GenerateEnrollmentReport("Mathematics 101");
        }
    }
}
