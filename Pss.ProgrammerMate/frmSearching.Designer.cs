namespace Pss.ProgrammerMate
{
    partial class frmSearching
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
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.Search_txt = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gbHeader.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.lblHeader);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(375, 69);
            this.gbHeader.TabIndex = 4;
            this.gbHeader.TabStop = false;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(3, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(369, 50);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Search";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.cmdSearch);
            this.gbContent.Controls.Add(this.Search_txt);
            this.gbContent.Controls.Add(this.lblName);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gbContent.Location = new System.Drawing.Point(0, 69);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(375, 64);
            this.gbContent.TabIndex = 5;
            this.gbContent.TabStop = false;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdSearch.BackgroundImage = global::Pss.ProgrammerMate.Properties.Resources._1417109725_document_search;
            this.cmdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSearch.Location = new System.Drawing.Point(311, 18);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(46, 34);
            this.cmdSearch.TabIndex = 36;
            this.cmdSearch.UseVisualStyleBackColor = false;
            // 
            // Search_txt
            // 
            this.Search_txt.Location = new System.Drawing.Point(93, 18);
            this.Search_txt.Name = "Search_txt";
            this.Search_txt.Size = new System.Drawing.Size(212, 25);
            this.Search_txt.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 17);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "Search Text";
            // 
            // frmSearching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 133);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.gbHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearching";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Searching";
            this.gbHeader.ResumeLayout(false);
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Button cmdSearch;
        public System.Windows.Forms.TextBox Search_txt;
        private System.Windows.Forms.Label lblName;

    }
}