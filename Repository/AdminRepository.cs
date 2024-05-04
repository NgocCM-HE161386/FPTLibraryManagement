using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Management;

namespace LibraryManagement.Repository
{
    internal class AdminRepository : IAdminRepository
    {
        public bool AdminLogin(string name, string pass) => AdminManagement.Instance.AdminLogin(name, pass);

        public Admin GetAdminByID(int adminId) => AdminManagement.Instance.GetAdminByID(adminId);
    }
}
