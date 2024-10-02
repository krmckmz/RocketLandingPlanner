namespace RocketLandingPlanner.Data.Entities
{
    public static class StaticConfiguration
    {
        public static int HorizontalLength { get; set; } = 24;
        public static int VerticalLength { get; set; } = 32;

        #region Açıklamalar
        //Bu class rancher veya alternatif bir tool üzerinde statik bir vault alanı ile eşleştirmek
        //ve statik alanlar ile appsettings dosyası üzerinden okumak amaçlı eklenmiştir. 
        //Proje konfigürasyonunda buradan yönetilecektir. Pist alanı çok sık değişken olmadığı düşünülerek bu şekilde 
        //kurgulanmıştır. Burada tercihe veya değiştirme sıklığına göre enum kullanımı
        //veya daha sağlıklı fakat biraz efor isteyecek bir versiyonda konfigürasyon api konumlandırmak da tercih edilebilir.
        #endregion
    }
}
