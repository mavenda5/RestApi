using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class BahiaModel
    {
        public int IdBahia { get; set; }
        [Required(ErrorMessage = "El parqueadero es obligatorio.")]
        public int IdParqueadero { get; set; }
        [Required(ErrorMessage = "La disponibilidad es obligatoria.")]
        public bool Dispobinle { get; set; }
    }
}