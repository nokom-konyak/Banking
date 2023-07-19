using OnlineBankingAPI.Models;
using System.Security.Cryptography;

namespace OnlineBankingAPI.Controllers
{
    public class TransactionImpl : ITransaction
    {
        readonly OnlineBankingDbContext db;
        //We are injecting the object in the constructor
        public TransactionImpl(OnlineBankingDbContext db)
        {
            this.db = db;
        }
        public bool AddFunds(Transaction t)
        {
            var olddata = db.Customer.Where(c => c.AccountNumber == t.AccountNumber).FirstOrDefault();
            if (olddata.Balance < 0 || olddata.Balance == 0 || olddata.Balance < t.Amount)
            {
                return false;
            }
            else
            {
                var Balance = olddata.Balance - t.Amount;
                olddata.Balance = Balance;
                try
                {
                    db.Transaction.Add(t);
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
            }
            return false;
        }

        public List<Transaction> ShowFundsByAccountNumber(long accno, DateTime fromDate, DateTime toDate)
        {
            var data = db.Transaction.Where(t => t.AccountNumber == accno && (t.TranDate >= fromDate && t.TranDate <= toDate)).ToList();
            return data;
        }

        public Transaction ShowFundsByReferenceID(int refid)
        {
            return db.Transaction.Where(t => t.ReferenceId == refid).FirstOrDefault();
        }
    }
}