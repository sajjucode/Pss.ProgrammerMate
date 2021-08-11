using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.CommonClasses.SQL.MS_SQL;
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

namespace Pss.ProgrammerMate.SQL_Generator
{
    public partial class frmSQLGeneratorMSSQLServer : Form
    {
        string CurrentDBType = "";
        int CurrentDBID = 0;
        string ExecutedSQLLog = string.Empty;

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

                this.ViewAll_SolutionsDB();

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

                myDataTable_SolutionsDB = new SolutionsDBDAL().getList_Search(1000, 1, " SolutionID =" + this.cmbSolutions.SelectedValue.ToString() + " and DBType like 'MS SQL' ", "DBType");

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

        void GetAutoSQLName_SolutionsDB(string TableName)
        {
            try
            {
                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                if (myRow != null && myRow["SPFormat"].ToString().Length > 0)
                {
                    //this.txtSqlName_Insert.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Insert");
                    //this.txtSqlName_Delete.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Delete");
                    //this.txtSqlName_GetRecord.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "GetList");
                    //this.txtSqlName_Update.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Update");
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Format");
            }

        }

        void GetSelectDB_Tables()
        {
            try
            {
                DataTable myDataTable_SolutionsDBTables = new SolutionsDBTablesDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString(), "TableName");

                if (myDataTable_SolutionsDBTables != null)
                {
                    this.SolutionsDBTables_bindingSource.DataSource = myDataTable_SolutionsDBTables;
                }

                if (this.SolutionsDBTables_bindingSource.DataSource != null)
                {
                    this.cmbDBTables.DataSource = this.SolutionsDBTables_bindingSource;
                    this.cmbDBTables.DisplayMember = "TableName";
                    this.cmbDBTables.ValueMember = "TableName";
                }

                this.cmbDBTables.Refresh();
                this.cmbDBTables.Update();

            }
            catch (Exception ex)
            {

            }
        }

        void GetSelectDB_TableColumns()
        {
            try
            {
                DataTable myDataTable_SolutionsDBTableColumns = new SolutionsDBTableColumnsDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString() + " and TableName like '" + this.cmbDBTables.Text + "'", "ID");

                if (myDataTable_SolutionsDBTableColumns != null)
                {
                    this.TableColumns_bindingSource.DataSource = myDataTable_SolutionsDBTableColumns;
                }

                this.dvgTableColumns.DataSource = this.TableColumns_bindingSource;

                this.dvgTableColumns.Columns["clmName"].DataPropertyName = "ColumnName";
                this.dvgTableColumns.Columns["clmType"].DataPropertyName = "ColumnType";
                this.dvgTableColumns.Columns["clmIdentity"].DataPropertyName = "isIdentity";
                this.dvgTableColumns.Columns["clmWhere"].DataPropertyName = "isWhere";
                this.dvgTableColumns.Columns["clmDefaultValue"].DataPropertyName = "DefaultValue";

                this.dvgTableColumns.Refresh();
                this.dvgTableColumns.Update();


            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region "Ms SQL Server "

        DataAccess.Ms_Sql.MsSqlDBFunctions MsSqlDBFunctions = new DataAccess.Ms_Sql.MsSqlDBFunctions();
        DataTable MsSql_DB_Tables, mySql_DB_Tables = new DataTable();
        void MsSQL_Connect_GetTable()
        {
            try
            {
                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;
                SolutionsDBTablesDAL SolutionsDBTablesDAL = new SolutionsDBTablesDAL();

                SolutionsDBTablesDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBTablesDAL.isActive = true;
                SolutionsDBTablesDAL.UserId = Security.UserID;

                if (myRow != null && myRow["DBType"].ToString().ToLower() == "ms sql")
                {
                    mySql_DB_Tables = new DataTable();
                    this.MsSqlDBFunctions.ServerName = myRow["ServerName"].ToString();
                    this.MsSqlDBFunctions.DatabaseName = myRow["DBName"].ToString();
                    this.MsSqlDBFunctions.UserName = myRow["UserName"].ToString();
                    this.MsSqlDBFunctions.UserPassword = myRow["DPassword"].ToString();

                    if (this.MsSqlDBFunctions.getSQLConnection().State == ConnectionState.Open)
                    {
                        MsSql_DB_Tables = this.MsSqlDBFunctions.getTablesList();

                        if (MsSql_DB_Tables != null && MsSql_DB_Tables.Rows.Count > 0)
                        {
                            foreach (DataRow myTableRow in MsSql_DB_Tables.Rows)
                            {
                                SolutionsDBTablesDAL.TableName = myTableRow["Tables"].ToString();
                                SolutionsDBTablesDAL.Insert();
                            }

                        }

                    }
                    else
                    {
                        CommonClasses.Messages.GeneralError("Invalid server information.", " MS SQL DB Connection");
                    }

                }
                else
                {
                    CommonClasses.Messages.GeneralError("Selected DB is not MS Sql DB.", " MS SQL DB Connection");
                }


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " MS SQL DB Connection");
            }
        }

