namespace RocketLandingPlanner.Data.Entities.Base
{
    public class BaseEntity
    {
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }

    #region Açıklamalar
    //Ana DB entity objesidir. Insert ve update işlemleri sırasında modifieddate alanı ile güncel tarih alanı tutulur.
    //Modified by alanı ile de işlem yapan kullanıcı bilgisi takip edilebilir.
    //İleride insert ve update işlemleri eklendiğinde bu alan kullanılarak kullancıcı verilerini tutmak amaçlı eklenmiştir.
    #endregion
}
