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
    [BreadCrumb(Title = "Empleado", Url = "/Empleado/Index", Order = 0)]
    public class EmpleadoController : Controller
    {
        public static List<Empleado> empleados;
        // GET: Empleado
        [BreadCrumb(Title = "Listado de Empleado", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                           string sortExpression = "Nombre")
        {
            if (empleados == null)
            {
                empleados = new List<Empleado>();
                int i;
                for (i = 1; i < 6; i++)
                {
                    Empleado empleado = new Empleado()
                    {
                        Codigo = i,
                        Cedula = "00000000000",
                        FechaNacimiento = DateTime.Now.AddMonths(2),
                        FechaIngreso = DateTime.Now,
                        Nombre = "Juan",
                        Apellido = "Patriarca",
                        Sexo = "Masculino",
                        EstadoCivil = "Relacion",
                        TipoSangre = "No se Positivo (ns+)",
                        Nacionalidad = "Dominicano",
                        Religion = "No se",
                        Telefono = "0000000000",
                        Email = "reydi@gmail.com",
                        Direccion = "Pimentel",
                        SalarioMensual = "0.00",
                        DepartamentoQuePertenece = "Laboratorios",
                        NombreContactoEmergencia = "Alejandro",
                        TelefonoContactoEmergencia = "1111111111",
                        AFPQuePertenece = "AFP",
                        ARSQuePertenece = "ARS",
                        Observaciones = "Un buen muchacho"
                    };
                    empleados.Add(empleado);
                }
                for (i = 6; i < 11; i++)
                {
                    Empleado empleado = new Empleado()
                    {
                        Codigo = i,
                        Cedula = "22222222222",
                        FechaNacimiento = DateTime.Now.AddMonths(2),
                        FechaIngreso = DateTime.Now,
                        Nombre = "Matrifucio",
                        Apellido = "Petriopelo",
                        Sexo = "Masculino",
                        EstadoCivil = "Soltera",
                        TipoSangre = "No se Positivo (ns+)",
                        Nacionalidad = "Dominicano",
                        Religion = "No se",
                        Telefono = "0000000000",
                        Email = "herminio@gmail.com",
                        Direccion = "Pimentel",
                        SalarioMensual = "0.00",
                        DepartamentoQuePertenece = "Laboratorios",
                        NombreContactoEmergencia = "Alejandro",
                        TelefonoContactoEmergencia = "1111111111",
                        AFPQuePertenece = "AFP",
                        ARSQuePertenece = "ARS",
                        Observaciones = "Un buen muchacho"
                    };
                    empleados.Add(empleado);
                }
                for (i = 11; i < 16; i++)
                {
                    Empleado empleado = new Empleado()
                    {
                        Codigo = i,
                        Cedula = "33333333333",
                        FechaNacimiento = DateTime.Now.AddMonths(2),
                        FechaIngreso = DateTime.Now,
                        Nombre = "Patrilesi",
                        Apellido = "Ostiloci",
                        Sexo = "Masculino",
                        EstadoCivil = "Soltera",
                        TipoSangre = "No se Positivo (ns+)",
                        Nacionalidad = "Dominicano",
                        Religion = "No se",
                        Telefono = "0000000000",
                        Email = "herminio@gmail.com",
                        Direccion = "Pimentel",
                        SalarioMensual = "0.00",
                        DepartamentoQuePertenece = "Laboratorios",
                        NombreContactoEmergencia = "Alejandro",
                        TelefonoContactoEmergencia = "1111111111",
                        AFPQuePertenece = "AFP",
                        ARSQuePertenece = "ARS",
                        Observaciones = "Una buena muchacha"
                    };
                    empleados.Add(empleado);
                }                
                
            }

            List<Empleado> filtrada = empleados;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = empleados.FindAll(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
            }

            var model = PagingList.Create(filtrada, 5, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";
            ViewBag.NumPagina = page;
            return View(model);
        }

        // GET: Empleado/Details/5
        [BreadCrumb(Title = "Detalle del Empleado", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = empleados.Find(x => x.Codigo == id);  //verifica si existe el id y lo busca en el arreglo
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // GET: Empleado/Create
        [BreadCrumb(Title = "Crear Empleado", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleados.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: Empleado/Edit/5
        [BreadCrumb(Title = "Editar Empleado", Order = 3)]
        public ActionResult Edit(int id)
        {
            var modelo = empleados.Find(x => x.Codigo == id);  //verifica si existe el id y lo busca en el arreglo
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado modelo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //Usamos el índice, que es el PrimaryKey del modelo en este caso.
                    int indice = empleados.FindIndex(x => x.Codigo == modelo.Codigo);
                    //Le pasamos al arreglo, el modelo que está en la vista.
                    empleados[indice] = modelo;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }

        // GET: Empleado/Delete/5
        [BreadCrumb(Title = "Eliminar Empleado", Order = 3)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleado/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Empleado modelo)
        {
            try
            {
                int indice = empleados.FindIndex(x => x.Codigo == id);
                empleados.RemoveAt(indice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }
    }
}