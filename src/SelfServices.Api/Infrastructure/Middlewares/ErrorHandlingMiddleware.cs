using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SelfServices.Core.Common.Exceptions;

namespace SelfServices.Api.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AuthenticationException ex)
            {
                await catchError(ex, HttpStatusCode.Unauthorized, "unAuthorized");
            }
            catch (ValidationException ex)
            {
                await catchError(ex, HttpStatusCode.BadRequest, "validationError");
            }
            catch (CheckLimitException ex)
            {
                await catchError(ex, ex.Code == "reservationError" ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError, ex.Code);
            }
            catch (Exception ex)
            {
                await catchError(ex, HttpStatusCode.InternalServerError, "internalError");
            }

            async Task catchError(Exception ex, HttpStatusCode statusCode, string errorCode)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new Error { ErrorCode = errorCode, ErrorMessage = ex.Message }));
            }
        }
    }
}