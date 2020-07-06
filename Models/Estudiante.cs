﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AprendiendoWeb.Models
{
    public class Estudiante
    {
        [Key]
        public int Matricula { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Ocupacion { get; set; }
        public string TipoSangre { get; set; }
        public string Nacionalidad { get; set; }
        public string Religion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NombrePadre { get; set; }
        public string NombreMadre { get; set; }
        public string Direccion { get; set; }
        public string TipoColegio { get; set; }
        public string Carrera { get; set; }
        public string Observaciones { get; set; }
    }
}
