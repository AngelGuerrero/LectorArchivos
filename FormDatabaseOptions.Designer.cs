namespace LecturaDeArchivos
{
    partial class FormDatabaseOptions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabOptionsProperties = new System.Windows.Forms.TabControl();
            this.tabPage_tables = new System.Windows.Forms.TabPage();
            this.tabPage_Procs = new System.Windows.Forms.TabPage();
            this.listView_Procs = new System.Windows.Forms.ListView();
            this.txtProcName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabOptionsProperties.SuspendLayout();
            this.tabPage_Procs.SuspendLayout();
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
            this.tabOptionsProperties.Controls.Add(this.tabPage_tables);
            this.tabOptionsProperties.Controls.Add(this.tabPage_Procs);
            this.tabOptionsProperties.Location = new System.Drawing.Point(0, 0);
            this.tabOptionsProperties.Name = "tabOptionsProperties";
            this.tabOptionsProperties.SelectedIndex = 0;
            this.tabOptionsProperties.Size = new System.Drawing.Size(749, 398);
            this.tabOptionsProperties.TabIndex = 0;
            // 
            // tabPage_tables
            // 
            this.tabPage_tables.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tables.Name = "tabPage_tables";
            this.tabPage_tables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tables.Size = new System.Drawing.Size(741, 372);
            this.tabPage_tables.TabIndex = 0;
            this.tabPage_tables.Text = "Tablas";
            this.tabPage_tables.UseVisualStyleBackColor = true;
            // 
            // tabPage_Procs
            // 
            this.tabPage_Procs.Controls.Add(this.listView_Procs);
            this.tabPage_Procs.Controls.Add(this.txtProcName);
            this.tabPage_Procs.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Procs.Name = "tabPage_Procs";
            this.tabPage_Procs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Procs.Size = new System.Drawing.Size(741, 372);
            this.tabPage_Procs.TabIndex = 1;
            this.tabPage_Procs.Text = "Procedimientos almacenados";
            this.tabPage_Procs.UseVisualStyleBackColor = true;
            this.tabPage_Procs.Enter += new System.EventHandler(this.tabPage_Procs_Enter);
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
            // txtProcName
            // 
            this.txtProcName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcName.Location = new System.Drawing.Point(8, 6);
            this.txtProcName.Name = "txtProcName";
            this.txtProcName.Size = new System.Drawing.Size(730, 20);
            this.txtProcName.TabIndex = 0;
            this.txtProcName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtProcName_PreviewKeyDown);
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
            // FormDatabaseOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(749, 476);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDatabaseOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Propiedades";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabOptionsProperties.ResumeLayout(false);
            this.tabPage_Procs.ResumeLayout(false);
            this.tabPage_Procs.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabOptionsProperties;
        private System.Windows.Forms.TabPage tabPage_tables;
        private System.Windows.Forms.TabPage tabPage_Procs;
        private System.Windows.Forms.ListView listView_Procs;
        private System.Windows.Forms.TextBox txtProcName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
    }
}