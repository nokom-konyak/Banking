using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace OnlineBankingAPI.Models
{
    public class OnlineBankingDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Beneficiary> Beneficiary { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<InternetBanking> InternetBanking { get; set; }

        public OnlineBankingDbContext() : base() { }

        public OnlineBankingDbContext(DbContextOptions<OnlineBankingDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    if (!builder.IsConfigured)
        //    {
        //          builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Banking_DB;Integrated Security=True;");
        //    }
        //} 
    }
}

