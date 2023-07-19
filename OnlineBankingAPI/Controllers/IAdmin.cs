using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    public interface IAdmin
    {
        List<Customer> GetCustomersByStatus();
        List<Customer> GetAllCustomers();
        bool ChangeStatus(long accno);
        bool UpdateBalance(long accno, long newBalance);
    }
}
