using RocketLandingPlanner.Data.Contexts.Mongo.Abstract;

namespace RocketLandingPlanner.Data.Contexts.Mongo.Concrete
{

    public class MongoDBSettings : IMongoDBSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string HostName { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }

    #region Açıklamalar
    //Mongo bağlantılarının olduğu temel connection class'ıdır.Library entegre edildiğinde isteğe göre ana projede de konumlanabilir.
    #endregion
}
