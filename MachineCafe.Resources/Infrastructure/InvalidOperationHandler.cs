using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MachineCafe.WebApi.Infrastructure
{
    public class InvalidOperationExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var exception = actionExecutedContext.Exception;
            if (exception.GetType() == typeof(InvalidOperationException))
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateResponse(HttpStatusCode.Conflict, exception.Message);
          //  return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
            return Task.FromResult(0);
        }
    }
}