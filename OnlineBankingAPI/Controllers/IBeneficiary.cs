using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    public interface IBeneficiary
    {
        bool AddBeneficiary(Beneficiary b);
        List<Beneficiary> GetBeneficiaryList(int accno);
    }
}