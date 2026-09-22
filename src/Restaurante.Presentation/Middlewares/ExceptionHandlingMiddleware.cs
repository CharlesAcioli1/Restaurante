using Restaurante.Domain.Compartilhar;
using System.Net;
using System.Text.Json;

namespace Restaurante.Presentation.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro não tratado, capturado no middleware: {Message}", ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }
        
        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = Resultado.Falha($"Ocorreu um erro interno no servidor: {ex.Message}");
            var jsonResponse = JsonSerializer.Serialize(response, _jsonOptions);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
