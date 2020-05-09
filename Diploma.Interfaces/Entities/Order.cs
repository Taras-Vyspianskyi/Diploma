using Diploma.Interfaces.Enums;
using System;

namespace Diploma.Interfaces.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int CrewId { get; set; }

        public int CustomerId { get; set; }

        public int OperatorId { get; set; }

        public WorkerCategoryEnum Category { get; set; }

        public DateTime OrderTime { get; set; }

        public ExecutionStatusEnum Status { get;set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
