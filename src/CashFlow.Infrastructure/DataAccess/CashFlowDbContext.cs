
using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

public class CashFlowDbContext: DbContext 
{
    //Expenses will always be the name of the table on the database
    public DbSet<Expense> Expenses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=";

        var version = new Version(8,0,39);

        var serverVersion = new MySqlServerVersion(version);

        optionsBuilder.UseMySql(connectionString, serverVersion);
        //base.OnConfiguring(optionsBuilder);
    }
}
