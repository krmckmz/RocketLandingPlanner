using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Extensions;
using RocketLandingPlanner.Business.Response_Models;
using RocketLandingPlanner.Business.Services.RocketLanding.Abstract;
using RocketLandingPlanner.Data.Contexts.Mongo.Abstract;
using RocketLandingPlanner.Data.Contexts.Mongo.Concrete;
using RocketLandingPlanner.Data.Contexts.Mongo.Context;
using RocketLandingPlanner.Data.Entities;
using RocketLandingPlanner.Data.Entities.RocketLanding;
using RocketLandingPlanner.Data.Repositories.RocketLanding.Abstract;

namespace RocketLandingPlanner.Business.Services.RocketLanding.Concrete
{
    public class RocketLandingService : IRocketLandingService
    {
        private readonly IRocketLandingRepository _rocketLandingRepository;
        private readonly MongoDBSettings _mongoDBSettings = null;
        private readonly MongoContext<RocketLandingLog> _rocketLandingLogRepository;

        public RocketLandingService(IRocketLandingRepository rocketLandingRepository, MongoDBSettings mongoDBSettings)
        {
            _rocketLandingRepository = rocketLandingRepository;
            _mongoDBSettings = mongoDBSettings;
            _rocketLandingLogRepository = new MongoContext<RocketLandingLog>("RocketLandingLog", _mongoDBSettings);
        }

        public async Task<RocketLandingResponseModel> CanRocketLand(int horizontalIndex, int verticalIndex, int userId)
        {
            var response = new RocketLandingResponseModel();

            if (horizontalIndex < default(int) || horizontalIndex > StaticConfiguration.HorizontalLength
               || verticalIndex < default(int) || verticalIndex > StaticConfiguration.VerticalLength)
                response = ResponseCreater.CreateResponseMessage(false, RocketLandingResponseType.OutOfPlatform, response);
            else
            {
                var currentRocketLanding = await _rocketLandingRepository.GetItemAsync(
                                         x => (x.HorizontalIndex >= horizontalIndex - 1 && x.HorizontalIndex <= horizontalIndex + 1) &&
                                              (x.VerticalIndex >= verticalIndex - 1 && x.VerticalIndex <= verticalIndex + 1));

                if (currentRocketLanding != null)
                    response = ResponseCreater.CreateResponseMessage(false, RocketLandingResponseType.Crash, response);
                else
                    response = ResponseCreater.CreateResponseMessage(true, RocketLandingResponseType.SuitableToLand, response);

            }

            await LogCreater.CreateMongoLog(response.ResponseType, horizontalIndex, verticalIndex, userId, _rocketLandingLogRepository);
            return response;
        }

        #region Açıklamalar
        //Class'ın en üst kısmında mongo ayarları , mongo log'u için gerekli repository ve ana data erişim için gerekli repository nesnesi enjekte edilmektedir.
        //Ana proje altında bir register class'ı ile herhangi bir dependency injection teknolojisi ile bu interface'ler injekte edilebilir.
        //Özel bir tercih yoksa mevcut .Net kütüphanesi ile var ise autofac vb. ile devam edilebilir.
        //Roket iniş isteklerine pist uygunluk cevabını dönecek ana servis class'ıdır. 3 tip cevap içeren bir response model dönmektedir.
        //Parametre olarak dikey ve yatay koordinat , ayrıca platform kurma isteği yapan kullanıcının id'sini istemektedir.
        //Bu alan işlemi yapan kişiyi görmek amaçlı konumlanmıştır , bir amacı da log alanında bu isteği kimin yaptığını görmektir.
        //İleriye yönelik yetki yönetimi amaçlı da kullanılabilir.
        //Hem dikey hem yatay eksende bir birim ileri , geri veya iki eksen için de birer birim ileri ve geri pozisyonda 
        //platform bulunup bulunmadığı sorgusu çekilmektedir , burada yapı gereği predicate ifadesi kullanılmıştır.
        //Ana sorgu tek bir seferde DB'e gidip gelecek şekilde olması açısından bu yapıda kurgulanmıştır.
        //Response nesnesi if koşulları içinde örülerek metot sonunda dönülmektedir.
        //Cevaplara göre istek sonuçları mongo taraflı loglanmaktadır.
        //Bu log da daha az maliyet oluşturmak amaçlı metot sonunda atılmaktadır.
        #endregion
    }
}
