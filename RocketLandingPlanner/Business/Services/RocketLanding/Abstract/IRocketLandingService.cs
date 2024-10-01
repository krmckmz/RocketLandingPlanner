using RocketLandingPlanner.Business.Response_Models;

namespace RocketLandingPlanner.Business.Services.RocketLanding.Abstract
{
    public interface IRocketLandingService
    {
        Task<RocketLandingResponseModel> CanRocketLand(int horizontalIndex, int verticalIndex);
    }
}