using Pss.ProgrammerMate.UI;
using Pss.ProgrammerMate.WebAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pss.ProgrammerMate
{
    public partial class frmHome : Form
    {

        void OpenForm(Form myForm)
        {
            try
            {
                myForm.MdiParent = this;
                //myForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                myForm.Show();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.MaximizeBox = false;
                myForm.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
            }
        }

        #region "Solutions"
        frmSolutions frmSolutions = new frmSolutions();
        void SolutionsForm()
        {
            try
            {
                if (this.frmSolutions == null || this.frmSolutions.IsDisposed == true)
                {
                    this.frmSolutions = new frmSolutions();
                }

                this.OpenForm(this.frmSolutions);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region " DB"
        frmSolutionsDB frmSolutionsDB = new frmSolutionsDB();
        void SolutionsDBForm()
        {
            try
            {
                if (this.frmSolutionsDB == null || this.frmSolutionsDB.IsDisposed == true)
                {
                    this.frmSolutionsDB = new frmSolutionsDB();
                }

                this.OpenForm(this.frmSolutionsDB);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "SQL Generator"
        frmSQLGenerate frmSQLGenerate = new frmSQLGenerate();

        void SQLGenerateForm()
        {
            try
            {
                if (this.frmSQLGenerate == null || this.frmSQLGenerate.IsDisposed == true)
                {
                    this.frmSQLGenerate = new frmSQLGenerate();
                }

                this.OpenForm(this.frmSQLGenerate);
            }
            catch (Exception ex)
            {

            }
        }

        SQL_Generator.frmSQLGeneratorMSSQLServer frmSqlGeneratorMSSQlServer = new SQL_Generator.frmSQLGeneratorMSSQLServer();
        void SQLGeneratorMSSQLServerForm()
        {
            try
            {
                if (this.frmSqlGeneratorMSSQlServer == null || this.frmSqlGeneratorMSSQlServer.IsDisposed == true)
                {
                    this.frmSqlGeneratorMSSQlServer = new SQL_Generator.frmSQLGeneratorMSSQLServer();
                }

                this.OpenForm(this.frmSqlGeneratorMSSQlServer);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "API & WCF"
        WCFGenerator WCFGenerator = new WCFGenerator();

        void WCFGeneratorForm()
        {
            try
            {
                if (this.WCFGenerator == null || this.WCFGenerator.IsDisposed == true)
                {
                    this.WCFGenerator = new WCFGenerator();
                }

                this.OpenForm(this.WCFGenerator);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Folder & Table Mapping"

        frmSolutionFolderTableMapping frmSolutionFolderTableMapping = new frmSolutionFolderTableMapping();

        void SolutionFolderTableMappingForm()
        {
            try
            {
                if (this.frmSolutionFolderTableMapping == null || this.frmSolutionFolderTableMapping.IsDisposed == true)
                {
                    this.frmSolutionFolderTableMapping = new frmSolutionFolderTableMapping();
                }

                this.OpenForm(this.frmSolutionFolderTableMapping);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Business Entity"
        frmBusinessEntity frmBusinessEntity = new frmBusinessEntity();
        void BusinessEntityForm()
        {
            try
            {
                if (this.frmBusinessEntity == null || this.frmBusinessEntity.IsDisposed == true)
                {
                    this.frmBusinessEntity = new frmBusinessEntity();
                }

                this.OpenForm(this.frmBusinessEntity);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Solution Projects"
        frmProjects frmProjects = new frmProjects();

        void ProjectsForm()
        {
            try
            {
                if (this.frmProjects == null || this.frmProjects.IsDisposed == true)
                {
                    this.frmProjects = new frmProjects();
                }

                this.OpenForm(this.frmProjects);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Data Access"
        frmDataAccess frmDataAccess = new frmDataAccess();

        void DataAccessForm()
        {
            try
            {
                if (this.frmDataAccess == null || this.frmDataAccess.IsDisposed == true)
                {
                    this.frmDataAccess = new frmDataAccess();
                }

                this.OpenForm(this.frmDataAccess);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "UI"        
        WinForm frmWinForm = new WinForm();

        void UIWinForm()
        {
            try
            {
                if (this.frmWinForm == null || this.frmWinForm.IsDisposed == true)
                {
                    this.frmWinForm = new WinForm();
                }

                this.OpenForm(this.frmWinForm);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        public frmHome()
        {
            InitializeComponent();
        }

        private void solutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SolutionsForm();
        }

        private void solutionsDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SolutionsDBForm();
        }

        private void dBSQLGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SQLGenerateForm();
        }

        private void solutionProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ProjectsForm();
        }

        private void dBTableFolderMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SolutionFolderTableMappingForm();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void businessEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BusinessEntityForm();
        }

        private void dataAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataAccessForm();
        }

        private void mSServerServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SQLGeneratorMSSQLServerForm();
        }

        private void uIDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UIWinForm();
        }

        private void simpleAndLiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SQLGenerateForm();
        }

        private void wCFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WCFGeneratorForm();
        }
    }
}
