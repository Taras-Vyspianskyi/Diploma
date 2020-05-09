using System.ComponentModel;

namespace Diploma.Interfaces.Enums
{
    public enum WorkerCategoryEnum
    {
        Unknown = 0,

        [Description("Internet")]
        Internet = 1,

        [Description("Water")]
        Water = 2,

        [Description("Gas")]
        Gas = 3,

        [Description("Electicity")]
        Electicity = 4
    }
}
