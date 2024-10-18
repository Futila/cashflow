
namespace CashFlow.Exception.ExceptionsBase;

public class NotFoundException: CashFlowException
{
    //In this case, the base class is CashFlowException
    public NotFoundException(String message): base(message)
    {
        
    }
}
