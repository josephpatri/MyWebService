using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DistributedServices.Filtros
{
    public class FiltroDeExcepcion : ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroDeExcepcion> logger;

        public FiltroDeExcepcion(ILogger<FiltroDeExcepcion> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }               
    }
    public class ActionFilter2 : ActionFilterAttribute
    {        
        public ActionFilter2()
        {            

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logger = (ILogger<ActionFilter2>)context.HttpContext.RequestServices.GetService(typeof(ILogger<ActionFilter2>));
            logger.LogInformation($"Headers: {JsonConvert.SerializeObject(context.HttpContext.Request.Headers, Formatting.Indented)}");
            base.OnActionExecuting(context);
        }
    }
}
