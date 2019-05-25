using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

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

            string script = "";

            if (!file.Exists)
            {
                pMessage = $"File not found: {file}";
                return false;
            }

            using (var reader = file.OpenText())
            {
                script = reader.ReadToEnd();
            }


            try
            {
                pMessage = $"--------------- Server: {Server} - Database: {DataBase} --------------- {Environment.NewLine}{Environment.NewLine}";

                ExecuteNonQueryBatch(ConnectionString, script);
                pMessage += $"--- File: '{file}' {Environment.NewLine} Ok. {Environment.NewLine}";
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



        public void ExecuteNonQueryBatch(string connectionString, string sqlStatements)
        {
            if (sqlStatements == null) throw new ArgumentNullException("sqlStatements");
            if (sqlStatements == null) throw new ArgumentNullException("connectionString");


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Regex r = new Regex(@"^(\s|\t)*go(\s\t)?.*", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                foreach (string s in r.Split(sqlStatements))
                {
                    // Skip empty statements, in case of a GO and trailing blanks or something
                    string thisStatement = s.Trim();
                    if (String.IsNullOrEmpty(thisStatement)) continue;

                    using (SqlCommand cmd = new SqlCommand(thisStatement, connection))
                    {
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
        }



        public DataTable GetUsers(ref string pMessage, ref bool pError)
        {
            DataTable table = new DataTable();

            string query = $@"SELECT USUCOD,
	                                 IdLocalidad										AS USULOC,
	                                 CASE WHEN	USUPERFIL = 'TODO'		THEN	1
			                              WHEN	USUPERFIL = 'PLANTA'	THEN	2
			                              WHEN	USUPERFIL = 'CEDIS'		THEN	3
			                              WHEN	USUPERFIL = 'TREINTA'	THEN	4
			                              ELSE	5
	                                 END												AS USUPERID,
	                                 USUNOMBRE
                                   , USUEST
                                   , USUCRE
                                   , USUFECCRE
                                   , USUMOD
                                   , USUFECMOD
                                   , ''                                                 AS USUPASSWORD
                                FROM			segUSUARIO
                               CROSS JOIN		confSistema
                                    ";

            return ExecuteQuery(query, ref pMessage, ref pError);
        }



        /// <summary>
        /// This method gets the databases from the connected server.
        /// 
        /// Executes a query using the curreny connection string
        /// it gets the 'U' type databases.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pError"></param>
        /// <returns>Devuelve un conjunto de datos, que representan las 
        ///          bases de datos del equipo.</returns>
        public DataTable GetDataBases(ref string pMessage, ref bool pError)
        {
            DataTable datatable = new DataTable();

            string query = @"SELECT [name] AS [database]
                               FROM sys.databases d
                              WHERE d.database_id > 4;
                            ";

            return ExecuteQuery(query, ref pMessage, ref pError);
        }



        public DataTable GetTablesFromDatabase(string pDatabase, ref string pMessage, ref bool pError)
        {
            string query = $@"SELECT TABLE_NAME AS [name]
                                FROM [{pDatabase}].INFORMATION_SCHEMA.TABLES 
                               WHERE 1 = 1
                                 AND TABLE_TYPE = 'BASE TABLE'
                                 AND NOT (TABLE_NAME IN ('sysdiagrams'))
                                   ;
                              ";

            return ExecuteQuery(query, ref pMessage, ref pError);
        }



        public DataTable GetStoreProceduresFromDataBase(string pDatabase, ref string pMessage, ref bool pError)
        {
            string query = $@"SELECT specific_name AS [name]
                               FROM {pDatabase}.INFORMATION_SCHEMA.ROUTINES
                              WHERE 1 = 1
                                AND routine_type = 'PROCEDURE'
                                AND LEFT(routine_name, 3) NOT IN ('sp_', 'xp_', 'ms_')";


            return ExecuteQuery(query, ref pMessage, ref pError);
        }



        private DataTable ExecuteQuery(string pQuery, ref string pMessage, ref bool pError)
        {
            DataTable datatable = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(pQuery, con))
                {
                    command.CommandTimeout = 0;
                    SqlDataReader reader;

                    con.Open();
                    reader = command.ExecuteReader();
                    datatable.Load(reader);

                    reader.Close();
                    con.Close();

                    pMessage = "Query executed successfully!";
                    pError = false;
                }
            }
            catch (Exception ex)
            {
                pMessage = ex.Message;
                pError = true;

                if (ex.InnerException != null)
                {
                    pMessage += ex.InnerException.Message;
                }
            }

            return datatable;
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
                    pMessage = $"Connected to server {Server} successfully.";
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
