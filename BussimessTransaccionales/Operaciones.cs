using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SecurityTransaccionales;
using System.Data;
using MySql.Data.MySqlClient;

namespace BussimessTransaccionales
{
    public class Operaciones
    {
        private Conexion_DB _conexion_DB;

        /* LEVEL 1 */
        public DataTable TraerParqueaderos() => Consultar("spTraerParqueaderos");
        public DataTable TraerTarifas() => Consultar("spTraerTarifas");
        public DataTable TraerTiposPersonas() => Consultar("spTraerTiposPersonas");
        public DataTable TraerTiposDocumentos() => Consultar("spTraerTiposDocumentos");

        /* LEVEL 2 */
        public DataTable TraerTiposVehiculo() => Consultar("spTraerTipoVehiculo");
        public DataTable TraerBahias() => Consultar("spTraerBahias");

        public DataTable TraerBahiasParqueadero(int id)
        {
            MySqlParameter[] parameters = new MySqlParameter[1]
            {
                new MySqlParameter("idparqueader", MySqlDbType.Int32){ Value = id }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            return Consultar("spTraerBahiasParqueadero", parameters);
        }

        public int CrearPersona(int tipoDocumento, int numeroDocumento, string nombres, string apellidos, int tipoPersona, string direccion = "", long telefono = 0)
        {
            int r = 0;
            MySqlParameter[] parameters = new MySqlParameter[7]
            {
                new MySqlParameter("Inombre", MySqlDbType.VarChar, 150){ Value = nombres },
                new MySqlParameter("Iapellido", MySqlDbType.VarChar, 150){ Value = apellidos },
                new MySqlParameter("Itipodocumento", MySqlDbType.Int32){ Value = tipoDocumento },
                new MySqlParameter("Inumerodocumento", MySqlDbType.Int32){ Value = numeroDocumento },
                new MySqlParameter("Idireccion", MySqlDbType.VarChar, 200){ Value = direccion },
                new MySqlParameter("Itelefono", MySqlDbType.Int64){ Value = telefono },
                new MySqlParameter("Itipopersona", MySqlDbType.Int32){ Value = tipoPersona }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            r = Convert.ToInt32(Consultar("spCrearPersona", parameters).Rows[0].ItemArray[0].ToString());
            return r;
        }

        public int ActualizarPersona(int idPersona, int tipoDocumento, int numeroDocumento, string nombres, string apellidos, int tipoPersona, string direccion, long telefono)
        {
            int r = 0;
            MySqlParameter[] parameters = new MySqlParameter[8]
            {
                new MySqlParameter("Inombre", MySqlDbType.VarChar, 150){ Value = nombres },
                new MySqlParameter("Iapellido", MySqlDbType.VarChar, 150){ Value = apellidos },
                new MySqlParameter("Itipodocumento", MySqlDbType.Int32){ Value = tipoDocumento },
                new MySqlParameter("Inumerodocumento", MySqlDbType.Int32){ Value = numeroDocumento },
                new MySqlParameter("Idireccion", MySqlDbType.VarChar, 200){ Value = direccion },
                new MySqlParameter("Itelefono", MySqlDbType.Int64){ Value = telefono },
                new MySqlParameter("Itipopersona", MySqlDbType.Int32){ Value = tipoPersona },
                new MySqlParameter("Iidpersona", MySqlDbType.Int32){ Value = idPersona }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            r = Convert.ToInt32(Consultar("spActualizarPersona", parameters).Rows[0].ItemArray[0].ToString());
            return r;
        }

        public DataTable ConsultarPersona(int tipoPersona, int tipoDocumento, int numeroDocumento)
        {
            MySqlParameter[] parameters = new MySqlParameter[3]
            {
                new MySqlParameter("ItipoPersona", MySqlDbType.Int32){ Value = tipoPersona },
                new MySqlParameter("ItipoDocumento", MySqlDbType.Int32){ Value = tipoDocumento },
                new MySqlParameter("InumeroDocumento", MySqlDbType.Int32){ Value = numeroDocumento }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            return Consultar("spConsultarPersona", parameters);
        }

        /* LEVEL 4 */
        public DataTable ConsultarVehiculo(string id)
        {
            MySqlParameter[] parameters = new MySqlParameter[1]
            {
                new MySqlParameter("id", MySqlDbType.VarChar, 6){ Value = id }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            return Consultar("spConsultarVehiculo", parameters);
        }

        public int CrearVehiculo(string marca, int idTipo, int idPersona, string placa)
        {
            int r = 0;
            MySqlParameter[] parameters = new MySqlParameter[4]
            {
                new MySqlParameter("Imarca", MySqlDbType.VarChar, 20){ Value = marca },
                new MySqlParameter("IidTipo", MySqlDbType.Int32){ Value = idTipo },
                new MySqlParameter("IidPersona", MySqlDbType.Int32){ Value = idPersona },
                new MySqlParameter("Iplaca", MySqlDbType.VarChar, 6){ Value = placa }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            r = Convert.ToInt32(Consultar("spCrearVehiculo", parameters).Rows[0].ItemArray[0].ToString());
            return r;
        }

        public int ActualizarVehiculo(int idVehiculo, string marca, int idTipo, int idPersona, string placa)
        {
            int r = 0;
            MySqlParameter[] parameters = new MySqlParameter[5]
            {
                new MySqlParameter("IidVehiculo", MySqlDbType.VarChar, 150){ Value = idVehiculo },
                new MySqlParameter("Imarca", MySqlDbType.VarChar, 150){ Value = marca },
                new MySqlParameter("IidTipo", MySqlDbType.Int32){ Value = idTipo },
                new MySqlParameter("Iplaca", MySqlDbType.VarChar, 6){ Value = placa },
                new MySqlParameter("Iidpersona", MySqlDbType.Int32){ Value = idPersona }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            r = Convert.ToInt32(Consultar("spActualizarVehiculo", parameters).Rows[0].ItemArray[0].ToString());
            return r;
        }

        /* LEVEL 5 */
        public DataTable ConsultarPago(int idVehiculo, DateTime fecha)
        {
            MySqlParameter[] parameters = new MySqlParameter[2]
            {
                new MySqlParameter("IidVehiculo", MySqlDbType.VarChar, 150){ Value = idVehiculo },
                new MySqlParameter("Ifecha", MySqlDbType.DateTime){ Value = fecha }
            };
            foreach (MySqlParameter par in parameters)
                par.Direction = ParameterDirection.Input;
            return Consultar("spConsultarPago", parameters);
        }

        private DataTable Consultar(string nombreSp, MySqlParameter[] sqlParameters = null)
        {
            Seguridad seguridad = new Seguridad();
            //_conexion_DB = new Conexion_DB(Properties.Settings.Default.Servidor, Properties.Settings.Default.BD, seguridad.Encryptando(Properties.Settings.Default.Usuario), seguridad.Encryptando(Properties.Settings.Default.Password));
            _conexion_DB = new Conexion_DB(Properties.Settings.Default.Conectar);
            return _conexion_DB.Consultar(nombreSp, sqlParameters);
        }
    }
}
