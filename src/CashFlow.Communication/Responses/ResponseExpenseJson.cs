
namespace CashFlow.Communication.Responses;

public class ResponseExpenseJson
{
    //ResponseShortExpenseJson is used to return only some datas
    public List<ResponseShortExpenseJson> Expenses { get; set; } = [];
}
