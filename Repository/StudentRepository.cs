using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Management;
using System.Collections.Generic;

namespace LibraryManagement.Repository
{
    internal class StudentRepository : IStudentRepository
    {
        public Student GetStudenByID(string studentId) => StudentManagement.Instance.GetStudentByID(studentId);

        public IEnumerable<Student> GetStudents() => StudentManagement.Instance.GetStudentList();
    }
}
