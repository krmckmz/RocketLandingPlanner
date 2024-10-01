using RocketLandingPlanner.Data.Repositories.Base.Abstract;

namespace RocketLandingPlanner.Data.Repositories.RocketLanding.Abstract
{
    public interface IRocketLandingRepository : IAsyncRepository<Entities.RocketLanding.RocketLanding>
    {
    }
}