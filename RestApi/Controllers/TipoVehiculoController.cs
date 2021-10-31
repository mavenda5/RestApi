using BussimessTransaccionales;
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
    public class TipoVehiculoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                DataTable dataTable = operaciones.TraerTiposVehiculo();
                List<TipoVehiculoModel> tipoDocumentos = dataTable.AsEnumerable().Select(
                    (x) => new TipoVehiculoModel()
                    {
                        IdTipo = x.Field<int>("IDTIPO"),
                        IdTarifa = x.Field<int>("IDTARIFA"),
                        Clase = x.Field<string>("CLASE")
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
