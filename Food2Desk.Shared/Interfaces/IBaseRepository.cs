using Food2Desk.Shared.DTOs;

namespace Food2Desk.Shared.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : DTOBase
    {
        TModel GetById(Guid id, Path<TModel> path = null);
        TModel Insert(TModel dto);
        TModel Update(TModel dto, Path<TModel> path = null);
        void Delete(Guid id);
    }
}
