using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class VehiculoModel
    {
        public int IdVehiculo { get; set; }
        [Required(ErrorMessage = "La marca del vehículo es obligatoria.")]
        [MaxLength(20, ErrorMessage = "La marca del vehículo es demasiado larga.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El tipo de vehículo es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "El id del tipo de vehículo no puede ser negativo.")]
        public int IdTipo { get; set; }
        [Required(ErrorMessage = "El id de la persona asociada al vehículo es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "El id de la persona asociada no puede ser negativo.")]
        public int idPersona { get; set; }
        [Required(ErrorMessage = "La placa del vehículo es obligatoria.")]
        [MaxLength(6, ErrorMessage = "La placa debe de ser de 6 caracteres.")]
        [MinLength(6, ErrorMessage = "La placa debe de ser de 6 caracteres.")]
        public string placa { get; set; }
    }
}