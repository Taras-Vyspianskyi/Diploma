using System.Data.Common;

namespace Diploma.Interfaces.Entities
{
    public class TimeToOrder
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public double Minutes { get; set; }

        public Order Order { get; set; }
    }
}
