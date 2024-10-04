
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;

namespace CashFlow.Infrastructure.DataAccess.Repositories;


/*
 * the class remains internal so that this class is not used within the api project
 * class that will be responsible for implementing everything 
 * we need in relation to operations in our repository (add, remove, update expenses)
 * 
 * */
internal class ExpensesRepository : IExpensesRepository
{

    private readonly CashFlowDbContext _dbContext;

    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Expense expense)
    {
 

        _dbContext.Expenses.Add(expense);

        _dbContext.SaveChanges();    
    }
}
