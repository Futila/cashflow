
using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping: Profile
{
    public AutoMapping() {
        RequestToEntity();
        EntityToResponse();
    }


    //Mapping a Request to an Entity
    private void RequestToEntity()
    {
        CreateMap<RequestRegisterExpenseJson, Expense>();
    }


    //Mapping an Entity to a Response
    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
    }
}
