using System.Net;
using System.Text.Json;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Models;

namespace EcommerDiscountSystem.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                AppException e => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException e => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new ExceptionDto { Message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}