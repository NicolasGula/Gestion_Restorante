using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Gestion_Restaurant.Filter;

namespace Gestion_Restaurant.Controllers
{
    [MozoFilter]
    public class MozoController : Controller
    {

        Administrativa sistema = Administrativa.Instancia;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.NombreMozo = HttpContext.Session.GetString("nombre");
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.ListaDeServicios = sistema.ListarLocales();

            return View(ViewBag.ListaDeServicios);
        }

        public IActionResult FiltroPorNombre(DateTime inicial, DateTime final)
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.ListaDeServicios = sistema.ServicioLocal(inicial, final);

            return View("index", ViewBag.ListaDeServicios);
        }

    }
}
