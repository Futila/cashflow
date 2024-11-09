
namespace CashFlow.Exception.ExceptionsBase;

public abstract class CashFlowException: SystemException
{
    //CashFlowException receives a messagem and will repass to SystemExeption class 
    protected CashFlowException(string message): base(message)
    {
        
    }


    public abstract int StatusCode { get; }


    public abstract List<string> GetErrors();
}
