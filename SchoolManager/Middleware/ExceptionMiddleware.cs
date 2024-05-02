using SchoolManager.Domain.Entities.Exception;
using SchoolManager.Domain.Entities.Exception.Base;
using System.Net;

namespace SchoolManager.Application.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await this.HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ExceptionResponseBase exceptionResponseBase;
            switch (exception)
            {
                case CustomException customException:
                    exceptionResponseBase = new ExceptionResponseBase(HttpStatusCode.InternalServerError, customException.Message);
                    break;
                default:
                    exceptionResponseBase = new ExceptionResponseBase(HttpStatusCode.InternalServerError, "Algo inesperado ocorreu. Por favor, tente novamente");
                    break;
            }

            context.Response.StatusCode = exceptionResponseBase.StatusCode;

            await context.Response.WriteAsJsonAsync(exceptionResponseBase);
        }
    }
}
