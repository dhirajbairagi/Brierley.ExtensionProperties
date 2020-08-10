using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ErrorInformation _errorInformation = new ErrorInformation();
            HttpStatusCode status;
            Type exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                _errorInformation.HttpStatus = HttpStatusCode.Unauthorized;
                _errorInformation.DeveloperMessage = context.Exception?.Message;
                _errorInformation.UserMessage = context.Exception.InnerException?.Message;
                _errorInformation.MoreInfo = "";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                _errorInformation.HttpStatus = HttpStatusCode.NotImplemented;
                _errorInformation.DeveloperMessage = context.Exception?.Message;
                _errorInformation.UserMessage = context.Exception.InnerException?.Message;
                _errorInformation.MoreInfo = "";
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                _errorInformation.HttpStatus = HttpStatusCode.NoContent;
                _errorInformation.DeveloperMessage = context.Exception?.Message;
                _errorInformation.UserMessage = context.Exception.InnerException?.Message;
                _errorInformation.MoreInfo = "";
                status = HttpStatusCode.NoContent;
            }
            else if (exceptionType == typeof(DbUpdateException))
            {
                _errorInformation.HttpStatus = HttpStatusCode.BadRequest;
                _errorInformation.DeveloperMessage = context.Exception?.Message;
                _errorInformation.UserMessage = context.Exception.InnerException?.Message;
                _errorInformation.MoreInfo = "";
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                _errorInformation.HttpStatus = HttpStatusCode.InternalServerError;
                _errorInformation.DeveloperMessage = context.Exception?.Message;
                _errorInformation.UserMessage = context.Exception.InnerException?.Message;
                _errorInformation.MoreInfo = "";
                status = HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            string err = $"{JsonConvert.SerializeObject(_errorInformation)}";
            response.WriteAsync(err);
        }
    }
}