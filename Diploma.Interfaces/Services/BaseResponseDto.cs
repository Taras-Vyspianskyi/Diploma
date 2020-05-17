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
    }
}
