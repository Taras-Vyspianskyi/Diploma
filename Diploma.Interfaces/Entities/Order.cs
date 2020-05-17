using Diploma.Interfaces.Enums;
using System;

namespace Diploma.Interfaces.Entities
{
    public class Order
    {
        public string Id { get; set; }

        public string OrderId { get; set; }

        public string CrewId { get; set; }

        public string CustomerId { get; set; }

        public string OperatorId { get; set; }

        public WorkerCategoryEnum Category { get; set; }

        public DateTime Time { get; set; }

        public ExecutionStatusEnum Status { get;set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
