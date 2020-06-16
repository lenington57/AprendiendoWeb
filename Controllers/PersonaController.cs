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
        private static List<Persona> personas;
        // GET: Persona
        public ActionResult Index()
        {
            if (personas == null)
            {

                personas = new List<Persona>();
                Persona persona = new Persona()
                {
                    Id = 1,
                    Nombre = "Lenington",
                    FechaNacimiento = DateTime.Now,
                    Telefono = "000-000-0000"
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
            }
            return View(personas);
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            var modelo = personas.Find(c => c.Id == id);
            //Verificar si el modelo está nulo.
            if (modelo == null)
            {
                //Redirigir al 'Index'
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona modelo)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    personas.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }                
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            var modelo = personas.Find(c => c.Id == id);
            //Verificar si el modelo está nulo.
            if (modelo == null)
            {
                //Redirigir al 'Index'
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Persona modelo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //Usamos el índice, que es el PrimaryKey del modelo en este caso.
                    int indice = personas.FindIndex(x => x.Id == modelo.Id);
                    //Le pasamos al arreglo, el modelo que está en la vista.
                    personas[indice] = modelo;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            var modelo = personas.Find(c => c.Id == id);
            //Verificar si el modelo está nulo.
            if (modelo == null)
            {
                //Redirigir al 'Index'
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Persona modelo)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    //Verificar si el modelo está nulo.
                    if (modelo == null)
                    {
                        //Redirigir al 'Index'
                        return RedirectToAction(nameof(Index));
                    }
                    int indice = personas.FindIndex(x => x.Id == modelo.Id);
                    personas.RemoveAt(indice);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }
    }
}