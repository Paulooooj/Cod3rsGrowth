using LinqToDB.Mapping;
using LinqToDB.SqlQuery;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Cod3rsGrowth.Web
{
    public static class ProblemDetailsExtensions
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };
                        if (exception is FluentValidation.ValidationException validationException)
                        {
                            problemDetails.Title = "Erro de Validação!";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = validationException.StackTrace;
                            problemDetails.Extensions["Erro de validação"] = validationException.Errors
                            .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                            .ToDictionary(y => y.Key, y => y.ToList());
                        }
                        else if (exception is SqlException sqlException)
                        {
                            problemDetails.Title = "Erro no Banco de Dados!";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = sqlException.StackTrace;
                            problemDetails.Extensions["Erro Banco de Dadosgi"] = sqlException.Message;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");
                            problemDetails.Title = exception.Message;
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = exception.Demystify().ToString();
                        }
                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";
                        var json = JsonConvert.SerializeObject(problemDetails);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
