using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pss.ProgrammerMate.DAL;
using PSS.DAL.COMMON;
using Pss.ProgrammerMate.CommonClasses;

namespace Pss.ProgrammerMate
{
    public partial class frmSolutions : Form
    {
        #region "Combo box"
        void getMethodologyList()
        {
            try
            {
                this.Methodology_bindingSource.DataSource = null;

                this.Methodology_bindingSource.DataSource = new MethodologyDAL().getList(1000, 1, "Name");

                if (this.Methodology_bindingSource.DataSource !=null)
                {
                    this.cmbMethodology.DataSource = this.Methodology_bindingSource;
                    this.cmbMethodology.DisplayMember = "Name";
                    this.cmbMethodology.ValueMember = "Name";
                }
                else
                {
                    this.cmbMethodology.DataSource = null; 
                }

                this.cmbMethodology.Refresh();
                this.cmbMethodology.Update();

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solution");
            }
        }
        #endregion

        #region "Solutions"
        private Boolean isNew_Solutions, isEdit_Solutions, isDelete_Solutions;
        private Boolean isMapped_Solutions, isSearch;
        clsActionStatus clsActionStatus = new clsActionStatus();
        SolutionsDAL SolutionsDAL = new SolutionsDAL();

        void New_Solutions()
        {
            try
            {

                this.isNew_Solutions = true;
                this.isEdit_Solutions = false;

                new Appearances.SetFocusBlur_Color().ClearAllControl(this);
                this.txtID.Text = CommonClasses.CommonVariables.New_IntialValue;
                this.txtSolutionName.Focus();
            }

            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");

            }
        }

