using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BussimessTransaccionales;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Data;

namespace RestApi.Controllers
{
    public class PersonaController : ApiController
    {
        /// <summary>
        /// Crear una persona
        /// </summary>
        /// <param name="personaR1Json"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] JObject personaR1Json)
        {
            HttpResponseMessage httpResponse;
            PersonaModel personaR1Model = JsonConvert.DeserializeObject<PersonaModel>(personaR1Json.ToString());
            Operaciones operaciones = new Operaciones();
            try
            {
                int r = operaciones.CrearPersona(personaR1Model.tipoDocumento, personaR1Model.numeroDocumento, personaR1Model.nombres, personaR1Model.apellidos, personaR1Model.TipoPersona, personaR1Model.direccion, personaR1Model.telefono);
                httpResponse = Request.CreateResponse((r < 0) ? HttpStatusCode.Conflict : HttpStatusCode.Created, r);
            }
            catch (Exception ex)
            {
                httpResponse = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpResponse;
        }

        /// <summary>
        /// Obtener una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Persona/{tipoPersona}/{tipoDocumento}/{numeroDocumento}/")]
        public HttpResponseMessage Get(int tipoPersona, int tipoDocumento, int numeroDocumento)
        {
            HttpResponseMessage httpResponse;
            Operaciones operaciones = new Operaciones();
            try
            {
                DataTable dataTable = operaciones.ConsultarPersona(tipoPersona, tipoDocumento, numeroDocumento);
                List<PersonaModel> personaR1Model;
                if (dataTable.Rows.Count == 0)
                {
                    personaR1Model = new List<PersonaModel>()
                    {
                        new PersonaModel()
                        {
                            IdPersona = -1
                        }
                    };
                }
                else
                {
                    personaR1Model = dataTable.AsEnumerable().Select(
                        (x) => new PersonaModel()
                        {
                            IdPersona = x.Field<int>("IDPERSONA"),
                            nombres = x.Field<string>("NOMBRE"),
                            apellidos = x.Field<string>("APELLIDO"),
                            tipoDocumento = x.Field<int>("TIPODOCUMENTO"),
                            numeroDocumento = x.Field<int>("NUMERODOCUMENTO"),
                            direccion = x.Field<string>("DIRECCION"),
                            telefono = Convert.ToInt64(x.Field<string>("TELEFONO") ?? "0"),
                            TipoPersona = x.Field<int>("TIPOPERSONA")
                        }).ToList();
                }
                httpResponse = Request.CreateResponse((personaR1Model[0].IdPersona < 0) ? HttpStatusCode.Conflict : HttpStatusCode.Created, personaR1Model);
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
            PersonaModel personaR1Model = JsonConvert.DeserializeObject<PersonaModel>(personaR1Json.ToString());
            Operaciones operaciones = new Operaciones();
            try
            {
                int r = operaciones.ActualizarPersona(personaR1Model.IdPersona, personaR1Model.tipoDocumento, personaR1Model.numeroDocumento, personaR1Model.nombres, personaR1Model.apellidos, personaR1Model.TipoPersona, personaR1Model.direccion, personaR1Model.telefono);
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