using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    public class BeneficiaryImpl : IBeneficiary
    {
        readonly OnlineBankingDbContext db;
        //We are injecting the object in the constructor
        public BeneficiaryImpl(OnlineBankingDbContext db)
        {
            this.db = db;
        }
        public bool AddBeneficiary(Beneficiary b)
        {
            try
            {
                db.Beneficiary.Add(b);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
                throw;
            }
            return false;
        }

        public List<Beneficiary> GetBeneficiaryList(int accno)
        {
            return db.Beneficiary.Where(x=>x.AccountNumber==accno).ToList();
        }
    }
}

