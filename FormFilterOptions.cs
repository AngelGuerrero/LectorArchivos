using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public partial class FormFilterOptions : Form
    {
        public string Options { get; set; } = "";

        public string Filter { get; set; } = "";

        public FormMain formMain;

        public FormFilterOptions()
        {
            InitializeComponent();
        }

        private void FormFilterOptions_Load(object sender, EventArgs e)
        {
            //
            // Inicializa el botón
            radioBtnEquals.Checked = true;

            //
            // Get the instance of FormMain
            formMain = Application.OpenForms.OfType<Form>().First() as FormMain;
        }

        private List<string> ApplyOptions(string pDatabase)
        {
            //
            // Return values
            List<string> retList = new List<string>();


            //
            // Get the stored procedures
            var storedProcedures = Utils.GetStoredProceduresFromCurrentDatabase(formMain.RemoteConnection, pDatabase);

            //
            // It gets the tables using the current connection.
            var tables = Utils.GetTablesFromCurrentDatabase(formMain.RemoteConnection, pDatabase);


            if (Options.Equals("Igual"))
            {
                //
                // Filter stored procedures
                storedProcedures = storedProcedures.Where(sp => sp.ToLower().Equals(Filter.ToLower()))
                                                   .ToList();


                //
                // Filter the tables
                tables = tables.Where(table => table.ToLower().Equals(Filter.ToLower()))
                               .ToList();

            }
            else if (Options.Equals("Contiene"))
            {
                //
                // Filter the stored procedures
                storedProcedures = storedProcedures.Where(sp => sp.ToLower().Contains(Filter.ToLower()))
                                                   .ToList();

                //
                // Filter the tables
                tables = tables.Where(table => table.ToLower().Contains(Filter.ToLower()))
                               .ToList();

            }

            //
            // Merge the list
            List<string> li_1 = new List<string>();
            List<string> li_2 = new List<string>();

            storedProcedures.ForEach(sp => li_1.Add($"Stored Procedure: {sp}"));
            tables.ForEach(t => li_2.Add($"Table: {t}"));

            return li_1.Union(li_2).ToList();
        }

        private void radioBtnEquals_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in this.groupBox.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        Options = radio.Text;
                    }
                }
            }
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text)) return;

            Filter = txtFilter.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //
            // Validations
            if (formMain.SelectedDatabasesList.Count <= 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna base de datos", "Filtrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!formMain.RemoteConnection.Connected)
            {
                MessageBox.Show("No se ha establecido la conexión con el servidor", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //
            // Clear the log
            richTextBoxLog.Text = string.Empty;

            formMain.SelectedDatabasesList.ForEach(selecteddb =>
            {
                string msg = "";

                //
                // Test the connection for each databases selected
                lblStatus.Text = $"Estableciendo conexión con {selecteddb}";
                if (!formMain.RemoteConnection.TestConnectionnWindowsAuth(formMain.RemoteServer.Name, ref msg, selecteddb))
                {
                    lblStatus.Text = msg;
                    MessageBox.Show(msg, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //
                // Write the output in the RichTextBox
                richTextBoxLog.AppendText($"Servidor: {formMain.RemoteServer.Name}, Base de datos: {selecteddb} {Environment.NewLine}");

                var listResult = ApplyOptions(selecteddb);

                if (listResult.Count <= 0)
                {
                    richTextBoxLog.AppendText($"\t- Not found: {Filter}", Color.Red);
                    return;
                }

                listResult.ForEach(result => richTextBoxLog.AppendText($"\t- Found: {result}", Color.Green));
            });
        }

    }
}
