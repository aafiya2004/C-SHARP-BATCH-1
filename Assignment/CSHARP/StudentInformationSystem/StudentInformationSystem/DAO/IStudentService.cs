using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAO
{
    internal interface IStudentService
    {
        void EnrollStudentWithCourses(Student student, List<int> courseIds, DateTime enrollmentDate);
  
        
    }
}
