using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.DistributedServices.APIBehavior
{
    public static class BehaviorBadRequest
    {
        public static void Parse(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var response = new List<string>();
                foreach (var key in actionContext.ModelState.Keys)
                {
                    foreach (var error in actionContext.ModelState[key].Errors)
                    {
                        response.Add($"{key}: {error.ErrorMessage}");
                    }
                }

                return new BadRequestObjectResult(response);
            };
        }
    }
}
