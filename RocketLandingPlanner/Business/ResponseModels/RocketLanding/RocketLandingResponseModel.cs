using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Response_Models.Base;

namespace RocketLandingPlanner.Business.Response_Models
{
    public class RocketLandingResponseModel : BaseResponseModel
    {
        public RocketLandingResponseType ResponseType { get; set; }

        #region Açıklamalar
        //Roket kalkış isteklerine cevap olması açısından eklenmiştir. Base bir response model'den türetilmiştir.
        //Burada ileriye dönük roket kalkış , roket pist yeri taşınması gibi senaryolar düşünülerek bu şekilde bir baz oluşturulmuştur.
        #endregion
    }
}
