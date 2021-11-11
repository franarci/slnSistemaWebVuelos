using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Filter
{
    public class BeforeAfterFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine(controller + " Action: " + action + " Paso por OnActionExecuting");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //NO COPIAR Y PEGAR ESTE METODO, ESCRIBIRLO A MANO
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine(controller + " Action: " + action + " Paso por OnActionExecuting");
            base.OnActionExecuted(filterContext);
        }
    }
}