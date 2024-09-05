using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    //Every Exception triggered in the application will be redirected to this function
    public void OnException(ExceptionContext context)
    {
       if(context.Exception is ErrorOnValidationException)
        {
            HandleProjectException(context);
            HandleProjectException(context);
        }else
        {
            ThrowUnknownError(context);
        }
    }



    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException) 
        {
            //Cast
            var ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseErrorJson(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {

        }
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("unknown error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
