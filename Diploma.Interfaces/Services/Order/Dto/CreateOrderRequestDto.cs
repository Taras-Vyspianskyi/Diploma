using Diploma.Interfaces.Enums;

namespace Diploma.Interfaces.Services.Order.Dto
{
    public class CreateOrderRequestDto : BaseRequestDto
    {
        public string CustomerId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string OperatorId { get; set; }

        public string CrewId { get; set; }

        public WorkerCategoryEnum Category { get; set; }
    }
}
