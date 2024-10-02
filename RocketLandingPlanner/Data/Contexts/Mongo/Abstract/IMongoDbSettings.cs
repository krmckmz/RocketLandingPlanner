namespace RocketLandingPlanner.Data.Contexts.Mongo.Abstract
{
    public interface IMongoDBSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string HostName { get; set; }
        string Port { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}
