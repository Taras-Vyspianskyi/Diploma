using System.ComponentModel;

namespace Diploma.Interfaces.Enums
{
    public enum UserTypeEnum
    {
        Unknown = 0,

        [Description("Customer")]
        Customer,

        [Description("Worker")]
        Worker,

        [Description("Operator")]
        Operator,

        [Description("Manager")]
        Manager
    }
}
