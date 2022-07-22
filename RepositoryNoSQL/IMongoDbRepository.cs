using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FXTF.Lib.RepositoryNoSQL
{
    public interface IMongoDbRepository<TEntity> where TEntity : EntityBase
    {
        Task<dynamic> GetByID(Guid id, string strClassName);
        Task<dynamic> GetSum<T>(IEnumerable<T> list, double ColName);
        Task<dynamic> InsertOne(TEntity entity, string strClassName);
        Task<dynamic> InsertMany(IEnumerable<TEntity> entity, string strClassName);
        Task<dynamic> Update(TEntity entity, string strClassName);
        Task<dynamic> Delete(Guid id, string strClassName);
        Task<dynamic> Delete(TEntity entity, string strClassName);
        Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate, string strClassName);
        Task<dynamic> FindByCustomer(Expression<Func<TEntity, bool>> predicate, string strClassName);
        Task<IEnumerable<TEntity>> GetAll(string strClassName);
    }
}
