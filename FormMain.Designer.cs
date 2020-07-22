namespace LecturaDeArchivos
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblAuthentication = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLine_1 = new System.Windows.Forms.Label();
            this.tblLayPanelAuthentication = new System.Windows.Forms.TableLayoutPanel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbxAuthentication = new System.Windows.Forms.ComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.multiplesServidoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDelProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoLogDelProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chklbxDataBases = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStripDataBases = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarTodotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PropiedadestoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chklbxFiles = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tblLayPanelAuthentication.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStripDataBases.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 649);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(564, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel.Text = "Listo.";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Seleccione un procedimiento almacenado";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.45161F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 448F));
            this.tableLayoutPanel1.Controls.Add(this.lblServer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtServer, 1, 0);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 93);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 29);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(3, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(94, 29);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Servidor:";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServer
            // 
            this.txtServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServer.Location = new System.Drawing.Point(103, 3);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(442, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.TextChanged += new System.EventHandler(this.TxtServer_TextChanged);
            // 
            // lblAuthentication
            // 
            this.lblAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthentication.Location = new System.Drawing.Point(3, 0);
            this.lblAuthentication.MaximumSize = new System.Drawing.Size(0, 25);
            this.lblAuthentication.Name = "lblAuthentication";
            this.lblAuthentication.Size = new System.Drawing.Size(88, 25);
            this.lblAuthentication.TabIndex = 1;
            this.lblAuthentication.Text = "Autenticación:";
            this.lblAuthentication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(564, 57);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Carga de procedimientos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAccept);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenFile);
            this.flowLayoutPanel1.Controls.Add(this.btnConnect);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 619);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(564, 30);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(481, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Ejecuta&r";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(400, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(319, 3);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.Text = "Abrir archiv&o";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Location = new System.Drawing.Point(229, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(84, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "&Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 57);
            this.panel1.TabIndex = 5;
            // 
            // lblLine_1
            // 
            this.lblLine_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine_1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLine_1.Location = new System.Drawing.Point(10, 84);
            this.lblLine_1.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_1.Name = "lblLine_1";
            this.lblLine_1.Size = new System.Drawing.Size(540, 2);
            this.lblLine_1.TabIndex = 8;
            // 
            // tblLayPanelAuthentication
            // 
            this.tblLayPanelAuthentication.ColumnCount = 3;
            this.tblLayPanelAuthentication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.6474F));
            this.tblLayPanelAuthentication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.3526F));
            this.tblLayPanelAuthentication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 371F));
            this.tblLayPanelAuthentication.Controls.Add(this.lblAuthentication, 0, 0);
            this.tblLayPanelAuthentication.Controls.Add(this.lblPassword, 1, 2);
            this.tblLayPanelAuthentication.Controls.Add(this.lblUser, 1, 1);
            this.tblLayPanelAuthentication.Controls.Add(this.txtUser, 2, 1);
            this.tblLayPanelAuthentication.Controls.Add(this.txtPassword, 2, 2);
            this.tblLayPanelAuthentication.Controls.Add(this.cbxAuthentication, 1, 0);
            this.tblLayPanelAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayPanelAuthentication.Location = new System.Drawing.Point(3, 16);
            this.tblLayPanelAuthentication.Name = "tblLayPanelAuthentication";
            this.tblLayPanelAuthentication.RowCount = 3;
            this.tblLayPanelAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.81967F));
            this.tblLayPanelAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.18033F));
            this.tblLayPanelAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblLayPanelAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayPanelAuthentication.Size = new System.Drawing.Size(538, 93);
            this.tblLayPanelAuthentication.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(97, 58);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 35);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(97, 29);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(66, 29);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Usuario:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUser.Location = new System.Drawing.Point(169, 32);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(366, 20);
            this.txtUser.TabIndex = 4;
            this.txtUser.TextChanged += new System.EventHandler(this.TxtUser_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(169, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(366, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // cbxAuthentication
            // 
            this.tblLayPanelAuthentication.SetColumnSpan(this.cbxAuthentication, 2);
            this.cbxAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAuthentication.FormattingEnabled = true;
            this.cbxAuthentication.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbxAuthentication.Location = new System.Drawing.Point(97, 3);
            this.cbxAuthentication.Name = "cbxAuthentication";
            this.cbxAuthentication.Size = new System.Drawing.Size(438, 21);
            this.cbxAuthentication.TabIndex = 6;
            this.cbxAuthentication.SelectedIndexChanged += new System.EventHandler(this.CbxAuthentication_SelectedIndexChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.toolStripSeparator2,
            this.multiplesServidoresToolStripMenuItem,
            this.toolStripSeparator3,
            this.abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem,
            this.toolStripSeparator4,
            this.salirToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem1.Text = "&Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.abrirToolStripMenuItem.Text = "Seleccionar &archivos...";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(291, 6);
            // 
            // multiplesServidoresToolStripMenuItem
            // 
            this.multiplesServidoresToolStripMenuItem.Name = "multiplesServidoresToolStripMenuItem";
            this.multiplesServidoresToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.multiplesServidoresToolStripMenuItem.Text = "Seleccionar &múltiples servidores...";
            this.multiplesServidoresToolStripMenuItem.Click += new System.EventHandler(this.multiplesServidoresToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(291, 6);
            // 
            // abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem
            // 
            this.abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem.Name = "abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem";
            this.abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem.Text = "Abrir directorio de generación de &inserts...";
            this.abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem.Click += new System.EventHandler(this.abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(291, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDelProgramaToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ay&uda";
            // 
            // acercaDelProgramaToolStripMenuItem
            // 
            this.acercaDelProgramaToolStripMenuItem.Name = "acercaDelProgramaToolStripMenuItem";
            this.acercaDelProgramaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.acercaDelProgramaToolStripMenuItem.Text = "Acerca del programa";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editarToolStripMenuItem,
            this.verToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(564, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "&Editar";
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buscarToolStripMenuItem.Text = "&Buscar";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoLogDelProgramaToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "&Ver";
            // 
            // archivoLogDelProgramaToolStripMenuItem
            // 
            this.archivoLogDelProgramaToolStripMenuItem.Name = "archivoLogDelProgramaToolStripMenuItem";
            this.archivoLogDelProgramaToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.archivoLogDelProgramaToolStripMenuItem.Text = "Archivo &Log del programa";
            this.archivoLogDelProgramaToolStripMenuItem.Click += new System.EventHandler(this.archivoLogDelProgramaToolStripMenuItem_Click);
            // 
            // chklbxDataBases
            // 
            this.chklbxDataBases.ContextMenuStrip = this.contextMenuStripDataBases;
            this.chklbxDataBases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklbxDataBases.Enabled = false;
            this.chklbxDataBases.FormattingEnabled = true;
            this.chklbxDataBases.Location = new System.Drawing.Point(3, 16);
            this.chklbxDataBases.Name = "chklbxDataBases";
            this.chklbxDataBases.Size = new System.Drawing.Size(540, 93);
            this.chklbxDataBases.Sorted = true;
            this.chklbxDataBases.TabIndex = 11;
            this.chklbxDataBases.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklbxDataBases_ItemCheck);
            this.chklbxDataBases.Click += new System.EventHandler(this.chklbxDataBases_Click);
            // 
            // contextMenuStripDataBases
            // 
            this.contextMenuStripDataBases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarTodotoolStripMenuItem,
            this.toolStripSeparator1,
            this.PropiedadestoolStripMenuItem});
            this.contextMenuStripDataBases.Name = "contextMenuStripDataBases";
            this.contextMenuStripDataBases.Size = new System.Drawing.Size(163, 54);
            // 
            // seleccionarTodotoolStripMenuItem
            // 
            this.seleccionarTodotoolStripMenuItem.Name = "seleccionarTodotoolStripMenuItem";
            this.seleccionarTodotoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.seleccionarTodotoolStripMenuItem.Text = "Seleccionar todo";
            this.seleccionarTodotoolStripMenuItem.Click += new System.EventHandler(this.seleccionarTodotoolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // PropiedadestoolStripMenuItem
            // 
            this.PropiedadestoolStripMenuItem.Name = "PropiedadestoolStripMenuItem";
            this.PropiedadestoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.PropiedadestoolStripMenuItem.Text = "Propiedades";
            this.PropiedadestoolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // chklbxFiles
            // 
            this.chklbxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklbxFiles.FormattingEnabled = true;
            this.chklbxFiles.HorizontalScrollbar = true;
            this.chklbxFiles.Location = new System.Drawing.Point(3, 16);
            this.chklbxFiles.Name = "chklbxFiles";
            this.chklbxFiles.Size = new System.Drawing.Size(540, 99);
            this.chklbxFiles.Sorted = true;
            this.chklbxFiles.TabIndex = 12;
            this.chklbxFiles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklbxFiles_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chklbxDataBases);
            this.groupBox1.Location = new System.Drawing.Point(8, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 112);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bases de datos";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.chklbxFiles);
            this.groupBox2.Location = new System.Drawing.Point(8, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 118);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archivos seleccionados";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(8, 488);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(546, 115);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultado";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 16);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(540, 96);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tblLayPanelAuthentication);
            this.groupBox4.Location = new System.Drawing.Point(10, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(544, 112);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Conexión con el servidor";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(564, 671);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblLine_1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tblLayPanelAuthentication.ResumeLayout(false);
            this.tblLayPanelAuthentication.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStripDataBases.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblAuthentication;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblLayPanelAuthentication;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblLine_1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDelProgramaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.CheckedListBox chklbxDataBases;
        private System.Windows.Forms.CheckedListBox chklbxFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.ComboBox cbxAuthentication;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataBases;
        private System.Windows.Forms.ToolStripMenuItem PropiedadestoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodotoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem multiplesServidoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoLogDelProgramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem abrirDirectorioDeGeneraciónDeInsertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

