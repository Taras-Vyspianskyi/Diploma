using Diploma.Interfaces.Enums;

namespace Diploma.Interfaces.Services.Order.Dto
{
    public class CreateOrderRequestDto : BaseRequestDto
    {
        public string CustomerId { get; set; }

        public string Coordinates { get; set; }

        public string OperatorId { get; set; }

        public int CrewId { get; set; }

        public WorkerCategoryEnum Category { get; set; }
    }
}
