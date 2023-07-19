using OnlineBankingAPI.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace OnlineBankingAPI.Controllers
{
    public class AdminImpl : IAdmin
    {
        readonly OnlineBankingDbContext db;
        //We are injecting the object in the constructor
        public AdminImpl(OnlineBankingDbContext db)
        {
            this.db = db;
        }
        public List<Customer> GetCustomersByStatus()
        {
            var data = db.Customer.Where(c => c.Status == false).ToList();
            if (data.Count == 0)
            {
                List<Customer> list = new List<Customer>();
                return list;
            }
            else
                return data;
        }
        public bool ChangeStatus(long accno)
        {
            try
            {
                var olddata = db.Customer.Where(x => x.AccountNumber == accno).FirstOrDefault();
                if (olddata != null)
                {
                    if(olddata.Status == true)
                    {
                        return true;
                    }
                    olddata.Status = true;
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
        public List<Customer> GetAllCustomers()
        {
            return db.Customer.ToList();
        }

        public bool UpdateBalance(long accno, long newBalance)
        {
            try
            {
                var olddata = db.Customer.Where(x => x.AccountNumber == accno && x.Status==true).FirstOrDefault();
                if (olddata != null)
                {
                    olddata.Balance = olddata.Balance + newBalance;
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}