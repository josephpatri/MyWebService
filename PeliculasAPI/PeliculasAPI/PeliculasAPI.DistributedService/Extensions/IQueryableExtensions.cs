using PeliculasAPI.Domain.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.DistributedServices.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationDTO pagination)
        {
            return query.
                Skip((pagination.Page - 1) * pagination.RecordsPage).
                Take(pagination.RecordsPage);
        }
    }
}
