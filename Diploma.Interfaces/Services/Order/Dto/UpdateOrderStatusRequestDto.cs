using Diploma.Interfaces.Enums;

namespace Diploma.Interfaces.Services.Order.Dto
{
    public class UpdateOrderStatusRequestDto : BaseRequestDto
    {
        public string OrderId { get; set; }

        public ExecutionStatusEnum Status { get; set; }
    }
}
