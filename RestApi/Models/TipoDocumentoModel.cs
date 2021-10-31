using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class TipoDocumentoModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Debe tneer una descripción")]
        [MaxLength(50, ErrorMessage = "El largo de la descripción no debe ser mayor a 50 caracteres.")]
        public string Descripcion { get; set; }
    }
}