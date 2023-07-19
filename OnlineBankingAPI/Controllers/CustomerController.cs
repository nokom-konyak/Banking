using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBankingAPI.Models;

namespace OnlineBankingAPI.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [EnableCors(PolicyName = "BankingProject")]
    public class CustomerController : ControllerBase
    {
        readonly OnlineBankingDbContext db;
        readonly IBeneficiary ben;
        readonly INetBanking net;
        readonly ITransaction transaction;
        readonly IAuthenticate auth;
        public CustomerController(OnlineBankingDbContext db, IBeneficiary ben, INetBanking net, ITransaction transaction, IAuthenticate auth)
        {
            this.db = db;
            this.ben = ben;
            this.net = net;
            this.transaction = transaction;
            this.auth = auth;
        }
        [HttpGet]
        [Route("/api/Customer/GetCustomerDetails/{accno}")]
        public Customer GetCustomerDetails(long accno)
        {
            return auth.GetCustomerDetails(accno);
        }
        [HttpPost]
        [Route("/api/Customer/Beneficiary")]
        public bool PostBeneficiaryDetails([FromBody] Beneficiary b)
        {
            return ben.AddBeneficiary(b);
        }
        [HttpPost]
        [Route("/api/Customer/NetBanking")]
        public bool PostNetBankingDetails([FromBody] InternetBanking ib)
        {
            return net.AddNetBanking(ib);
        }
        [HttpPost]
        [Route("/api/Customer/AddFunds")]
        public bool PostFunds([FromBody] Transaction t)
        {
            return transaction.AddFunds(t);
        }
        [HttpGet]
        [Route("/api/Customer/ShowFundsByAccountNumber/{accno}/{fromDate}/{toDate}")]
        public List<Transaction> GetFundsByAccountNumber(long accno, DateTime fromDate, DateTime toDate)
        {
            return transaction.ShowFundsByAccountNumber(accno, fromDate, toDate);
        }
        [HttpGet]
        [Route("/api/Customer/ShowFundsByReferenceID/{refid}")]
        public Transaction GetFundsByReferenceID(int refid)
        {
            return transaction.ShowFundsByReferenceID(refid);
        }

        [HttpGet]
        [Route("/api/Customer/GetBeneficiaryList/{accno}")]
        public List<Beneficiary> GetBeneficiary(int accno)
        {
            return ben.GetBeneficiaryList(accno);
        }
    }
}
