using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Response_Models;
using RocketLandingPlanner.Business.Response_Models.Base;

namespace RocketLandingPlanner.Business.Extensions
{
    public static class ResponseCreater
    {
        public static RocketLandingResponseModel CreateResponseMessage(bool result, RocketLandingResponseType responseType, RocketLandingResponseModel responseModel)
        {
            responseModel.IsSuccess = true;
            responseModel.Message = responseType.GetDescription();

            return responseModel;
        }
    }
}
