using System.ComponentModel;

namespace RocketLandingPlanner.Business.Enums
{
    public enum RocketLandingResponseType
    {
        [Description("Platform Dışı")]
        OutOfPlatform = 1,
        [Description("Çarpışma")]
        Crash = 2,
        [Description("İniş İçin Uygun")]
        SuitableToLand = 3
    }
}