        void MSSql_Table_GetColumns(string TableName)
        {
            try
            {
                DataTable myDataTable_TableColumns = new DataTable();
                SolutionsDBTableColumnsDAL SolutionsDBTableColumnsDAL = new SolutionsDBTableColumnsDAL();

                SolutionsDBTableColumnsDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBTableColumnsDAL.TableName = TableName;
                SolutionsDBTableColumnsDAL.TableId = 0;
                SolutionsDBTableColumnsDAL.isActive = true;




                this.TableColumns_bindingSource.DataSource = null;
                this.dvgTableColumns.DataSource = null;

                myDataTable_TableColumns = this.MsSqlDBFunctions.getTablesColumns(this.MsSqlDBFunctions.DatabaseName, TableName);

                if (myDataTable_TableColumns != null)
                {
                    foreach (DataRow myRow in myDataTable_TableColumns.Rows)
                    {
                        SolutionsDBTableColumnsDAL.ColumnName = myRow["column_name"].ToString();
                        SolutionsDBTableColumnsDAL.ColumnType = myRow["columntype"].ToString();
                        SolutionsDBTableColumnsDAL.COLUMN_KEY = myRow["COLUMN_KEY"].ToString();
                        SolutionsDBTableColumnsDAL.ColumnDataType = myRow["DATA_TYPE"].ToString();
                        SolutionsDBTableColumnsDAL.isIdentity = Boolean.Parse(myRow["is_identity"].ToString());

                        if (SolutionsDBTableColumnsDAL.isIdentity == true)
                        {
                            SolutionsDBTableColumnsDAL.DefaultValue = string.Empty;
                            SolutionsDBTableColumnsDAL.isInsert = false;
                            SolutionsDBTableColumnsDAL.isUpdate = false;
                            SolutionsDBTableColumnsDAL.isDelete = true;
                            SolutionsDBTableColumnsDAL.isWhere = true;
                        }
                        else if (SolutionsDBTableColumnsDAL.ColumnType.ToLower().Contains("date") && (SolutionsDBTableColumnsDAL.ColumnName.ToLower().Contains("create")))
                        {
                            SolutionsDBTableColumnsDAL.DefaultValue = "getDate()";
                            SolutionsDBTableColumnsDAL.isInsert = true;
                            SolutionsDBTableColumnsDAL.isUpdate = false;
                            SolutionsDBTableColumnsDAL.isDelete = false;
                            SolutionsDBTableColumnsDAL.isWhere = false;
                        }
                        else if (SolutionsDBTableColumnsDAL.ColumnType.ToLower().Contains("date") && (SolutionsDBTableColumnsDAL.ColumnName.ToLower().Contains("updat") || SolutionsDBTableColumnsDAL.ColumnName.ToLower().Contains("delet")))
                        {
                            SolutionsDBTableColumnsDAL.DefaultValue = "getDate()";
                            SolutionsDBTableColumnsDAL.isInsert = true;
                            SolutionsDBTableColumnsDAL.isUpdate = true;
                            SolutionsDBTableColumnsDAL.isDelete = true;
                            SolutionsDBTableColumnsDAL.isWhere = false;
                        }
                        else
                        {
                            SolutionsDBTableColumnsDAL.DefaultValue = string.Empty;
                            SolutionsDBTableColumnsDAL.isInsert = true;
                            SolutionsDBTableColumnsDAL.isUpdate = true;
                            SolutionsDBTableColumnsDAL.isDelete = false;
                            SolutionsDBTableColumnsDAL.isWhere = false;
                        }

                        SolutionsDBTableColumnsDAL.isSelected = true;

                        SolutionsDBTableColumnsDAL.DataType = SQLDataTypeConversion.getType(myRow["DATA_TYPE"].ToString());
                        SolutionsDBTableColumnsDAL.Insert();
                    }
                }



            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " My DB SQL Connection");
            }
        }

