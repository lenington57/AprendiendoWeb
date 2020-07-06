using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprendiendoWeb.Models;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReflectionIT.Mvc.Paging;

namespace AprendiendoWeb.Controllers
{
    [BreadCrumb(Title = "Estudiante", Url = "/Estudiante/Index", Order = 0)]
    public class EstudianteController : Controller
    {
        public static List<Estudiante> estudiantes;
        // GET: Estudiante
        [BreadCrumb(Title = "Listado de Estudiante", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                           string sortExpression = "Nombre")
        {
            if (estudiantes == null)
            {
                estudiantes = new List<Estudiante>();
                int i;
                for (i = 1; i < 6; i++)
                {
                    Estudiante estudiante = new Estudiante()
                    {
                        Matricula = i,
                        Cedula = "00000000000",
                        FechaNacimiento = DateTime.Now.AddMonths(2),
                        FechaIngreso = DateTime.Now,
                        Nombre = "Jose",
                        Apellido = "Loco",
                        Sexo = "Masculino",
                        EstadoCivil = "Soltero",
                        Ocupacion = "Estudiante ISC",
                        TipoSangre = "No se Positivo (ns+)",
                        Nacionalidad = "Dominicano",
                        Religion = "No se",
                        Telefono = "0000000000",
                        Email = "herminio@gmail.com",
                        NombrePadre = "Mumo",
                        NombreMadre = "No recuerdo",
                        Direccion = "Los Lanos",
                        TipoColegio = "Privado",
                        Carrera = "Ingeniería en Sistemas y Computación",
                        Observaciones = "Un buen muchacho"
                    };
                    estudiantes.Add(estudiante);
                }
                for (i = 6; i < 11; i++)
                {
                    Estudiante estudiante = new Estudiante()
                    {
                        Matricula = i,
                        Cedula = "00000000000",
                        FechaNacimiento = DateTime.Now.AddMonths(2),
                        FechaIngreso = DateTime.Now,
                        Nombre = "Pedro",
                        Apellido = "Paralosi",
                        Sexo = "Masculino",
                        EstadoCivil = "Soltero",
                        Ocupacion = "Estudiante ISC",
                        TipoSangre = "No se Positivo (ns+)",
                        Nacionalidad = "Dominicano",
                        Religion = "No se",
                        Telefono = "0000000000",
                        Email = "herminio@gmail.com",
                        NombrePadre = "Mumo",
                        NombreMadre = "No recuerdo",
                        Direccion = "Los Lanos",
                        TipoColegio = "Privado",
                        Carrera = "Ingeniería en Sistemas y Computación",
                        Observaciones = "Un buen muchacho"
                    };
                    estudiantes.Add(estudiante);
                }
                for (i = 11; i < 16; i++)
                {
                    Estudiante estudiante = new Estudiante()
                    {
                        Matricula = i,
                        Cedula = "00000000000",
                        FechaNacimiento = DateTime.Now.AddMonths(2),
                        FechaIngreso = DateTime.Now,
                        Nombre = "Panil",
                        Apellido = "Medicina",
                        Sexo = "Masculino",
                        EstadoCivil = "Soltero",
                        Ocupacion = "Estudiante ISC",
                        TipoSangre = "No se Positivo (ns+)",
                        Nacionalidad = "Dominicano",
                        Religion = "No se",
                        Telefono = "0000000000",
                        Email = "herminio@gmail.com",
                        NombrePadre = "Mumo",
                        NombreMadre = "No recuerdo",
                        Direccion = "Los Lanos",
                        TipoColegio = "Privado",
                        Carrera = "Ingeniería en Sistemas y Computación",
                        Observaciones = "Un buen muchacho"
                    };
                    estudiantes.Add(estudiante);
                }
            }

            List<Estudiante> filtrada = estudiantes;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = estudiantes.FindAll(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
            }

            var model = PagingList.Create(filtrada, 5, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";
            ViewBag.NumPagina = page;
            return View(model);
        }

        // GET: Estudiante/Details/5
        [BreadCrumb(Title = "Detalle del Estudiante", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = estudiantes.Find(x => x.Matricula == id);  //verifica si existe el id y lo busca en el arreglo
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // GET: Estudiante/Create
        [BreadCrumb(Title = "Crear Estudiante", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiante modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estudiantes.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: Estudiante/Edit/5
        [BreadCrumb(Title = "Editar Estudiante", Order = 3)]
        public ActionResult Edit(int id)
        {
            var modelo = estudiantes.Find(x => x.Matricula == id);  //verifica si existe el id y lo busca en el arreglo
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Estudiante modelo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //Usamos el índice, que es el PrimaryKey del modelo en este caso.
                    int indice = estudiantes.FindIndex(x => x.Matricula == modelo.Matricula);
                    //Le pasamos al arreglo, el modelo que está en la vista.
                    estudiantes[indice] = modelo;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }

        // GET: Estudiante/Delete/5
        [BreadCrumb(Title = "Eliminar Estudiante", Order = 3)]
        public ActionResult Delete(int id)
        {
            var modelo = estudiantes.Find(x => x.Matricula == id);  //verifica si existe el id y lo busca en el arreglo
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Estudiante modelo)
        {
            try
            {
                int indice = estudiantes.FindIndex(x => x.Matricula == id);
                estudiantes.RemoveAt(indice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }
    }
}