using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppObligatorio2.Controllers
{
    public class PersonaController : Controller
    {
        Sistema s = Sistema.getInstancia();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AltaCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AltaCliente(Cliente c, string user, string pass)
        {
            Cliente cli = s.ValidarCliente(c, user, pass);
            if (cli != null)
            {
                s.AltaCliente(c, user, pass);
                ViewBag.msg = "Registrado con exito.";
                return View();
            }
            else
            {
                ViewBag.msg = "Datos Incorrectos";
                return View();
            }
        }
    }
}
