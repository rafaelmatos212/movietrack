using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieTrack.Application.Exceptions;

namespace MovieTrack.Api.ExceptionHandling
{
    public sealed class GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger,
        IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var (status, title, detail) = exception switch
            {
                AuthenticationFailedException e => (StatusCodes.Status401Unauthorized, "Não autorizado", e.Message),
                NotFoundException e => (StatusCodes.Status404NotFound, "Recurso não encontrado", e.Message),
                ConflictException e => (StatusCodes.Status409Conflict, "Conflito", e.Message),
                _ => (StatusCodes.Status500InternalServerError,
                      "Erro interno do servidor",
                      "Ocorreu um erro inesperado. Tente novamente mais tarde.")
            };

            if (status >= 500)
            {
                logger.LogError(exception,
                    "Erro não tratado. TraceId: {TraceId}", httpContext.TraceIdentifier);
            }
            else
            {
                logger.LogWarning(
                    "Falha de negócio {ExceptionType}. TraceId: {TraceId}",
                    exception.GetType().Name, httpContext.TraceIdentifier);
            }

            httpContext.Response.StatusCode = status;

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Status = status,
                    Title = title,
                    Detail = detail
                }
            });
        }
    }
}
