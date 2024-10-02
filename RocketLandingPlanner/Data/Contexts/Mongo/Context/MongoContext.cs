using MongoDB.Driver;
using RocketLandingPlanner.Data.Contexts.Mongo.Abstract;
using System.Linq.Expressions;

namespace RocketLandingPlanner.Data.Contexts.Mongo.Context
{
    public class MongoContext<T>
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        private IMongoCollection<T> _collection;

        public MongoContext(string collectionName, IMongoDBSettings mongoDBSettings)
        {
            var connectionString = mongoDBSettings.ConnectionString;
            var mongoDbName = mongoDBSettings.Database;

            client = new MongoClient(connectionString);
            database = client.GetDatabase(mongoDbName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<T> InsertEntityAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }
        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> expression)
        {
            return await _collection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<T> FindAndUpdateAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> updateDefinition)
        {
            return await _collection.FindOneAndUpdateAsync(expression, updateDefinition);
        }

        #region Açıklamalar
        //Mongo bilgilerini injekte eden ve temel mongo işlem metotlarını barındıran bir base class olarak eklenmiştir.
        //Library ana proje solution'ı içerisine entegre edildiğinde ortak bir dizine de alınabilir.
        #endregion
    }
}
