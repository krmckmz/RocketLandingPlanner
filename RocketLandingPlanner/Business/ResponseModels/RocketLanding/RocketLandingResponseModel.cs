using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Response_Models.Base;

namespace RocketLandingPlanner.Business.Response_Models
{
    public class RocketLandingResponseModel : BaseResponseModel
    {
        public RocketLandingResponseType ResponseType { get; set; }
    }
}
