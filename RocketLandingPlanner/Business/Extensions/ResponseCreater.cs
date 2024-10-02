using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Response_Models;

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

        #region Açıklamalar
        //Roket iniş isteklerine dönülecek response model'i örmek amaçlı eklenmiş küçük bir metot'tur.
        //Tekrarı engellemek amaçlı yapılmıştır.
        //Class library ana projeye eklendiğinde ,uygunluğa göre orada generic yapıda benzer bir class üreterek onun içerisinde de kullanılabilir.
        #endregion
    }
}
