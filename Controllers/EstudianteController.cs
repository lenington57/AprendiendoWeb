using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprendiendoWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AprendiendoWeb.Controllers
{
    public class EstudianteController : Controller
    {
        private List<Estudiante> estudiantes;
        // GET: Estudiante
        public ActionResult Index()
        {
            if (estudiantes == null)
            {
                estudiantes = new List<Estudiante>()
                {
                    new Estudiante(){
                        Matricula=20200001,
                        Cedula="00000000000",
                        FechaNacimiento=DateTime.Now.AddMonths(2),
                        FechaIngreso=DateTime.Now,
                        Nombre="Herminio",
                        Apellido="Mendoza",
                        Sexo = "Masculino",
                        EstadoCivil="Soltero",
                        Ocupacion="Estudiante ISC",
                        TipoSangre="No se Positivo (ns+)",
                        Nacionalidad="Dominicano",
                        Religion="No se",
                        Telefono="0000000000",
                        Email = "herminio@gmail.com",
                        NombrePadre = "Mumo",
                        NombreMadre = "No recuerdo",
                        Direccion="Los Lanos",
                        TipoColegio="Privado",
                        Carrera="Ingeniería en Sistemas y Computación",
                        Observaciones="Un buen muchacho"
                    },
                    new Estudiante(){
                        Matricula=20200002,
                        Cedula="00000000000",
                        FechaNacimiento=DateTime.Now.AddMonths(2),
                        FechaIngreso=DateTime.Now,
                        Nombre="Herminio",
                        Apellido="Mendoza",
                        Sexo = "Masculino",
                        EstadoCivil="Soltero",
                        Ocupacion="Estudiante ISC",
                        TipoSangre="No se Positivo (ns+)",
                        Nacionalidad="Dominicano",
                        Religion="No se",
                        Telefono="0000000000",
                        Email = "herminio@gmail.com",
                        NombrePadre = "Mumo",
                        NombreMadre = "No recuerdo",
                        Direccion="Los Lanos",
                        TipoColegio="Privado",
                        Carrera="Ingeniería en Sistemas y Computación",
                        Observaciones="Un buen muchacho"
                    },
                    new Estudiante(){
                        Matricula=20200003,
                        Cedula="00000000000",
                        FechaNacimiento=DateTime.Now.AddMonths(2),
                        FechaIngreso=DateTime.Now,
                        Nombre="Herminio",
                        Apellido="Mendoza",
                        Sexo = "Masculino",
                        EstadoCivil="Soltero",
                        Ocupacion="Estudiante ISC",
                        TipoSangre="No se Positivo (ns+)",
                        Nacionalidad="Dominicano",
                        Religion="No se",
                        Telefono="0000000000",
                        Email = "herminio@gmail.com",
                        NombrePadre = "Mumo",
                        NombreMadre = "No recuerdo",
                        Direccion="Los Lanos",
                        TipoColegio="Privado",
                        Carrera="Ingeniería en Sistemas y Computación",
                        Observaciones="Un buen muchacho"
                    }
                };
            }
            return View(estudiantes);
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
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

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estudiante/Edit/5
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

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiante/Delete/5
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