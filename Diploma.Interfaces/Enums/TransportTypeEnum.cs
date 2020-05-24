using System.ComponentModel;

namespace Diploma.Interfaces.Enums
{
    public enum TransportTypeEnum
    {
        Unknown = 0,

        [Description("driving-traffic")]
        Car = 1,

        [Description("cycling")]
        Bicycle = 2,

        [Description("walking")]
        Legs = 3
    }
}
