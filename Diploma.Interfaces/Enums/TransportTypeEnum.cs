using System.ComponentModel;

namespace Diploma.Interfaces.Enums
{
    public enum TransportTypeEnum
    {
        Unknown = 0,

        [Description("Car")]
        Car = 1,

        [Description("Bicycle")]
        Bicycle = 2,

        [Description("Legs")]
        Legs = 3
    }
}
