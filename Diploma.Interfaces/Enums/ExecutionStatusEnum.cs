using System.ComponentModel;

namespace Diploma.Interfaces.Enums
{
    public enum ExecutionStatusEnum
    {
        Unknow = 0,

        [Description("Pending")]
        Pending = 1,

        [Description("WorkerAssigned")]
        WorkerAssigned = 2,

        [Description("WorkerOnTheWay")]
        WorkerOnTheWay = 3,

        [Description("Executing")]
        InProgress = 4,

        [Description("Done")]
        Done = 5
    }
}
