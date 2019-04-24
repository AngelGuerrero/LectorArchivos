using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public FormMain()
        {
            InitializeComponent();
        }


        public string OpenFile(string pFilter)
        {
            string retval = "";

            //txtVisualizer.Text = string.Empty;

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog.Filter = pFilter;
            DialogResult chooseFile = openFileDialog.ShowDialog();

            if (chooseFile == DialogResult.Cancel) return retval;

            retval = openFileDialog.FileName;

            return retval;
        }



        public void WriteTextPrev()
        {
            string filter = "Text files(*.txt)| *.txt| All files(*.*) | *.*";

            string filePath = OpenFile(filter);

            if (string.IsNullOrEmpty(filePath)) return;

            FileInfo file = new FileInfo(filePath);

            using (var reader = file.OpenText())
            {
                do
                {
                    string currentLine = reader.ReadLine();
                    //txtVisualizer.Text += currentLine;
                } while (reader.Peek() != -1);
            }
        }



        private void BtnExecute_Click(object sender, EventArgs e) => WriteTextPrev();
        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e) => WriteTextPrev();
    }
}
