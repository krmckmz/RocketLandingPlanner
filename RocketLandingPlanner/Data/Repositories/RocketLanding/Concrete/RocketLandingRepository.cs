using RocketLandingPlanner.Data.Contexts;
using RocketLandingPlanner.Data.Repositories.Base.Concrete;
using RocketLandingPlanner.Data.Repositories.RocketLanding.Abstract;

namespace RocketLandingPlanner.Data.Repositories.RocketLanding.Concrete
{
    public class RocketLandingRepository : BaseRepository<Entities.RocketLanding.RocketLanding>, IRocketLandingRepository
    {
        public RocketLandingRepository(RocketLandingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
