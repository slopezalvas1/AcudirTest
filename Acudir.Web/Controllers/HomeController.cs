using Acudir.Infraestructure.Models;
using Acudir.Infraestructure.Services;
using Acudir.Infraestructure.ViewModels;
using Acudir.Services.Services;
using Acudir.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonaService _personaService;

        public HomeController(ILogger<HomeController> logger, IPersonaService personaService)
        {
            _logger = logger;
            _personaService = personaService;
        }


        public async Task<IActionResult> Tarea()
        {
            var personasList = new PersonaListViewModel();

            var persona = await _personaService.GetPersonaAleatoria();
            var model = new PersonaViewModel()
            {
                ID = persona.ID,
                Apellido = persona.Apellido,
                Nombre = persona.Nombre,
                Documento = persona.Documento,
                Mail = persona.Mail,
                Provincia = persona.Provincia,
                Telefono = persona.Telefono
            };

            personasList.PersonaActual = model;

            ViewBag.PersonasListCount = 0;
            return View(personasList);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPersona([FromQuery] int count, string[] idList)
        {
            var personasList = new PersonaListViewModel();

            //persona que se va a ver a la izquierda
            var persona = await _personaService.GetPersonaAleatoria();
            var personaActual = new PersonaViewModel()
            {
                ID = persona.ID,
                Apellido = persona.Apellido,
                Nombre = persona.Nombre,
                Documento = persona.Documento,
                Mail = persona.Mail,
                Provincia = persona.Provincia,
                Telefono = persona.Telefono
            };

            personasList.PersonaActual = personaActual;

            //personas que se van a ver a la derecha
            if (idList[0] != null)
            {
                var arrResult = idList[0].Split(',');
                foreach (var id in arrResult)
                {
                    var personaVista = await _personaService.GetById(Int32.Parse(id));
                    var personaVistaVM = new PersonaViewModel()
                    {
                        ID = personaVista.ID,
                        Apellido = personaVista.Apellido,
                        Nombre = personaVista.Nombre,
                        Documento = personaVista.Documento,
                        Mail = personaVista.Mail,
                        Provincia = personaVista.Provincia,
                        Telefono = personaVista.Telefono
                    };

                    personasList.PersonasAnterioresList.Add(personaVistaVM);
                }
            }
            ViewBag.PersonasListCount = count;

            return PartialView("~/Views/Home/_PartialCreatePersonasList.cshtml", personasList);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
