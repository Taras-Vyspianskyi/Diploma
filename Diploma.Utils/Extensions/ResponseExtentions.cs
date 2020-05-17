using Diploma.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Utils.Extensions
{
    public static class ResponseExtentions
    {

        public static T AsSuccess<T>(this T response)
            where T : BaseResponseDto, new()
        {
            response.IsError = false;
            return response;
        }

        public static T AsError<T>(this T response, string message)
            where T : BaseResponseDto, new()
        {
            response.IsError = true;
            response.ErrorMessage = message;
            return response;
        }

        public static void SetErrorMessage<T>(this T response, string message)
            where T : BaseResponseDto, new()
        {
            response.IsError = true;
            response.ErrorMessage = message;
        }
    }
}
