using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using Event.Uau.Comum.Configuracao.Helpers;
using Newtonsoft.Json;
using Event.Uau.Comum.Util.Exceptions;
using Flurl.Http;

namespace Event.Uau.Comum.Configuracao.Middleware
{
    public static class ExceptionMiddleware
    {

        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(e => e.Run(CustomErrors));

            return app;
        }

        private static async Task CustomErrors(HttpContext context)
        {
            var feature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = feature.Error;
            var body = new ExceptionBody(exception);

            if(exception is ValidationException validationException)
            {
                body = new ExceptionBody(validationException);
                context.Response.StatusCode = 400;
            }
            else if(exception is FlurlHttpException flurlHttpException)
            {
                var eventUauException = await flurlHttpException.GetResponseJsonAsync<EventUauBadRequestException>();

                body = new ExceptionBody(eventUauException);
                context.Response.StatusCode = 400;
            }
            else if(exception is EventUauBadRequestException eventUauBadRequest)
            {
                body = new ExceptionBody(eventUauBadRequest);
                context.Response.StatusCode = 400;
            }
            else
                context.Response.StatusCode = 500;
            

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(body));
        }

    }
}
