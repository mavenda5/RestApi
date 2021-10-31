using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class TarifaModel
    {
        public int IdTarifa { get; set; }
        [Required(ErrorMessage = "El costo de la tarifa es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "La tarifa debe ser un valor mayor que cero.")]
        public int Costo { get; set; }
    }
}