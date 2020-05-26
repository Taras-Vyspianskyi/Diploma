using Diploma.Interfaces.Enums;
using System;

namespace Diploma.Interfaces.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public int CrewId { get; set; }

        public string CustomerId { get; set; }

        public string OperatorId { get; set; }

        public WorkerCategoryEnum Category { get; set; }

        public DateTime Time { get; set; }

        public ExecutionStatusEnum Status { get;set; }

        public string Coordinates { get; set; }

        public Customer Customer { get; set; }

        public User User { get; set; }

        public Worker Worker{ get; set; }
    }
}
