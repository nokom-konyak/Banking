using Microsoft.Win32;
using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    public class AuthenticateImpl : IAuthenticate
    {
        readonly OnlineBankingDbContext db;
        //We are injecting the object in the constructor
        public AuthenticateImpl(OnlineBankingDbContext db)
        {
            this.db = db;
        }
        public bool NewRegister(Customer c)
        {
            try
            {
                c.Status = false;
                c.Balance = 0;
                db.Customer.Add(c);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }
        public bool Login(long accno, string password)
        {
            try
            {
                var olddata = db.Customer.Where(x => x.AccountNumber == accno && x.Password == password).FirstOrDefault();
                if (olddata == null)    // Invalid LogIn Credentials
                {
                    return false;
                }
                else
                {
                    return olddata.Status;     // User Approval Status
                }
            }
            catch
            {
                throw;
            }
        }
        public bool ChangePassword(long accno, string oldpwd, string newpwd)
        {
            try
            {
                var olddata = db.Customer.Where(x => x.AccountNumber == accno && x.Password == oldpwd).FirstOrDefault();
                if (olddata == null)   // Invalid Credentials
                {
                    return false;
                }
                else
                {
                    olddata.Password = newpwd;
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return false;
        }
        public Customer GetCustomerDetails(long accno)
        {
            return db.Customer.Where(c => c.AccountNumber == accno).FirstOrDefault();
        }
    }
}
