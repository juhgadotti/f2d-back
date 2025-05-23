using Food2Desk.DataAccess.Context;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.DataAccess
{

    public class BaseRepository<TModel>(Food2deskContext basicContext) : IBaseRepository<TModel> where TModel : DTOBase
    {
        private readonly Food2deskContext DbContext = basicContext;
        private static readonly Dictionary<Type, PropertyInfo[]> PropertyCache = [];

        public virtual TModel GetById(Guid id, Path<TModel> path = null)
        {
            var item = Query(path).Include(path).FirstOrDefault(i => i.Id == id);

            return item ?? throw new Exception($"Item com id {id} não encontrado.");
        }

        public virtual TModel Insert(TModel model)
        {
            DbContext.Set<TModel>().Add(model);
            return model;
        }

        public virtual TModel Update(TModel dto, Path<TModel> path = null)
        {
            TModel item = GetById(dto.Id, path);

            UpdateValues(dto, item);

            return item;
        }

        public virtual void Delete(Guid id)
        {
            TModel item = GetById(id);

            DbContext.Set<TModel>().Remove(item);
        }

        private static TModel UpdateValues(TModel modelBase, TModel modelDestiny)
        {
            var properties = GetPropertiesCached(modelBase.GetType());

            foreach (var property in properties)
            {
                if (property.Name == "Id")
                    continue;

                var value = property.GetValue(modelBase);
                UpdatePropertyIfCompatible(property, value, modelDestiny);                
            }

            return modelDestiny;
        }

        private static PropertyInfo[] GetPropertiesCached(Type type)
        {
            if (!PropertyCache.TryGetValue(type, out var properties))
            {
                properties = type.GetProperties()
                                 .Where(p => !string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase))
                                 .ToArray();

                PropertyCache[type] = properties;
            }

            return properties;
        }

        private static void UpdatePropertyIfCompatible(PropertyInfo property, object value, TModel modelDestiny)
        {
            var destinyProperty = modelDestiny.GetType().GetProperty(property.Name);

            if (destinyProperty == null || !destinyProperty.CanWrite)
                return;

            if (!destinyProperty.PropertyType.IsAssignableFrom(property.PropertyType))
                throw new Exception($"A propriedade {property.Name} tem tipo incompatível.");

            destinyProperty.SetValue(modelDestiny, value);
        }

        public virtual IQueryable<TModel> Query(Path<TModel> path = null)
        {
            return DbContext.Set<TModel>().Include(path);
        }
    }
}
