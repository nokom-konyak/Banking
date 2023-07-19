using Microsoft.EntityFrameworkCore;
using OnlineBankingAPI.Controllers;
using OnlineBankingAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();


builder.Services.AddDbContext<OnlineBankingDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BankingConn")));


builder.Services.AddCors(c => c.AddPolicy("BankingProject", c => c.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
builder.Services.AddEndpointsApiExplorer();
// Configure the HTTP request pipeline.
builder.Services.AddScoped<IAuthenticate, AuthenticateImpl>();
builder.Services.AddScoped<IAdmin, AdminImpl>();
builder.Services.AddScoped<IBeneficiary, BeneficiaryImpl>();
builder.Services.AddScoped<INetBanking, NetBankingImpl>();
builder.Services.AddScoped<ITransaction, TransactionImpl>();

var app = builder.Build();
app.MapControllers();
app.UseRouting();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();
app.Run();

