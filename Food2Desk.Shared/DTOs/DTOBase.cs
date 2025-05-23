using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;

namespace Food2Desk.Shared.DTOs
{
    public static class PathExtension
    {
        public static IQueryable<Tdto> Include<Tdto>(this IQueryable<Tdto> query, Path<Tdto> dtoPath) where Tdto : class
        {
            dtoPath?.Paths?.ForEach(pathList =>
            {

                var IncludeMethod = typeof(EntityFrameworkQueryableExtensions).GetTypeInfo().GetDeclaredMethods("Include")
                                    .Single(mi => mi.GetGenericArguments().Count() == 2 && mi.GetParameters().Any(pi => pi.ParameterType != typeof(string)));

                var q = IncludeMethod.MakeGenericMethod(typeof(Tdto), pathList.First().Type.IsGenericType ? pathList.First().Type.GenericTypeArguments.Last() : typeof(object)).Invoke(null, new object[] { query, pathList.First() });

                pathList.Skip(1).ToList().ForEach(p =>
                {
                    var ThenIncludeMethod = typeof(EntityFrameworkQueryableExtensions).GetTypeInfo().GetDeclaredMethods("ThenInclude")
                            .Single(mi => mi.GetGenericArguments().Count() == 3 && mi.GetParameters()[0].ParameterType.GenericTypeArguments[1].IsInterface);

                    q = ThenIncludeMethod.MakeGenericMethod(typeof(Tdto), p.Type.GenericTypeArguments.First(), p.Type.GenericTypeArguments.Last()).Invoke(null, new object[] { q, p });
                });

                query = (IQueryable<Tdto>)q;
            });

            return query;
        }
    }

    public class Path<Tdto> where Tdto : class
    {
        public List<Expression> SortExpressions { get; set; }
        public List<string> SortDatabaseString { get; set; }
        public bool? SortAsc { get; set; }
        public string SortAscString { get => !SortAsc.HasValue || SortAsc.Value ? "ASC" : "DESC"; }
        public int? Page { get; set; }

        public List<List<Expression>> Paths { get; private set; } = new List<List<Expression>>();

        public Path()
        {
        }

        public Path(params Expression<Func<Tdto, object>>[] paths) : this()
        {
            if (paths != null)
            {
                foreach (var path in paths)
                {
                    LoadPath(path);
                }
            }
        }

        public Path(List<List<Expression>> cpaths, params Expression<Func<Tdto, object>>[] paths) : this()
        {
            if (paths != null)
            {
                foreach (var path in cpaths)
                {
                    Paths.Add(path);
                }
                foreach (var path in paths)
                {
                    LoadPath(path);
                }
            }
        }

        public void LoadPath(Expression<Func<Tdto, object>> path)
        {
            Paths.Add(new List<Expression>() { path });
        }
    }

    public class DTOBase
    {
        [NotMapped]
        public virtual Guid Id { get; set; }
    }
}
