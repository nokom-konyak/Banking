using Microsoft.Win32;
using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    public interface IAuthenticate
    {
        bool Login(long accno, string password);
        bool NewRegister(Customer c);
        bool ChangePassword(long ano, string oldpwd, string newpwd);

        Customer GetCustomerDetails(long accno);
    }
}