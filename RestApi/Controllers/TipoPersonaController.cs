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
    public class TipoPersonaController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                DataTable dataTable = operaciones.TraerTiposPersonas();
                List<TipoPersonaModel> tipoDocumentos = dataTable.AsEnumerable().Select(
                    (x) => new TipoPersonaModel()
                    {
                        Id = x.Field<int>("ID"),
                        Descripcion = x.Field<string>("DESCRIPCION")
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
