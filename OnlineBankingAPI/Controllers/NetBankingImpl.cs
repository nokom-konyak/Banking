using OnlineBankingAPI.Models;
namespace OnlineBankingAPI.Controllers
{
    public class NetBankingImpl : INetBanking
    {
        readonly OnlineBankingDbContext db;
        //We are injecting the object in the constructor
        public NetBankingImpl(OnlineBankingDbContext db)
        {
            this.db = db;
        }
        public bool AddNetBanking(InternetBanking n)
        {
            try
            {
                db.InternetBanking.Add(n);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
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