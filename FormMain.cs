using LecturaDeArchivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public partial class FormMain : Form
    {
        public FormMain() { InitializeComponent(); }





        #region Properties

        public Server CurrentServer { get; set; }


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


        public List<string> SelectedFiles { get; set; } = new List<string>();


        public List<string> SelectedDatabasesList { get; set; } = new List<string>();

        public List<Server> listaServidores { get; private set; } = new List<Server>();

        public string path { get; } = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\INSERTS\\{DateTime.Now.ToString("yyyyMMdd_hhmmss")}_Localidades";

        #endregion





        #region Module: UI

        private void CheckAllowExecute() => btnAccept.Enabled = ((SelectedFiles.Count >= 1) && (SelectedDatabasesList.Count >= 1)) ? true : false;


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


        private void OpenFormSearcher()
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

        #endregion





        #region Module: Load Documents

        private DialogResult OpenFile(string pExt, string pFileName, string pFilter)
        {

            openFileDialog.DefaultExt = pExt;
            openFileDialog.FileName = pFileName;
            openFileDialog.Filter = pFilter;

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            DialogResult chooseFile = openFileDialog.ShowDialog();

            return chooseFile;
        }


        private void LoadStoreProcedureInMemory()
        {
            string DefaultExt = "sql";
            string FileName = "StoreProcedure";
            string Filter = "Sql files(*.sql)| *.sql";
            openFileDialog.Multiselect = true;

            if (OpenFile(DefaultExt, FileName, Filter) == DialogResult.Cancel)
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


        private void LoadServersListInMemory()
        {
            if (multiplesServidoresToolStripMenuItem.Checked)
            {
                listaServidores.Clear();
                multiplesServidoresToolStripMenuItem.Text = "Cargar lista de localidades y sus servidores";
                multiplesServidoresToolStripMenuItem.Checked = false;
                MessageBox.Show("Se borró la lista de servidores correctamente", "Lista de servidores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string DefaultExt = "csv";
            string FileName = "Servidores";
            string Filter = "CSV files(*.csv)| *.csv";
            openFileDialog.Multiselect = false;

            if (OpenFile(DefaultExt, FileName, Filter) == DialogResult.Cancel) return;

            MessageBox.Show("Se cargó el archivo correctamente", "Lista de servidores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                //
                // Read the CSV
                using (var reader = new StreamReader(File.OpenRead(openFileDialog.FileName)))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Split(',').ToArray();

                        listaServidores.Add(new Server() { IdLocalidad = line[0], Localidad = line[1], Name = line[2], DataBase = line[3] });
                    }
                }

                multiplesServidoresToolStripMenuItem.Checked = true;
                multiplesServidoresToolStripMenuItem.Text = "Lista de servidores cargada";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error leyendo el archivo de servidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion





        #region Module: Execute Documents in Memory

        public void ExecuteStoreProceduresLoaded()
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

                    Log.Escribir("EJECUCIÓN DE SCRIPT", "Ejecución de scrpit (archivo)", CurrentServer.Name, CurrentServer.DataBase, msg);
                });
            });

            MessageBox.Show("All scripts executed", "Process finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void GetUsersFromServerListLoaded()
        {
            DataTable table = new DataTable();

            listaServidores.ForEach(server =>
            {
                string msg = "";
                bool error = false;

                var conn = new Connection();

                if (conn.TestConnectionnWindowsAuth(server.Name, ref msg, server.DataBase))
                {
                    var result = conn.GetUsers(ref msg, ref error);

                    if (!error)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder = CreateUserInserts(result, server.Name, server.DataBase);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        File.WriteAllText($"{path}/{server.IdLocalidad}-{server.Name}-{server.DataBase}-INSERTS.sql", stringBuilder.ToString());

                        //
                        // Merge the results in one table
                        table.Merge(result);
                    }
                }
                Debug.WriteLine($"Localidad: {server.IdLocalidad}, Resultado: {msg}");
                Log.Escribir($"Consulta información localidad: {server.IdLocalidad}", "Consulta de usuarios", server.Name, server.DataBase, msg);
            });

            //
            // Inserts of all locations
            StringBuilder builder = new StringBuilder();

            builder = CreateUserInserts(table, "Insert general", "Insert general");

            File.WriteAllText($"{path}/USUARIOS_TOTAL-INSERTS.sql", builder.ToString());
        }


        public StringBuilder CreateUserInserts(DataTable pTable, string pServer, string pDatabase)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                (from data in pTable.AsEnumerable()
                 select new
                 {
                     USUCOD = data.Field<string>("USUCOD"),
                     USULOC = data.Field<string>("USULOC"),
                     USUPERID = data.Field<int>("USUPERID"),
                     USUNOMBRE = data.Field<string>("USUNOMBRE"),
                     USUEST = data.Field<bool>("USUEST").ToString().ToLower().Equals("true") ? 1 : 0,
                     USUCRE = data.Field<string>("USUCRE"),
                     USUFECCRE = data.Field<DateTime>("USUFECCRE").ToString("yyyy-MM-dd HH':'mm':'ss"),
                     USUMOD = data.Field<string>("USUMOD"),
                     USUFECMOD = data.Field<DateTime>("USUFECMOD").ToString("yyyy-MM-dd HH':'mm':'ss"),
                     USUPASSWORD = data.Field<string>("USUPASSWORD")
                 })
                 .ToList()
                 .ForEach(user =>
                 {
                     string current = $"INSERT INTO [dbo].[catUsuario] VALUES ('{user.USUCOD}','{user.USULOC}',{user.USUPERID},'{user.USUNOMBRE}',{user.USUEST},'{user.USUCRE}','{user.USUFECCRE}','{user.USUMOD}','{user.USUFECMOD}','{user.USUPASSWORD}'){Environment.NewLine}{Environment.NewLine}";
                     Debug.WriteLine(current);
                     stringBuilder.Append(current);
                 });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error al generar un insert para los usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Escribir("Generar inserts de usuarios", "Consulta y obtencion de datos anónimos", pServer, pDatabase, exception.Message);
            }

            return stringBuilder;
        }

        #endregion





        #region Module: Authentication methods

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


        private void ConnectToServer()
        {
            Action<object> fn = null;

            //
            // Controls
            toolStripStatusLabel.Text = $"Connecting to server {CurrentServer.Name}...";
            btnConnect.Enabled = false;

            //
            // Select the authentication function method
            string message = "";
            if (Authentication.Equals("Windows Authentication"))
            {
                fn = (arg) => RemoteConnection.TestConnectionnWindowsAuth(CurrentServer.Name, ref message);
            }
            else if (Authentication.Equals("SQL Server Authentication"))
            {
                fn = (arg) => RemoteConnection.TestConnectionSql(CurrentServer.Name, CurrentServer.User, CurrentServer.Password, ref message, CurrentServer.DataBase);
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

        #endregion





        #region Helpers: Backgrounds Workers

        public void ExecBackgroundWorker(Action<object> pFnWork, Action<object> pCallback, string pResult = "Listo.")
        {
            toolStripStatusLabel.ForeColor = Color.Red;
            toolStripProgressBar.Visible = true;

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

                    toolStripStatusLabel.ForeColor = Color.Black;
                    toolStripStatusLabel.Text = pResult;
                    toolStripProgressBar.Visible = false;
                };

                worker.RunWorkerAsync(pFnWork);
            }
        }

        #endregion





        #region ToolStripMenu Section: Ver

        private void ViewLog()
        {
            string path = $@"{Log.Destino}\\{Log.NombreArchivo}";

            if (!File.Exists(path))
            {
                MessageBox.Show("El archivo log no existe", "Error al cargar el log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            // Allowed Menus
            List<Dictionary<string, Action>> controlList = new List<Dictionary<string, Action>>()
            {
                new Dictionary<string, Action>() { { "archivoToolStripMenuItem", null } },
                new Dictionary<string, Action>() { { "limpiarLogToolStripMenuItem", () => { DeleteLogFile(path); CloseFormLog(); } } },
                new Dictionary<string, Action>() { { "salirToolStripMenuItem", () => CloseFormLog() } }
            };

            //
            // Creates a FormLog instance for load the log file content
            OpenFormLog(File.ReadAllText(path), controlList, "Log de la aplicación");
        }


        public void DeleteLogFile(string pPath)
        {
            if (File.Exists(pPath))
            {
                File.Delete(pPath);
                MessageBox.Show("Log eliminado correctamente", "Eliminación de archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void OpenFormLog(string pTxt, List<Dictionary<string, Action>> pControls, string pTitle = "Información")
        {
            //
            // Crea una instancia de un formulario para ver los logs
            FrmLog frmLog = new FrmLog();
            frmLog.Title = pTitle;
            frmLog.BodyText = pTxt;

            frmLog.FiltrarItems(pControls);

            //
            // Muestra la ventana en forma de diálogo
            frmLog.ShowDialog(this);
        }


        private void CloseFormLog() => Application.OpenForms.OfType<FrmLog>().FirstOrDefault().Close();

        #endregion





        private void FormMain_Load(object sender, EventArgs e)
        {
            //
            // Crea una instancia de un servidor
            CurrentServer = new Server();
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

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.KeyData);

            ///
            /// Combinación: Control+Shift+U
            /// 
            ///     Inicia a generar los inserts para los usuarios de las localidades del archivo cargado
            if ((e.Control && e.Shift && (e.KeyCode == Keys.U)))
            {
                if (listaServidores.Count <= 0)
                {
                    MessageBox.Show("No se ha cargado la lista de localidades", "Error al obtener los inserts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                toolStripStatusLabel.Text = "Generando scripts de las localidades para los usuarios...";

                ExecBackgroundWorker(
                (arg) =>
                {
                    GetUsersFromServerListLoaded();
                }
                , (arg) => MessageBox.Show("Proceso terminado", "Generación de inserts", MessageBoxButtons.OK, MessageBoxIcon.Information)
                , "Listo."
                );

            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => LoadStoreProcedureInMemory();

        private void TxtServer_TextChanged(object sender, EventArgs e)
        {
            CurrentServer.Name = txtServer.Text;
            ChangeControls(false);
        }

        private void CbxAuthentication_SelectedIndexChanged(object sender, EventArgs e) => SelectAuthenticationMethod();

        private void TxtUser_TextChanged(object sender, EventArgs e) => CurrentServer.User = txtUser.Text;

        private void TxtPassword_TextChanged(object sender, EventArgs e) => CurrentServer.Password = txtPassword.Text;

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

        private void BtnOpenFile_Click(object sender, EventArgs e) => LoadStoreProcedureInMemory();

        private void BtnCancel_Click(object sender, EventArgs e) => this.Close();

        private void chklbxDataBases_Click(object sender, EventArgs e) => DataBaseFocused = chklbxDataBases.GetItemText(chklbxDataBases.SelectedItem).ToString();

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DataBaseFocused)) return;

            FormDataBaseOptions formdatabaseoptions = new FormDataBaseOptions(DataBaseFocused);

            formdatabaseoptions.ShowDialog(this);
        }

        private void btnAccept_Click(object sender, EventArgs e) => ExecuteStoreProceduresLoaded();

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e) => OpenFormSearcher();

        private void seleccionarTodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklbxDataBases.Items.Count; i++)
            {
                chklbxDataBases.SetItemChecked(i, true);
            }
        }

        private void multiplesServidoresToolStripMenuItem_Click(object sender, EventArgs e) => LoadServersListInMemory();

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void archivoLogDelProgramaToolStripMenuItem_Click(object sender, EventArgs e) => ViewLog();

        private void abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("explorer.exe", path);
    }
}
