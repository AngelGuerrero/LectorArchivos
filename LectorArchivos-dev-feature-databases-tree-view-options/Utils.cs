using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    class Utils
    {
        public static List<string> GetTablesFromCurrentDatabase(Connection pConnection, string pDatabaseName)
        {
            string msg = "";
            bool error = false;

            List<string> retList = new List<string>();

            retList = (from table in pConnection.GetTablesFromDatabase(pDatabaseName, ref msg, ref error).AsEnumerable()
                       select table.Field<string>("name")).ToList();

            if (error)
            {
                MessageBox.Show("Error al cargar las tablas", msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retList;
        }



        public static List<string> GetStoredProceduresFromCurrentDatabase(Connection pConnection, string pDatabaseName)
        {
            string msg = "";
            bool error = false;

            List<string> retList = new List<string>();

            //
            // It gets the stored procedures using the current connection.
            retList = (from sp in pConnection.GetStoreProceduresFromDataBase(pDatabaseName, ref msg, ref error).AsEnumerable()
                       select sp.Field<string>("name")).ToList();


            if (error)
            {
                MessageBox.Show("Error al cargar los procedimientos almacenados", msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retList;
        }

    }
}
