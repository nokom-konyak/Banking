using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineBankingAPI.Models;



namespace OnlineBankingAPI.Controllers
{
    [Route("api/Authenticate")]
    [ApiController]
    [EnableCors(PolicyName = "BankingProject")]
    public class AuthenticateController : ControllerBase
    {
        readonly OnlineBankingDbContext db;
        readonly IAuthenticate auth;
        public AuthenticateController(OnlineBankingDbContext db, IAuthenticate auth)
        {
            this.db = db;
            this.auth = auth;
        }
        [HttpPost]
        [Route("/api/Authenticate/NewRegister")]
        public bool Post([FromBody] Customer c)
        {
            c.Password = EncodePasswordToBase64(c.Password);
            return auth.NewRegister(c);
        }
        [HttpGet]
        [Route("/api/Authenticate/Login/{accno}/{pwd}")]
        public bool Get(long accno, string pwd)
        {
            pwd = EncodePasswordToBase64(pwd);
            return auth.Login(accno, pwd);
        }
        [HttpPut]
        [Route("/api/Authenticate/UpdatePwd/{accno}/{oldp}/{newp}")]
        public bool Put(long accno, string oldp, string newp)
        {
            oldp = EncodePasswordToBase64(oldp);
            newp = EncodePasswordToBase64(newp);
            return auth.ChangePassword(accno, oldp, newp);
        }
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}