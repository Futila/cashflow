
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;


/*
 * the class remains internal so that this class is not used within the api project
 * class that will be responsible for implementing everything  we need in relation to operations in our repository (add, remove, update expenses)
 * 
 * */
internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository, IExpensesUpdateOnlyRepository
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

    public async Task<bool> Delete (long id)
    {
        var result = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

        if(result is null)
        {
            return false;
        }

        _dbContext.Expenses.Remove(result);

        return true;
    }

    public async Task<List<Expense>> GetAll()
    {
        //ToListAsync() - will actually execute the select query to bring all
        //expenses from the table and return it as a list of expenses

        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    public async Task<Expense ?> GetById(long id)
    {
        // FirstOrDefaultAsync - If it does not find a match for that id,
        // it will return the default of that type, which is an entity (class),
        // and the default of a class when not instantiated is null
        return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
    }


    async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }
}
