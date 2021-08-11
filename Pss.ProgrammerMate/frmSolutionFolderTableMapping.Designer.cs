namespace Pss.ProgrammerMate
{
    partial class frmSolutionFolderTableMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolutionFolderTableMapping));
            this.gbRight = new System.Windows.Forms.GroupBox();
            this.bnMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.cmbSolutionsDB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSolutions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dvgUnMappedTables = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbkSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dvgMappedTables = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmdColumns = new System.Windows.Forms.Button();
            this.cmbSolutionFolders = new System.Windows.Forms.ComboBox();
            this.clmSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdWithdraw = new System.Windows.Forms.Button();
            this.cmdAssign = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bnbtnExit = new System.Windows.Forms.ToolStripButton();
            this.txtCopyClipboard = new System.Windows.Forms.ToolStripButton();
            this.cmdExecuteQuery = new System.Windows.Forms.ToolStripButton();
            this.Solutions_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionsDB_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionsDBTables_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionFolders_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionsMappedDBTables_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clmSelectMapped = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnMain)).BeginInit();
            this.bnMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgUnMappedTables)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgMappedTables)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Solutions_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDB_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDBTables_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionFolders_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsMappedDBTables_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRight
            // 
            this.gbRight.Controls.Add(this.bnMain);
            this.gbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbRight.Location = new System.Drawing.Point(900, 0);
            this.gbRight.Name = "gbRight";
            this.gbRight.Size = new System.Drawing.Size(84, 611);
            this.gbRight.TabIndex = 9;
            this.gbRight.TabStop = false;
            // 
            // bnMain
            // 
            this.bnMain.AddNewItem = null;
            this.bnMain.CountItem = this.bindingNavigatorCountItem;
            this.bnMain.DeleteItem = null;
            this.bnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bnbtnExit,
            this.toolStripSeparator1,
            this.txtCopyClipboard,
            this.toolStripSeparator2,
            this.cmdExecuteQuery});
            this.bnMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.bnMain.Location = new System.Drawing.Point(3, 16);
            this.bnMain.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnMain.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnMain.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnMain.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnMain.Name = "bnMain";
            this.bnMain.PositionItem = this.bindingNavigatorPositionItem;
            this.bnMain.Size = new System.Drawing.Size(78, 592);
            this.bnMain.TabIndex = 2;
            this.bnMain.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(76, 6);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(76, 6);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(76, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(76, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(76, 6);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.cmdRefresh);
            this.gbHeader.Controls.Add(this.cmdConnect);
            this.gbHeader.Controls.Add(this.cmbSolutionsDB);
            this.gbHeader.Controls.Add(this.label1);
            this.gbHeader.Controls.Add(this.cmbSolutions);
            this.gbHeader.Controls.Add(this.label3);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(900, 58);
            this.gbHeader.TabIndex = 10;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "DB Connection";
            // 
            // cmbSolutionsDB
            // 
            this.cmbSolutionsDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolutionsDB.FormattingEnabled = true;
            this.cmbSolutionsDB.Items.AddRange(new object[] {
            "MS SQL",
            "My SQL"});
            this.cmbSolutionsDB.Location = new System.Drawing.Point(409, 23);
            this.cmbSolutionsDB.Name = "cmbSolutionsDB";
            this.cmbSolutionsDB.Size = new System.Drawing.Size(388, 21);
            this.cmbSolutionsDB.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "DB Connection:";
            // 
            // cmbSolutions
            // 
            this.cmbSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolutions.FormattingEnabled = true;
            this.cmbSolutions.Items.AddRange(new object[] {
            "MS SQL",
            "My SQL"});
            this.cmbSolutions.Location = new System.Drawing.Point(67, 23);
            this.cmbSolutions.Name = "cmbSolutions";
            this.cmbSolutions.Size = new System.Drawing.Size(206, 21);
            this.cmbSolutions.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Solution:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 553);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Un-Mapped Tables";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdWithdraw);
            this.groupBox2.Controls.Add(this.cmdAssign);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(297, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(85, 553);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(382, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 553);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mapped Folder & Tables";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dvgUnMappedTables);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 499);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // dvgUnMappedTables
            // 
            this.dvgUnMappedTables.AllowUserToAddRows = false;
            this.dvgUnMappedTables.AllowUserToDeleteRows = false;
            this.dvgUnMappedTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgUnMappedTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgUnMappedTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSelect,
            this.clmName});
            this.dvgUnMappedTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgUnMappedTables.Location = new System.Drawing.Point(3, 16);
            this.dvgUnMappedTables.Name = "dvgUnMappedTables";
            this.dvgUnMappedTables.RowHeadersVisible = false;
            this.dvgUnMappedTables.Size = new System.Drawing.Size(285, 480);
            this.dvgUnMappedTables.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbkSelectAll);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(291, 35);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // cbkSelectAll
            // 
            this.cbkSelectAll.AutoSize = true;
            this.cbkSelectAll.Location = new System.Drawing.Point(6, 13);
            this.cbkSelectAll.Name = "cbkSelectAll";
            this.cbkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.cbkSelectAll.TabIndex = 14;
            this.cbkSelectAll.Text = "Select All";
            this.cbkSelectAll.UseVisualStyleBackColor = true;
            this.cbkSelectAll.CheckedChanged += new System.EventHandler(this.cbkSelectAll_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dvgMappedTables);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 80);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(275, 470);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Columns";
            // 
            // dvgMappedTables
            // 
            this.dvgMappedTables.AllowUserToAddRows = false;
            this.dvgMappedTables.AllowUserToDeleteRows = false;
            this.dvgMappedTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgMappedTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgMappedTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSelectMapped,
            this.clmTableName});
            this.dvgMappedTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgMappedTables.Location = new System.Drawing.Point(3, 16);
            this.dvgMappedTables.Name = "dvgMappedTables";
            this.dvgMappedTables.RowHeadersVisible = false;
            this.dvgMappedTables.Size = new System.Drawing.Size(269, 451);
            this.dvgMappedTables.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox1);
            this.groupBox7.Controls.Add(this.cmdColumns);
            this.groupBox7.Controls.Add(this.cmbSolutionFolders);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(275, 64);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmdColumns
            // 
            this.cmdColumns.Location = new System.Drawing.Point(152, 41);
            this.cmdColumns.Name = "cmdColumns";
            this.cmdColumns.Size = new System.Drawing.Size(117, 20);
            this.cmdColumns.TabIndex = 13;
            this.cmdColumns.Text = "Get Mapped Tables";
            this.cmdColumns.UseVisualStyleBackColor = true;
            this.cmdColumns.Click += new System.EventHandler(this.cmdColumns_Click);
            // 
            // cmbSolutionFolders
            // 
            this.cmbSolutionFolders.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbSolutionFolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolutionFolders.FormattingEnabled = true;
            this.cmbSolutionFolders.Items.AddRange(new object[] {
            "MS SQL",
            "My SQL"});
            this.cmbSolutionFolders.Location = new System.Drawing.Point(3, 16);
            this.cmbSolutionFolders.Name = "cmbSolutionFolders";
            this.cmbSolutionFolders.Size = new System.Drawing.Size(269, 21);
            this.cmbSolutionFolders.TabIndex = 3;
            this.cmbSolutionFolders.SelectedIndexChanged += new System.EventHandler(this.cmbSolutionFolders_SelectedIndexChanged);
            // 
            // clmSelect
            // 
            this.clmSelect.FalseValue = "0";
            this.clmSelect.Frozen = true;
            this.clmSelect.HeaderText = "Select";
            this.clmSelect.Name = "clmSelect";
            this.clmSelect.TrueValue = "1";
            this.clmSelect.Width = 43;
            // 
            // clmName
            // 
            this.clmName.Frozen = true;
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            this.clmName.Width = 200;
            // 
            // cmdWithdraw
            // 
            this.cmdWithdraw.BackgroundImage = global::Pss.ProgrammerMate.Properties.Resources.withdraw;
            this.cmdWithdraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdWithdraw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdWithdraw.Location = new System.Drawing.Point(6, 219);
            this.cmdWithdraw.Name = "cmdWithdraw";
            this.cmdWithdraw.Size = new System.Drawing.Size(73, 63);
            this.cmdWithdraw.TabIndex = 15;
            this.cmdWithdraw.UseVisualStyleBackColor = true;
            this.cmdWithdraw.Click += new System.EventHandler(this.cmdWithdraw_Click);
            // 
            // cmdAssign
            // 
            this.cmdAssign.BackgroundImage = global::Pss.ProgrammerMate.Properties.Resources.assign;
            this.cmdAssign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAssign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAssign.Location = new System.Drawing.Point(6, 150);
            this.cmdAssign.Name = "cmdAssign";
            this.cmdAssign.Size = new System.Drawing.Size(73, 60);
            this.cmdAssign.TabIndex = 14;
            this.cmdAssign.UseVisualStyleBackColor = true;
            this.cmdAssign.Click += new System.EventHandler(this.cmdAssign_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = global::Pss.ProgrammerMate.Properties.Resources._1417109849_view_refresh_32;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(279, 15);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(34, 35);
            this.cmdRefresh.TabIndex = 13;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdConnect.Image = global::Pss.ProgrammerMate.Properties.Resources.connectdb_small;
            this.cmdConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConnect.Location = new System.Drawing.Point(803, 13);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(91, 39);
            this.cmdConnect.TabIndex = 49;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdConnect.UseVisualStyleBackColor = false;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(76, 20);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(76, 20);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(76, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(76, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bnbtnExit
            // 
            this.bnbtnExit.Image = global::Pss.ProgrammerMate.Properties.Resources._1417110356_Log_Out;
            this.bnbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnbtnExit.Name = "bnbtnExit";
            this.bnbtnExit.Size = new System.Drawing.Size(76, 20);
            this.bnbtnExit.Text = "E&xit";
            this.bnbtnExit.Click += new System.EventHandler(this.bnbtnExit_Click);
            // 
            // txtCopyClipboard
            // 
            this.txtCopyClipboard.Image = ((System.Drawing.Image)(resources.GetObject("txtCopyClipboard.Image")));
            this.txtCopyClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtCopyClipboard.Name = "txtCopyClipboard";
            this.txtCopyClipboard.Size = new System.Drawing.Size(76, 20);
            this.txtCopyClipboard.Text = "&Copy";
            // 
            // cmdExecuteQuery
            // 
            this.cmdExecuteQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdExecuteQuery.Image")));
            this.cmdExecuteQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExecuteQuery.Name = "cmdExecuteQuery";
            this.cmdExecuteQuery.Size = new System.Drawing.Size(76, 20);
            this.cmdExecuteQuery.Text = "&Run Qry";
            // 
            // clmSelectMapped
            // 
            this.clmSelectMapped.FalseValue = "0";
            this.clmSelectMapped.Frozen = true;
            this.clmSelectMapped.HeaderText = "Select";
            this.clmSelectMapped.Name = "clmSelectMapped";
            this.clmSelectMapped.TrueValue = "1";
            this.clmSelectMapped.Width = 43;
            // 
            // clmTableName
            // 
            this.clmTableName.Frozen = true;
            this.clmTableName.HeaderText = "Name";
            this.clmTableName.Name = "clmTableName";
            this.clmTableName.Width = 200;
            // 
            // frmSolutionFolderTableMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.gbRight);
            this.MaximizeBox = false;
            this.Name = "frmSolutionFolderTableMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solutions Folder & Table Mapping";
            this.Load += new System.EventHandler(this.frmSolutionFolderTableMapping_Load);
            this.gbRight.ResumeLayout(false);
            this.gbRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnMain)).EndInit();
            this.bnMain.ResumeLayout(false);
            this.bnMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgUnMappedTables)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgMappedTables)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Solutions_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDB_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDBTables_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionFolders_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsMappedDBTables_bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRight;
        private System.Windows.Forms.BindingNavigator bnMain;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bnbtnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton txtCopyClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cmdExecuteQuery;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.ComboBox cmbSolutionsDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSolutions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dvgUnMappedTables;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbkSelectAll;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dvgMappedTables;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button cmdColumns;
        private System.Windows.Forms.ComboBox cmbSolutionFolders;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.BindingSource Solutions_bindingSource;
        private System.Windows.Forms.BindingSource SolutionsDB_bindingSource;
        private System.Windows.Forms.BindingSource SolutionsDBTables_bindingSource;
        private System.Windows.Forms.BindingSource SolutionFolders_bindingSource;
        private System.Windows.Forms.Button cmdWithdraw;
        private System.Windows.Forms.Button cmdAssign;
        private System.Windows.Forms.BindingSource SolutionsMappedDBTables_bindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelectMapped;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTableName;
    }
}