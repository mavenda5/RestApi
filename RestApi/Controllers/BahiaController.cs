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
    public class BahiaController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                DataTable dataTable = operaciones.TraerBahias();
                List<BahiaModel> tipoDocumentos = dataTable.AsEnumerable().Select(
                    (x) => new BahiaModel()
                    {
                        IdBahia = x.Field<int>("IDBAHIA"),
                        IdParqueadero = x.Field<int>("IDPARQUEADERO"),
                        Dispobinle = Convert.ToBoolean(x.Field<Int16>("DISPONIBLE"))
                    }).ToList();
                HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, tipoDocumentos);
                return httpResponse;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                DataTable dataTable = operaciones.TraerBahiasParqueadero(id);
                List<BahiaModel> tipoDocumentos = dataTable.AsEnumerable().Select(
                    (x) => new BahiaModel()
                    {
                        IdBahia = x.Field<int>("IDBAHIA"),
                        IdParqueadero = x.Field<int>("IDPARQUEADERO"),
                        Dispobinle = Convert.ToBoolean(x.Field<Int16>("DISPONIBLE"))
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
