using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.IRepository
{
    internal interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudenByID(string studentId);
    }
}
