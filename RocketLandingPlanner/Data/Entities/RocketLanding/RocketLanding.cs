using RocketLandingPlanner.Data.Entities.Base;

namespace RocketLandingPlanner.Data.Entities.RocketLanding
{
    public class RocketLanding : BaseEntity
    {
        public int HorizontalIndex { get; set; }
        public int VerticalIndex { get; set; }
    }
}
