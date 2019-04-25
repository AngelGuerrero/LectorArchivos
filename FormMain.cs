using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public partial class FormMain : Form
    {
        public Server RemoteServer { get; set; }



        public Connection RemoteConnection { get; set; }



        public string Authentication { get; set; }


        private bool _showDataBases;
        public bool ShowDataBases
        {
            get => _showDataBases;
            set
            {
                _showDataBases = chklbxDataBases.Enabled = value;

                chklbxDataBases.Items.Clear();

                string msg = "";
                bool error = false;

                if (value)
                {
                    (from database in RemoteConnection.GetDataBases(ref msg, ref error).AsEnumerable()
                     select database.Field<string>("database")).ToList()
                                                               .ForEach(item => chklbxDataBases.Items.Add(item));

                    toolStripStatusLabel.Text = msg;
                }
            }
        }



        public FormMain() => InitializeComponent();


        public string OpenFile()
        {
            string retval = "";

            //txtVisualizer.Text = string.Empty;

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //openFileDialog.Filter = pFilter;
            DialogResult chooseFile = openFileDialog.ShowDialog();

            if (chooseFile == DialogResult.Cancel) return retval;

            retval = openFileDialog.FileName;

            return retval;
        }




        private void FormMain_Load(object sender, EventArgs e)
        {
            //
            // Crea una instancia de un servidor
            RemoteServer = new Server();
            //
            // Clase para probar la conexión al servidor
            RemoteConnection = new Connection();
            //
            // Selecciona el método de autenticación por defecto
            cbxAuthentication.SelectedIndex = 0;
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();

        private void TxtServer_TextChanged(object sender, EventArgs e) => RemoteServer.Name = txtServer.Text;


        private void CbxAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            // Habilita o no los controles para autenticación por medio de Sql Server
            tblLayPanelAuthentication.Enabled = cbxAuthentication.SelectedItem.Equals("Windows Authentication") ? false : true;

            Authentication = cbxAuthentication.SelectedItem.ToString();
        }

        private void TxtUser_TextChanged(object sender, EventArgs e) => RemoteServer.User = txtUser.Text;

        private void TxtPassword_TextChanged(object sender, EventArgs e) => RemoteServer.Password = txtPassword.Text;

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Conectando...";

            string message = "";

            if (Authentication.Equals("Windows Authentication"))
            {
                RemoteConnection.TestConnectionnWindowsAuth(RemoteServer.Name, ref message);
            }
            else if (Authentication.Equals("SQL Server Authentication"))
            {
                RemoteConnection.TestConnectionSql(RemoteServer.Name, RemoteServer.User, RemoteServer.Password, ref message, RemoteServer.DataBase);
            }

            if (!RemoteConnection.Connected)
            {
                ShowDataBases = false;
                toolStripStatusLabel.Text = message;
                return;
            }

            //
            // Si la conexión se realizó, trata de cargar las bases de datos
            ShowDataBases = true;
        }

        private void BtnOpenFile_Click(object sender, EventArgs e) => OpenFile();

        private void BtnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
