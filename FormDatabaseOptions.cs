using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public partial class FormDatabaseOptions : Form
    {
        public Connection RemoteConnection { get; set; }

        public string ServerName { get; set; }

        public string DataBaseName { get; set; }

        public List<string> ListStoreProcedures { get; set; } = new List<string>();

        public FormDatabaseOptions()
        {
            InitializeComponent();
        }


        public FormDatabaseOptions(string pServerName, string pDataBaseName)
        {
            InitializeComponent();

            //
            // Server
            ServerName = pServerName;
            //
            // Database
            DataBaseName = pDataBaseName;
            //
            // Title of form
            lblTitle.Text += DataBaseName;
            //
            // Init the instance for remote connection
            RemoteConnection = new Connection();
        }

        private void FilterStoreProcedures()
        {
            //
            // Clear the list
            listView_Procs.Items.Clear();

            if (string.IsNullOrEmpty(txtProcName.Text))
            {
                ShowOriginalListStoreProcedures();
                return;
            }

            string sp = txtProcName.Text;

            bool any = ListStoreProcedures.Any(item => item.ToLower().Contains(sp.ToLower()));

            if (any)
            {
                ListStoreProcedures.Where(item => item.ToLower().Contains(sp.ToLower()))
                                   .ToList()
                                   .ForEach(item => listView_Procs.Items.Add(item));
            }
            else
            {
                listView_Procs.Items.Clear();
            }
        }

        private void ShowOriginalListStoreProcedures()
        {
            //
            // Clear the list
            listView_Procs.Items.Clear();
            //
            // Original list
            ListStoreProcedures.ForEach(item => listView_Procs.Items.Add(item));
        }

        private void txtProcName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                FilterStoreProcedures();
            }

            if ((e.Shift && e.KeyCode == Keys.Enter))
            {
                ShowOriginalListStoreProcedures();
            }
        }

        private void tabPage_Procs_Enter(object sender, EventArgs e)
        {
            string msg = "";
            bool error = false;
            if (!RemoteConnection.TestConnectionnWindowsAuth(ServerName, ref msg, DataBaseName))
            {
                MessageBox.Show(msg, "Conexión a la base de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(msg, "Conexión a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var storeProcedures = (from sp in RemoteConnection.GetStoreProcedures(ref msg, ref error).AsEnumerable()
                                   select sp.Field<string>("name")).ToList();

            storeProcedures.AsEnumerable()
                           .ToList()
                           .ForEach(sp => listView_Procs.Items.Add(sp));

            ListStoreProcedures.AddRange(storeProcedures);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
