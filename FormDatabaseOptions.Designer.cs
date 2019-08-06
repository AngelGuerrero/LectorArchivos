namespace LecturaDeArchivos
{
    partial class FormDataBaseOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabOptionsProperties = new System.Windows.Forms.TabControl();
            this.tabPage_DatabaseTables = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeViewTables = new System.Windows.Forms.TreeView();
            this.contextMenuStripTablesProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verPropiedadesDeLaTablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTables_Filter = new System.Windows.Forms.TextBox();
            this.tabPage_StoredProcedures = new System.Windows.Forms.TabPage();
            this.listView_Procs = new System.Windows.Forms.ListView();
            this.txtProcedures_Filter = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabOptionsProperties.SuspendLayout();
            this.tabPage_DatabaseTables.SuspendLayout();
            this.contextMenuStripTablesProperties.SuspendLayout();
            this.tabPage_StoredProcedures.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.tabOptionsProperties);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 426);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 398);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(749, 28);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.MaximumSize = new System.Drawing.Size(100, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabOptionsProperties
            // 
            this.tabOptionsProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOptionsProperties.Controls.Add(this.tabPage_DatabaseTables);
            this.tabOptionsProperties.Controls.Add(this.tabPage_StoredProcedures);
            this.tabOptionsProperties.Location = new System.Drawing.Point(0, 0);
            this.tabOptionsProperties.Name = "tabOptionsProperties";
            this.tabOptionsProperties.SelectedIndex = 0;
            this.tabOptionsProperties.Size = new System.Drawing.Size(749, 398);
            this.tabOptionsProperties.TabIndex = 0;
            // 
            // tabPage_DatabaseTables
            // 
            this.tabPage_DatabaseTables.Controls.Add(this.panel3);
            this.tabPage_DatabaseTables.Controls.Add(this.treeViewTables);
            this.tabPage_DatabaseTables.Controls.Add(this.txtTables_Filter);
            this.tabPage_DatabaseTables.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DatabaseTables.Name = "tabPage_DatabaseTables";
            this.tabPage_DatabaseTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DatabaseTables.Size = new System.Drawing.Size(741, 372);
            this.tabPage_DatabaseTables.TabIndex = 0;
            this.tabPage_DatabaseTables.Text = "Tablas";
            this.tabPage_DatabaseTables.UseVisualStyleBackColor = true;
            this.tabPage_DatabaseTables.Enter += new System.EventHandler(this.tabPage_DatabaseTables_Enter);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Location = new System.Drawing.Point(264, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(474, 334);
            this.panel3.TabIndex = 2;
            // 
            // treeViewTables
            // 
            this.treeViewTables.ContextMenuStrip = this.contextMenuStripTablesProperties;
            this.treeViewTables.Location = new System.Drawing.Point(8, 32);
            this.treeViewTables.Name = "treeViewTables";
            this.treeViewTables.Size = new System.Drawing.Size(250, 334);
            this.treeViewTables.TabIndex = 1;
            // 
            // contextMenuStripTablesProperties
            // 
            this.contextMenuStripTablesProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPropiedadesDeLaTablaToolStripMenuItem});
            this.contextMenuStripTablesProperties.Name = "contextMenuStripTablesProperties";
            this.contextMenuStripTablesProperties.Size = new System.Drawing.Size(216, 26);
            // 
            // verPropiedadesDeLaTablaToolStripMenuItem
            // 
            this.verPropiedadesDeLaTablaToolStripMenuItem.Name = "verPropiedadesDeLaTablaToolStripMenuItem";
            this.verPropiedadesDeLaTablaToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.verPropiedadesDeLaTablaToolStripMenuItem.Text = "Ver propiedades de la tabla";
            // 
            // txtTables_Filter
            // 
            this.txtTables_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTables_Filter.Location = new System.Drawing.Point(8, 6);
            this.txtTables_Filter.Name = "txtTables_Filter";
            this.txtTables_Filter.Size = new System.Drawing.Size(730, 20);
            this.txtTables_Filter.TabIndex = 0;
            this.txtTables_Filter.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtTables_Filter_PreviewKeyDown);
            // 
            // tabPage_StoredProcedures
            // 
            this.tabPage_StoredProcedures.Controls.Add(this.listView_Procs);
            this.tabPage_StoredProcedures.Controls.Add(this.txtProcedures_Filter);
            this.tabPage_StoredProcedures.Location = new System.Drawing.Point(4, 22);
            this.tabPage_StoredProcedures.Name = "tabPage_StoredProcedures";
            this.tabPage_StoredProcedures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_StoredProcedures.Size = new System.Drawing.Size(741, 372);
            this.tabPage_StoredProcedures.TabIndex = 1;
            this.tabPage_StoredProcedures.Text = "Procedimientos almacenados";
            this.tabPage_StoredProcedures.UseVisualStyleBackColor = true;
            this.tabPage_StoredProcedures.Enter += new System.EventHandler(this.tabPage_StoredProcedures_Enter);
            // 
            // listView_Procs
            // 
            this.listView_Procs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Procs.Location = new System.Drawing.Point(8, 32);
            this.listView_Procs.Name = "listView_Procs";
            this.listView_Procs.Size = new System.Drawing.Size(730, 337);
            this.listView_Procs.TabIndex = 1;
            this.listView_Procs.UseCompatibleStateImageBehavior = false;
            this.listView_Procs.View = System.Windows.Forms.View.List;
            // 
            // txtProcedures_Filter
            // 
            this.txtProcedures_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcedures_Filter.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtProcedures_Filter.Location = new System.Drawing.Point(8, 6);
            this.txtProcedures_Filter.Name = "txtProcedures_Filter";
            this.txtProcedures_Filter.Size = new System.Drawing.Size(730, 20);
            this.txtProcedures_Filter.TabIndex = 0;
            this.txtProcedures_Filter.Text = "Buscar en los procedimientos almacenados";
            this.txtProcedures_Filter.Enter += new System.EventHandler(this.TxtProcName_Enter);
            this.txtProcedures_Filter.Leave += new System.EventHandler(this.TxtProcName_Leave);
            this.txtProcedures_Filter.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtProcName_PreviewKeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 50);
            this.panel2.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Propiedades de la base de datos: ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDataBaseOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(749, 476);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDataBaseOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Propiedades";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabOptionsProperties.ResumeLayout(false);
            this.tabPage_DatabaseTables.ResumeLayout(false);
            this.tabPage_DatabaseTables.PerformLayout();
            this.contextMenuStripTablesProperties.ResumeLayout(false);
            this.tabPage_StoredProcedures.ResumeLayout(false);
            this.tabPage_StoredProcedures.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabOptionsProperties;
        private System.Windows.Forms.TabPage tabPage_DatabaseTables;
        private System.Windows.Forms.TabPage tabPage_StoredProcedures;
        private System.Windows.Forms.ListView listView_Procs;
        private System.Windows.Forms.TextBox txtProcedures_Filter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeViewTables;
        private System.Windows.Forms.TextBox txtTables_Filter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTablesProperties;
        private System.Windows.Forms.ToolStripMenuItem verPropiedadesDeLaTablaToolStripMenuItem;
    }
}