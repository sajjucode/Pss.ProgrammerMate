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
    public partial class frmSolutionFolders : Form
    {

        #region "Solutions"
        public void getList_Solutions(Int64 SolutionID=0)
        {
            try
            {
                this.dvgSolutions.AutoGenerateColumns = false;
                DataTable myDataTable_Solutions = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");                
                if (SolutionID == 0)
                {
                    myDataTable_Solutions = new SolutionsDAL().getList(1000, 1, "ID", "asc");
                }
                else
                {
                    myDataTable_Solutions = new SolutionsDAL().getInfo(SolutionID);
                }


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

        #region "SolutionFolders"
        private Boolean isNew_SolutionFolders, isEdit_SolutionFolders, isDelete_SolutionFolders;
        private Boolean isMapped_SolutionFolders, isSearch;
        clsActionStatus clsActionStatus = new clsActionStatus();

        SolutionFoldersDAL SolutionFoldersDAL = new SolutionFoldersDAL();

        void New_SolutionFolders()
        {
            try
            {

                this.isNew_SolutionFolders = true;
                this.isEdit_SolutionFolders = false;

                new Appearances.SetFocusBlur_Color().ClearAllControl_GroupBox(gbContent);
                this.txtID.Text = CommonClasses.CommonVariables.New_IntialValue;
                //this.txtNamespaceFormat.Text = "{Parent}.Model.{FolderName}";
                this.txtNamespaceFormat.Text = "{Parent}.{FolderName}";
                this.txtInterfaceNamespaceFormat.Text = "{Parent}.Interface.{FolderName}";
                this.chkisCreateFolder.Checked = true;
                this.cbkisActive.Checked = true;
                this.cmbParentFolderId.Focus();
            }

            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solution Folders");

            }
        }

        void Update_SolutionFolders()
        {
            try
            {
                SolutionFoldersDAL = new DAL.SolutionFoldersDAL();

                clsActionStatus = new clsActionStatus();

                SolutionFoldersDAL.ID = this.txtID.Text == CommonVariables.New_IntialValue ? 0 : int.Parse(this.txtID.Text);
                SolutionFoldersDAL.SolutionID = int.Parse(this.txtSolutionID.Text);
                SolutionFoldersDAL.ParentFolderId = 0; //int.Parse(this.cmbParentFolderId.SelectedValue.ToString());
                SolutionFoldersDAL.FolderName = this.txtFolderName.Text;
                SolutionFoldersDAL.NamespaceFormat = this.txtNamespaceFormat.Text;
                SolutionFoldersDAL.FDescription = this.txtFDescription.Text;
                SolutionFoldersDAL.InterfaceNamespaceFormat = this.txtInterfaceNamespaceFormat.Text;
                SolutionFoldersDAL.isCreateFolder = this.chkisCreateFolder.Checked;

                SolutionFoldersDAL.UserId = CommonClasses.Security.UserID;
                SolutionFoldersDAL.isActive = this.cbkisActive.Checked;

                if (isNew_SolutionFolders == false && isEdit_SolutionFolders == false)
                {
                    Messages.Edit_New_error("Solution Folders");
                    return;
                }

                if (SolutionFoldersDAL.ID > 0)
                {
                    clsActionStatus = SolutionFoldersDAL.Update();
                }
                else
                {
                    clsActionStatus = SolutionFoldersDAL.Insert();
                }

                if (clsActionStatus.is_Error == false)
                {
                    isNew_SolutionFolders = isEdit_SolutionFolders = false;
                    Messages.SuccessMessage(clsActionStatus.Action_SuccessStatus, "Solution Folders");

                    this.txtID.Text = clsActionStatus.Return_Id;


                    this.Solutions_bindingSource.EndEdit();

                    if (SolutionFoldersDAL.ID <= 0)
                    {
                        if (Messages.myAddMore("Solution Folders") == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.txtID.Focus();
                            this.New_SolutionFolders();
                        }
                    }

                }
                else
                {
                    Messages.GeneralError(clsActionStatus.Action_FailureStatus, "Solution Folders");
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " SolutionFolders");
            }
        }

        void Edit_SolutionFolders()
        {
            try
            {
                this.isEdit_SolutionFolders = true;
                this.isNew_SolutionFolders = false;
                this.cmbParentFolderId.Focus();
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solution Folders");
            }
        }

        void Cancel_SolutionFolders()
        {
            try
            {
                if (Messages.myCancelMsgBox("Solution Folders") == System.Windows.Forms.DialogResult.Yes)
                {
                    this.isEdit_SolutionFolders = false;
                    this.isNew_SolutionFolders = false;

                    this.SolutionFolders_bindingSource.CancelEdit();
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solution Folders");
            }
        }

        void Delete_SolutionFolders()
        {
            try
            {
                if (Messages.myDeleteMsgBox("Solution Folders", this.txtFolderName.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    SolutionFoldersDAL = new DAL.SolutionFoldersDAL();
                    clsActionStatus = new clsActionStatus();

                    SolutionFoldersDAL.ID = int.Parse(this.txtID.Text);

                    clsActionStatus = SolutionFoldersDAL.Delete();

                    if (clsActionStatus.is_Error == false)
                    {
                        isNew_SolutionFolders = false;
                        isEdit_SolutionFolders = false;
                        Messages.DeletionMessage(clsActionStatus.Action_SuccessStatus, "Solution Folders");

                        this.SolutionFolders_bindingSource.RemoveCurrent();

                    }
                    else
                    {
                        Messages.DeletionMessage(clsActionStatus.Action_FailureStatus, "Solution Folders");
                    }


                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solution Folders");
            }
        }

        void Binding_SolutionFolders()
        {
            try
            {
                this.txtID.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "ID", false, DataSourceUpdateMode.Never, "new");
                this.cmbParentFolderId.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "ParentFolderId", false);
                this.txtFolderName.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "FolderName", false);
                this.txtFDescription.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "FDescription", false);
                this.txtNamespaceFormat.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "NamespaceFormat", false);
                this.chkisCreateFolder.DataBindings.Add("Checked", this.SolutionFolders_bindingSource, "isCreateFolder", true);

                this.txtInterfaceNamespaceFormat.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "InterfaceNamespaceFormat", false);

                this.cbkisActive.DataBindings.Add("Checked", this.SolutionFolders_bindingSource, "isActive", true);
                this.txtCreatedOnUtc.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "CreatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
                this.txtUpdatedOnUtc.DataBindings.Add("Text", this.SolutionFolders_bindingSource, "UpdatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solution Folders");
            }
        }
        void ViewAll_SolutionFolders(Boolean isSearch = false, string SearchText = "")
        {
            try
            {

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                if (isSearch == true)
                {

                    myDataTable_SolutionsDB = new SolutionFoldersDAL().getList_Search(1000, 1, " SolutionID=" + this.txtSolutionID.Text + " and (FolderName like '" + SearchText + "%' or NamespaceFormat like '" + SearchText + "%')", "ID", "asc");
                }
                else
                {
                    myDataTable_SolutionsDB = new SolutionFoldersDAL().getList_Search(1000, 1, " SolutionID=" + this.txtSolutionID.Text, "ID");
                }

                this.SolutionFolders_bindingSource.DataSource = myDataTable_SolutionsDB;

                this.bnMain.BindingSource = this.SolutionFolders_bindingSource;

                if (this.isMapped_SolutionFolders == false)
                {

                    this.Binding_SolutionFolders();
                    this.isMapped_SolutionFolders = true;

                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solution Folders");
            }
        }


        void Search_SolutionFolders()
        {
            try
            {
                frmSearching frmSearching = new frmSearching();

                //frmSearching.MdiParent = this.MdiParent;

                if (frmSearching.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.ViewAll_SolutionFolders(true, frmSearching.Search_txt.Text);

                    frmSearching.Close();
                    frmSearching.Dispose();
                }
            }

            catch (Exception ex)
            {
            }
        }

        #endregion
        public frmSolutionFolders()
        {
            InitializeComponent();
        }

        private void frmSolutionFolders_Load(object sender, EventArgs e)
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

        private void mnuNew_Click(object sender, EventArgs e)
        {
            this.New_SolutionFolders();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            this.Update_SolutionFolders();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            this.Edit_SolutionFolders();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            this.Delete_SolutionFolders();
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_SolutionFolders();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bnbtnNew_Click(object sender, EventArgs e)
        {
            this.New_SolutionFolders();
        }

        private void bnbtnSave_Click(object sender, EventArgs e)
        {
            this.Update_SolutionFolders();
        }

        private void bnbtnViewAll_Click(object sender, EventArgs e)
        {
            this.ViewAll_SolutionFolders();
        }

        private void bnbtnSearch_Click(object sender, EventArgs e)
        {
            this.Search_SolutionFolders();
        }

        private void bnbtnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_SolutionFolders();
        }

        private void bnbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSolutionID_TextChanged(object sender, EventArgs e)
        {
            this.ViewAll_SolutionFolders();
        }
    }
}
