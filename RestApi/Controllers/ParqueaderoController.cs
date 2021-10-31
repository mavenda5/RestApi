using BussimessTransaccionales;
using Newtonsoft.Json;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class ParqueaderoController : ApiController
    {
        /// <summary>
        /// Obtener el listado de los parqueaderos.
        /// </summary>
        /// <returns>JSON</returns>
        public HttpResponseMessage Get()
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                DataTable dataTable = operaciones.TraerParqueaderos();
                List<ParqueaderoModel> tipoDocumentos = dataTable.AsEnumerable().Select(
                    (x) => new ParqueaderoModel()
                    {
                        idParqueadero = x.Field<int>("IDPARQUEADERO"),
                        nombre = x.Field<string>("NOMBRE"),
                        Ubicacion = x.Field<string>("UBICACION")
                    }).ToList();
                HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, tipoDocumentos);
                return httpResponse;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
