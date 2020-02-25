using System.Linq;

namespace GameControllerProject.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : class where TId : struct
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> GetAll();

        TEntity GetById(TId id);
    }
}
