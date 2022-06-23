using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Restaurant.Filter;

namespace Gestion_Restaurant.Controllers
{
    [RepartidorFilter]
    public class RepartidorController : Controller
    {

        Administrativa sistema = Administrativa.Instancia;

        public IActionResult Index()
        {
            string nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            int id = (int)HttpContext.Session.GetInt32("id");

            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            return View(sistema.ServicioRepartidor(nombreUsuario, id));
        }
    }
}
