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
using System.Web.Http;

namespace RestApi.Controllers
{
    public class VehiculoController : ApiController
    {
        /// <summary>
        /// Crear un vehículo
        /// </summary>
        /// <param name="VehiculoJson"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] JObject VehiculoJson)
        {
            HttpResponseMessage httpResponse;
            VehiculoModel vehiculoModel = JsonConvert.DeserializeObject<VehiculoModel>(VehiculoJson.ToString());
            Operaciones operaciones = new Operaciones();
            try
            {
                int r = operaciones.CrearVehiculo(vehiculoModel.Marca, vehiculoModel.IdTipo, vehiculoModel.idPersona, vehiculoModel.placa);
                httpResponse = Request.CreateResponse((r < 0) ? HttpStatusCode.Conflict : HttpStatusCode.Created, r);
            }
            catch (Exception ex)
            {
                httpResponse = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpResponse;
        }

        /// <summary>
        /// Obtener un vehículo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage httpResponse;
            Operaciones operaciones = new Operaciones();
            try
            {
                DataTable dataTable = operaciones.ConsultarVehiculo(id);
                List<VehiculoModel> vehiculoModel = dataTable.AsEnumerable().Select(
                    (x) => new VehiculoModel()
                    {
                        IdVehiculo = x.Field<int>("IDVEHICULO"),
                        Marca = x.Field<string>("MARCA"),
                        IdTipo = x.Field<int>("IDTIPO"),
                        idPersona = x.Field<int>("IDPERSONA"),
                        placa = x.Field<string>("PLACA")
                    }).ToList();
                httpResponse = Request.CreateResponse((vehiculoModel[0].IdVehiculo < 0) ? HttpStatusCode.Conflict : HttpStatusCode.Created, vehiculoModel);
            }
            catch (Exception ex)
            {
                httpResponse = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpResponse;
        }

        /// <summary>
        /// Actualizar una persona
        /// </summary>
        /// <param name="personaR1Json"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] JObject personaR1Json)
        {
            HttpResponseMessage httpResponse;
            VehiculoModel vehiculoModel = JsonConvert.DeserializeObject<VehiculoModel>(personaR1Json.ToString());
            Operaciones operaciones = new Operaciones();
            try
            {
                int r = operaciones.ActualizarVehiculo(vehiculoModel.IdVehiculo, vehiculoModel.Marca, vehiculoModel.IdTipo, vehiculoModel.idPersona, vehiculoModel.placa);
                httpResponse = Request.CreateResponse((r < 0) ? HttpStatusCode.Conflict : HttpStatusCode.Created, r);
            }
            catch (Exception ex)
            {
                httpResponse = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpResponse;
        }
    }
}
