using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class TipoPersonaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Se requiere una descripción del tipo de persona")]
        [MaxLength(50, ErrorMessage = "La descripción no puede tener más de 50 caracteres.")]
        public string Descripcion { get; set; }
    }
}