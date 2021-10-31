using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    [Serializable]
    public class PersonaModel
    {
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "Se requiere el tipo de documento.")]
        public int tipoDocumento { get; set; }
        [Required(ErrorMessage = "El numero de documento es requerido.")]
        [Range(100000, 2000000000, ErrorMessage ="Debe ser un número entre 100000 y 2000000000.")]
        public int numeroDocumento { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(150, ErrorMessage = "El nombre es muy largo.")]
        public string nombres { get; set; }
        [Required(ErrorMessage = "El apellido es requerido.")]
        [MaxLength(150, ErrorMessage = "El apellido es muy largo.")]
        public string apellidos { get; set; }
        [Required(ErrorMessage = "La dirección es requerida.")]
        [MaxLength(200, ErrorMessage = "La dirección es muy larga.")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "El número de teléfono es requerido.")]
        [Range(1000000, 3600000000, ErrorMessage = "Ingrese un número de teléfono válido.")]
        public long telefono { get; set; }
        [Required(ErrorMessage = "El tipo de persona es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El tipo de persona debe ser una llave mayor que cero.")]
        public int TipoPersona { get; set; }
    }
}