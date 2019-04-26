using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            get { return _showDataBases; }
            set
            {
                chklbxDataBases.Items.Clear();
                SelectedDatabasesList.Clear();

                string msg = "";
                bool errorResult = false;

                if (value)
                {
                    (from database in RemoteConnection.GetDataBases(ref msg, ref errorResult).AsEnumerable()
                     select database.Field<string>("database")).ToList()
                                                               .ForEach(item => chklbxDataBases.Items.Add(item));

                    toolStripStatusLabel.Text = msg;
                    MessageBox.Show(msg, "Mensaje de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _showDataBases = chklbxDataBases.Enabled = (!errorResult) ? true : false;
            }
        }



        public List<string> SelectedFiles { get; set; } = new List<string>();


        public List<string> SelectedDatabasesList { get; set; } = new List<string>();


        public FormMain() { InitializeComponent(); }


        private void CheckAllowExecute() => btnAccept.Enabled = ((SelectedFiles.Count >= 1) && (SelectedDatabasesList.Count >= 1)) ? true : false;

        public void OpenFile()
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            DialogResult chooseFile = openFileDialog.ShowDialog();

            if (chooseFile == DialogResult.Cancel)
            {
                SelectedFiles.Clear();

                CheckAllowExecute();

                return;
            }

            //
            // Agrega los archivos seleccionados para mostrarlos
            chklbxFiles.Items.Clear();
            openFileDialog.FileNames.ToList().ForEach(f => chklbxFiles.Items.Add(f, true));

            CheckAllowExecute();
        }

        public void ChangeControls(bool state)
        {
            ShowDataBases = state;

            List<Control> controls = new List<Control>()
            {
                chklbxDataBases,
                txtLog,
                //lblSelectedFile,
                btnAccept
            };

            controls.ForEach(c =>
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
                else if (c is Button)
                {
                    ((Button)c).Enabled = state;
                }
                else if (c is Label)
                {
                    ((Label)c).Text = string.Empty;
                }
            });
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
            // Asigna el nombre de la máquina al nombre del servidor
            txtServer.Text = Environment.MachineName;
            //
            // Selecciona el método de autenticación por defecto
            cbxAuthentication.SelectedIndex = 0;
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();

        private void TxtServer_TextChanged(object sender, EventArgs e)
        {
            RemoteServer.Name = txtServer.Text;
            ChangeControls(false);
        }

        private void CbxAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            // Reinicia los controles para ejecutar el procedimiento
            ChangeControls(false);
            //
            // Habilita o no los controles para autenticación por medio de Sql Server
            tblLayPanelAuthentication.Enabled = cbxAuthentication.SelectedItem.Equals("Windows Authentication") ? false : true;

            Authentication = cbxAuthentication.SelectedItem.ToString();
        }

        private void TxtUser_TextChanged(object sender, EventArgs e) => RemoteServer.User = txtUser.Text;

        private void TxtPassword_TextChanged(object sender, EventArgs e) => RemoteServer.Password = txtPassword.Text;

        private void chklbxDataBases_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!chklbxDataBases.GetItemChecked(e.Index))
            {
                SelectedDatabasesList.Add(chklbxDataBases.Items[e.Index].ToString());
            }
            else
            {
                SelectedDatabasesList.Remove(chklbxDataBases.Items[e.Index].ToString());
            }

            CheckAllowExecute();
        }

        private void chklbxFiles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!chklbxFiles.GetItemChecked(e.Index))
            {
                SelectedFiles.Add(chklbxFiles.Items[e.Index].ToString());
                Debug.WriteLine($"Se agregó un archivo a la lista: {chklbxFiles.Items[e.Index].ToString()}");
            }
            else
            {
                SelectedFiles.Remove(chklbxFiles.Items[e.Index].ToString());
            }

            CheckAllowExecute();
        }

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
                ChangeControls(false);
                toolStripStatusLabel.Text = message;
                return;
            }

            //
            // Si la conexión se realizó, trata de cargar las bases de datos
            ShowDataBases = true;
        }

        private void BtnOpenFile_Click(object sender, EventArgs e) => OpenFile();

        private void BtnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnAccept_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;

            //
            // Recorre las bases de datos seleccionadas
            SelectedDatabasesList.ForEach(database =>
            {
                string msg = "";

                //
                // Recorre los archivos seleccionados
                SelectedFiles.ForEach(file =>
                {
                    if (RemoteConnection.CargarScript(file, database, Authentication, ref msg))
                    {
                        txtLog.AppendText($"{msg}", Color.Green);
                    }
                    else
                    {
                        txtLog.AppendText($"{msg}", Color.Red);
                    }
                });
            });
        }
    }
}
