namespace RocketLandingPlanner.Data.Entities.Base
{
    public class BaseEntity
    {
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }
}
