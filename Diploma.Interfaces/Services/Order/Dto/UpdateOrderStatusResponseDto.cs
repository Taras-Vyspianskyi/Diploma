using Diploma.Interfaces.Enums;
using System;

namespace Diploma.Interfaces.Services.Order.Dto
{
    public class UpdateOrderStatusResponseDto : BaseResponseDto
    {
        public DateTime Time { get; set; }

        public ExecutionStatusEnum Status { get; set; }
    }
}