        void MSSql_Query_Execute(string QueryName, string SqlQuery,Boolean RunMultiple=false)
        {
            try
            {
                string Return = this.MsSqlDBFunctions.ExecuteQuery(SqlQuery);

                ExecutedSQLLog = ExecutedSQLLog + Environment.NewLine + "Query \" " + QueryName + " \" :" + Return;


                //if (Return.Contains("Error"))
                //{
                //    ExecutedSQLLog = ExecutedSQLLog + Environment.NewLine + "Query \" " + QueryName + " \" :" +  Return;
                //    CommonClasses.Messages.GeneralError(Return, " MS SQL Query");
                //}
                //else
                //{
                //    CommonClasses.Messages.SuccessMessage(Return, "MS Sql Query");
                //}




            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " My DB SQL Connection");
            }
        }

        #endregion

        #region "SQL Query DB Record"

        Boolean isMapped = false;

        void getList_SolutionQueryDB(string TableName)
        {
            try
            {
                string WhereCondition = string.Empty;

                //WhereCondition = " TableName like '" + TableName + "' and SolutionsDBID=" + CurrentDBID;

                //DataTable myDataTable_SolutinsDBQuery = new DAL.SolutionsDBQueryDAL().getList_Search(1000, 1, WhereCondition, "ID", "Desc");
                DataTable myDataTable_SolutinsDBQuery = new DAL.SolutionsDBQueryDAL().getList(CurrentDBID.ToString(), TableName);

                if (myDataTable_SolutinsDBQuery != null) //&& myDataTable_SolutinsDBQuery.Rows.Count > 0
                {
                    this.SolutionDBQuery_bindingSource.DataSource = myDataTable_SolutinsDBQuery;
                }
                else
                {
                    this.SolutionDBQuery_bindingSource.DataSource = null;
                    this.dvgSolutionDBQuery.DataSource = null;
                }

                if (this.SolutionDBQuery_bindingSource.DataSource != null && this.isMapped == false)
                {
                    this.isMapped = true;
                    this.dvgSolutionDBQuery.DataSource = this.SolutionDBQuery_bindingSource;
                    this.dvgSolutionDBQuery.Columns["clmID"].DataPropertyName = "ID";
                    this.dvgSolutionDBQuery.Columns["clmQueryName"].DataPropertyName = "QueryName";
                    this.dvgSolutionDBQuery.Columns["clmType_DBAction"].DataPropertyName = "QueryType";
                    this.dvgSolutionDBQuery.Columns["clmActionType_DBAction"].DataPropertyName = "ActionType";
                    this.dvgSolutionDBQuery.Columns["clmDALMethodName_DBAction"].DataPropertyName = "DALMethodName";
                    this.dvgSolutionDBQuery.Columns["clmActionID"].DataPropertyName = "ActionID";

                    this.txtGeneratedQuery.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "QueryText");
                    this.txtQueryName.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "QueryName");
                    this.txtActionType.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "ActionType");
                    this.txtQueryType.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "QueryType");

                }

                if (this.dvgSolutionDBQuery.DataSource !=null)
                {

                    DataRowView myRow_SolutionDB = (DataRowView)this.SolutionsDB_bindingSource.Current;
                    String StoreProcedureNameFormat = "{TableName}{Action}";

                    if (myRow_SolutionDB != null)
                    {
                        StoreProcedureNameFormat = myRow_SolutionDB["SPFormat"].ToString();
                    }

                    foreach (DataGridViewRow myGridRow in this.dvgSolutionDBQuery.Rows)
                    {
                        if (myGridRow.Cells["clmActionID"].Value.ToString() != "0")
                        {
                            myGridRow.Cells["clmSelected"].ReadOnly = true;
                            myGridRow.Cells["clmSelected"].Value = "1";
                        }

                        if (string.IsNullOrEmpty(myGridRow.Cells["clmType_DBAction"].Value.ToString()))
                        {
                            
                            myGridRow.Cells["clmType_DBAction"].Value = "Store Procedure";
                        }

                        if (string.IsNullOrEmpty(myGridRow.Cells["clmQueryName"].Value.ToString()))
                        {
                            myGridRow.Cells["clmQueryName"].Value = StoreProcedureNameFormat.Replace("{TableName}", TableName).Replace("{Action}", myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString().Trim().Replace (" ","")); 
                        }


                    }

                }

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Get Query List");
            }
        }
        Boolean isQueryExist(string TableName, string QueryName)
        {
            SolutionsDBQueryDAL SolutionsDBQueryDAL = new DAL.SolutionsDBQueryDAL();
            Boolean isExist = SolutionsDBQueryDAL.isQueryExist(this.CurrentDBID, TableName, QueryName);

            if (isExist)
            {
                CommonClasses.Messages.GeneralError("Query with name \" " + QueryName + " \" already exists", " Insert Query");
            }

            return isExist;
        }        
        #endregion

        public frmSQLGeneratorMSSQLServer()
        {
            InitializeComponent();
        }

        private void frmSQLGeneratorMSSQLServer_Load(object sender, EventArgs e)
        {
            try
            {

                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgTableColumns);
                //Appearances.GridViewStyles.setGridDefaultStyle(this.dvgSolutionDBQuery);
                this.dvgTableColumns.AutoGenerateColumns = false;
                this.dvgSolutionDBQuery.AutoGenerateColumns = false;

                this.getList_Solutions();

                this.dvgTableColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
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

                if (myRow != null && myRow["DBType"].ToString().ToLower() == "ms sql")
                {

                    this.MsSQL_Connect_GetTable();
                }

                this.GetSelectDB_Tables();
                this.GetAutoSQLName_SolutionsDB(this.cmbDBTables.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }
        }

        #region "Generate SQL Queries"
        void GenerateSQLQueries()
        {
            try
            {
                foreach (DataGridViewRow myGridRow in this.dvgSolutionDBQuery.Rows)
                {
                    switch (myGridRow.Cells["clmActionType_DBAction"].Value.ToString ().ToLower())
                    {
                        case "insert":
                            QueryGenerator.InsertQuery(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "update":
                            QueryGenerator.UpdateQuery(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "update status":
                            QueryGenerator.UpdateStatusQuery(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "delete":
                            QueryGenerator.DeleteQuery(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "get info":
                            QueryGenerator.GetInfoByIDQuery(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "get list":
                            QueryGenerator.GetList(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "get list paginated":
                            QueryGenerator.GetListPagination(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "search":
                            QueryGenerator.SearchQuery(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                        case "search pagination":
                            QueryGenerator.SearchWithPaginationQuery(CurrentDBID, 0, this.cmbDBTables.Text, myGridRow.Cells["clmQueryName"].Value.ToString(), myGridRow.Cells["clmDALMethodName_DBAction"].Value.ToString(), int.Parse(myGridRow.Cells["clmActionID"].Value.ToString()), this.dvgTableColumns, true);
                            break;
                            
                    }
                    
                    
                }


                this.getList_SolutionQueryDB(this.cmbDBTables.Text);

                Messages.SuccessMessage("Queries Generated", "SQL Generator");

                this.cmbDBTables.Focus();
            }
            catch (Exception ex)
            {

                Messages.GeneralError(ex.Message, "SQL Queries Generation");
            }
        }
        #endregion

        private void cmdColumns_Click(object sender, EventArgs e)
        {
            try
            {
                //this.SolutionDBQuery_bindingSource.DataSource = null;
                //this.dvgSolutionDBQuery.DataBindings.Clear();

                this.getList_SolutionQueryDB(this.cmbDBTables.Text);

                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                if (myRow != null && myRow["DBType"].ToString().ToLower() == "ms sql")
                {
                    this.MSSql_Table_GetColumns(this.cmbDBTables.SelectedValue.ToString());
                }

                this.GetAutoSQLName_SolutionsDB(this.cmbDBTables.SelectedValue.ToString());

                this.GetSelectDB_TableColumns();

                //this.cbkSelectAll.Checked = true;

                this.cbkSelectAll_CheckedChanged(null, null);


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Table Columns");
            }
        }

        private void cmdGeneratorQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.GenerateSQLQueries();
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

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];
                        myCell.Value = 1;
                    }

                }
                else
                {
                    this.cbkSelectAll.Text = "Select All";

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
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

        private void txtCopyClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.txtGeneratedQuery.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdExecuteQuery_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutedSQLLog = string.Empty;
                if (Messages.myGeneralAskMsgBox("Execute Query", "Query ") == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                    if (myRow != null && myRow["DBType"].ToString().ToLower() == "ms sql")
                    {
                        this.MSSql_Query_Execute(this.txtQueryName.Text, this.txtGeneratedQuery.Text);
                    }

                    Messages.SuccessMessage(ExecutedSQLLog, "Executed All Queries");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbRulAllQueries_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutedSQLLog = string.Empty;
                if (Messages.myGeneralAskMsgBox("Execute All Selected Queries", "Query ") == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    foreach (DataGridViewRow myGridRow in this.dvgSolutionDBQuery.Rows)
                    {
                        if (myGridRow.Cells["clmSelected"].Value.ToString() == "1")
                        {


                            DataRowView myRow = (DataRowView)myGridRow.DataBoundItem;//this.SolutionsDB_bindingSource.Current;

                            if (myRow != null && myRow["QueryText"].ToString().Length>9)
                            {
                                this.MSSql_Query_Execute(myRow["QueryName"].ToString(), myRow["QueryText"].ToString());
                            }
                        }
                    }

                    Messages.SuccessMessage(ExecutedSQLLog, "Executed All Queries");

                    this.cmbDBTables.Focus();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbDBTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmdColumns_Click(null, null);
        }
    }
}
