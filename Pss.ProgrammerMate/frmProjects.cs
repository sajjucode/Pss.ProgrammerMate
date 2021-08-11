using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.DAL;
using PSS.DAL.COMMON;
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
    public partial class frmProjects : Form
    {

        #region "Solutions"
        void getList_Solutions()
        {
            try
            {

                DataTable myDataTable_Solutions = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");                
                myDataTable_Solutions = new SolutionsDAL().getList(1000, 1, "ID", "asc");


                this.Solutions_bindingSource.DataSource = myDataTable_Solutions;
                //this.bnMain.BindingSource = this.Solutions_bindingSource;

                this.dvgSolutions.DataSource = null;
                this.txtSolutionID.DataBindings.Clear();

                this.txtSolutionID.DataBindings.Add("Text", this.Solutions_bindingSource, "ID", false, DataSourceUpdateMode.Never, "new");
                this.dvgSolutions.DataSource = this.Solutions_bindingSource;

                this.dvgSolutions.Columns["clmSolutionName"].DataPropertyName = "SolutionName";

                this.dvgSolutions.Refresh();
                this.dvgSolutions.Update();


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }
        #endregion

        #region "Projects"
        private Boolean isNew_Projects, isEdit_Projects, isDelete_Projects;
        private Boolean isMapped_Projects, isSearch;
        clsActionStatus clsActionStatus = new clsActionStatus();

        ProjectsDAL ProjectsDAL = new ProjectsDAL();

        void New_Projects()
        {
            try
            {

                this.isNew_Projects = true;
                this.isEdit_Projects= false;

                new Appearances.SetFocusBlur_Color().ClearAllControl_GroupBox(gbContent);
                this.txtID.Text = CommonClasses.CommonVariables.New_IntialValue;
                this.cbkisActive.Checked = true;
                this.cmbProjectType.Focus();
            }

            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Projects");

            }
        }

        void Update_Projects()
        {
            try
            {
                ProjectsDAL = new DAL.ProjectsDAL();

                clsActionStatus = new clsActionStatus();

                ProjectsDAL.ID = this.txtID.Text == CommonVariables.New_IntialValue ? 0 : int.Parse(this.txtID.Text);
                ProjectsDAL.SolutionID = int.Parse(this.txtSolutionID.Text);
                ProjectsDAL.ProjectType = this.cmbProjectType.Text;
                ProjectsDAL.ProjectName = this.txtProjectName.Text;
                ProjectsDAL.PDescription = this.txtPDescription.Text;
                ProjectsDAL.PNameSpace = this.txtPNameSpace.Text;
                ProjectsDAL.MethodNamingFormat = this.txtMethodNamingFormat.Text;
                ProjectsDAL.BaseFolder = this.txtBaseFolder.Text;
                
                ProjectsDAL.UserId = CommonClasses.Security.UserID;
                ProjectsDAL.isActive = this.cbkisActive.Checked;

                if (isNew_Projects == false && isEdit_Projects == false)
                {
                    Messages.Edit_New_error("Project");
                    return;
                }

                if (ProjectsDAL.ID > 0)
                {
                    clsActionStatus = ProjectsDAL.Update();
                }
                else
                {
                    clsActionStatus = ProjectsDAL.Insert();
                }

                if (clsActionStatus.is_Error == false)
                {
                    isNew_Projects= isEdit_Projects= false;
                    Messages.SuccessMessage(clsActionStatus.Action_SuccessStatus, "Project");

                    this.txtID.Text = clsActionStatus.Return_Id;


                    this.Solutions_bindingSource.EndEdit();

                    if (ProjectsDAL.ID <= 0)
                    {
                        if (Messages.myAddMore("Project") == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.txtID.Focus();
                            this.New_Projects();
                        }
                    }

                }
                else
                {
                    Messages.GeneralError(clsActionStatus.Action_FailureStatus, "Project");
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Projects");
            }
        }

        void Edit_Projects()
        {
            try
            {
                this.isEdit_Projects = true;
                this.isNew_Projects= false;
                this.cmbProjectType.Focus();
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project");
            }
        }

        void Cancel_Projects()
        {
            try
            {
                if (Messages.myCancelMsgBox("Project") == System.Windows.Forms.DialogResult.Yes)
                {
                    this.isEdit_Projects= false;
                    this.isNew_Projects= false;

                    this.Projects_bindingSource.CancelEdit();
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project");
            }
        }

        void Delete_Projects()
        {
            try
            {
                if (Messages.myDeleteMsgBox("Project", this.txtProjectName.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    ProjectsDAL = new DAL.ProjectsDAL();
                    clsActionStatus = new clsActionStatus();

                    ProjectsDAL.ID = int.Parse(this.txtID.Text);

                    clsActionStatus = ProjectsDAL.Delete();

                    if (clsActionStatus.is_Error == false)
                    {
                        isNew_Projects= false;
                        isEdit_Projects= false;
                        Messages.DeletionMessage(clsActionStatus.Action_SuccessStatus, "Project");

                        this.Projects_bindingSource.RemoveCurrent();

                    }
                    else
                    {
                        Messages.DeletionMessage(clsActionStatus.Action_FailureStatus, "Project");
                    }


                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project");
            }
        }

        void Binding_Projects()
        {
            try
            {
                this.txtID.DataBindings.Add("Text", this.Projects_bindingSource, "ID", false, DataSourceUpdateMode.Never, "new");
                this.cmbProjectType.DataBindings.Add("Text", this.Projects_bindingSource, "ProjectType", false);
                this.txtProjectName.DataBindings.Add("Text", this.Projects_bindingSource, "ProjectName", false);
                this.txtPDescription.DataBindings.Add("Text", this.Projects_bindingSource, "PDescription", false);
                this.txtPNameSpace.DataBindings.Add("Text", this.Projects_bindingSource, "PNameSpace", false);
                this.txtMethodNamingFormat.DataBindings.Add("Text", this.Projects_bindingSource, "MethodNamingFormat", false);

                this.txtBaseFolder.DataBindings.Add("Text", this.Projects_bindingSource, "BaseFolder", false);

                this.cbkisActive.DataBindings.Add("Checked", this.Projects_bindingSource, "isActive", true);
                this.txtCreatedOnUtc.DataBindings.Add("Text", this.Projects_bindingSource, "CreatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
                this.txtUpdatedOnUtc.DataBindings.Add("Text", this.Projects_bindingSource, "UpdatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project");
            }
        }
        void ViewAll_Projects(Boolean isSearch = false, string SearchText = "")
        {
            try
            {

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                if (isSearch == true)
                {

                    myDataTable_SolutionsDB = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.txtSolutionID.Text + " and (ProjectName like '" + SearchText + "%' or ProjectType like '" + SearchText + "%')", "ID", "asc");
                }
                else
                {
                    myDataTable_SolutionsDB = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.txtSolutionID.Text, "ID");
                }

                this.Projects_bindingSource.DataSource = myDataTable_SolutionsDB;

                this.bnMain.BindingSource = this.Projects_bindingSource;

                if (this.isMapped_Projects== false)
                {

                    this.Binding_Projects();
                    this.isMapped_Projects= true;

                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project");
            }
        }


        void Search_Projects()
        {
            try
            {
                frmSearching frmSearching = new frmSearching();

                //frmSearching.MdiParent = this.MdiParent;

                if (frmSearching.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.ViewAll_Projects(true, frmSearching.Search_txt.Text);

                    frmSearching.Close();
                    frmSearching.Dispose();
                }
            }

            catch (Exception ex)
            {
            }
        }

        #endregion

        public frmProjects()
        {
            InitializeComponent();
        }

        private void frmProjects_Load(object sender, EventArgs e)
        {
            try
            {
                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgSolutions);
                this.dvgSolutions.AutoGenerateColumns = false;

                this.getList_Solutions();
            }
            catch (Exception ex)
            {
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSolutionID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.ViewAll_Projects();
            }
            catch (Exception ex)
            {

            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            this.New_Projects();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            this.Update_Projects();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            this.Edit_Projects();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            this.Delete_Projects();
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_Projects();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bnbtnNew_Click(object sender, EventArgs e)
        {
            this.New_Projects();
        }

        private void bnbtnSave_Click(object sender, EventArgs e)
        {
            this.Update_Projects();
        }

        private void bnbtnViewAll_Click(object sender, EventArgs e)
        {
            this.ViewAll_Projects();
        }

        private void bnbtnSearch_Click(object sender, EventArgs e)
        {
            this.Search_Projects();
        }

        private void bnbtnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_Projects();
        }

        private void bnbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBrowseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.folderBrowserDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                {
                    this.txtBaseFolder.Text = this.folderBrowserDialog1.SelectedPath.ToString();
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
