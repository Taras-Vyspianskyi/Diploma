using Diploma.Interfaces.Enums;

namespace Diploma.Interfaces.Services.Order.Dto
{
    public class CreateOrderRequestDto : BaseRequestDto
    {
        public string OrderId { get; set; }

        public int CustomerId { get; set; }

        public WorkerCategoryEnum Category { get; set; }
    }
}
