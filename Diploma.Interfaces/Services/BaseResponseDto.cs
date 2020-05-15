using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Interfaces.Services
{
    public class BaseResponseDto
    {
        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccess()
        {
            return !this.IsError;
        }

        public BaseResponseDto AsSuccess()
        {
            this.IsError = false;
            return this;
        }

        public BaseResponseDto AsError(string message)
        {
            this.IsError = true;
            this.ErrorMessage = message;
            return this;
        }
    }
}
