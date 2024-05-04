using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Management
{
    internal class StudentManagement
    {
        private static StudentManagement instance = null;
        private static readonly object instanceLock = new object();
        private StudentManagement() { }
        public static StudentManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentManagement();
                    }
                    return instance;
                }
            }
        }
        public Student GetStudentByID(string Id)
        {
            Student student = null;
            try
            {
                var myLibrary = new LibraryManagementContext();
                student = myLibrary.Students.SingleOrDefault(student => student.StudentId == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return student;
        }
        public IEnumerable<Student> GetStudentList()
        {
            List<Student> students;
            try
            {
                var myLibrary = new LibraryManagementContext();
                students = myLibrary.Students.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return students;
        }
    }
}
