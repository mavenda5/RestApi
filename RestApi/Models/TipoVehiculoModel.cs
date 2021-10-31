using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class TipoVehiculoModel
    {
        public int IdTipo { get; set; }
        [Required(ErrorMessage = "El tipo de tarifa es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "No se puede asociar a una llave de tarifa negativa.")]
        public int IdTarifa { get; set; }
        [Required(ErrorMessage = "La clase del vehículo es obligatoria.")]
        [MaxLength(30, ErrorMessage = "LA clase del vehículo es demasiado larga.")]
        public string Clase { get; set; }
    }
}