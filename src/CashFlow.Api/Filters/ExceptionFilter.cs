﻿using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    //Every Exception triggered in the application will be redirected to this function
    public void OnException(ExceptionContext context)
    {
       if(context.Exception is CashFlowException)
        {
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
            //Convert the Exception as an ErrorOnValidationException
            var ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseErrorJson(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {

            var errorResponse = new ResponseErrorJson(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
