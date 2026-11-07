using Restaurante.Domain.Compartilhar;
using System.Net;
using System.Text.Json;

namespace Restaurante.Presentation.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment environment)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
        private readonly IWebHostEnvironment _environment = environment;

        private readonly JsonSerializerOptions _jsonOptions = new()
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
                if (context.Response.HasStarted)
                    throw;

                _logger.LogError(ex, "Erro não tratado, capturado no middleware: {Message}", ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }
        
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var mensagem = _environment.IsDevelopment() ? ex.ToString() : "Ocorreu um erro interno no servidor!";

            var response = Resultado.Falha(mensagem);

            var jsonResponse = JsonSerializer.Serialize(response, _jsonOptions);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
