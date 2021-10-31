using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BussimessTransaccionales;

namespace RestApi.Models
{
    public class PagoModel
    {
        public int idPago { get; set; }
        [Required(ErrorMessage = "La bahia es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La bahia debe ser un valor positivo.")]
        public int IdBahia { get; set; }
        [Required(ErrorMessage = "El vehículo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El vehículo debe ser un valor positivo.")]
        public int IdVehiculo { get; set; }
        [Required(ErrorMessage = "El tempo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El tiempo debe ser un valor positivo.")]
        public int tiempo { get; set; }
        [Required(ErrorMessage = "El costo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El costo debe ser un valor positivo.")]
        public int costo { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [CurrentDate(ErrorMessage = "LA fecha no puede ser mayor a hoy.")]
        public DateTime Fecha { get; set; }
    }
}