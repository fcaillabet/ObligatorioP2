using Dominio;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppObligatorio2.Controllers
{
    public class ServicioController : Controller
    {
        Sistema s = Sistema.getInstancia();
        public IActionResult Servicio()
        {
            string rol = HttpContext.Session.GetString("LogueadoRol");
            if (rol == "Cliente")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }    
        }

        [HttpPost]
        public IActionResult Servicio(DateTime f1, DateTime f2)
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            List<Servicio> l = s.GetServiciosFecha(f1, f2, idLogueado);
            return View(l);
        }

        public IActionResult ServiciosAbiertos()
        {
            string rol = HttpContext.Session.GetString("LogueadoRol");
            if (rol == "Cliente")
            {
                int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
                List<Servicio> n = s.GetServiciosAbiertos(idLogueado);
                return View(n);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Aniadir(int Id)
        {
            Servicio ser = s.GetServicioPorId(Id);
            return RedirectToAction("AgregarPlato", "Servicio");
        }

        public IActionResult AgregarPlato()
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
        public IActionResult AgregarPlato(int plato, int cant, Servicio ser)
        {
            Plato p = s.ObtenerPlato(plato);
            s.AgregarPlato(p, cant, ser);
            return View();
        }
    }
}
