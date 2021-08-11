namespace Pss.ProgrammerMate
{
    partial class frmSolutionFolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolutionFolders));
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
            this.mnuFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbtnViewAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dvgSolutions = new System.Windows.Forms.DataGridView();
            this.clmSolutionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSolutionID = new System.Windows.Forms.TextBox();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.chkisCreateFolder = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbParentFolderId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamespaceFormat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbkisActive = new System.Windows.Forms.CheckBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.txtUpdatedOnUtc = new System.Windows.Forms.TextBox();
            this.UpdatedOnUtc = new System.Windows.Forms.Label();
            this.txtCreatedOnUtc = new System.Windows.Forms.TextBox();
            this.lbleCreatedOnUtc = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.Solutions_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SolutionFolders_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtInterfaceNamespaceFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnMain)).BeginInit();
            this.bnMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSolutions)).BeginInit();
            this.gbContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Solutions_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionFolders_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRight
            // 
            this.gbRight.Controls.Add(this.bnMain);
            this.gbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbRight.Location = new System.Drawing.Point(630, 0);
            this.gbRight.Name = "gbRight";
            this.gbRight.Size = new System.Drawing.Size(84, 427);
            this.gbRight.TabIndex = 10;
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
            this.mnuFile,
            this.toolStripSeparator1,
            this.bnbtnNew,
            this.toolStripSeparator2,
            this.bnbtnSave,
            this.toolStripSeparator10,
            this.bnbtnViewAll,
            this.toolStripSeparator3,
            this.bnbtnSearch,
            this.toolStripSeparator4,
            this.bnbtnCancel,
            this.toolStripSeparator7,
            this.bnbtnExit,
            this.toolStripSeparator8});
            this.bnMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.bnMain.Location = new System.Drawing.Point(3, 16);
            this.bnMain.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnMain.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnMain.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnMain.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnMain.Name = "bnMain";
            this.bnMain.PositionItem = this.bindingNavigatorPositionItem;
            this.bnMain.Size = new System.Drawing.Size(78, 408);
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
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripSeparator6,
            this.mnuSave,
            this.toolStripMenuItem1,
            this.mnuEdit,
            this.toolStripMenuItem2,
            this.mnuDelete,
            this.toolStripMenuItem3,
            this.mnuCancel,
            this.toolStripMenuItem5,
            this.mnuClose,
            this.toolStripSeparator5});
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(76, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuNew
            // 
            this.mnuNew.Image = global::Pss.ProgrammerMate.Properties.Resources._1416248218_Add;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(151, 22);
            this.mnuNew.Text = "&New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = global::Pss.ProgrammerMate.Properties.Resources._1416248239_Save;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(151, 22);
            this.mnuSave.Text = "&Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Pss.ProgrammerMate.Properties.Resources._1417106980_document_edit;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEdit.Size = new System.Drawing.Size(151, 22);
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Pss.ProgrammerMate.Properties.Resources._1417107109_folder_delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDelete.Size = new System.Drawing.Size(151, 22);
            this.mnuDelete.Text = "&Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Image = global::Pss.ProgrammerMate.Properties.Resources._1417107178_cancel;
            this.mnuCancel.Name = "mnuCancel";
            this.mnuCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuCancel.Size = new System.Drawing.Size(151, 22);
            this.mnuCancel.Text = "&Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuClose
            // 
            this.mnuClose.Image = global::Pss.ProgrammerMate.Properties.Resources._1417110356_Log_Out;
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.mnuClose.Size = new System.Drawing.Size(151, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(148, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(76, 6);
            // 
            // bnbtnNew
            // 
            this.bnbtnNew.Image = global::Pss.ProgrammerMate.Properties.Resources._1416248218_Add;
            this.bnbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnbtnNew.Name = "bnbtnNew";
            this.bnbtnNew.Size = new System.Drawing.Size(76, 20);
            this.bnbtnNew.Text = "&New";
            this.bnbtnNew.Click += new System.EventHandler(this.bnbtnNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(76, 6);
            // 
            // bnbtnSave
            // 
            this.bnbtnSave.Image = global::Pss.ProgrammerMate.Properties.Resources._1416248239_Save;
            this.bnbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnbtnSave.Name = "bnbtnSave";
            this.bnbtnSave.Size = new System.Drawing.Size(76, 20);
            this.bnbtnSave.Text = "&Save";
            this.bnbtnSave.Click += new System.EventHandler(this.bnbtnSave_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(76, 6);
            // 
            // bnbtnViewAll
            // 
            this.bnbtnViewAll.Image = global::Pss.ProgrammerMate.Properties.Resources._1417109849_view_refresh_32;
            this.bnbtnViewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnbtnViewAll.Name = "bnbtnViewAll";
            this.bnbtnViewAll.Size = new System.Drawing.Size(76, 20);
            this.bnbtnViewAll.Text = "&View All";
            this.bnbtnViewAll.Click += new System.EventHandler(this.bnbtnViewAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(76, 6);
            // 
            // bnbtnSearch
            // 
            this.bnbtnSearch.Image = global::Pss.ProgrammerMate.Properties.Resources._1417109725_document_search;
            this.bnbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnbtnSearch.Name = "bnbtnSearch";
            this.bnbtnSearch.Size = new System.Drawing.Size(76, 20);
            this.bnbtnSearch.Text = "Searc&h";
            this.bnbtnSearch.Click += new System.EventHandler(this.bnbtnSearch_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(76, 6);
            // 
            // bnbtnCancel
            // 
            this.bnbtnCancel.Image = global::Pss.ProgrammerMate.Properties.Resources._1417107178_cancel;
            this.bnbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnbtnCancel.Name = "bnbtnCancel";
            this.bnbtnCancel.Size = new System.Drawing.Size(76, 20);
            this.bnbtnCancel.Text = "&Cancel";
            this.bnbtnCancel.Click += new System.EventHandler(this.bnbtnCancel_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(76, 6);
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(76, 6);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.lblHeader);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(630, 58);
            this.gbHeader.TabIndex = 11;
            this.gbHeader.TabStop = false;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblHeader.Location = new System.Drawing.Point(3, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(624, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Solution Folders";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dvgSolutions);
            this.groupBox1.Controls.Add(this.txtSolutionID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 369);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solutions";
            // 
            // dvgSolutions
            // 
            this.dvgSolutions.AllowUserToAddRows = false;
            this.dvgSolutions.AllowUserToDeleteRows = false;
            this.dvgSolutions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgSolutions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgSolutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgSolutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSolutionName});
            this.dvgSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgSolutions.Location = new System.Drawing.Point(3, 16);
            this.dvgSolutions.Name = "dvgSolutions";
            this.dvgSolutions.RowHeadersVisible = false;
            this.dvgSolutions.Size = new System.Drawing.Size(219, 350);
            this.dvgSolutions.TabIndex = 1;
            // 
            // clmSolutionName
            // 
            this.clmSolutionName.HeaderText = "Solution Name";
            this.clmSolutionName.Name = "clmSolutionName";
            // 
            // txtSolutionID
            // 
            this.txtSolutionID.Location = new System.Drawing.Point(55, 85);
            this.txtSolutionID.Name = "txtSolutionID";
            this.txtSolutionID.Size = new System.Drawing.Size(94, 20);
            this.txtSolutionID.TabIndex = 45;
            this.txtSolutionID.Tag = "readonly";
            this.txtSolutionID.TextChanged += new System.EventHandler(this.txtSolutionID_TextChanged);
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.txtInterfaceNamespaceFormat);
            this.gbContent.Controls.Add(this.label1);
            this.gbContent.Controls.Add(this.chkisCreateFolder);
            this.gbContent.Controls.Add(this.label6);
            this.gbContent.Controls.Add(this.txtFDescription);
            this.gbContent.Controls.Add(this.label4);
            this.gbContent.Controls.Add(this.cmbParentFolderId);
            this.gbContent.Controls.Add(this.label3);
            this.gbContent.Controls.Add(this.txtNamespaceFormat);
            this.gbContent.Controls.Add(this.label2);
            this.gbContent.Controls.Add(this.cbkisActive);
            this.gbContent.Controls.Add(this.lblIsActive);
            this.gbContent.Controls.Add(this.txtUpdatedOnUtc);
            this.gbContent.Controls.Add(this.UpdatedOnUtc);
            this.gbContent.Controls.Add(this.txtCreatedOnUtc);
            this.gbContent.Controls.Add(this.lbleCreatedOnUtc);
            this.gbContent.Controls.Add(this.txtID);
            this.gbContent.Controls.Add(this.txtFolderName);
            this.gbContent.Controls.Add(this.lblId);
            this.gbContent.Controls.Add(this.lblName);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gbContent.Location = new System.Drawing.Point(225, 58);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(405, 369);
            this.gbContent.TabIndex = 13;
            this.gbContent.TabStop = false;
            // 
            // chkisCreateFolder
            // 
            this.chkisCreateFolder.AutoSize = true;
            this.chkisCreateFolder.Location = new System.Drawing.Point(112, 250);
            this.chkisCreateFolder.Name = "chkisCreateFolder";
            this.chkisCreateFolder.Size = new System.Drawing.Size(15, 14);
            this.chkisCreateFolder.TabIndex = 7;
            this.chkisCreateFolder.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 53;
            this.label6.Text = "Create Folder:";
            // 
            // txtFDescription
            // 
            this.txtFDescription.Location = new System.Drawing.Point(105, 182);
            this.txtFDescription.Multiline = true;
            this.txtFDescription.Name = "txtFDescription";
            this.txtFDescription.Size = new System.Drawing.Size(271, 60);
            this.txtFDescription.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 49;
            this.label4.Text = "Description:";
            // 
            // cmbParentFolderId
            // 
            this.cmbParentFolderId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentFolderId.FormattingEnabled = true;
            this.cmbParentFolderId.Items.AddRange(new object[] {
            "Business Entity",
            "Data Access",
            "Web API",
            "UI"});
            this.cmbParentFolderId.Location = new System.Drawing.Point(105, 59);
            this.cmbParentFolderId.Name = "cmbParentFolderId";
            this.cmbParentFolderId.Size = new System.Drawing.Size(271, 25);
            this.cmbParentFolderId.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Parent:";
            // 
            // txtNamespaceFormat
            // 
            this.txtNamespaceFormat.Location = new System.Drawing.Point(105, 121);
            this.txtNamespaceFormat.Name = "txtNamespaceFormat";
            this.txtNamespaceFormat.Size = new System.Drawing.Size(271, 25);
            this.txtNamespaceFormat.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "cls Namespace:";
            // 
            // cbkisActive
            // 
            this.cbkisActive.AutoSize = true;
            this.cbkisActive.Location = new System.Drawing.Point(112, 278);
            this.cbkisActive.Name = "cbkisActive";
            this.cbkisActive.Size = new System.Drawing.Size(15, 14);
            this.cbkisActive.TabIndex = 8;
            this.cbkisActive.UseVisualStyleBackColor = true;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(12, 276);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(50, 17);
            this.lblIsActive.TabIndex = 39;
            this.lblIsActive.Text = "Enable:";
            // 
            // txtUpdatedOnUtc
            // 
            this.txtUpdatedOnUtc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUpdatedOnUtc.Location = new System.Drawing.Point(105, 335);
            this.txtUpdatedOnUtc.Name = "txtUpdatedOnUtc";
            this.txtUpdatedOnUtc.ReadOnly = true;
            this.txtUpdatedOnUtc.Size = new System.Drawing.Size(228, 25);
            this.txtUpdatedOnUtc.TabIndex = 11;
            // 
            // UpdatedOnUtc
            // 
            this.UpdatedOnUtc.AutoSize = true;
            this.UpdatedOnUtc.Location = new System.Drawing.Point(12, 338);
            this.UpdatedOnUtc.Name = "UpdatedOnUtc";
            this.UpdatedOnUtc.Size = new System.Drawing.Size(78, 17);
            this.UpdatedOnUtc.TabIndex = 38;
            this.UpdatedOnUtc.Text = "Updated At:";
            // 
            // txtCreatedOnUtc
            // 
            this.txtCreatedOnUtc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCreatedOnUtc.Location = new System.Drawing.Point(105, 303);
            this.txtCreatedOnUtc.Name = "txtCreatedOnUtc";
            this.txtCreatedOnUtc.ReadOnly = true;
            this.txtCreatedOnUtc.Size = new System.Drawing.Size(228, 25);
            this.txtCreatedOnUtc.TabIndex = 10;
            // 
            // lbleCreatedOnUtc
            // 
            this.lbleCreatedOnUtc.AutoSize = true;
            this.lbleCreatedOnUtc.Location = new System.Drawing.Point(12, 306);
            this.lbleCreatedOnUtc.Name = "lbleCreatedOnUtc";
            this.lbleCreatedOnUtc.Size = new System.Drawing.Size(73, 17);
            this.lbleCreatedOnUtc.TabIndex = 37;
            this.lbleCreatedOnUtc.Text = "Created At:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(105, 28);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(94, 25);
            this.txtID.TabIndex = 1;
            this.txtID.Tag = "readonly";
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(105, 90);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(271, 25);
            this.txtFolderName.TabIndex = 3;
            this.txtFolderName.Tag = "nospace";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 31);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 17);
            this.lblId.TabIndex = 36;
            this.lblId.Text = "ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 93);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 17);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "Name:";
            // 
            // txtInterfaceNamespaceFormat
            // 
            this.txtInterfaceNamespaceFormat.Location = new System.Drawing.Point(105, 152);
            this.txtInterfaceNamespaceFormat.Name = "txtInterfaceNamespaceFormat";
            this.txtInterfaceNamespaceFormat.Size = new System.Drawing.Size(271, 25);
            this.txtInterfaceNamespaceFormat.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "IntFace Nmspace:";
            // 
            // frmSolutionFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(714, 427);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.gbRight);
            this.MaximizeBox = false;
            this.Name = "frmSolutionFolders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solutions Folder";
            this.Load += new System.EventHandler(this.frmSolutionFolders_Load);
            this.gbRight.ResumeLayout(false);
            this.gbRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnMain)).EndInit();
            this.bnMain.ResumeLayout(false);
            this.bnMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSolutions)).EndInit();
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Solutions_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionFolders_bindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStripDropDownButton mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bnbtnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bnbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton bnbtnViewAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bnbtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bnbtnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton bnbtnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dvgSolutions;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSolutionName;
        private System.Windows.Forms.TextBox txtSolutionID;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamespaceFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbkisActive;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.TextBox txtUpdatedOnUtc;
        private System.Windows.Forms.Label UpdatedOnUtc;
        private System.Windows.Forms.TextBox txtCreatedOnUtc;
        private System.Windows.Forms.Label lbleCreatedOnUtc;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbParentFolderId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkisCreateFolder;
        private System.Windows.Forms.BindingSource Solutions_bindingSource;
        private System.Windows.Forms.BindingSource SolutionFolders_bindingSource;
        private System.Windows.Forms.TextBox txtInterfaceNamespaceFormat;
        private System.Windows.Forms.Label label1;
    }
}