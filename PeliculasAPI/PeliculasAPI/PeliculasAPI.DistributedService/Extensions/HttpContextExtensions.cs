using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.DistributedServices.Extensions
{
   public static class HttpContextExtensions
    {
        public async static Task InsertPaginationHeadersParams<T>(this HttpContext httpContext
            , IQueryable<T> queryable)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            double cuantity = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalrecords", cuantity.ToString());
        }
    }
}
