using LibraryManagement.DataAccess;
using System;
using System.Linq;

namespace LibraryManagement.Management
{
    internal class AdminManagement
    {
        private static AdminManagement instance = null;
        private static readonly object instanceLock = new object();
        private AdminManagement() { }
        public static AdminManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AdminManagement();
                    }
                    return instance;
                }
            }
        }
        public Admin GetAdminByID(int adminId)
        {
            Admin admin = null;
            try
            {
                var myLibrary = new LibraryManagementContext();
                admin = myLibrary.Admins.SingleOrDefault(admin => admin.Aid == adminId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return admin;
        }

        public bool AdminLogin(string name, String pass)
        {
            Admin admin = null;
            try
            {
                var myLibrary = new LibraryManagementContext();
                admin = myLibrary.Admins.SingleOrDefault(admin => admin.Name.Equals(name) && admin.Password == pass);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return admin == null ? false : true;
        }
    }
}
