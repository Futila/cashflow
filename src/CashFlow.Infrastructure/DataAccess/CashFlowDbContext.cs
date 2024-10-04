
using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;


//"internal" Ensure that CashFlowDbContext is only used in the infrastructure project
internal class CashFlowDbContext: DbContext 
{

    public CashFlowDbContext(DbContextOptions options): base(options){}

    //Expenses will always be the name of the table on the database
    public DbSet<Expense> Expenses { get; set; }


}
