using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Dominio;
namespace WebAppObligatorio2.Controllers
{
    public class PlatoController : Controller
    {
        Sistema s = Sistema.getInstancia();
        public IActionResult Index()
        {
            return View(s.GetPlatos());
        }

        public IActionResult Like(int id)
        {
            s.Likear(id);
            return RedirectToAction("Index");
        }
    }
}
