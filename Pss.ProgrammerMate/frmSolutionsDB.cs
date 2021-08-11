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
    public partial class frmSolutionsDB : Form
    {
        #region "Test DB"

        void TestDB()
        {
            try
            {
                if (this.cmbDBType.Text.ToLower ()=="my sql")
                {
                    this.TestMySQLConnection();
                }
                else if (this.cmbDBType.Text.ToLower() == "ms sql")
                {
                    this.TestMsSQLConnection();
                }
            }
            catch (Exception ex)
            {

            }
        }
        void TestMySQLConnection()
        {
            try
            {
                DataAccess.MySql.mySqlDBFunctions mySqlDBFunctions = new DataAccess.MySql.mySqlDBFunctions();

                mySqlDBFunctions.Server = this.txtServerNamer.Text;
                mySqlDBFunctions.DatabaseName = this.txtDBName.Text;
                mySqlDBFunctions.DBUserName = this.txtUserName.Text;
                mySqlDBFunctions.DBPassword = this.txtDPassword.Text;

                if (mySqlDBFunctions.getConnection() != null && mySqlDBFunctions.getConnection().State == ConnectionState.Open)
                {
                    CommonClasses.Messages.SuccessMessage("Server connected successfully.", "My SQL DB Connection");
                    mySqlDBFunctions.closeConnection();
                }
                else
                {
                    CommonClasses.Messages.GeneralError("Invalid server information", " My DB SQL Connection");
                }

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " My DB SQL Connection");
            }
        }

        void TestMsSQLConnection()
        {
            try
            {
                DataAccess.Ms_Sql.MsSqlDBFunctions MsSqlDBFunctions = new DataAccess.Ms_Sql.MsSqlDBFunctions();

                MsSqlDBFunctions.ServerName = this.txtServerNamer.Text;
                MsSqlDBFunctions.DatabaseName = this.txtDBName.Text;
                MsSqlDBFunctions.UserName = this.txtUserName.Text;
                MsSqlDBFunctions.UserPassword = this.txtDPassword.Text;

                if (MsSqlDBFunctions.getSQLConnection() != null && MsSqlDBFunctions.getSQLConnection().State == ConnectionState.Open)
                {
                    CommonClasses.Messages.SuccessMessage("Server connected successfully.", "MS SQL DB Connection");
                    MsSqlDBFunctions.CloseSqlConnection();
                }
                else
                {
                    CommonClasses.Messages.GeneralError("Invalid server information", " Ms SQL DB Connection");
                }

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Ms SQL DB Connection");
            }
        }
        #endregion

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
        #region "Solutions DB"
        private Boolean isNew_SolutionsDB, isEdit_SolutionsDB, isDelete_SolutionsDB;
        private Boolean isMapped_SolutionsDB, isSearch;
        clsActionStatus clsActionStatus = new clsActionStatus();
        SolutionsDBDAL SolutionsDBDAL = new SolutionsDBDAL();

        void New_SolutionsDB()
        {
            try
            {

                this.isNew_SolutionsDB = true;
                this.isEdit_SolutionsDB = false;

                new Appearances.SetFocusBlur_Color().ClearAllControl_GroupBox(gbContent);
                this.txtID.Text = CommonClasses.CommonVariables.New_IntialValue;
                this.cbkisActive.Checked = true;
                this.cmbDBType.Focus();
                this.txtSPFormat.Text = "sp_{TableName}_{Action}";
            }

            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");

            }
        }

        void Update_SolutionsDB()
        {
            try
            {

                SolutionsDBDAL = new DAL.SolutionsDBDAL();                
                clsActionStatus = new clsActionStatus();

                SolutionsDBDAL.ID = this.txtID.Text == CommonVariables.New_IntialValue ? 0 : int.Parse(this.txtID.Text);
                SolutionsDBDAL.SolutionID = int.Parse(this.txtSolutionID.Text);
                SolutionsDBDAL.DBType = this.cmbDBType.Text;
                SolutionsDBDAL.ServerName = this.txtServerNamer.Text;
                SolutionsDBDAL.UserName = this.txtUserName.Text;
                SolutionsDBDAL.DBName = this.txtDBName.Text;
                SolutionsDBDAL.DPassword = this.txtDPassword.Text;
                SolutionsDBDAL.SQLType = this.cmbSqlType.Text;
                SolutionsDBDAL.SPFormat = this.txtSPFormat.Text;
                SolutionsDBDAL.UserId = CommonClasses.Security.UserID;
                SolutionsDBDAL.isActive = this.cbkisActive.Checked;

                if (isNew_SolutionsDB == false && isEdit_SolutionsDB == false)
                {
                    Messages.Edit_New_error("Solutions DB");
                    return;
                }

                if (SolutionsDBDAL.ID > 0)
                {
                    clsActionStatus = SolutionsDBDAL.Update();
                }
                else
                {
                    clsActionStatus = SolutionsDBDAL.Insert();
                }

                if (clsActionStatus.is_Error == false)
                {
                    isNew_SolutionsDB = isEdit_SolutionsDB = false;
                    Messages.SuccessMessage(clsActionStatus.Action_SuccessStatus, "Solutions DB");

                    this.txtID.Text = clsActionStatus.Return_Id;


                    this.Solutions_bindingSource.EndEdit();

                    if (SolutionsDBDAL.ID <= 0)
                    {
                        if (Messages.myAddMore("Solutions DB") == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.txtID.Focus();
                            this.New_SolutionsDB();
                        }
                    }

                }
                else
                {
                    Messages.GeneralError(clsActionStatus.Action_FailureStatus, "Solutions DB");
                }



            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        void Edit_SolutionsDB()
        {
            try
            {
                this.isEdit_SolutionsDB = true;
                this.isNew_SolutionsDB = false;
                this.cmbDBType.Focus();
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        void Cancel_SolutionsDB()
        {
            try
            {
                if (Messages.myCancelMsgBox("Solutions DB") == System.Windows.Forms.DialogResult.Yes)
                {
                    this.isEdit_SolutionsDB = false;
                    this.isNew_SolutionsDB = false;
                    this.Solutions_bindingSource.CancelEdit();
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        void Delete_SolutionsDB()
        {
            try
            {
                if (Messages.myDeleteMsgBox("Solutions DB", this.txtServerNamer.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    SolutionsDBDAL = new DAL.SolutionsDBDAL();
                    clsActionStatus = new clsActionStatus();

                    SolutionsDBDAL.ID = int.Parse(this.txtID.Text);

                    clsActionStatus = SolutionsDBDAL.Delete();

                    if (clsActionStatus.is_Error == false)
                    {
                        isNew_SolutionsDB = false;
                        isEdit_SolutionsDB = false;
                        Messages.DeletionMessage(clsActionStatus.Action_SuccessStatus, "Solutions DB");

                        this.SolutionsDB_bindingSource.RemoveCurrent();

                    }
                    else
                    {
                        Messages.DeletionMessage(clsActionStatus.Action_FailureStatus, "Solutions DB");
                    }


                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        void Binding_SolutionsDB()
        {
            try
            {
                this.txtID.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "ID", false, DataSourceUpdateMode.Never, "new");
                this.cmbDBType.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "DBType", false);
                this.txtServerNamer.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "ServerName", false);
                this.txtDBName.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "DBName", false);
                this.txtUserName.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "UserName", false);
                this.txtDPassword.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "DPassword", false);
                this.txtSPFormat.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "SPFormat", false);

                this.cmbSqlType.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "SQLType", false);
                this.cbkisActive.DataBindings.Add("Checked", this.SolutionsDB_bindingSource, "isActive", true);
                this.txtCreatedOnUtc.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "CreatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
                this.txtUpdatedOnUtc.DataBindings.Add("Text", this.SolutionsDB_bindingSource, "UpdatedOnUtc", true, DataSourceUpdateMode.Never, null, CommonVariables.DateFormat_Full);
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        void ViewAll_SolutionsDB(Boolean isSearch = false, string SearchText = "")
        {
            try
            {

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                if (isSearch == true)
                {

                    myDataTable_SolutionsDB = new SolutionsDBDAL().getList_Search(1000, 1, " SolutionID=" + this.txtSolutionID.Text + " and (ServerName like '" + SearchText + "%' or DBType like '" + SearchText + "%')", "ID", "asc");
                }
                else
                {
                    myDataTable_SolutionsDB = new SolutionsDBDAL().getList_Search(1000, 1, " SolutionID=" + this.txtSolutionID.Text, "DBType");
                }

                this.SolutionsDB_bindingSource.DataSource = myDataTable_SolutionsDB;

                this.bnMain.BindingSource = this.SolutionsDB_bindingSource;

                if (this.isMapped_SolutionsDB == false)
                {

                    this.Binding_SolutionsDB();
                    this.isMapped_SolutionsDB = true;

                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        void Search_SolutionsDB()
        {
            try
            {
                frmSearching frmSearching = new frmSearching();

                //frmSearching.MdiParent = this.MdiParent;

                if (frmSearching.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.ViewAll_SolutionsDB(true, frmSearching.Search_txt.Text);

                    frmSearching.Close();
                    frmSearching.Dispose();
                }
            }

            catch (Exception ex)
            {
            }
        }

        #endregion

        public frmSolutionsDB()
        {
            InitializeComponent();
        }

        private void frmSolutionsDB_Load(object sender, EventArgs e)
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

        private void cmdTestDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.TestDB();
            }
            catch (Exception ex)
            {

            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            this.New_SolutionsDB();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            this.Update_SolutionsDB();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            this.Edit_SolutionsDB();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            this.Delete_SolutionsDB();
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_SolutionsDB();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bnbtnNew_Click(object sender, EventArgs e)
        {
            this.New_SolutionsDB();
        }

        private void bnbtnSave_Click(object sender, EventArgs e)
        {
            this.Update_SolutionsDB();
        }

        private void bnbtnViewAll_Click(object sender, EventArgs e)
        {
            this.ViewAll_SolutionsDB();
        }

        private void bnbtnSearch_Click(object sender, EventArgs e)
        {
            this.Search_SolutionsDB();
        }

        private void bnbtnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel_SolutionsDB();
        }

        private void bnbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSolutionID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.ViewAll_SolutionsDB();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSPFormat_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar==(Char)Keys.Enter)
                {
                    this.Update_SolutionsDB();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
