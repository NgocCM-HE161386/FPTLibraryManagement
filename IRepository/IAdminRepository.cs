using LibraryManagement.DataAccess;

namespace LibraryManagement.IRepository
{
    public interface IAdminRepository
    {
        Admin GetAdminByID(int adminId);
        bool AdminLogin(string name, string pass);
    }
}
