using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AprendiendoWeb.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
    }
}
