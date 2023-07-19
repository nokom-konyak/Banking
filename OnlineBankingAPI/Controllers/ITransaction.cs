using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    public interface ITransaction
    {
        bool AddFunds(Transaction t);
        List<Transaction> ShowFundsByAccountNumber(long accno, DateTime fromDate, DateTime toDate);
        Transaction ShowFundsByReferenceID(int refid);
    }
}