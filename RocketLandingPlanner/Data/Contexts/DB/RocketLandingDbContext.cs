using Microsoft.EntityFrameworkCore;
using RocketLandingPlanner.Data.Entities.RocketLanding;

namespace RocketLandingPlanner.Data.Contexts.DB
{
    public class RocketLandingDbContext
    {
        public DbSet<RocketLanding> RocketLandings { get; set; }
    }
}
