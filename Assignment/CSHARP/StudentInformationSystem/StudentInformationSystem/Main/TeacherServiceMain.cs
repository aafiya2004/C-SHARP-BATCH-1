using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.DAO;
using StudentInformationSystem.CustomExceptions;


namespace StudentInformationSystem.Main
{
    internal class TeacherServiceMain
    {
        static void Main(string[] args)
        {
            TeacherService service1 = new TeacherService();
            service1.GetOrAddTeacher(1, "Sarah", "Smith", "sarah.smith@example.com");

            service1.AssignTeacherToCourse("CS101", "Sarah Smith");
        }

    }
}
