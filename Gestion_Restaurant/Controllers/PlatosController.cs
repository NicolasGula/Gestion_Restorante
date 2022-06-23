using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Restaurant.Filter;

namespace Gestion_Restaurant.Controllers
{
    [PlatoFilter]
    public class PlatosController : Controller
    {
        Administrativa sistema = Administrativa.Instancia;

        [HttpGet]
        public IActionResult Index()
        {
            return View(sistema.ListarPlatos());
        }
    }
}
