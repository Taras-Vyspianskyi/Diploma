using Diploma.Interfaces.Enums;
using System;

namespace Diploma.Interfaces.Services.Order.Dto
{
    public class UpdateOrderStatusResponseDto : BaseResponseDto
    {
        public DateTime OrderTime { get; set; }

        public ExecutionStatusEnum Status { get; set; }
    }
}
