using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Restaurant.Filter
{
    public class ClienteFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.GetString("rol") != "cliente")
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("/Persona/Login");
                return;
            }
        }
    }

    public class MozoFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != "mozo")
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("/Persona/Login");
                return;
            }
        }
    }

    public class RepartidorFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != "repartidor")
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("/Persona/Login");
                return;
            }
        }
    }

    public class PlatoFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != null)
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("/Persona/Login");
                return;
            }
        }
    }
}
