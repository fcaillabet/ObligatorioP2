using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppObligatorio2.Models;
using Logica;
using Microsoft.AspNetCore.Http;

namespace WebAppObligatorio2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Sistema s = Sistema.getInstancia();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");

            if(idLogueado != null)
            {
                string rol = HttpContext.Session.GetString("LogueadoRol");
                ViewBag.msg = $"Bienvenido, usted está logueado, su rol es {rol}";
            }else
            {
                ViewBag.msg = "Inicie sesión";
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string user, string pass)
        {
            Persona l = s.ValidarLogin(user, pass);
            if (l != null)
            {

                
                string rol = "";
                if(l is Cliente)
                {
                    rol = "Cliente";
                }else if (l is Mozo)
                {
                    rol = "Mozo";
                }else if(l is Repartidor)
                {
                    rol = "Repartidor";
                }

                HttpContext.Session.SetInt32("LogueadoId", l.id);
                HttpContext.Session.SetString("LogueadoRol", rol);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Datos Incorrectos";
                return View();
            }
            
        }

        public IActionResult AltaServicioLocal()
        {
            string rol = HttpContext.Session.GetString("LogueadoRol");
            if (rol == "Cliente")
            {
                return View(s.GetPlatos());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AltaServicioLocal(int plato, int cant, int mozo, int mesa, int cantPersonas)
        {
            Plato p = s.ObtenerPlato(plato);
            int id = (int)HttpContext.Session.GetInt32("LogueadoId");
            Servicio serv = s.AltaServicioLocal(mesa, mozo, cantPersonas, id);
            s.AgregarPlato(p, cant, serv);
            return View(s.GetPlatos());
        }

        public IActionResult AltaServicioDelivery()
        {
            string rol = HttpContext.Session.GetString("LogueadoRol");
            if (rol == "Cliente")
            {
                return View(s.GetPlatos());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }  
        }

        [HttpPost]
        public IActionResult AltaServicioDelivery(int plato, int cant, string direccion, double distancia, int repartidor)
        {
            Plato p = s.ObtenerPlato(plato);
            int id = (int)HttpContext.Session.GetInt32("LogueadoId");
            Delivery ser = s.AltaServicioDelivery(direccion, repartidor, distancia, id);

            s.AgregarPlato(p, cant, ser);
            return View(s.GetPlatos());
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
