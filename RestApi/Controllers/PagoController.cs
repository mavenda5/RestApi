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
    public class PagoController : ApiController
    {
        [Route("api/Pago/{idVehiculo}/{fecha}")]
        public HttpResponseMessage Get(int idVehiculo, DateTime fecha)
        {
            HttpResponseMessage httpResponse;
            Operaciones operaciones = new Operaciones();
            try
            {
                DataTable dataTable = operaciones.ConsultarPago(idVehiculo, fecha);
                List<PagoModel> vehiculoModel = dataTable.AsEnumerable().Select(
                    (x) => new PagoModel()
                    {
                        idPago = x.Field<int>("IDPAGO"),
                        IdBahia = x.Field<int>("IDBAHIA"),
                        IdVehiculo = x.Field<int>("IDVEHICULO"),
                        tiempo = x.Field<int>("TIEMPO"),
                        costo = x.Field<int>("COSTO"),
                        Fecha = x.Field<DateTime>("FECHA")
                    }).ToList();
                httpResponse = Request.CreateResponse((vehiculoModel.Count == 0) ? HttpStatusCode.Conflict : HttpStatusCode.Created, vehiculoModel);
            }
            catch (Exception ex)
            {
                httpResponse = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpResponse;
        }
    }
}
