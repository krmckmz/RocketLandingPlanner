using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Data.Contexts.Mongo.Context;
using RocketLandingPlanner.Data.Entities.RocketLanding;

namespace RocketLandingPlanner.Business.Extensions
{
    public static class LogCreater
    {
        public static async Task CreateMongoLog(RocketLandingResponseType responseType, int horizontalIndex,int verticalIndex, int userId,MongoContext<RocketLandingLog> _rocketLandingLogRepository)
        {
            var batchRequestId = Guid.NewGuid();

            RocketLandingLog rocketLandingLog = new RocketLandingLog()
            {
                BatchRequestId = batchRequestId.ToString(),
                CreateDate = DateTime.Now,
                ErrorMessage = responseType.GetDescription(),
                HorizontalIndex = horizontalIndex,
                VerticalIndex = verticalIndex,
                UserId = userId,
                ResponseType = responseType.ToString()
            };

            await _rocketLandingLogRepository.InsertEntityAsync(rocketLandingLog);
        }

        #region Açıklamalar
        //Her roket alanı uygunluk sorgusu , bir roket kalkış planlama isteği olarak düşünülmüş ve loglanmak istenmiştir. 
        //Bu amaçla bir mongo log entity'si örecek bir adet static class ve metot konumlandırılmıştır. 
        //Bu kısım sayesinde iniş uygunluk istek / sorguları log'lanacak ve bu datalar takip edilerek
        //pist ileriye yönelik geliştirme veya geçmişe yönelik talepleri monitör etmeye açık olacaktır.
        #endregion
    }
}
