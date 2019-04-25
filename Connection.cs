using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeArchivos
{
    public class Connection
    {
        public Connection()
        {
            //
            // Inicialmente la cadena de conexión de tipo Windows Authentication
            StringConnection = "WIN";
        }

        public bool Connected { get; private set; }

        private string Server { get; set; }

        private string DataBase { get; set; }

        private string User { get; set; }

        private string Password { get; set; }


        private string _stringConnection;
        private string StringConnection
        {
            get { return _stringConnection; }
            set
            {
                if (value == "WIN")
                {
                    _stringConnection = "Data Source=" + Server + ";Initial Catalog=" + DataBase + "; Integrated Security=true;";
                }
                else if (value == "SQL")
                {
                    _stringConnection = "Data Source=" + Server + ";Initial Catalog=" + DataBase + ";User ID=" + User + ";Password=" + Password + ";";
                }
            }
        }


        public bool TestConnectionnWindowsAuth(string pServer, ref string pMessage, string pDataBase = "master")
        {
            Server = pServer;
            DataBase = pDataBase;
            StringConnection = "WIN";

            return Connect(StringConnection, ref pMessage);
        }

        public bool TestConnectionSql(string pServer, string pUser, string pPassword, ref string pMessage, string pNombreBD = "master")
        {
            Server = pServer;
            DataBase = pNombreBD;
            User = pUser;
            Password = pPassword;
            StringConnection = "SQL";

            return Connect(StringConnection, ref pMessage);
        }



        /// <summary>
        /// Obtiene las bases de datos del equipo conectado.
        /// 
        /// Ejecuta un query con la cadena de conexión dada
        /// para obtener las bases de datos de tipo 'U'.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pError"></param>
        /// <returns>Devuelve un conjunto de datos, que representan las 
        ///          bases de datos del equipo.</returns>
        public DataTable GetDataBases(ref string pMessage, ref bool pError)
        {
            DataTable datatable = new DataTable();

            string query = @"SELECT p.[name] AS [user]
                                  , d.[name] AS [database]
	                              , d.create_date
                              FROM master.sys.server_principals p
                                 , master.sys.databases d
                             WHERE 1 = 1
                               AND p.[sid] = d.owner_sid
                               AND p.[type] = 'U'
                                 ;";

            try
            {
                using (SqlConnection con = new SqlConnection(StringConnection))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandTimeout = 0;
                    SqlDataReader reader;

                    con.Open();
                    reader = command.ExecuteReader();
                    datatable.Load(reader);

                    reader.Close();
                    con.Close();

                    pMessage = "Se cargaron correctamente las bases de datos.";
                    pError = false;
                }
            }
            catch (Exception e)
            {
                pMessage = $"Error al obtener las bases de datos: {e.Message}";
                Debug.WriteLine(pMessage);
                pError = true;
            }

            return datatable;
        }



        private SqlConnection ConectarSQL()
        {
            StringConnection = "SQL";

            return new SqlConnection(StringConnection);
        }



        private SqlConnection ConectarWindowsAuth()
        {
            StringConnection = "WIN";

            return new SqlConnection(StringConnection);
        }



        /// <summary>
        /// Realiza sólo la apertura y el cierre de la conexión
        /// </summary>
        /// <param name="pConStr"></param>
        /// <param name="pMessage"></param>
        /// <returns>Devuelve verdadero si la conexión se realizó correctamente,
        ///          de lo contrario ejecuta une excepción y devuelve el error
        /// </returns>
        private bool Connect(string pConStr, ref string pMessage)
        {
            bool retval = false;
            Debug.WriteLine("Probando la conectividad...");

            try
            {
                using (SqlConnection con = new SqlConnection(pConStr))
                {
                    con.Open();
                    con.Close();
                    pMessage = "Conexión realizada exitosamente.";
                    retval = true;
                }
            }
            catch (Exception ex)
            {
                pMessage = $"{ex.Message}";
            }

            Debug.WriteLine(pMessage);

            Connected = retval;

            return retval;
        }

    }
}
