
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute (RequestRegisterExpenseJson request)
    {
        validate(request);
        return new ResponseRegisteredExpenseJson();
     
    }

    private void validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);
    }
}
