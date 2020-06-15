using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprendiendoWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AprendiendoWeb.Controllers
{
    public class PersonaController : Controller
    {
        public List<Persona> personas;
        // GET: Persona
        public ActionResult Index()
        {
            personas = new List<Persona>();
            Persona persona = new Persona()
            {
                Id=1,
                Nombre="Lenington",
                FechaNacimiento=DateTime.Now,
                Telefono="000-000-0000"
            };
            Persona personaa = new Persona()
            {
                Id = 2,
                Nombre = "Lenington",
                FechaNacimiento = DateTime.Now,
                Telefono = "000-000-0000"
            };

            personas.Add(persona);
            personas.Add(personaa);
            return View(personas);
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Persona/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}