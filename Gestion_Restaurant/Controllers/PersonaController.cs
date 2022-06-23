using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Gestion_Restaurant.Controllers
{
    public class PersonaController : Controller
    {
        

        Administrativa sistema = Administrativa.Instancia;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.personas = sistema.ListaPersona();
            return View();
        }

        [HttpGet]
        public IActionResult AltaCliente()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult AltaCliente(string Nombre, string Apellido, string Password, string NombreUsuario, string mail)
        {
            ViewBag.Nombre = Nombre;
            ViewBag.Apellido = Apellido;
            ViewBag.Password = Password;
            ViewBag.NombreUsuario = NombreUsuario;
            ViewBag.mail = mail;

            string rol = "cliente";
            if (sistema.CargarCliente(Nombre, Apellido, Password, NombreUsuario, rol, mail))
            {
                ViewBag.Resultado = true;
                ViewBag.Mensaje = "Tu usuario se genero correctamente.";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Resultado = false;
                ViewBag.Mensaje = "No se pudo generar el usuario. Intentalo nuevamente.";
                return View();
            }
        }


        [HttpPost]
        public IActionResult Login(string nombreUsuario, string password)
        {
            Persona unP = sistema.ObtenerPersona(nombreUsuario, password);

            if (unP == null)
            {
                ViewBag.Error = true;
                return View("login");
            }

            HttpContext.Session.SetString("nombreUsuario", nombreUsuario);
            HttpContext.Session.SetString("rol", unP.Rol);
            HttpContext.Session.SetInt32("id", unP.Id);
            HttpContext.Session.SetString("nombre", unP.Nombre);

            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("~/Cliente/index");
            }
            else if (HttpContext.Session.GetString("rol") == "mozo")
            {
                return Redirect("~/Mozo/index");
            }
            else
            {
                return Redirect("~/Repartidor/index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
