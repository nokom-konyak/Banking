using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    public interface INetBanking
    {
        bool AddNetBanking(InternetBanking n);
    }
}
