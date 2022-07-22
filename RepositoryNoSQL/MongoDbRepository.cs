using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FXTF.Lib.RepositoryNoSQL
{
    /// <summary>
    /// A MongoDB repository. Maps to a collection with the same name
    /// as type TEntity.
    /// </summary>
    /// <typeparam name="T">Entity type for this repository</typeparam>
    public class MongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : EntityBase
    {
        private IMongoDatabase database;
        private IMongoCollection<TEntity> collection;
        public MongoDbRepository()
        {
            try
            {
                //< add key = "MongoDbDatabaseName" value = "FXTFPlusDev" />
                //< add key = "MongoDbConnectionString" value = "mongodb://fxtfadmin:Admin432!@13.78.91.3:27017/FXTFPlusDev" />
                var conString = "mongodb://fxtfadmin:Admin432!@13.78.91.3:27017/FXTFPlusDev";
                var Client = new MongoClient(conString);
                database = Client.GetDatabase("FXTFPlusDev");
                collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
            catch (Exception ex)
            {
                // Logger = new Logger();
                // Need to log write
            }
        }

        public async Task<dynamic> GetByID(Guid id, string strClassName)
        {
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                return await Task.FromResult(collection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync().Result);
            }
            catch (Exception ex)
            {
                // Need to log write
                return ex.Message;
            }
        }
        public async Task<dynamic> GetSum<T>(IEnumerable<T> list, double ColName)
        {
            return await Task.FromResult(list.Sum(x => ColName).ToString());
        }
        public async Task<dynamic> InsertOne(TEntity entity, string strClassName)
        {
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                entity.Id = Guid.NewGuid();
                collection.InsertOne(entity);
                return await Task.FromResult("Save Successfully");
            }
            catch (Exception ex)
            {
                // Need to log write
                return ex.Message;
            }
        }
        public async Task<dynamic> InsertMany(IEnumerable<TEntity> entity, string strClassName)
        {
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                collection.InsertMany(entity);
                return await Task.FromResult("Save Successfully");
            }
            catch (Exception ex)
            {
                // Need to log write
                return ex.Message;
            }
        }
        public async Task<dynamic> Update(TEntity entity, string strClassName)
        {
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                if (entity.Id == null)
                    return await InsertOne(entity, strClassName);

                await collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
                {
                    IsUpsert = true
                });
                return entity;
            }
            catch (Exception ex)
            {
                // Need to log write
                return ex.Message;
            }
        }
        public async Task<dynamic> Delete(Guid id, string strClassName)
        {
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                return await collection.DeleteOneAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                // Need to log write
                return ex.Message;
            }
        }
        public async Task<dynamic> Delete(TEntity entity, string strClassName)
        {
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                return await collection.DeleteManyAsync(x => x.Id.Equals(entity.Id));
            }
            catch (Exception ex)
            {
                // Need to log write
                return ex.Message;
            }
        }
        public async Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate, string strClassName)
        {
            dynamic result = null;
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                result = collection.AsQueryable<TEntity>().Where(predicate.Compile()).ToList();
            }
            catch (Exception ex)
            {
            }
            return await Task.FromResult(result);
        }
        public async Task<dynamic> FindByCustomer(Expression<Func<TEntity, bool>> predicate, string strClassName)
        {
            try
            {
                collection = this.database.GetCollection<TEntity>(strClassName);
                return await Task.FromResult(collection.AsQueryable<TEntity>().Where(predicate.Compile()).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<IEnumerable<TEntity>> GetAll(string strClassName)
        {
            collection = this.database.GetCollection<TEntity>(strClassName);
            return await Task.FromResult(collection.Find(new BsonDocument()).ToListAsync().Result);
        }


    }
}