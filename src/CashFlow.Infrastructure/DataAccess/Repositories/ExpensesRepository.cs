
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
    public void Add(Expense expense)
    {
        var dbContext = new CashFlowDbContext();

        dbContext.Expenses.Add(expense);

        dbContext.SaveChanges();    
    }
}
