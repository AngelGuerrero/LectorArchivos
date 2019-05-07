using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public partial class FormDataBaseOptions : Form
    {
        public string DataBaseName { get; set; }


        public FormMain formMain;


        public FormDataBaseOptions()
        {
            InitializeComponent();
        }

        public FormDataBaseOptions(string pDataBaseName)
        {
            InitializeComponent();

            //
            // Get the instance of FormMain
            formMain = Application.OpenForms.OfType<Form>().First() as FormMain;
            //
            // Database
            DataBaseName = pDataBaseName;
            //
            // Title of form
            lblTitle.Text += DataBaseName;
        }




        private void FilterStoreProcedures()
        {
            //
            // Clear the list
            listView_Procs.Items.Clear();

            if (string.IsNullOrEmpty(txtProcedures_Filter.Text))
            {
                ShowOriginalListStoreProcedures();
                return;
            }

            string sp = txtProcedures_Filter.Text;

            bool any = GetStoredProceduresFromCurrentDatabase().Any(item => item.ToLower().Contains(sp.ToLower()));

            if (any)
            {
                GetStoredProceduresFromCurrentDatabase().Where(item => item.ToLower().Contains(sp.ToLower()))
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
            GetStoredProceduresFromCurrentDatabase().ForEach(item => listView_Procs.Items.Add(item));
        }

        private List<string> GetStoredProceduresFromCurrentDatabase()
        {
            string msg = "";
            bool error = false;

            //
            // It gets the stored procedures using the current connection.
            return (from sp in formMain.RemoteConnection.GetStoreProceduresFromDataBase(DataBaseName, ref msg, ref error).AsEnumerable()
                    select sp.Field<string>("name")).ToList();

        }

        private List<string> GetTablesFromCurrentDatabase()
        {
            treeViewTables.Nodes.Clear();

            string msg = "";
            bool error = false;

            //
            // It gets the tables using the current connection.
            return (from table in formMain.RemoteConnection.GetTablesFromDatabase(DataBaseName, ref msg, ref error).AsEnumerable()
                    select table.Field<string>("name")).ToList();
        }

        private void LoadStoredProceduresInListView()
        {
            listView_Procs.Clear();

            GetStoredProceduresFromCurrentDatabase().AsEnumerable()
                                                    .ToList()
                                                    .ForEach(sp => listView_Procs.Items.Add(sp));
        }

        private void LoadTreeViewDatabase()
        {
            //
            // Tables node
            TreeNode treeNodeTables = new TreeNode("Tables");
            treeNodeTables.Name = "treeNodeTables";
            //
            // Load the information into the table node
            GetTablesFromCurrentDatabase().ForEach(table => treeNodeTables.Nodes.Add(table));

            //
            // Stored procedures node
            TreeNode treeNodeStoredProcedures = new TreeNode("Stored Procedures");
            treeNodeStoredProcedures.Name = "treeNodeStoredProcedures";
            //
            // Load the stored procedures into the tree node
            GetStoredProceduresFromCurrentDatabase().ForEach(sp => treeNodeStoredProcedures.Nodes.Add(sp));

            LoadTreeViewDatabase(treeNodeTables, treeNodeStoredProcedures);
        }

        private void LoadTreeViewDatabase(TreeNode pTreeNodeTables, TreeNode pTreeNodeStoredProcedures)
        {
            //
            // Add a root node
            TreeNode root = new TreeNode(DataBaseName);
            root.Name = "Root";
            root.Text = DataBaseName;

            //
            // Add nodes into the root node
            root.Nodes.Add(pTreeNodeTables);
            root.Nodes.Add(pTreeNodeStoredProcedures);

            //
            // Add root node into the tree view
            treeViewTables.Nodes.Add(root);
            treeViewTables.ExpandAll();
        }

        private void tabPage_DatabaseTables_Enter(object sender, EventArgs e) => LoadTreeViewDatabase();

        private void tabPage_StoredProcedures_Enter(object sender, EventArgs e) => LoadStoredProceduresInListView();

        private void FilterTreeView(string pFilter)
        {
            //
            // Tables node
            TreeNode treeNodeTables = new TreeNode("Tables");
            treeNodeTables.Name = "treeNodeTables";

            //
            // Stored procedures node
            TreeNode treeNodeStoredProcedures = new TreeNode("Stored Procedures");
            treeNodeStoredProcedures.Name = "treeNodeStoredProcedures";


            //
            // Filter the tables
            GetTablesFromCurrentDatabase().Where(table => table.ToLower().Contains(pFilter.ToLower()))
                                          .ToList()
                                          .ForEach(table => treeNodeTables.Nodes.Add(table));

            //
            // Filter the stored procedures
            GetStoredProceduresFromCurrentDatabase().Where(sp => sp.ToLower().Contains(pFilter.ToLower()))
                                                    .ToList()
                                                    .ForEach(sp => treeNodeStoredProcedures.Nodes.Add(sp));

            LoadTreeViewDatabase(treeNodeTables, treeNodeStoredProcedures);
        }

        private void txtTables_Filter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                FilterTreeView(txtTables_Filter.Text);
            }

            if ((e.Shift && e.KeyCode == Keys.Enter))
            {
                LoadTreeViewDatabase();
            }
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

        private void TxtProcName_Enter(object sender, EventArgs e)
        {
            if (txtProcedures_Filter.Text.Equals("Buscar en los procedimientos almacenados"))
            {
                txtProcedures_Filter.Text = string.Empty;
                txtProcedures_Filter.ForeColor = System.Drawing.Color.Black;
                return;
            }
        }

        private void TxtProcName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProcedures_Filter.Text)) return;

            txtProcedures_Filter.ForeColor = System.Drawing.Color.Gray;
            txtProcedures_Filter.Text = "Buscar en los procedimientos almacenados";
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

    }
}
