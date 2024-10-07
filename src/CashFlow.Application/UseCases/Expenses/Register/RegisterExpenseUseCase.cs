
using AutoMapper;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Exception.ExceptionsBase;


namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase: IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    //Param: repositoy. receipt parameter in the constructor that will be an instance injected by the dependency injection service.
    public RegisterExpenseUseCase(
        IExpensesRepository repository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }
    public async Task<ResponseRegisteredExpenseJson> Execute (RequestRegisterExpenseJson request)
    {
        validate(request);

        var entity = _mapper.Map<Expense>(request);

     
        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
     
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
