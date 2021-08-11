namespace Pss.ProgrammerMate.SQL_Generator
{
    partial class frmSQLGeneratorMSSQLServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQLGeneratorMSSQLServer));
            this.Solutions_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionsDB_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TableColumns_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionDBQuery_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionsDBTables_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionDB_TableColumns_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbRight = new System.Windows.Forms.GroupBox();
            this.bnMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCopyClipboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdExecuteQuery = new System.Windows.Forms.ToolStripButton();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmbSolutionsDB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSolutions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dvgTableColumns = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbkSelectAll = new System.Windows.Forms.CheckBox();
            this.cmdColumns = new System.Windows.Forms.Button();
            this.cmbDBTables = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dvgSolutionDBQuery = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmdGeneratorQuery = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtGeneratedQuery = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtActionType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQueryType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueryName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbRulAllQueries = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmQueryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType_DBAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmActionType_DBAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDALMethodName_DBAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmActionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmWhere = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Solutions_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDB_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableColumns_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionDBQuery_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDBTables_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionDB_TableColumns_bindingSource)).BeginInit();
            this.gbRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnMain)).BeginInit();
            this.bnMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTableColumns)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSolutionDBQuery)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRight
            // 
            this.gbRight.Controls.Add(this.bnMain);
            this.gbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbRight.Location = new System.Drawing.Point(1379, 0);
            this.gbRight.Name = "gbRight";
            this.gbRight.Size = new System.Drawing.Size(84, 661);
            this.gbRight.TabIndex = 14;
            this.gbRight.TabStop = false;
            // 
            // bnMain
            // 
            this.bnMain.AddNewItem = null;
            this.bnMain.BindingSource = this.SolutionDBQuery_bindingSource;
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
            this.cmdExecuteQuery,
            this.toolStripSeparator3,
            this.cmbRulAllQueries});
            this.bnMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.bnMain.Location = new System.Drawing.Point(3, 16);
            this.bnMain.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnMain.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnMain.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnMain.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnMain.Name = "bnMain";
            this.bnMain.PositionItem = this.bindingNavigatorPositionItem;
            this.bnMain.Size = new System.Drawing.Size(78, 642);
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
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(76, 6);
            // 
            // bnbtnExit
            // 
            this.bnbtnExit.Image = global::Pss.ProgrammerMate.Properties.Resources._1417110356_Log_Out;
            this.bnbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnbtnExit.Name = "bnbtnExit";
            this.bnbtnExit.Size = new System.Drawing.Size(76, 20);
            this.bnbtnExit.Text = "E&xit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(76, 6);
            // 
            // txtCopyClipboard
            // 
            this.txtCopyClipboard.Image = ((System.Drawing.Image)(resources.GetObject("txtCopyClipboard.Image")));
            this.txtCopyClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtCopyClipboard.Name = "txtCopyClipboard";
            this.txtCopyClipboard.Size = new System.Drawing.Size(76, 20);
            this.txtCopyClipboard.Text = "&Copy";
            this.txtCopyClipboard.Click += new System.EventHandler(this.txtCopyClipboard_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(76, 6);
            // 
            // cmdExecuteQuery
            // 
            this.cmdExecuteQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdExecuteQuery.Image")));
            this.cmdExecuteQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExecuteQuery.Name = "cmdExecuteQuery";
            this.cmdExecuteQuery.Size = new System.Drawing.Size(76, 20);
            this.cmdExecuteQuery.Text = "&Run Qry";
            this.cmdExecuteQuery.Click += new System.EventHandler(this.cmdExecuteQuery_Click);
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
            this.gbHeader.Size = new System.Drawing.Size(1379, 58);
            this.gbHeader.TabIndex = 15;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "DB Connection";
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
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 603);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dvgTableColumns);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 520);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Columns";
            // 
            // dvgTableColumns
            // 
            this.dvgTableColumns.AllowUserToAddRows = false;
            this.dvgTableColumns.AllowUserToDeleteRows = false;
            this.dvgTableColumns.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgTableColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTableColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSelect,
            this.clmName,
            this.clmType,
            this.clmIdentity,
            this.clmWhere,
            this.clmDefaultValue});
            this.dvgTableColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgTableColumns.Location = new System.Drawing.Point(3, 16);
            this.dvgTableColumns.Name = "dvgTableColumns";
            this.dvgTableColumns.RowHeadersVisible = false;
            this.dvgTableColumns.Size = new System.Drawing.Size(497, 501);
            this.dvgTableColumns.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbkSelectAll);
            this.groupBox3.Controls.Add(this.cmdColumns);
            this.groupBox3.Controls.Add(this.cmbDBTables);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 64);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // cbkSelectAll
            // 
            this.cbkSelectAll.AutoSize = true;
            this.cbkSelectAll.Location = new System.Drawing.Point(6, 41);
            this.cbkSelectAll.Name = "cbkSelectAll";
            this.cbkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.cbkSelectAll.TabIndex = 14;
            this.cbkSelectAll.Text = "Select All";
            this.cbkSelectAll.UseVisualStyleBackColor = true;
            this.cbkSelectAll.CheckedChanged += new System.EventHandler(this.cbkSelectAll_CheckedChanged);
            // 
            // cmdColumns
            // 
            this.cmdColumns.Location = new System.Drawing.Point(425, 43);
            this.cmdColumns.Name = "cmdColumns";
            this.cmdColumns.Size = new System.Drawing.Size(75, 20);
            this.cmdColumns.TabIndex = 13;
            this.cmdColumns.Text = "Columns";
            this.cmdColumns.UseVisualStyleBackColor = true;
            this.cmdColumns.Click += new System.EventHandler(this.cmdColumns_Click);
            // 
            // cmbDBTables
            // 
            this.cmbDBTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbDBTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBTables.FormattingEnabled = true;
            this.cmbDBTables.Location = new System.Drawing.Point(3, 16);
            this.cmbDBTables.Name = "cmbDBTables";
            this.cmbDBTables.Size = new System.Drawing.Size(497, 21);
            this.cmbDBTables.TabIndex = 3;
            this.cmbDBTables.SelectedIndexChanged += new System.EventHandler(this.cmbDBTables_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(509, 58);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(509, 603);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DB Actions & Queries";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dvgSolutionDBQuery);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(503, 537);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // dvgSolutionDBQuery
            // 
            this.dvgSolutionDBQuery.AllowUserToAddRows = false;
            this.dvgSolutionDBQuery.AllowUserToDeleteRows = false;
            this.dvgSolutionDBQuery.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgSolutionDBQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgSolutionDBQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSelected,
            this.clmQueryName,
            this.clmType_DBAction,
            this.clmActionType_DBAction,
            this.clmDALMethodName_DBAction,
            this.clmActionID,
            this.clmID});
            this.dvgSolutionDBQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgSolutionDBQuery.Location = new System.Drawing.Point(3, 16);
            this.dvgSolutionDBQuery.Name = "dvgSolutionDBQuery";
            this.dvgSolutionDBQuery.RowHeadersVisible = false;
            this.dvgSolutionDBQuery.Size = new System.Drawing.Size(497, 518);
            this.dvgSolutionDBQuery.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmdGeneratorQuery);
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(503, 47);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // cmdGeneratorQuery
            // 
            this.cmdGeneratorQuery.Location = new System.Drawing.Point(375, 15);
            this.cmdGeneratorQuery.Name = "cmdGeneratorQuery";
            this.cmdGeneratorQuery.Size = new System.Drawing.Size(122, 32);
            this.cmdGeneratorQuery.TabIndex = 15;
            this.cmdGeneratorQuery.Text = "&Generate SQL";
            this.cmdGeneratorQuery.UseVisualStyleBackColor = true;
            this.cmdGeneratorQuery.Click += new System.EventHandler(this.cmdGeneratorQuery_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtGeneratedQuery);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(1018, 58);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(361, 603);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Query Detail";
            // 
            // txtGeneratedQuery
            // 
            this.txtGeneratedQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGeneratedQuery.HideSelection = false;
            this.txtGeneratedQuery.Location = new System.Drawing.Point(3, 109);
            this.txtGeneratedQuery.Multiline = true;
            this.txtGeneratedQuery.Name = "txtGeneratedQuery";
            this.txtGeneratedQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGeneratedQuery.Size = new System.Drawing.Size(355, 491);
            this.txtGeneratedQuery.TabIndex = 18;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtActionType);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.txtQueryType);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.txtQueryName);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(3, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(355, 93);
            this.groupBox9.TabIndex = 17;
            this.groupBox9.TabStop = false;
            // 
            // txtActionType
            // 
            this.txtActionType.Location = new System.Drawing.Point(81, 62);
            this.txtActionType.Name = "txtActionType";
            this.txtActionType.Size = new System.Drawing.Size(266, 20);
            this.txtActionType.TabIndex = 52;
            this.txtActionType.Tag = "readonly";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Action:";
            // 
            // txtQueryType
            // 
            this.txtQueryType.Location = new System.Drawing.Point(82, 36);
            this.txtQueryType.Name = "txtQueryType";
            this.txtQueryType.Size = new System.Drawing.Size(266, 20);
            this.txtQueryType.TabIndex = 50;
            this.txtQueryType.Tag = "readonly";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Query Type:";
            // 
            // txtQueryName
            // 
            this.txtQueryName.Location = new System.Drawing.Point(81, 13);
            this.txtQueryName.Name = "txtQueryName";
            this.txtQueryName.Size = new System.Drawing.Size(266, 20);
            this.txtQueryName.TabIndex = 48;
            this.txtQueryName.Tag = "readonly";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Query Name:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(76, 6);
            // 
            // cmbRulAllQueries
            // 
            this.cmbRulAllQueries.Image = ((System.Drawing.Image)(resources.GetObject("cmbRulAllQueries.Image")));
            this.cmbRulAllQueries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmbRulAllQueries.Name = "cmbRulAllQueries";
            this.cmbRulAllQueries.Size = new System.Drawing.Size(76, 20);
            this.cmbRulAllQueries.Text = "Run Al&l";
            this.cmbRulAllQueries.Click += new System.EventHandler(this.cmbRulAllQueries_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "false";
            this.dataGridViewCheckBoxColumn1.Frozen = true;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "true";
            this.dataGridViewCheckBoxColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.FalseValue = "False";
            this.dataGridViewCheckBoxColumn2.Frozen = true;
            this.dataGridViewCheckBoxColumn2.HeaderText = "Identity";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.TrueValue = "True";
            this.dataGridViewCheckBoxColumn2.Width = 50;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.FalseValue = "False";
            this.dataGridViewCheckBoxColumn3.Frozen = true;
            this.dataGridViewCheckBoxColumn3.HeaderText = "Where";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.TrueValue = "true";
            this.dataGridViewCheckBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Default Value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.FalseValue = "false";
            this.dataGridViewCheckBoxColumn4.Frozen = true;
            this.dataGridViewCheckBoxColumn4.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.TrueValue = "true";
            this.dataGridViewCheckBoxColumn4.Width = 43;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Type";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "SP Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Method Name";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Action ID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // clmSelected
            // 
            this.clmSelected.FalseValue = "0";
            this.clmSelected.Frozen = true;
            this.clmSelected.HeaderText = "Select";
            this.clmSelected.Name = "clmSelected";
            this.clmSelected.TrueValue = "1";
            this.clmSelected.Width = 43;
            // 
            // clmQueryName
            // 
            this.clmQueryName.Frozen = true;
            this.clmQueryName.HeaderText = "Name";
            this.clmQueryName.Name = "clmQueryName";
            this.clmQueryName.Width = 150;
            // 
            // clmType_DBAction
            // 
            this.clmType_DBAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmType_DBAction.Frozen = true;
            this.clmType_DBAction.HeaderText = "Type";
            this.clmType_DBAction.Name = "clmType_DBAction";
            this.clmType_DBAction.Width = 80;
            // 
            // clmActionType_DBAction
            // 
            this.clmActionType_DBAction.HeaderText = "Action";
            this.clmActionType_DBAction.Name = "clmActionType_DBAction";
            // 
            // clmDALMethodName_DBAction
            // 
            this.clmDALMethodName_DBAction.HeaderText = "Method Name";
            this.clmDALMethodName_DBAction.Name = "clmDALMethodName_DBAction";
            // 
            // clmActionID
            // 
            this.clmActionID.HeaderText = "Action ID";
            this.clmActionID.Name = "clmActionID";
            // 
            // clmID
            // 
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
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
            this.clmName.Width = 150;
            // 
            // clmType
            // 
            this.clmType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmType.Frozen = true;
            this.clmType.HeaderText = "Type";
            this.clmType.Name = "clmType";
            this.clmType.Width = 80;
            // 
            // clmIdentity
            // 
            this.clmIdentity.FalseValue = "False";
            this.clmIdentity.Frozen = true;
            this.clmIdentity.HeaderText = "Identity";
            this.clmIdentity.Name = "clmIdentity";
            this.clmIdentity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmIdentity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmIdentity.TrueValue = "True";
            this.clmIdentity.Width = 50;
            // 
            // clmWhere
            // 
            this.clmWhere.FalseValue = "False";
            this.clmWhere.Frozen = true;
            this.clmWhere.HeaderText = "Where";
            this.clmWhere.Name = "clmWhere";
            this.clmWhere.TrueValue = "true";
            this.clmWhere.Width = 50;
            // 
            // clmDefaultValue
            // 
            this.clmDefaultValue.Frozen = true;
            this.clmDefaultValue.HeaderText = "Default Value";
            this.clmDefaultValue.Name = "clmDefaultValue";
            // 
            // frmSQLGeneratorMSSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1463, 661);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.gbRight);
            this.MaximizeBox = false;
            this.Name = "frmSQLGeneratorMSSQLServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS SQL Server Query Generator";
            this.Load += new System.EventHandler(this.frmSQLGeneratorMSSQLServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Solutions_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDB_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableColumns_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionDBQuery_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDBTables_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionDB_TableColumns_bindingSource)).EndInit();
            this.gbRight.ResumeLayout(false);
            this.gbRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnMain)).EndInit();
            this.bnMain.ResumeLayout(false);
            this.bnMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTableColumns)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgSolutionDBQuery)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource Solutions_bindingSource;
        private System.Windows.Forms.BindingSource SolutionsDB_bindingSource;
        private System.Windows.Forms.BindingSource TableColumns_bindingSource;
        private System.Windows.Forms.BindingSource SolutionDBQuery_bindingSource;
        private System.Windows.Forms.BindingSource SolutionsDBTables_bindingSource;
        private System.Windows.Forms.BindingSource SolutionDB_TableColumns_bindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
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
        private System.Windows.Forms.DataGridView dvgTableColumns;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbkSelectAll;
        private System.Windows.Forms.Button cmdColumns;
        private System.Windows.Forms.ComboBox cmbDBTables;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dvgSolutionDBQuery;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtGeneratedQuery;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtActionType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQueryType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQueryName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQueryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmType_DBAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmActionType_DBAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDALMethodName_DBAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmActionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIdentity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmWhere;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button cmdGeneratorQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton cmbRulAllQueries;
    }
}