using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAO
{
    internal interface ITeacherService
    {
        int GetOrAddTeacher(int teacherID,string firstName, string lastName, string email);
    }
}