        void Update_Solutions()
        {
            try
            {

                SolutionsDAL = new SolutionsDAL();
                clsActionStatus = new clsActionStatus();

                SolutionsDAL.ID = this.txtID.Text == CommonVariables.New_IntialValue ? 0 : int.Parse(this.txtID.Text);
                SolutionsDAL.SolutionName = this.txtSolutionName.Text;
                SolutionsDAL.SNameSpace = this.txtSNameSpace.Text;
                SolutionsDAL.SDescription = this.txtSDescription.Text;
                SolutionsDAL.Methodology = this.cmbMethodology.SelectedValue.ToString();
                SolutionsDAL.UserId = CommonClasses.Security.UserID;
                SolutionsDAL.isActive = this.cbkisActive.Checked;

                if (isNew_Solutions== false && isEdit_Solutions == false)
                {
                    Messages.Edit_New_error("Solution");
                    return;
                }

                if (SolutionsDAL.ID > 0)
                {
                    clsActionStatus = SolutionsDAL.Update();
                }
                else
                {
                    clsActionStatus = SolutionsDAL.Insert();
                }

                if (clsActionStatus.is_Error == false)
                {
                    isNew_Solutions = isEdit_Solutions = false;
                    Messages.SuccessMessage(clsActionStatus.Action_SuccessStatus, "Solutions");

                    


                    this.Solutions_bindingSource.EndEdit();

                    if (SolutionsDAL.ID <= 0)
                    {
                        this.txtID.Text = clsActionStatus.Return_Id;
                        if (Messages.myAddMore("Solutions") == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.txtID.Focus();
                            this.New_Solutions ();
                        }
                    }

                }
                else
                {
                    Messages.GeneralError(clsActionStatus.Action_FailureStatus, "Solutions");
                }



            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        void Edit_Solutions()
        {
            try
            {
                this.isEdit_Solutions = true;
                this.isNew_Solutions = false;
                this.txtSolutionName.Focus();
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        void Cancel_Solutions()
        {
            try
            {
                if (Messages.myCancelMsgBox("Solutions") == System.Windows.Forms.DialogResult.Yes)
                {
                    this.isEdit_Solutions = false;
                    this.isNew_Solutions = false;
                    this.Solutions_bindingSource.CancelEdit();
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        void Delete_Solutions()
        {
            try
            {
                if (Messages.myDeleteMsgBox("Job Status", this.txtSolutionName.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    SolutionsDAL = new SolutionsDAL();
                    clsActionStatus = new clsActionStatus();

                    SolutionsDAL.ID = int.Parse(this.txtID.Text);

                    clsActionStatus = SolutionsDAL.Delete();

                    if (clsActionStatus.is_Error == false)
                    {
                        isNew_Solutions = false;
                        isEdit_Solutions = false;
                        Messages.DeletionMessage(clsActionStatus.Action_SuccessStatus, "Solutions");

                        this.Solutions_bindingSource.RemoveCurrent();

                    }
                    else
                    {
                        Messages.DeletionMessage(clsActionStatus.Action_FailureStatus, "Solutions");
                    }


                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        void Binding_Solutions()
        {
            try
            {
                this.txtID.DataBindings.Add("Text", this.Solutions_bindingSource, "ID", false, DataSourceUpdateMode.Never, "new");
                this.txtSolutionName.DataBindings.Add("Text", this.Solutions_bindingSource, "SolutionName", false);
                this.txtSNameSpace.DataBindings.Add("Text", this.Solutions_bindingSource, "SNameSpace", false);
                this.txtSDescription.DataBindings.Add("Text", this.Solutions_bindingSource, "SDescription", false);
                this.cmbMethodology.DataBindings.Add("Text", this.Solutions_bindingSource, "Methodology", false);
                this.cbkisActive.DataBindings.Add("Checked", this.Solutions_bindingSource, "isActive", true);
                this.txtCreatedOnUtc.DataBindings.Add("Text", this.Solutions_bindingSource, "CreatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
                this.txtUpdatedOnUtc.DataBindings.Add("Text", this.Solutions_bindingSource, "UpdatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Job Status");
            }
        }

        void ViewAll_Solutions(Boolean isSearch = false, string SearchText = "")
        {
            try
            {

                DataTable myDataTable_JobStatusHead = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                if (isSearch == true)
                {

                    myDataTable_JobStatusHead = new SolutionsDAL().getList_Search(1000, 1, " (SolutionName like '" + SearchText + "%' or Methodology like '" + SearchText + "%')", "ID", "asc");
                }
                else
                {
                    myDataTable_JobStatusHead = new SolutionsDAL().getList(1000, 1, "ID", "asc");
                }

                this.Solutions_bindingSource.DataSource = myDataTable_JobStatusHead;
                this.bnMain.BindingSource = this.Solutions_bindingSource;

                if (this.isMapped_Solutions == false)
                {

                    this.Binding_Solutions();
                    this.isMapped_Solutions = true;

                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        void Search_Solutions()
        {
            try
            {
                frmSearching frmSearching = new frmSearching();

                //frmSearching.MdiParent = this.MdiParent;

                if (frmSearching.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.ViewAll_Solutions(true, frmSearching.Search_txt.Text);

                    frmSearching.Close();
                    frmSearching.Dispose();
                }
            }

            catch (Exception ex)
            {
            }
        }



        #endregion
        public frmSolutions()
        {
            InitializeComponent();
        }

        private void frmSolutions_Load(object sender, EventArgs e)
        {
            try
            {

                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);

                this.getMethodologyList();
                this.ViewAll_Solutions();
               
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            this.New_Solutions();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            this.Update_Solutions();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            this.Edit_Solutions();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            this.Delete_Solutions();
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_Solutions();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bnbtnNew_Click(object sender, EventArgs e)
        {
            this.New_Solutions();
        }

        private void bnbtnSave_Click(object sender, EventArgs e)
        {
            this.Update_Solutions();
        }

        private void bnbtnViewAll_Click(object sender, EventArgs e)
        {
            this.ViewAll_Solutions();
        }

        private void bnbtnSearch_Click(object sender, EventArgs e)
        {
            this.Search_Solutions();
        }

        private void bnbtnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_Solutions();
        }

        private void bnbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdFolders_Click(object sender, EventArgs e)
        {
            try
            {
                frmSolutionFolders frmSolutionsFolder = new frmSolutionFolders();

                frmSolutionsFolder.getList_Solutions(int.Parse(this.txtID.Text));

                frmSolutionsFolder.ShowDialog(this);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
