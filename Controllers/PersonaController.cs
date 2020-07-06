using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprendiendoWeb.Models;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;

namespace AprendiendoWeb.Controllers
{
    [BreadCrumb(Title = "Persona", Url = "/Persona/Index", Order = 0)]
    public class PersonaController : Controller
    {
        private static List<Persona> personas;
        // GET: Persona
        [BreadCrumb(Title = "Listado de Personas", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                           string sortExpression = "Nombre")
        {
            if (personas == null)
            {
                personas = new List<Persona>();
                int i;
                for (i = 1; i < 6; i++)
                {
                    Persona persona = new Persona()
                    {
                        Id = i,
                        Nombre = "Lenington",
                        FechaNacimiento = DateTime.Now,
                        Telefono = "000-000-0000"
                    };
                    personas.Add(persona);
                };

                for (i = 6; i < 11; i++)
                {
                    Persona personaDos = new Persona()
                    {
                        Id = i,
                        Nombre = "Pedro",
                        FechaNacimiento = DateTime.Now,
                        Telefono = "000-000-0000"
                    };
                    personas.Add(personaDos);
                }
                for (i = 11; i < 16; i++)
                {
                    Persona personaTres = new Persona()
                    {
                        Id = i,
                        Nombre = "Pablo",
                        FechaNacimiento = DateTime.Now,
                        Telefono = "000-000-0000"
                    };
                    personas.Add(personaTres);
                }
            }

            List<Persona> filtrada = personas;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = personas.FindAll(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
            }

            var model = PagingList.Create(filtrada, 5, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter
}
            };
            model.Action = "Index";
            return View(model);
        }

        // GET: Persona/Details/5
        [BreadCrumb(Title = "Detalle de la Persona", Order = 2)]
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
        [BreadCrumb(Title = "Crear Persona", Order = 3)]
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
        [BreadCrumb(Title = "Editar Persona", Order = 3)]
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
        [BreadCrumb(Title = "Eliminar Persona", Order = 3)]
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