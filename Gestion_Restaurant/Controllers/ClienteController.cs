using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Restaurant.Filter;

namespace Gestion_Restaurant.Controllers
{
    [ClienteFilter]
    public class ClienteController : Controller
    {
        Administrativa sistema = Administrativa.Instancia;

        //Muestra la lista de todos los platos y los me gusta.
      
        public IActionResult Index()
        {
            return View(sistema.ListarPlatos());
        }

        //MUESTRA LOS SERVICIOS PEDIDOS
        public IActionResult VerServicios()
        {
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Servicios = sistema.ListarServicioPorCliente(ViewBag.NombreUsuario);

            if (ViewBag.Servicios.Count == 0)
            {
                return View("VerServicios");
            }
            else
            {
                return View("VerServicios", ViewBag.Servicios);
            }
        }
         
       //MUESTRA LOS SERVICIOS PEDIDOS AL FILTRARLOS POR FECHAS
        public IActionResult FiltroPorFecha(DateTime inicio, DateTime fin)
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");
            ViewBag.Servicios = sistema.ServicioClienteFiltradoPorfecha(inicio, fin, ViewBag.NombreUsuario);

            if (ViewBag.Servicios.Count == 0)
            {
                return View("VerServicios");
            }
            else
            {
                return View("VerServicios", ViewBag.Servicios);
            }
        }

        //AUMENTA LOS ME GUSTA
        public IActionResult AgregarLike(string nombre)
        {
            sistema.AgregarLike(nombre);
            return RedirectToAction("index");
        }

        //MUESTRA EL SERVICIO CON MAYOR PRECIO
        public IActionResult MostrarMayorPrecioServicio()
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");

            ViewBag.ServicioMasCaro = sistema.ServicioMasCaro(ViewBag.NombreUsuario);
            
            return View("MostrarMayorPrecioServicio", ViewBag.ServicioMasCaro);
        }


        public IActionResult MostrarPlatosUnaVez(int idPlato)
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.platos = sistema.ListarPlatos();
            ViewBag.PlatoUnaVez = sistema.MostrarPlatoUnaVez(ViewBag.NombreUsuario, idPlato);
            
            return View("MostrarPlatosUnaVez");
        }


        public IActionResult SolicitarServicio()
        {
            
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Id = HttpContext.Session.GetInt32("id");

            ViewBag.platos = sistema.ListarPlatos();
            ViewBag.mozos = sistema.ListarMozo();
            ViewBag.ServiciosLocalesAbiertos = sistema.ServiciosLocalesPorClienteEstadoAbierto(ViewBag.Id);

            return View("SolicitarServicio", sistema.ListarLocales());
        }

        [HttpPost]
        public IActionResult SolicitarServicio(int idPlato, int idMozo, int cantidad, DateTime fecha, int mesa, int comensales, decimal cubierto)
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Id = HttpContext.Session.GetInt32("id");
            string nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            bool estado = true;

            sistema.SolicitarServicioLocal(idPlato, idMozo, cantidad, fecha, mesa, comensales, cubierto, nombreUsuario, estado);

            ViewBag.platos = sistema.ListarPlatos();
            ViewBag.mozos = sistema.ListarMozo();
            ViewBag.ServiciosLocalesAbiertos = sistema.ServiciosLocalesPorClienteEstadoAbierto(ViewBag.Id);

            return View("SolicitarServicio", sistema.ListarLocales());
        }


        public IActionResult CerrarServicio(int idServicio)
        {
            sistema.CerrarCaja(idServicio);

            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Id = HttpContext.Session.GetInt32("id");

            ViewBag.platos = sistema.ListarPlatos();
            ViewBag.mozos = sistema.ListarMozo();
            ViewBag.ServiciosLocalesAbiertos = sistema.ServiciosLocalesPorClienteEstadoAbierto(ViewBag.Id);

            return View("SolicitarServicio", sistema.ListarLocales());
        }


        [HttpGet]
        public IActionResult SolicitarDelivery()
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Id = HttpContext.Session.GetInt32("id");

            ViewBag.platos = sistema.ListarPlatos();
            ViewBag.repartidores = sistema.ListarRepartidores();
            ViewBag.Deliverys = sistema.ListarDeliverys();

            ViewBag.ServiciosDeliverysAbiertos = sistema.ServicioDeliveryPorClienteEstadoAbierto(ViewBag.id);
            return View("SolicitarDelivery", sistema.ListarDeliverys());
        }

        [HttpPost]
        public IActionResult SolicitarDelivery(DateTime fecha, int idPlato, int cantidad, string direccion, int idRepartidor, decimal distancia)
        {
            string nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            bool estado = true;
            sistema.SolicitarDelivery(fecha, idPlato, cantidad, direccion, idRepartidor, distancia, nombreUsuario, estado);

            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Id = HttpContext.Session.GetInt32("id");

            ViewBag.platos = sistema.ListarPlatos();
            ViewBag.repartidores = sistema.ListarRepartidores();
            ViewBag.ServiciosDeliverysAbiertos = sistema.ServicioDeliveryPorClienteEstadoAbierto(ViewBag.id);
            
            return View("SolicitarDelivery");
        }

        public IActionResult CerrarServicioDelivery(int idServicio)
        {
            sistema.CerrarCajaDelivery(idServicio);
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.Id = HttpContext.Session.GetInt32("id");

            ViewBag.platos = sistema.ListarPlatos();
            ViewBag.repartidores = sistema.ListarRepartidores();
            ViewBag.ServiciosDeliverysAbiertos = sistema.ServicioDeliveryPorClienteEstadoAbierto(ViewBag.id);

            return View("SolicitarDelivery");
        }

        [HttpGet]
        public IActionResult ModificarServicio()
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.platos = sistema.ListarPlatos();
            return View("modificarServicio", sistema.ListarServicio());
        }

        [HttpPost]
        public IActionResult ModificarServicio(int idPlato, int Cantidad, int idServicio)
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            ViewBag.platos = sistema.ListarPlatos();
            sistema.AgregarPlatoServicio(idPlato, Cantidad, idServicio);

            return View("modificarServicio", sistema.ListarServicio());
        }

    }
}
