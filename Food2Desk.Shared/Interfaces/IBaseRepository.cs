using Food2Desk.Shared.DTOs;
using System.Linq.Expressions;

namespace Food2Desk.Shared.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : DTOBase
    {
        TModel GetById(Guid id, Path<TModel> path = null);
        TModel GetPath(Guid id, Expression<Func<TModel, object>> path = null);

        TModel Insert(TModel dto);
        TModel Update(TModel dto, Path<TModel> path = null);
        void Delete(Guid id);
    }
}
