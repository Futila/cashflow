
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task Add(Expense expense)
    {
 

       await _dbContext.Expenses.AddAsync(expense);
  
    }

    public async Task<List<Expense>> GetAll()
    {
        //ToListAsync() - will actually execute the select query to bring all
        //expenses from the table and return it as a list of expenses
        return await _dbContext.Expenses.ToListAsync();
    }
}
