using LecturaDeArchivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public partial class FormMain : Form
    {
        public FormMain() { InitializeComponent(); }



        #region PROPERTIES

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
                    //MessageBox.Show(msg, "Connection message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _showDataBases = chklbxDataBases.Enabled = (!errorResult) ? true : false;
            }
        }


        public List<string> SelectedFiles { get; set; } = new List<string>();


        public List<string> SelectedDatabasesList { get; set; } = new List<string>();

        #endregion



        private string _databasefocused;
        public string DataBaseFocused
        {
            get { return _databasefocused; }
            set
            {
                _databasefocused = value;
                Debug.WriteLine(value);
            }
        }


        private void CheckAllowExecute() => btnAccept.Enabled = ((SelectedFiles.Count >= 1) && (SelectedDatabasesList.Count >= 1)) ? true : false;


        private void OpenFile()
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            DialogResult chooseFile = openFileDialog.ShowDialog();

            if (chooseFile == DialogResult.Cancel)
            {
                CheckAllowExecute();

                return;
            }

            //
            // Agrega los archivos seleccionados para mostrarlos
            chklbxFiles.Items.Clear();
            SelectedFiles.Clear();
            openFileDialog.FileNames.ToList().ForEach(f => chklbxFiles.Items.Add(f, true));

            CheckAllowExecute();
        }


        private void ChangeControls(bool state)
        {
            ShowDataBases = state;

            List<Control> controls = new List<Control>()
            {
                chklbxDataBases,
                txtLog,
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


        public void ChangeSQLAuthenticationControls(bool pEnabled)
        {
            //
            // Controls for SQL Authentication method
            List<Control> sqlAuthMethodControls = new List<Control>()
            {
                lblUser,
                txtUser,
                lblPassword,
                txtPassword
            };

            sqlAuthMethodControls.ForEach(control =>
            {
                if (control is Label)
                {
                    ((Label)control).Enabled = pEnabled;
                }
                else if (control is TextBox)
                {
                    ((TextBox)control).Enabled = pEnabled;
                }
            });
        }



        public void ExecBackgroundWorker(Action<object> pFnWork, Action<object> pCallback, string pResult = "Listo.")
        {
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += (s, e) =>
                {
                    pFnWork.Invoke(e.Argument);

                    e.Result = pResult;
                };

                worker.RunWorkerCompleted += (s, e) =>
                {
                    pCallback.Invoke(e.Result);
                };

                worker.RunWorkerAsync(pFnWork);
            }
        }



        public void SelectAuthenticationMethod()
        {
            //
            // Reset controls for execute the process
            ChangeControls(false);

            //
            // Enable or not, authentication controls method
            bool state = cbxAuthentication.SelectedItem.Equals("Windows Authentication") ? false : true;

            ChangeSQLAuthenticationControls(state);

            Authentication = cbxAuthentication.SelectedItem.ToString();
        }



        private void ConnectToServer()
        {
            Action<object> fn = null;

            //
            // Controls
            toolStripStatusLabel.Text = $"Connecting to server {RemoteServer.Name}...";
            btnConnect.Enabled = false;

            //
            // Select the authentication function method
            string message = "";
            if (Authentication.Equals("Windows Authentication"))
            {
                fn = (arg) => RemoteConnection.TestConnectionnWindowsAuth(RemoteServer.Name, ref message);
            }
            else if (Authentication.Equals("SQL Server Authentication"))
            {
                fn = (arg) => RemoteConnection.TestConnectionSql(RemoteServer.Name, RemoteServer.User, RemoteServer.Password, ref message, RemoteServer.DataBase);
            }

            //
            // Execute the background worker
            ExecBackgroundWorker(fn,
                                (result) =>
                                {
                                    toolStripStatusLabel.Text = (string)result;
                                    btnConnect.Enabled = true;

                                    if (!RemoteConnection.Connected)
                                    {
                                        ShowDataBases = false;
                                        ChangeControls(false);
                                        MessageBox.Show(message, "Error connecting to server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    MessageBox.Show(message, "Connection to server", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //
                                    // If connected, tries load databases
                                    ShowDataBases = true;
                                }
            );
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
            SelectAuthenticationMethod();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();

        private void TxtServer_TextChanged(object sender, EventArgs e)
        {
            RemoteServer.Name = txtServer.Text;
            ChangeControls(false);
        }

        private void CbxAuthentication_SelectedIndexChanged(object sender, EventArgs e) => SelectAuthenticationMethod();

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

        private void BtnConnect_Click(object sender, EventArgs e) => ConnectToServer();

        private void BtnOpenFile_Click(object sender, EventArgs e) => OpenFile();

        private void BtnCancel_Click(object sender, EventArgs e) => this.Close();

        private void chklbxDataBases_Click(object sender, EventArgs e) => DataBaseFocused = chklbxDataBases.GetItemText(chklbxDataBases.SelectedItem).ToString();

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DataBaseFocused)) return;

            FormDataBaseOptions formdatabaseoptions = new FormDataBaseOptions(DataBaseFocused);

            formdatabaseoptions.ShowDialog(this);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;

            SelectedDatabasesList.ForEach(database =>
            {
                string msg = "";

                SelectedFiles.ForEach(file =>
                {
                    if (RemoteConnection.LoadScript(file, database, Authentication, ref msg))
                    {
                        txtLog.AppendText($"{msg}", Color.Green);
                    }
                    else
                    {
                        txtLog.AppendText($"{msg}", Color.Red);
                    }
                });
            });

            MessageBox.Show("All scripts executed", "Process finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            bool openForm = fc.OfType<Form>()
                              .AsEnumerable()
                              .Any(form => form is FormFilterOptions);

            if (openForm)
            {
                fc.OfType<Form>()
                  .First(form => form is FormFilterOptions).Focus();

                return;
            }

            FormFilterOptions formfilteroptions = new FormFilterOptions();
            formfilteroptions.Show();
        }

        private void seleccionarTodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklbxDataBases.Items.Count; i++)
            {
                chklbxDataBases.SetItemChecked(i, true);
            }
        }
    }
}
