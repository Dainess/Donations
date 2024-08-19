using Microsoft.AspNetCore.Mvc.Filters;
using Donations.Communication.Responses;
using Donations.Exception.ExceptionBase;
//using Donations.Exception.ResourceManagement;
using Microsoft.AspNetCore.Mvc;
using Donations.Exception.Resources;

namespace Donations.API.Filters
{

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DonationsException)
        {
            var DonationsException = (DonationsException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)DonationsException.GetStatusCode();
            var responseJson = new ResponseErrorsJson(DonationsException.GetErrorMessages());
            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var responseJson = new ResponseErrorsJson(new List<string> {ExceptionMessages.UNKNOWN_ERROR_MESSAGE}); //ResourceManagement.SpitResource("UNKNOWN_ERROR")
            context.Result = new ObjectResult(responseJson);
        }
    }
}
}