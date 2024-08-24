using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practica1.Models;

namespace practica1.Controllers
{
    public class OperacionController : Controller
    {
        private readonly ILogger<OperacionController> _logger;

        public OperacionController(ILogger<OperacionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new Operaciones();
            return View(model);
        }

        [HttpPost]
        public IActionResult Operar(Operaciones operaciones)
        {
            if (operaciones.Operacion == null || operaciones.Operacion.Count == 0)
            {
                ModelState.AddModelError("Operacion", "Debe seleccionar al menos un instrumento");
                return View("Index", operaciones);
            }

            operaciones.CalcularInversion();
            return View("Index", operaciones);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}