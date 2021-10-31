using BussimessTransaccionales;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class TipoDocumentoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                DataTable dataTable = operaciones.TraerTiposDocumentos();
                List<TipoDocumentoModel> tipoDocumentos = dataTable.AsEnumerable().Select(
                    (x) => new TipoDocumentoModel() {
                        ID = x.Field<int>("ID"),
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
