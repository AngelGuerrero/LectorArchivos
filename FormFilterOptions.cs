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

        public FormFilterOptions()
        {
            InitializeComponent();
        }

        private void FormFilterOptions_Load(object sender, EventArgs e)
        {
            //
            // Inicializa el botón
            radioBtnEquals.Checked = true;
        }

        private List<string> ApplyOptions(string pDatabase)
        {
            string msg = "";
            bool error = false;

            //
            // Get the instance of FormMain
            var formMain = Application.OpenForms.OfType<Form>().First() as FormMain;

            List<string> retval = new List<string>();

            var storeProcedures = from sp in formMain.RemoteConnection.GetStoreProceduresFromDataBase(pDatabase, ref msg, ref error).AsEnumerable()
                                  select sp.Field<string>("name");

            if (Options.Equals("Igual"))
            {
                retval = storeProcedures.ToList()
                                        .Where(sp => sp.ToLower().Equals(Filter.ToLower()))
                                        .ToList();
            }
            else if (Options.Equals("Contiene"))
            {
                retval = storeProcedures.Where(sp => sp.ToLower().Contains(Filter.ToLower()))
                                        .ToList();
            }
            else
            {
                retval = storeProcedures.ToList();
            }

            return retval;
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
            // Get the instance of FormMain
            var formMain = Application.OpenForms.OfType<Form>().First() as FormMain;

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

                if (!formMain.RemoteConnection.TestConnectionnWindowsAuth(formMain.RemoteServer.Name, ref msg, selecteddb))
                {
                    MessageBox.Show("No se ha establecido la conexión con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                richTextBoxLog.AppendText($"Servidor: {formMain.RemoteServer.Name}, Base de datos: {selecteddb} {Environment.NewLine}");

                var storeProcedures = ApplyOptions(selecteddb);

                if (storeProcedures.Count <= 0)
                {
                    richTextBoxLog.AppendText($"\t- Not found: {Filter}", Color.Red);
                    return;
                }

                storeProcedures.ForEach(sp => richTextBoxLog.AppendText($"\t- Found: {sp}", Color.Green));
            });
        }

    }
}
