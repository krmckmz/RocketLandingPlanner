using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Extensions;
using RocketLandingPlanner.Business.Response_Models;
using RocketLandingPlanner.Business.Services.RocketLanding.Abstract;
using RocketLandingPlanner.Data.Entities;
using RocketLandingPlanner.Data.Repositories.RocketLanding.Abstract;

namespace RocketLandingPlanner.Business.Services.RocketLanding.Concrete
{
    public class RocketLandingService : IRocketLandingService
    {
        private readonly IRocketLandingRepository _rocketLandingRepository;
        public RocketLandingService(IRocketLandingRepository rocketLandingRepository)
        {
            _rocketLandingRepository = rocketLandingRepository;
        }

        public async Task<RocketLandingResponseModel> CanRocketLand(int horizontalIndex, int verticalIndex)
        {
            var response = new RocketLandingResponseModel();

            if (horizontalIndex < 0 || horizontalIndex > StaticConfiguration.HorizontalLength
               || verticalIndex < 0 || verticalIndex > StaticConfiguration.VerticalLength)
                return ResponseCreater.CreateResponseMessage(false, RocketLandingResponseType.OutOfPlatform, response);

            var currentRocketLanding = await _rocketLandingRepository.GetItemAsync(
                                     x => (x.HorizontalIndex >= horizontalIndex - 1 && x.HorizontalIndex <= horizontalIndex + 1) &&
                                          (x.VerticalIndex >= verticalIndex - 1 && x.VerticalIndex <= verticalIndex + 1));

            if (currentRocketLanding != null)
                return ResponseCreater.CreateResponseMessage(false, RocketLandingResponseType.Crash, response);

            return ResponseCreater.CreateResponseMessage(true, RocketLandingResponseType.SuitableToLand, response);
        }
    }
}
