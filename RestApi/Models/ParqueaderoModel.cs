using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class ParqueaderoModel
    {
        public int idParqueadero { get; set; }
        [Required(ErrorMessage = "Se requiere un nombre para el parqueadero.")]
        [MaxLength(50, ErrorMessage = "El nombre del parqueadero es muy largo.")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Se requiere una ubicación para el parqueadero.")]
        [MaxLength(50, ErrorMessage = "La ubicación del parqueadero es muy larga.")]
        public string Ubicacion { get; set; }
    }
}