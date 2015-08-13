using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Services.Seguridad;
using Spring.Context;
using Spring.Context.Support;
using Bsd.Common.Infrastructure;

namespace ADS.LAPEM.Web.Infrastructure.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        protected ISystemLogService SystemLogService { get; set; }
        protected IUsuarioService UsuarioService { get; set; }        

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log(filterContext);           
        }

        private void Log(ActionExecutedContext context)
        {        
            //TODO Eliminar cuando se resuelva injección de Filtros
            IApplicationContext appContext =
                new XmlApplicationContext(context.HttpContext.Server.MapPath(@"~/Config/service.xml"), 
                    context.HttpContext.Server.MapPath(@"~/Config/repository.xml"),
                    context.HttpContext.Server.MapPath(@"~/Config/aop.xml"));
            UsuarioService = (IUsuarioService)appContext.GetObject("UsuarioService");
            SystemLogService = (ISystemLogService)appContext.GetObject("SystemLogService");
            //

            string username = context.RequestContext.HttpContext.User.Identity.Name;
            Usuario usuario = UsuarioService.ReadUsuarioByUsername(username).FirstOrDefault();

            SystemLog log = new SystemLog();
            log.UsuarioId = usuario.Id;
            log.Date = DateTime.Now;
            log.Modulo = context.RequestContext.RouteData.Values["controller"].ToString();
            log.Accion = context.RequestContext.RouteData.Values["action"].ToString();
            SystemLogService.CreateLog(log);
        }
    }
}