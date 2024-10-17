
using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public class GetAllExpenseUsecase: IGetAllExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public GetAllExpenseUsecase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<ResponseExpenseJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseExpenseJson
        {
           Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}
