using Diploma.Interfaces.Enums;

namespace Diploma.Interfaces.Entities
{
    public class Worker
    {
        public string UserId { get; set; }

        public TransportTypeEnum TransportType { get; set; }

        public WorkerCategoryEnum Category { get; set; }

        public int CrewId { get; set; }
    }
}
