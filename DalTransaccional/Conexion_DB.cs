using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SecurityTransaccionales;

namespace BussimessTransaccionales
{
    public class Conexion_DB
    {
        public string Servidor { get; set; }
        public string DB { get; set; }
        public byte[] User { get; set; }
        public byte[] Password { get; set; }
        public string Cadena { get; set; }

        private bool _Estado = false;
        private MySqlCommand _sqlCommand;
        private MySqlConnection _connection;

        private Conexion_DB() { }
        public Conexion_DB(string servidor, string db, byte[] user, byte[] password)
        {
            Servidor = servidor;
            DB = db;
            User = user;
            Password = password;
        }

        public Conexion_DB(string cadena) => Cadena = cadena;

        private bool Conectar()
        {
            string connectionString;
            if (Cadena == null)
            {
                string serv, port, u, p;
                serv = Servidor.Split(':')[0];
                port = Servidor.Split(':')[1];
                using(Seguridad seguridad = new Seguridad())
                {
                    u = seguridad.Decryptando(User);
                    p = seguridad.Decryptando(Password);
                }
                connectionString = "datasource=" + serv + ";port=" + port + ";username=" + u + ";password=" + p + ";database=" + DB + ";";
            }
            else
            {
                connectionString = Cadena;
            }
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            _Estado = true;
            return _Estado;
        }

        private bool Desconectar()
        {
            _connection.Close();
            _Estado = false;
            return _Estado;
        }

        public DataTable Consultar(string nombreSp, MySqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            Conectar();
            _sqlCommand = new MySqlCommand(nombreSp, _connection);
            _sqlCommand.CommandTimeout = 60;
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                _sqlCommand.Parameters.AddRange(parameters);
            MySqlDataReader dr = _sqlCommand.ExecuteReader();
            dt.Load(dr);
            Desconectar();
            return dt;
        }
    }
}
