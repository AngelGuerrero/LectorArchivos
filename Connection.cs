using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace LecturaDeArchivos
{
    public class Connection
    {
        public Connection()
        {
            //
            // Initialize with Windows Authentication
            ConnectionString = "WIN";
        }

        #region PROPERTIES

        public bool Connected { get; private set; }

        private string Server { get; set; }

        private string DataBase { get; set; }

        private string User { get; set; }

        private string Password { get; set; }


        private string _connectionString;
        private string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                if (value == "WIN")
                {
                    _connectionString = "Data Source=" + Server + ";Initial Catalog=" + DataBase + "; Integrated Security=true;";
                }
                else if (value == "SQL")
                {
                    _connectionString = "Data Source=" + Server + ";Initial Catalog=" + DataBase + ";User ID=" + User + ";Password=" + Password + ";";
                }
            }
        } 

        #endregion



        public bool TestConnectionnWindowsAuth(string pServer, ref string pMessage, string pDataBase = "master")
        {
            Server = pServer;
            DataBase = pDataBase;
            ConnectionString = "WIN";

            return Connect(ConnectionString, ref pMessage);
        }



        public bool TestConnectionSql(string pServer, string pUser, string pPassword, ref string pMessage, string pNombreBD = "master")
        {
            Server = pServer;
            DataBase = pNombreBD;
            User = pUser;
            Password = pPassword;
            ConnectionString = "SQL";

            return Connect(ConnectionString, ref pMessage);
        }



        public bool LoadScript(string pPath, string pDatabase, string pAuthentication, ref string pMessage)
        {
            DataBase = pDatabase;

            if (pAuthentication.Equals("Windows Authentication"))
            {
                ConnectionString = "WIN";
            }
            else if (pAuthentication.Equals("SQL Server Authentication"))
            {
                ConnectionString = "SQL";
            }

            return LoadScript(pPath, ref pMessage);
        }


        public bool LoadScript(string pPath, ref string pMessage)
        {
            bool retval = true;

            FileInfo file = new FileInfo(pPath);

            string script;
            using (var reader = file.OpenText())
            {
                script = reader.ReadToEnd();
                script = script.Replace("GO", "");
            }


            try
            {
                pMessage = $"--------------- Server: {Server} - Database: {DataBase} --------------- {Environment.NewLine}{Environment.NewLine}";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(script, conn))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    pMessage += $"--- File: '{file}' {Environment.NewLine} Ok. {Environment.NewLine}";
                }
            }
            catch (Exception ex)
            {
                pMessage += $"--- File: '{file}' {Environment.NewLine} Error: '{ex.Message}' {Environment.NewLine}";
                retval = false;

                if (ex.InnerException != null)
                {
                    pMessage += ex.InnerException.Message;
                }
            }

            return retval;
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
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandTimeout = 0;
                    SqlDataReader reader;

                    con.Open();
                    reader = command.ExecuteReader();
                    datatable.Load(reader);

                    reader.Close();
                    con.Close();

                    pMessage = "Databases loaded succesfully.";
                    pError = false;
                }
            }
            catch (Exception e)
            {
                pMessage = $"Error loading databases: {e.Message}";
                Debug.WriteLine(pMessage);
                pError = true;
            }

            return datatable;
        }



        private SqlConnection ConectarSQL()
        {
            ConnectionString = "SQL";

            return new SqlConnection(ConnectionString);
        }



        private SqlConnection ConectarWindowsAuth()
        {
            ConnectionString = "WIN";

            return new SqlConnection(ConnectionString);
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
            Debug.WriteLine("Testing connectivity...");

            try
            {
                using (SqlConnection con = new SqlConnection(pConStr))
                {
                    con.Open();
                    con.Close();
                    pMessage = "Connected to .";
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
