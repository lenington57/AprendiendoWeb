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
    [BreadCrumb(Title = "Profesor", Url = "/Profesor/Index", Order = 0)]
    public class ProfesorController : Controller
    {
        public static List<Profesor> profesors;
        // GET: Profesor
        [BreadCrumb(Title = "Listado de Profesores", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                           string sortExpression = "Nombre")
        {
            if (profesors == null)
            {
                profesors = new List<Profesor>();
                int i;
                for (i = 1; i < 6; i++)
                {
                    Profesor profesor = new Profesor();
                    profesor.Codigo = i;
                    profesor.Cedula = "000-0000000-0";
                    profesor.FechaNacimiento = DateTime.Now.AddMonths(2);
                    profesor.FechaIngreso = DateTime.Now;
                    profesor.Nombre = "Pedro";
                    profesor.Apellido = "Turizpatio";
                    profesor.Sexo = "Masculino";
                    profesor.EstadoCivil = "Soltero";
                    profesor.Ocupacion = "Estudiante ISC";
                    profesor.TipoSangre = "No se Positivo (ns+)";
                    profesor.Nacionalidad = "Dominicano";
                    profesor.Religion = "No se";
                    profesor.Telefono = "0000000000";
                    profesor.Email = "herminio@gmail.com";
                    profesor.Direccion = "Los Lanos";
                    profesor.Carrera = "Ingeniería en Sistemas y Computación";
                    profesor.TituloCarreraGrado = "Ing. Sis y Comp";
                    profesor.CategoriaProfesional = "Grado";
                    profesor.FacultadQuePertenece = "Ingeniería";
                    profesor.AsignaturasQueImparte = "Base de Datos";
                    profesor.Observaciones = "Un buen muchacho";
                    profesors.Add(profesor);
                }
                for (i = 6; i < 11; i++)
                {
                    Profesor profesorDos = new Profesor();
                    profesorDos.Codigo = i;
                    profesorDos.Cedula = "000-0000000-0";
                    profesorDos.FechaNacimiento = DateTime.Now.AddMonths(2);
                    profesorDos.FechaIngreso = DateTime.Now;
                    profesorDos.Nombre = "Pablo";
                    profesorDos.Apellido = "Turizpatio";
                    profesorDos.Sexo = "Masculino";
                    profesorDos.EstadoCivil = "Soltero";
                    profesorDos.Ocupacion = "Estudiante ISC";
                    profesorDos.TipoSangre = "No se Positivo (ns+)";
                    profesorDos.Nacionalidad = "Dominicano";
                    profesorDos.Religion = "No se";
                    profesorDos.Telefono = "0000000000";
                    profesorDos.Email = "herminio@gmail.com";
                    profesorDos.Direccion = "Los Lanos";
                    profesorDos.Carrera = "Ingeniería en Sistemas y Computación";
                    profesorDos.TituloCarreraGrado = "Ing. Sis y Comp";
                    profesorDos.CategoriaProfesional = "Grado";
                    profesorDos.FacultadQuePertenece = "Ingeniería";
                    profesorDos.AsignaturasQueImparte = "Base de Datos";
                    profesorDos.Observaciones = "Un buen muchacho";
                    profesors.Add(profesorDos);
                }
                for (i = 11; i < 16; i++)
                {
                    Profesor profesorTres = new Profesor();
                    profesorTres.Codigo = i;
                    profesorTres.Cedula = "000-0000000-0";
                    profesorTres.FechaNacimiento = DateTime.Now.AddMonths(2);
                    profesorTres.FechaIngreso = DateTime.Now;
                    profesorTres.Nombre = "Panio";
                    profesorTres.Apellido = "Turizpatio";
                    profesorTres.Sexo = "Masculino";
                    profesorTres.EstadoCivil = "Soltero";
                    profesorTres.Ocupacion = "Estudiante ISC";
                    profesorTres.TipoSangre = "No se Positivo (ns+)";
                    profesorTres.Nacionalidad = "Dominicano";
                    profesorTres.Religion = "No se";
                    profesorTres.Telefono = "0000000000";
                    profesorTres.Email = "herminio@gmail.com";
                    profesorTres.Direccion = "Los Lanos";
                    profesorTres.Carrera = "Ingeniería en Sistemas y Computación";
                    profesorTres.TituloCarreraGrado = "Ing. Sis y Comp";
                    profesorTres.CategoriaProfesional = "Grado";
                    profesorTres.FacultadQuePertenece = "Ingeniería";
                    profesorTres.AsignaturasQueImparte = "Base de Datos";
                    profesorTres.Observaciones = "Un buen muchacho";
                    profesors.Add(profesorTres);
                }

            }

            List<Profesor> filtrada = profesors;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = profesors.FindAll(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
            }

            var model = PagingList.Create(filtrada, 5, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";
            ViewBag.NumPagina = page;
            return View(model);
        }

        // GET: Profesor/Details/5
        [BreadCrumb(Title = "Detalle del Profesor", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = profesors.Find(x => x.Codigo == id);  //verifica si existe el id y lo busca en el arreglo
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // GET: Profesor/Create
        [BreadCrumb(Title = "Crear Profesor", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesor modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    profesors.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: Profesor/Edit/5
        [BreadCrumb(Title = "Editar Profesor", Order = 3)]
        public ActionResult Edit(int id)
        {
            var modelo = profesors.Find(c => c.Codigo == id);
            //Verificar si el modelo está nulo.
            if (modelo == null)
            {
                //Redirigir al 'Index'
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // POST: Profesor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Profesor modelo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //Usamos el índice, que es el PrimaryKey del modelo en este caso.
                    int indice = profesors.FindIndex(x => x.Codigo == modelo.Codigo);
                    //Le pasamos al arreglo, el modelo que está en la vista.
                    profesors[indice] = modelo;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }

        // GET: Profesor/Delete/5
        [BreadCrumb(Title = "Eliminar Profesor", Order = 3)]
        public ActionResult Delete(int id)
        {
            var modelo = profesors.Find(x => x.Codigo == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: Profesor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Profesor modelo)
        {
            try
            {
                int indice = profesors.FindIndex(x => x.Codigo == id);
                profesors.RemoveAt(indice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }
    }
}