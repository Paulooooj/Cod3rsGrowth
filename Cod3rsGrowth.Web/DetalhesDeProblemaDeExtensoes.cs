using LinqToDB.SqlQuery;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Cod3rsGrowth.Web
{
    public static class DetalhesDeProblemaDeExtensoes
    {
        public static void manipuladorDeExcecoesEDetalhesDoProblema(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var manipuladorDeExcecao = context.Features.Get<IExceptionHandlerFeature>();
                    if (manipuladorDeExcecao != null)
                    {
                        var erroDoManipuladorDaExcecao = manipuladorDeExcecao.Error;
                        var detalhesDeProblemas = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };
                        if (erroDoManipuladorDaExcecao is FluentValidation.ValidationException validationException)
                        {
                            detalhesDeProblemas.Title = "Erro de Validação!";
                            detalhesDeProblemas.Status = StatusCodes.Status400BadRequest;
                            detalhesDeProblemas.Detail = validationException.StackTrace;
                            detalhesDeProblemas.Extensions["ErroDeValidacao"] = validationException.Errors
                            .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                            .ToDictionary(y => y.Key, y => y.ToList());
                        }
                        else if (erroDoManipuladorDaExcecao is SqlException sqlException)
                        {
                            detalhesDeProblemas.Title = "Erro no Banco de Dados!";
                            detalhesDeProblemas.Status = StatusCodes.Status500InternalServerError;
                            detalhesDeProblemas.Detail = sqlException.StackTrace;
                            detalhesDeProblemas.Extensions["ErroBancoDeDados"] = sqlException.Message;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Unexpected error: {manipuladorDeExcecao.Error}");
                            detalhesDeProblemas.Title = erroDoManipuladorDaExcecao.Message;
                            detalhesDeProblemas.Status = StatusCodes.Status500InternalServerError;
                            detalhesDeProblemas.Detail = erroDoManipuladorDaExcecao.Demystify().ToString();
                            detalhesDeProblemas.Extensions["ErroInesperado"] = erroDoManipuladorDaExcecao.Message;
                        }
                        context.Response.StatusCode = detalhesDeProblemas.Status.Value;
                        context.Response.ContentType = "application/problem+json";
                        var json = JsonConvert.SerializeObject(detalhesDeProblemas);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
