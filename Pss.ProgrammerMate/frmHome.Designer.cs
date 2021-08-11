namespace Pss.ProgrammerMate
{
    partial class frmHome
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.solutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solutionsDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSServerServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.simpleAndLiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBTableFolderMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solutionProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPICreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wCFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.webAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.AutoSize = false;
            this.msMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solutionsToolStripMenuItem,
            this.solutionsDBToolStripMenuItem,
            this.sQLGeneratorToolStripMenuItem,
            this.dBTableFolderMappingToolStripMenuItem,
            this.solutionProjectsToolStripMenuItem,
            this.businessEntityToolStripMenuItem,
            this.dataAccessToolStripMenuItem,
            this.uIDesktopToolStripMenuItem,
            this.aPICreationToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1193, 37);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // solutionsToolStripMenuItem
            // 
            this.solutionsToolStripMenuItem.Name = "solutionsToolStripMenuItem";
            this.solutionsToolStripMenuItem.Size = new System.Drawing.Size(75, 33);
            this.solutionsToolStripMenuItem.Text = "Solutions";
            this.solutionsToolStripMenuItem.Click += new System.EventHandler(this.solutionsToolStripMenuItem_Click);
            // 
            // solutionsDBToolStripMenuItem
            // 
            this.solutionsDBToolStripMenuItem.Name = "solutionsDBToolStripMenuItem";
            this.solutionsDBToolStripMenuItem.Size = new System.Drawing.Size(97, 33);
            this.solutionsDBToolStripMenuItem.Text = "Solutions DB";
            this.solutionsDBToolStripMenuItem.Click += new System.EventHandler(this.solutionsDBToolStripMenuItem_Click);
            // 
            // sQLGeneratorToolStripMenuItem
            // 
            this.sQLGeneratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSServerServerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.simpleAndLiteToolStripMenuItem});
            this.sQLGeneratorToolStripMenuItem.Name = "sQLGeneratorToolStripMenuItem";
            this.sQLGeneratorToolStripMenuItem.Size = new System.Drawing.Size(109, 33);
            this.sQLGeneratorToolStripMenuItem.Text = "SQL Generator";
            // 
            // mSServerServerToolStripMenuItem
            // 
            this.mSServerServerToolStripMenuItem.Name = "mSServerServerToolStripMenuItem";
            this.mSServerServerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.mSServerServerToolStripMenuItem.Text = "MS Server Server";
            this.mSServerServerToolStripMenuItem.Click += new System.EventHandler(this.mSServerServerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // simpleAndLiteToolStripMenuItem
            // 
            this.simpleAndLiteToolStripMenuItem.Name = "simpleAndLiteToolStripMenuItem";
            this.simpleAndLiteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.simpleAndLiteToolStripMenuItem.Text = "Simple and Lite";
            this.simpleAndLiteToolStripMenuItem.Click += new System.EventHandler(this.simpleAndLiteToolStripMenuItem_Click);
            // 
            // dBTableFolderMappingToolStripMenuItem
            // 
            this.dBTableFolderMappingToolStripMenuItem.Name = "dBTableFolderMappingToolStripMenuItem";
            this.dBTableFolderMappingToolStripMenuItem.Size = new System.Drawing.Size(176, 33);
            this.dBTableFolderMappingToolStripMenuItem.Text = "DB Table Folder Mapping";
            this.dBTableFolderMappingToolStripMenuItem.Click += new System.EventHandler(this.dBTableFolderMappingToolStripMenuItem_Click);
            // 
            // solutionProjectsToolStripMenuItem
            // 
            this.solutionProjectsToolStripMenuItem.Name = "solutionProjectsToolStripMenuItem";
            this.solutionProjectsToolStripMenuItem.Size = new System.Drawing.Size(120, 33);
            this.solutionProjectsToolStripMenuItem.Text = "Solution Projects";
            this.solutionProjectsToolStripMenuItem.Click += new System.EventHandler(this.solutionProjectsToolStripMenuItem_Click);
            // 
            // businessEntityToolStripMenuItem
            // 
            this.businessEntityToolStripMenuItem.Name = "businessEntityToolStripMenuItem";
            this.businessEntityToolStripMenuItem.Size = new System.Drawing.Size(110, 33);
            this.businessEntityToolStripMenuItem.Text = "Business Entity";
            this.businessEntityToolStripMenuItem.Click += new System.EventHandler(this.businessEntityToolStripMenuItem_Click);
            // 
            // dataAccessToolStripMenuItem
            // 
            this.dataAccessToolStripMenuItem.Name = "dataAccessToolStripMenuItem";
            this.dataAccessToolStripMenuItem.Size = new System.Drawing.Size(97, 33);
            this.dataAccessToolStripMenuItem.Text = "Data Access";
            this.dataAccessToolStripMenuItem.Click += new System.EventHandler(this.dataAccessToolStripMenuItem_Click);
            // 
            // uIDesktopToolStripMenuItem
            // 
            this.uIDesktopToolStripMenuItem.Name = "uIDesktopToolStripMenuItem";
            this.uIDesktopToolStripMenuItem.Size = new System.Drawing.Size(87, 33);
            this.uIDesktopToolStripMenuItem.Text = "UI Desktop";
            this.uIDesktopToolStripMenuItem.Click += new System.EventHandler(this.uIDesktopToolStripMenuItem_Click);
            // 
            // aPICreationToolStripMenuItem
            // 
            this.aPICreationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wCFToolStripMenuItem,
            this.toolStripMenuItem2,
            this.webAPIToolStripMenuItem});
            this.aPICreationToolStripMenuItem.Name = "aPICreationToolStripMenuItem";
            this.aPICreationToolStripMenuItem.Size = new System.Drawing.Size(94, 33);
            this.aPICreationToolStripMenuItem.Text = "API Creation";
            // 
            // wCFToolStripMenuItem
            // 
            this.wCFToolStripMenuItem.Name = "wCFToolStripMenuItem";
            this.wCFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wCFToolStripMenuItem.Text = "WCF";
            this.wCFToolStripMenuItem.Click += new System.EventHandler(this.wCFToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // webAPIToolStripMenuItem
            // 
            this.webAPIToolStripMenuItem.Name = "webAPIToolStripMenuItem";
            this.webAPIToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.webAPIToolStripMenuItem.Text = "Web API";
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 488);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pss Programmer Mate 2015";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem solutionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solutionsDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solutionProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBTableFolderMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSServerServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uIDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem simpleAndLiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPICreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wCFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem webAPIToolStripMenuItem;
    }
}