using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBankingAPI.Models;



namespace OnlineBankingAPI.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    [EnableCors(PolicyName = "BankingProject")]
    public class AdminController : ControllerBase
    {
        readonly OnlineBankingDbContext db;
        readonly IAdmin admin;
        public AdminController(OnlineBankingDbContext db, IAdmin admin)
        {
            this.db = db;
            this.admin = admin;
        }
        [HttpGet]
        [Route("/api/Admin/GetCustomersByStatus")]
        public List<Customer> GetCustomersByStatus()
        {
            return admin.GetCustomersByStatus();
        }
        [HttpGet]
        [Route("/api/Admin/GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return admin.GetAllCustomers();
        }
        [HttpPut]
        [Route("/api/Admin/ChangeStatus/{accno}")]
        public bool Put(long accno)
        {
            return admin.ChangeStatus(accno);
        }
        [HttpPut]
        [Route("/api/Admin/UpdateBalance/{accno}/{newBalance}")]
        public bool PutBalance(long accno, long newBalance)
        {
            return admin.UpdateBalance(accno, newBalance);
        }
    }
}