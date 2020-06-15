using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AprendiendoWeb.Models
{
    public class Empleado
    {
        [Key]
        [Required(ErrorMessage = "El campo {0} no puede estar en blanco.")]
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string TipoSangre { get; set; }
        public string Nacionalidad { get; set; }
        public string Religion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string SalarioMensual { get; set; }
        public string DepartamentoQuePertenece { get; set; }
        public string NombreContactoEmergencia { get; set; }
        public string TelefonoContactoEmergencia { get; set; }
        public string AFPQuePertenece { get; set; }
        public string ARSQuePertenece { get; set; }
        public string Observaciones { get; set; }
    }
}
