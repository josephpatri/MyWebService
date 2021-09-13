using Microsoft.Extensions.Hosting;
using System;

namespace PeliculasAPI.CrossCutting
{
    public static class Class1
    {
        public static T GetServiceFromHostContext<T>(this IHost server)
        {
            return ((T) server.Services.GetService(typeof(T)));
        }
    }

}
