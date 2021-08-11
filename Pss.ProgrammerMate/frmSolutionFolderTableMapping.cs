using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.DAL;
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
    public partial class frmSolutionFolderTableMapping : Form
    {
        string CurrentDBType = "";
        int CurrentDBID = 0;
        #region "Solutions and Solution DB"
        void getList_Solutions()
        {
            try
            {

                DataTable myDataTable_Solutions = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");                
                myDataTable_Solutions = new SolutionsDAL().getList(1000, 1, "ID", "asc");


                this.Solutions_bindingSource.DataSource = myDataTable_Solutions;
                //this.bnMain.BindingSource = this.Solutions_bindingSource;

                this.cmbSolutions.DataSource = null;

                this.cmbSolutions.DataSource = this.Solutions_bindingSource;

                this.cmbSolutions.DisplayMember = "SolutionName";
                this.cmbSolutions.ValueMember = "ID";

                this.cmbSolutions.Refresh();
                this.cmbSolutions.Update();

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        void ViewAll_SolutionsDB()
        {
            try
            {
                if (this.cmbSolutions.DataSource == null)
                    return;


                this.cmbSolutionsDB.DataSource = null;
                this.cmbSolutionsDB.Items.Clear();

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                myDataTable_SolutionsDB = new SolutionsDBDAL().getList_Search(1000, 1, " SolutionID =" + this.cmbSolutions.SelectedValue.ToString(), "DBType");

                this.SolutionsDB_bindingSource.DataSource = myDataTable_SolutionsDB;

                this.cmbSolutionsDB.DataSource = this.SolutionsDB_bindingSource;

                if (this.SolutionsDB_bindingSource != null && this.SolutionsDB_bindingSource.Count > 0)
                {
                    this.cmbSolutionsDB.DisplayMember = "DBInfo";
                    this.cmbSolutionsDB.ValueMember = "ID";
                }
                this.cmbSolutionsDB.Refresh();
                this.cmbSolutionsDB.Update();


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        //void GetAutoSQLName_SolutionsDB(string TableName)
        //{
        //    try
        //    {
        //        DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

        //        if (myRow != null && myRow["SPFormat"].ToString().Length > 0)
        //        {
        //            this.txtSqlName_Insert.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Insert");
        //            this.txtSqlName_Delete.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Delete");
        //            this.txtSqlName_GetRecord.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "GetList");
        //            this.txtSqlName_Update.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Update");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonClasses.Messages.GeneralError(ex.Message, " Format");
        //    }

        //}

        void GetSelectDB_Tables()
        {
            try
            {
                //DataTable myDataTable_SolutionsDBTables = new SolutionsDBTablesDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString(), "TableName");

                DataTable myDataTable_SolutionsDBTables = new SolutionsDBTablesDAL().getUnMappedTables(int.Parse(this.cmbSolutions.SelectedValue.ToString()), int.Parse(this.cmbSolutionsDB.SelectedValue.ToString()));

                if (myDataTable_SolutionsDBTables != null)
                {
                    this.SolutionsDBTables_bindingSource.DataSource = myDataTable_SolutionsDBTables;
                }

                if (this.SolutionsDBTables_bindingSource.DataSource != null)
                {
                    this.dvgUnMappedTables.DataSource = this.SolutionsDBTables_bindingSource;
                    this.dvgUnMappedTables.Columns["clmName"].DataPropertyName = "TableName";
                }

                this.dvgUnMappedTables.Refresh();
                this.dvgUnMappedTables.Update();

            }
            catch (Exception ex)
            {

            }
        }

        void GetSelectedDB_Folders()
        {
            try
            {
                DataTable myDataTable_SolutionFolders = new SolutionFoldersDAL().getList_Search(10000, 1, " SolutionID= " + this.cmbSolutions.SelectedValue.ToString(), "FolderName");

                if (myDataTable_SolutionFolders != null)
                {
                    this.SolutionFolders_bindingSource.DataSource = myDataTable_SolutionFolders;
                }

                if (this.SolutionFolders_bindingSource.DataSource != null)
                {
                    this.cmbSolutionFolders.DataSource = this.SolutionFolders_bindingSource;
                    this.cmbSolutionFolders.DisplayMember= "FolderName";
                    this.cmbSolutionFolders.ValueMember = "ID";
                }

                this.cmbSolutionFolders.Refresh();
                this.cmbSolutionFolders.Update();

            }
            catch (Exception ex)
            {

            }
        }

        

        #endregion

        #region "Solution Folder & Table Mapping "

        void getMappedTables()
        {
            try
            {
                //DataTable myDataTable_SolutionsDBTables = new SolutionsDBTablesDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString(), "TableName");

                DataTable myDataTable_SolutionsDBTables = new SolutionFolders_TablesDAL().getMappedTables(int.Parse(this.cmbSolutions.SelectedValue.ToString()), 
                                                                                                            int.Parse(this.cmbSolutionsDB.SelectedValue.ToString()),
                                                                                                            int.Parse(this.cmbSolutionFolders.SelectedValue.ToString()));

                if (myDataTable_SolutionsDBTables != null)
                {
                    this.SolutionsMappedDBTables_bindingSource.DataSource = myDataTable_SolutionsDBTables;
                }

                if (this.SolutionsMappedDBTables_bindingSource.DataSource != null)
                {
                    this.dvgMappedTables.DataSource = this.SolutionsMappedDBTables_bindingSource;
                    this.dvgMappedTables.Columns["clmTableName"].DataPropertyName = "TableName";
                }

                this.dvgMappedTables.Refresh();
                this.dvgMappedTables.Update();

            }
            catch (Exception ex)
            {

            }
        }

        void AssignDBTable()
        {
            try
            {
                SolutionFolders_TablesDAL SolutionFolders_TablesDAL = new SolutionFolders_TablesDAL();
                DataRowView myRows;

                SolutionFolders_TablesDAL.UserId = Security.UserID;
                SolutionFolders_TablesDAL.FolderID = int.Parse(this.cmbSolutionFolders.SelectedValue.ToString());
                SolutionFolders_TablesDAL.FolderName = this.cmbSolutionFolders.Text;

                foreach (DataGridViewRow myRow in this.dvgUnMappedTables.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                    if (myCell.Value !=null && myCell.Value.ToString() == "1")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;



                        SolutionFolders_TablesDAL.TableID = int.Parse(myRows["ID"].ToString());
                        SolutionFolders_TablesDAL.TableName = myRows["TableName"].ToString();

                        SolutionFolders_TablesDAL.Insert();
                        

                    }
                }

               

            }
            catch (Exception ex)
            {
                Messages.GeneralError(ex.Message, "Un-Mapped to mapped");
            }

            this.getMappedTables();
            this.GetSelectDB_Tables();

        }

        void WithdrawDBTable()
        {
            try
            {
                SolutionFolders_TablesDAL SolutionFolders_TablesDAL = new SolutionFolders_TablesDAL();
                DataRowView myRows;
                
                SolutionFolders_TablesDAL.FolderID = int.Parse(this.cmbSolutionFolders.SelectedValue.ToString());                

                foreach (DataGridViewRow myRow in this.dvgMappedTables.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelectMapped"];

                    if (myCell.Value !=null &&  myCell.Value.ToString() == "1")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;



                        SolutionFolders_TablesDAL.TableID = int.Parse(myRows["ID"].ToString());


                        SolutionFolders_TablesDAL.Delete(SolutionFolders_TablesDAL.FolderID,SolutionFolders_TablesDAL.TableID);


                    }
                }

               


            }
            catch (Exception ex)
            {

            }

            this.getMappedTables();
            this.GetSelectDB_Tables();
        }

        #endregion

        public frmSolutionFolderTableMapping()
        {
            InitializeComponent();
        }

        private void frmSolutionFolderTableMapping_Load(object sender, EventArgs e)
        {
            try
            {
                this.dvgMappedTables.AutoGenerateColumns = false;
                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgUnMappedTables);
                this.dvgUnMappedTables.AutoGenerateColumns = false;

                this.getList_Solutions();

                this.dvgUnMappedTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.ViewAll_SolutionsDB();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                if (myRow != null)
                {
                    this.CurrentDBType = myRow["DBType"].ToString();
                    this.CurrentDBID = int.Parse(myRow["ID"].ToString());
                }
                
                this.GetSelectDB_Tables();
                this.GetSelectedDB_Folders();

                this.getMappedTables();
            }
            catch (Exception ex)
            {

            }
        }

        private void cbkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbkSelectAll.Checked == true)
                {
                    this.cbkSelectAll.Text = "Un-select All";

                    foreach (DataGridViewRow myRow in this.dvgUnMappedTables.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];
                        myCell.Value = 1;
                    }

                }
                else
                {
                    this.cbkSelectAll.Text = "Select All";

                    foreach (DataGridViewRow myRow in this.dvgUnMappedTables.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];
                        myCell.Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox1.Checked == true)
                {
                    this.checkBox1.Text = "Un-select All";

                    foreach (DataGridViewRow myRow in this.dvgMappedTables.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelectMapped"];
                        myCell.Value = 1;
                    }

                }
                else
                {
                    this.checkBox1.Text = "Select All";

                    foreach (DataGridViewRow myRow in this.dvgMappedTables.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelectMapped"];
                        myCell.Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdColumns_Click(object sender, EventArgs e)
        {
            this.getMappedTables();
        }

        private void cmbSolutionFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.getMappedTables();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdAssign_Click(object sender, EventArgs e)
        {
            this.AssignDBTable();
        }

        private void cmdWithdraw_Click(object sender, EventArgs e)
        {
            this.WithdrawDBTable();
        }

        private void bnbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
