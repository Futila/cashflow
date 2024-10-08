﻿
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

    public async Task Add(Expense expense)
    {
 

       await _dbContext.Expenses.AddAsync(expense);
  
    }
}
