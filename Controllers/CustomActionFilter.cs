using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Filtros.Controllers
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        // Antes que el metodo de acción se ejecute
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WriteValues(filterContext.Controller, filterContext.ActionDescriptor, filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            WriteValues(filterContext.Controller, filterContext.ActionDescriptor, filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            WriteValues(filterContext.Controller, null, filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            WriteValues(filterContext.Controller, null, filterContext.RouteData);
        }

        private void WriteValues(ControllerBase controllerBase, ActionDescriptor actionDescriptor, RouteData routeData, [CallerMemberName] string methodName="")
        {
            var message = $"Evento disparado {methodName}";
            Debug.WriteLine(message, "CustomActionFilter");
            string actionName = actionDescriptor != null ? actionDescriptor.ActionName : "";
            message = $"Controller: {controllerBase}, Action: {actionName}";
            Debug.WriteLine(message, "Controlador y acción");
            foreach (var keyValue in routeData.Values)
            {
                message = $"Key: {keyValue.Key}, Value: {keyValue.Value}";
                Debug.WriteLine(message, "Dato de la ruta");
            }
        }
    }
}