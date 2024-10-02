using System.ComponentModel;

namespace RocketLandingPlanner.Business.Enums
{
    public enum RocketLandingResponseType
    {
        [Description("Platform Dışı")]
        OutOfPlatform = 1,
        [Description("Çarpışma")]
        Crash = 2,
        [Description("İniş İçin Uygun")]
        SuitableToLand = 3

        #region Açıklamalar
        //Roket iniş isteğine cevaben dönülecek 3 adet servis cevabı için enum kullanılmıştır.
        //Cevapların artacak veya belirli bir adedi geçecek olması , ya da farklı birkaç değer daha kullanılması 
        //ihtimalinde MSSQL'de bir ara tablo konumlandırması ya da in memory cache kullanımı yapmak da mümkündür.
        #endregion
    }
}
