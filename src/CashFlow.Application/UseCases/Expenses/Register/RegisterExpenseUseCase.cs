
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute (RequestRegisterExpenseJson request)
    {
        validate(request);

        var dbContext = new CashFlowDbContext();

        var entity = new Expense
        {
            Amount = request.Amount,
            Date= request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType= (Domain.Enums.PaymentType)request.PaymentType,
        };

        //Here is just preparing the query and not saving in the database
        dbContext.Expenses.Add(entity);

        //Now, we're saving the datas in the Database
        dbContext.SaveChanges();

        return new ResponseRegisteredExpenseJson();
     
    }

    private void validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
