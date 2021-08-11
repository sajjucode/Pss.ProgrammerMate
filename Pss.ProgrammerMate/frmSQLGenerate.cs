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
    public partial class frmSQLGenerate : Form
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

        void GetAutoSQLName_SolutionsDB(string TableName)
        {
            try
            {
                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                if (myRow != null && myRow["SPFormat"].ToString().Length > 0)
                {
                    this.txtSqlName_Insert.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Insert");
                    this.txtSqlName_Delete.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Delete");
                    this.txtSqlName_GetRecord.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "GetList");
                    this.txtSqlName_Update.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Update");
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

                this.dvgTableColumns.Columns["clmSelect"].DataPropertyName = "isSelected";
                this.dvgTableColumns.Columns["clmInsert"].DataPropertyName = "isInsert";
                this.dvgTableColumns.Columns["clmUpdate"].DataPropertyName = "isUpdate";
                this.dvgTableColumns.Columns["clmDelete"].DataPropertyName = "isDelete";
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
        DataTable MsSql_DB_Tables = new DataTable();
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
                        else if (SolutionsDBTableColumnsDAL.ColumnType.ToLower().Contains("date") && (SolutionsDBTableColumnsDAL.ColumnName.ToLower().Contains("create") ))
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

        void MSSql_Query_Execute(string SqlQuery)
        {
            try
            {
                string Return = this.MsSqlDBFunctions.ExecuteQuery(SqlQuery);

                if (Return.Contains("Error"))
                {
                    CommonClasses.Messages.GeneralError(Return, " MS SQL Query");
                }
                else
                {
                    CommonClasses.Messages.SuccessMessage(Return, "MS Sql Query");
                }




            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " My DB SQL Connection");
            }
        }

        #endregion

        #region "My SQl "

        DataAccess.MySql.mySqlDBFunctions mySqlDBFunctions = new DataAccess.MySql.mySqlDBFunctions();
        DataTable mySql_DB_Tables = new DataTable();
        void MySQL_Connect_GetTable()
        {
            try
            {
                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;
                SolutionsDBTablesDAL SolutionsDBTablesDAL = new SolutionsDBTablesDAL();

                SolutionsDBTablesDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBTablesDAL.isActive = true;
                SolutionsDBTablesDAL.UserId = Security.UserID;

                if (myRow != null && myRow["DBType"].ToString().ToLower() == "my sql")
                {
                    mySql_DB_Tables = new DataTable();
                    this.mySqlDBFunctions.Server = myRow["ServerName"].ToString();
                    this.mySqlDBFunctions.DatabaseName = myRow["DBName"].ToString();
                    this.mySqlDBFunctions.DBUserName = myRow["UserName"].ToString();
                    this.mySqlDBFunctions.DBPassword = myRow["DPassword"].ToString();

                    if (this.mySqlDBFunctions.getConnection().State == ConnectionState.Open)
                    {
                        mySql_DB_Tables = this.mySqlDBFunctions.getTablesList();

                        if (mySql_DB_Tables != null && mySql_DB_Tables.Rows.Count > 0)
                        {
                            foreach (DataRow myTableRow in mySql_DB_Tables.Rows)
                            {
                                SolutionsDBTablesDAL.TableName = myTableRow["Tables"].ToString();
                                SolutionsDBTablesDAL.Insert();
                            }

                        }


                    }
                    else
                    {
                        CommonClasses.Messages.GeneralError("Invalid server information.", " My DB SQL Connection");
                    }

                }
                else
                {
                    CommonClasses.Messages.GeneralError("Selected DB is not My Sql DB.", " My DB SQL Connection");
                }


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " My DB SQL Connection");
            }
        }

        void MySql_Table_GetColumns(string TableName)
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

                myDataTable_TableColumns = this.mySqlDBFunctions.getTablesColumns(this.mySqlDBFunctions.DatabaseName, TableName);

                if (myDataTable_TableColumns != null)
                {
                    foreach (DataRow myRow in myDataTable_TableColumns.Rows)
                    {
                        SolutionsDBTableColumnsDAL.ColumnName = myRow["COLUMN_NAME"].ToString();
                        SolutionsDBTableColumnsDAL.ColumnType = myRow["COLUMN_TYPE"].ToString();
                        SolutionsDBTableColumnsDAL.COLUMN_KEY = myRow["COLUMN_KEY"].ToString();
                        SolutionsDBTableColumnsDAL.ColumnDataType = myRow["DATA_TYPE"].ToString();
                        SolutionsDBTableColumnsDAL.isIdentity = myRow["EXTRA"].ToString().ToLower().Contains("auto_increment") == true ? true : false;

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

        void MySql_Query_Execute(string SqlQuery)
        {
            try
            {
                string Return = this.mySqlDBFunctions.ExecuteQuery(SqlQuery);

                if (Return.Contains("Error"))
                {
                    CommonClasses.Messages.GeneralError(Return, " My SQL Query");
                }
                else
                {
                    CommonClasses.Messages.SuccessMessage(Return, "My Sql Query");
                }




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
                //this.SolutionDBQuery_bindingSource.DataSource = null;
                //this.dvgSolutionDBQuery.DataSource = null;
                //this.dvgSolutionDBQuery.DataBindings.Clear();


                //this.txtGeneratedQuery.DataBindings.Clear();
                //this.txtQueryName.DataBindings.Clear();
                //this.txtActionType.DataBindings.Clear();
                //this.txtQueryType.DataBindings.Clear();


                string WhereCondition = string.Empty;

                WhereCondition = " TableName like '" + TableName + "' and SolutionsDBID=" + CurrentDBID;

                DataTable myDataTable_SolutinsDBQuery = new DAL.SolutionsDBQueryDAL().getList_Search(1000, 1, WhereCondition, "ID", "Desc");

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
                    this.dvgSolutionDBQuery.Columns["clmQueryName"].DataPropertyName = "QueryName";

                    this.txtGeneratedQuery.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "QueryText");
                    this.txtQueryName.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "QueryName");
                    this.txtActionType.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "ActionType");
                    this.txtQueryType.DataBindings.Add("Text", this.SolutionDBQuery_bindingSource, "QueryType");

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

        void Insert_SolutionsDBQuery(string TableName, string QueryName, string ActionType, string QueryType, string QueryText, Boolean refreshGrid)
        {
            try
            {
                SolutionsDBQueryDAL SolutionsDBQueryDAL = new DAL.SolutionsDBQueryDAL();

                SolutionsDBQueryDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBQueryDAL.TableName = TableName;
                SolutionsDBQueryDAL.QueryName = QueryName;
                SolutionsDBQueryDAL.ActionType = ActionType;
                SolutionsDBQueryDAL.QueryType = QueryType;
                SolutionsDBQueryDAL.QueryText = QueryText;
                SolutionsDBQueryDAL.isActive = true;
                SolutionsDBQueryDAL.UserId = CommonClasses.Security.UserID;
                SolutionsDBQueryDAL.DALMethodName = "UpdatePayment";
                SolutionsDBQueryDAL.ActionID = 2;

                SolutionsDBQueryDAL.Insert();

                if (refreshGrid == true)
                {
                    this.getList_SolutionQueryDB(TableName);
                }

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Insert Query");
            }

        }
        #endregion

        #region "Generate SQL Queries"

        string ToolName = "Pss Programmer Mate";
        string Author = "Sajjucode";
        string DateTimeFormat = CommonClasses.CommonVariables.FullDateFormat;
        void Insert_GenerateSQLQuery(string DBType, string TableName, string SPName, Boolean refreshGrid)
        {
            try
            {


                if (this.isQueryExist(TableName, SPName) == true)
                {
                    return;
                }


                string HeaderComments = "-- ======================================================" + Environment.NewLine +
                                        "-- Name: " + SPName + Environment.NewLine +
                                        "-- Created By: " + this.ToolName + Environment.NewLine +
                                        "-- Author: " + this.Author + Environment.NewLine +
                                        "-- Created At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "-- Updated At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "-- Description : Insert" + Environment.NewLine +
                                        "-- ======================================================";
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string ColumnsName = "";
                string ColumnsValues = "";
                string OutputQuery = "";
                Boolean isIdentityInserted = false;
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBQueryColumnsDAL.QueryName = SPName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;




                if (DBType.ToLower() == "my sql")
                {
                    #region "my sql"
                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                        if (myCell.Value.ToString() == "1")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true)
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   in " + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString(); ;
                                    ColumnsName = myRows["ColumnName"].ToString();
                                    ColumnsValues = myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    inputerParameters = inputerParameters + " , " + Environment.NewLine + "   in " + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;

                                    if (ColumnsNo % 5 == 0)
                                    {
                                        ColumnsName = ColumnsName + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString();
                                        ColumnsValues = ColumnsValues + "," + Environment.NewLine + "               " + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        if (isIdentityInserted == false)
                                        {
                                            isIdentityInserted = true;
                                            ColumnsName = myRows["ColumnName"].ToString();
                                            ColumnsValues = myRows["ColumnName"].ToString();
                                        }
                                        else
                                        {
                                            ColumnsName = ColumnsName + " , " + myRows["ColumnName"].ToString();
                                            ColumnsValues = ColumnsValues + " , " + myRows["ColumnName"].ToString();
                                        }
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";
                            }
                            else
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   out " + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;
                                    OutputQuery = " Set " + myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                                }
                                else
                                {
                                    inputerParameters = inputerParameters + " , " + Environment.NewLine + "   out " + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;
                                    OutputQuery = " Set " + myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                                }
                            }


                            ColumnsNo++;

                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                            SolutionsDBQueryColumnsDAL.Insert();

                        }


                    }

                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " DELIMITER $$ " + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine +
                                                  "     Insert into " + TableName + Environment.NewLine +
                                                  "         ( " + Environment.NewLine + "              " + ColumnsName + Environment.NewLine + "           )" + Environment.NewLine +
                                                  "         Values " + Environment.NewLine +
                                                  "         ( " + Environment.NewLine + "               " + ColumnsValues + Environment.NewLine + "         ); " + Environment.NewLine +
                                                  "     " + OutputQuery + "" + Environment.NewLine +
                                                  " END$$ " + Environment.NewLine +
                                                  " DELIMITER ;";




                    #endregion
                }
                else if (DBType.ToLower() == "ms sql")
                {
                    #region "Ms sql"
                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmInsert"];

                        if (myCell.Value.ToString().ToLower() == "true")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true && string.IsNullOrEmpty(myRows["DefaultValue"].ToString()))
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();
                                    ColumnsName = myRows["ColumnName"].ToString();
                                    ColumnsValues = "@" + myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    inputerParameters = inputerParameters + " , " + Environment.NewLine + "   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;

                                    if (ColumnsNo % 5 == 0)
                                    {
                                        ColumnsName = ColumnsName + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString();
                                        ColumnsValues = ColumnsValues + "," + Environment.NewLine + "               " + "@" + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        //if (isIdentityInserted == false)
                                        //{
                                        //    isIdentityInserted = true;
                                        //    ColumnsName = myRows["ColumnName"].ToString();
                                        //    ColumnsValues = "@" + myRows["ColumnName"].ToString();
                                        //}
                                        //else
                                        //{
                                        //    ColumnsName = ColumnsName + " , " + myRows["ColumnName"].ToString();
                                        //    ColumnsValues = ColumnsValues + " , " + "@" + myRows["ColumnName"].ToString();
                                        //}

                                        ColumnsName = ColumnsName + " , " + myRows["ColumnName"].ToString();
                                        ColumnsValues = ColumnsValues + " , " + "@" + myRows["ColumnName"].ToString();
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";

                                ColumnsNo++;
                            }
                            else if (Boolean.Parse(myRows["isIdentity"].ToString()) != true && !string.IsNullOrEmpty(myRows["DefaultValue"].ToString()))
                            {
                                if (myRows["DefaultValue"].ToString().ToLower().Contains("date()"))
                                {
                                    InnerParameters = InnerParameters + Environment.NewLine + "     Declare   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + " = " + myRows["DefaultValue"].ToString();
                                }
                                else
                                {
                                    InnerParameters = InnerParameters + Environment.NewLine + "     Declare   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + " = '" + myRows["DefaultValue"].ToString() + "'";
                                }

                                if (ColumnsNo == 0)
                                {
                                    ColumnsName = myRows["ColumnName"].ToString();
                                    ColumnsValues = "@" + myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    if (ColumnsNo % 5 == 0)
                                    {
                                        ColumnsName = ColumnsName + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString();
                                        ColumnsValues = ColumnsValues + "," + Environment.NewLine + "               " + "@" + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        ColumnsName = ColumnsName + " , " + myRows["ColumnName"].ToString();
                                        ColumnsValues = ColumnsValues + " , " + "@" + myRows["ColumnName"].ToString();
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";

                                ColumnsNo++;
                            }
                            else
                            {

                                OutputQuery = " Select @@Identity;";

                            }




                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                            SolutionsDBQueryColumnsDAL.Insert();

                        }


                    }

                    //HeaderComments = " SET ANSI_NULLS ON " + Environment.NewLine +
                    //                 "   GO " + Environment.NewLine +
                    //                 "   SET QUOTED_IDENTIFIER ON " + Environment.NewLine +
                    //                 "   GO" + Environment.NewLine + Environment.NewLine +
                    //                 HeaderComments;


                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  "AS " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  "     SET NOCOUNT ON; " + Environment.NewLine +
                                                  "     " + InnerParameters + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  "     Insert into " + TableName + Environment.NewLine +
                                                  "         ( " + Environment.NewLine + "              " + ColumnsName + Environment.NewLine + "           )" + Environment.NewLine +
                                                  "         Values " + Environment.NewLine +
                                                  "         ( " + Environment.NewLine + "               " + ColumnsValues + Environment.NewLine + "         ); " + Environment.NewLine +
                                                  "     " + OutputQuery + "" + Environment.NewLine +
                                                  " END " + Environment.NewLine;



                    #endregion
                }
                this.Insert_SolutionsDBQuery(TableName, SPName, "Insert", "Store Procedure", QueryContent, refreshGrid);
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Insert Query");
            }
        }

        void Update_GenerateSQLQuery(string DBType, string TableName, string SPName, Boolean refreshGrid)
        {
            try
            {
                if (this.isQueryExist(TableName, SPName) == true)
                {
                    return;
                }

                string HeaderComments = "/*" + Environment.NewLine +
                                        "Name: " + SPName + Environment.NewLine +
                                        "Created By: " + this.ToolName + Environment.NewLine +
                                        "Author: " + this.Author + Environment.NewLine +
                                        "Created At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Updated At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Description : Update" + Environment.NewLine +
                                        "*/";
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string ColumnsName_Value = "";
                string OutputQuery = "";
                string myWhereCondition = "";
                Boolean isIdentityInserted = false;
                Boolean AlreadyWhered = false;
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBQueryColumnsDAL.QueryName = SPName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                if (DBType.ToLower() == "my sql")
                {
                    #region "My SQL"
                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                        if (myCell.Value.ToString() == "1")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true)
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   in " + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;
                                    ColumnsName_Value = myRows["ColumnName"].ToString() + "=" + myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    inputerParameters = inputerParameters + " , " + Environment.NewLine + "   in " + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;

                                    if (ColumnsNo % 5 == 0)
                                    {
                                        ColumnsName_Value = ColumnsName_Value + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString() + "=" + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        if (isIdentityInserted == false)
                                        {
                                            isIdentityInserted = true;
                                            ColumnsName_Value = myRows["ColumnName"].ToString() + "=" + myRows["ColumnName"].ToString();
                                        }
                                        else
                                        {
                                            ColumnsName_Value = ColumnsName_Value + " , " + myRows["ColumnName"].ToString() + "=" + myRows["ColumnName"].ToString();
                                        }
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";
                            }
                            else
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;
                                    OutputQuery = " select 1 as ReturnValue; ";// +myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                                    myWhereCondition = myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    inputerParameters = inputerParameters + " , " + Environment.NewLine + "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;
                                    OutputQuery = " select 1 as ReturnValue; ";
                                    myWhereCondition = myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString();
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                            }


                            ColumnsNo++;

                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                            SolutionsDBQueryColumnsDAL.Insert();

                        }


                    }

                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " DELIMITER $$ " + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine +
                                                  "     Update " + TableName + Environment.NewLine +
                                                  "     Set       " + ColumnsName_Value + " " + Environment.NewLine +
                                                  "     Where " + myWhereCondition + " ;" + Environment.NewLine +
                                                  "     " + OutputQuery + "" + Environment.NewLine +
                                                  " END$$ " + Environment.NewLine +
                                                  " DELIMITER ;";



                    #endregion

                }
                else if (DBType.ToLower() == "ms sql")
                {
                    #region "MS Sql "
                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmUpdate"];


                        myRows = (DataRowView)myRow.DataBoundItem;

                        if (myCell.Value.ToString().ToLower() == "true")
                        {
                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true && string.IsNullOrEmpty(myRows["DefaultValue"].ToString()))
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;
                                    ColumnsName_Value = myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    inputerParameters = inputerParameters + " , " + Environment.NewLine + "   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;

                                    if (ColumnsNo % 5 == 0)
                                    {
                                        ColumnsName_Value = ColumnsName_Value + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        if (isIdentityInserted == false)
                                        {
                                            isIdentityInserted = true;
                                            ColumnsName_Value = myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                        }
                                        else
                                        {
                                            ColumnsName_Value = ColumnsName_Value + " , " + myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                        }

                                        //ColumnsName_Value = ColumnsName_Value + " , " + myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";
                            }
                            else if (Boolean.Parse(myRows["isIdentity"].ToString()) != true && !string.IsNullOrEmpty(myRows["DefaultValue"].ToString()))
                            {
                                if (myRows["DefaultValue"].ToString().ToLower().Contains("date()"))
                                {
                                    InnerParameters = InnerParameters + Environment.NewLine + "     Declare   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + " = " + myRows["DefaultValue"].ToString();
                                }
                                else
                                {
                                    InnerParameters = InnerParameters + Environment.NewLine + "     Declare   @" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + " = '" + myRows["DefaultValue"].ToString() + "'";
                                }

                                if (ColumnsNo == 0)
                                {
                                    ColumnsName_Value = myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    if (ColumnsNo % 5 == 0)
                                    {
                                        ColumnsName_Value = ColumnsName_Value + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        ColumnsName_Value = ColumnsName_Value + " , " + myRows["ColumnName"].ToString() + "=@" + myRows["ColumnName"].ToString();
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";

                                ColumnsNo++;
                            }
                        }


                        if (Boolean.Parse(myRows["isWhere"].ToString()) == true)
                        {
                            if (ColumnsNo == 0)
                            {
                                inputerParameters = "   @org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();                                
                            }
                            else
                            {
                                inputerParameters = inputerParameters + " , " + Environment.NewLine + "   @org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;                                                                
                            }

                            if (AlreadyWhered ==false)
                            {
                                AlreadyWhered = true;
                                myWhereCondition = myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
                            }
                            else
                            {
                                myWhereCondition = myWhereCondition + Environment.NewLine  + "           And " + myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
                            }

                            SolutionsDBQueryColumnsDAL.ParameterName = "@org" + myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                        }


                        ColumnsNo++;

                        SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                        SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                        SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                        SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                        SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                        SolutionsDBQueryColumnsDAL.Insert();




                    }

                    OutputQuery = " select 1 as ReturnValue; ";

                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  " AS " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine + Environment.NewLine +
                                                  "     SET NOCOUNT ON; " + Environment.NewLine +
                                                  "     " + InnerParameters + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  "     Update " + TableName + Environment.NewLine +
                                                  "     Set       " + ColumnsName_Value + " " + Environment.NewLine +
                                                  "     Where " + myWhereCondition + " ;" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  "     " + OutputQuery + "" + Environment.NewLine +
                                                  " END " + Environment.NewLine;




                    #endregion

                }


                this.Insert_SolutionsDBQuery(TableName, SPName, "Update", "Store Procedure", QueryContent, refreshGrid);

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Update Query");
            }
        }

        void Delete_GenerateSQLQuery(string DBType, string TableName, string SPName, Boolean refreshGrid)
        {
            try
            {
                if (this.isQueryExist(TableName, SPName) == true)
                {
                    return;
                }

                string HeaderComments = "/*" + Environment.NewLine +
                                        "Name: " + SPName + Environment.NewLine +
                                        "Created By: " + this.ToolName + Environment.NewLine +
                                        "Author: " + this.Author + Environment.NewLine +
                                        "Created At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Updated At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Description : Delete by Id" + Environment.NewLine +
                                        "*/";
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string ColumnsName_Value = "";
                string OutputQuery = "";
                string myWhereCondition = "";
                Boolean AlreadyWhered = false;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBQueryColumnsDAL.QueryName = SPName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                if (DBType.ToLower() == "my sql")
                {
                    #region " My SQL"

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                        if (myCell.Value.ToString() == "1")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true)
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    OutputQuery = " select 1 as ReturnValue; ";// +myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                                    myWhereCondition = myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString();

                                    SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                                    SolutionsDBQueryColumnsDAL.ParameterType = "Where";
                                }
                                else
                                {
                                    inputerParameters = "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    OutputQuery = " select 1 as ReturnValue; ";
                                    myWhereCondition = myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString();

                                    SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                                    SolutionsDBQueryColumnsDAL.ParameterType = "Where";
                                }

                            }


                            ColumnsNo++;

                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                            SolutionsDBQueryColumnsDAL.Insert();

                        }


                    }

                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " DELIMITER $$ " + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine +
                                                  "     Delete From " + TableName + Environment.NewLine +
                                                  "     Where " + myWhereCondition + " ;" + Environment.NewLine +
                                                  "     " + OutputQuery + "" + Environment.NewLine +
                                                  " END$$ " + Environment.NewLine +
                                                  " DELIMITER ;";

                    #endregion
                }
                else if (DBType.ToLower() == "ms sql")
                {
                    #region " Ms SQL"

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmWhere"];

                        if (myCell.Value.ToString().ToLower() == "true")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            //if (Boolean.Parse(myRows["isWhere"].ToString()) == true)
                            //{
                            //    if (ColumnsNo == 0)
                            //    {
                            //        SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                            //        SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                            //        inputerParameters = "   @org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                            //        OutputQuery = " select 1 as ReturnValue; ";// +myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                            //        myWhereCondition = myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
                            //    }
                            //    else
                            //    {
                            //        SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                            //        SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                            //        inputerParameters = "   org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                            //        OutputQuery = " select 1 as ReturnValue; ";
                            //        myWhereCondition = myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString();
                            //    }

                            //}

                            if (Boolean.Parse(myRows["isWhere"].ToString()) == true)
                            {
                                if (ColumnsNo == 0)
                                {
                                    inputerParameters = "   @org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();
                                }
                                else
                                {
                                    inputerParameters = inputerParameters + " , " + Environment.NewLine + "   @org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString();// +Environment.NewLine;                                                                
                                }

                                if (AlreadyWhered == false)
                                {
                                    AlreadyWhered = true;
                                    myWhereCondition = myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
                                }
                                else
                                {
                                    myWhereCondition = myWhereCondition + Environment.NewLine + "            And " + myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@org" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                            }


                            ColumnsNo++;

                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                            SolutionsDBQueryColumnsDAL.Insert();

                        }


                    }

                    OutputQuery = " select 1 as ReturnValue; ";

                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  " AS " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine +
                                                  "     SET NOCOUNT ON; " + Environment.NewLine + Environment.NewLine +
                                                  "     Delete From " + TableName + Environment.NewLine +
                                                  "     Where " + myWhereCondition + " ;" + Environment.NewLine +
                                                  "     " + OutputQuery + "" + Environment.NewLine +
                                                  " END " + Environment.NewLine;

                    #endregion
                }


                this.Insert_SolutionsDBQuery(TableName, SPName, "Delete", "Store Procedure", QueryContent, refreshGrid);

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Delete Query");
            }
        }


        void GetList_GenerateSQLQuery(string DBType, string TableName, string SPName, Boolean refreshGrid)
        {
            try
            {

                if (this.isQueryExist(TableName, SPName) == true)
                {
                    this.GetListTableOperation_GenerateSQLQuery(DBType, TableName, "sp" + this.cmbDBTables.Text + "ListByTableOperations", refreshGrid);
                    return;
                }

                string HeaderComments = "/*" + Environment.NewLine +
                                        "Name: " + SPName + Environment.NewLine +
                                        "Created By: " + this.ToolName + Environment.NewLine +
                                        "Author: " + this.Author + Environment.NewLine +
                                        "Created At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Updated At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Description : Get List" + Environment.NewLine +
                                        "*/";
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string SelectedColumns = "";
                string OutputQuery = "";
                string myWhereCondition = "";

                string OrderByColumn = string.Empty;
                Boolean isIdentityInserted = false;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBQueryColumnsDAL.QueryName = SPName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;



                if (DBType.ToLower() == "my sql")
                {
                    #region "My Sql"

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                        if (myCell.Value.ToString() == "1")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true)
                            {
                                if (ColumnsNo == 0)
                                {

                                    SelectedColumns = myRows["ColumnName"].ToString();
                                }
                                else
                                {

                                    if (ColumnsNo % 5 == 0)
                                    {
                                        SelectedColumns = SelectedColumns + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        if (isIdentityInserted == false)
                                        {
                                            isIdentityInserted = true;
                                            SelectedColumns = myRows["ColumnName"].ToString(); ;
                                        }
                                        else
                                        {
                                            SelectedColumns = SelectedColumns + " , " + myRows["ColumnName"].ToString(); ;
                                        }
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Select";
                            }
                            else
                            {
                                isIdentityInserted = true;
                                if (ColumnsNo == 0)
                                {
                                    SelectedColumns = myRows["ColumnName"].ToString();
                                    inputerParameters = "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    OutputQuery = " select 1 as ReturnValue; ";// +myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                                    myWhereCondition = "(org_" + myRows["ColumnName"].ToString() + " = 0 Or " + myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString() + ")";
                                }
                                else
                                {
                                    SelectedColumns = SelectedColumns + " , " + myRows["ColumnName"].ToString();
                                    inputerParameters = inputerParameters + " , " + "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    myWhereCondition = "(org_" + myRows["ColumnName"].ToString() + " = 0 Or " + myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString() + ")";
                                }

                                OrderByColumn = myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                            }


                            ColumnsNo++;

                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                            SolutionsDBQueryColumnsDAL.Insert();

                        }


                    }

                    //QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                    //                              " DELIMITER $$ " + Environment.NewLine +
                    //                              " Create procedure " + SPName + " (" + Environment.NewLine +
                    //                              inputerParameters + Environment.NewLine +
                    //                              ") " + Environment.NewLine +
                    //                              " Begin " + Environment.NewLine +
                    //                              "     Select " + SelectedColumns + Environment.NewLine +
                    //                              "     From       " + TableName + " " + Environment.NewLine +
                    //                              "     Where " + myWhereCondition + " ;" + Environment.NewLine +
                    //                              " END$$ " + Environment.NewLine +
                    //                              " DELIMITER ;";

                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                 " DELIMITER $$ " + Environment.NewLine +
                                                 " Create procedure " + SPName + " (" + Environment.NewLine +
                                                 inputerParameters + Environment.NewLine +
                                                 ") " + Environment.NewLine +
                                                 " Begin " + Environment.NewLine +
                                                "  If (@OrderType like 'asc') " + Environment.NewLine +
                                                 "  Begin " + Environment.NewLine +
                                                 "     Select " + SelectedColumns + Environment.NewLine +
                                                 "     From       " + TableName + " " + Environment.NewLine +
                                                 "     Where " + myWhereCondition + " " + Environment.NewLine +
                                                 "     Order by " + OrderByColumn + " asc" + Environment.NewLine +
                                                 "     OFFSET @PageSize * (@PageNo - 1) ROWS " + Environment.NewLine +
                                                 "     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); " + Environment.NewLine +
                                                 "  End " + Environment.NewLine +
                                                 "Else " + Environment.NewLine +
                                                 "Begin " + Environment.NewLine +
                                                 "     Select " + SelectedColumns + Environment.NewLine +
                                                 "     From       " + TableName + " " + Environment.NewLine +
                                                 "     Where " + myWhereCondition + " " + Environment.NewLine +
                                                 "     Order by " + OrderByColumn + " desc" + Environment.NewLine +
                                                 "     Limit @PageSize * (@PageNo - 1),@PageSize ;" + Environment.NewLine +
                                                 "End " + Environment.NewLine +
                                                 " END$$ " + Environment.NewLine +
                                                 " DELIMITER ;";
                    #endregion
                }
                else if (DBType.ToLower() == "ms sql")
                {
                    #region "Ms Sql"

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                        if (myCell.Value.ToString() == "1")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true)
                            {
                                if (ColumnsNo == 0)
                                {

                                    SelectedColumns = myRows["ColumnName"].ToString();
                                }
                                else
                                {

                                    if (ColumnsNo % 5 == 0)
                                    {
                                        SelectedColumns = SelectedColumns + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        if (isIdentityInserted == false)
                                        {
                                            isIdentityInserted = true;
                                            SelectedColumns = myRows["ColumnName"].ToString(); ;
                                        }
                                        else
                                        {
                                            SelectedColumns = SelectedColumns + " , " + myRows["ColumnName"].ToString(); ;
                                        }
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Select";
                            }
                            else
                            {
                                isIdentityInserted = true;
                                if (ColumnsNo == 0)
                                {
                                    SelectedColumns = myRows["ColumnName"].ToString();

                                    inputerParameters = "   @org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;

                                    inputerParameters = inputerParameters + " , " + "   @PageSize " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    inputerParameters = inputerParameters + " , " + "   @PageNo " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    //inputerParameters = inputerParameters + " , " + "   @OrderBy " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    inputerParameters = inputerParameters + " , " + "   @OrderType " + myRows["ColumnType"].ToString() + Environment.NewLine;

                                    OutputQuery = " select 1 as ReturnValue; ";// +myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                                    myWhereCondition = "(@org_" + myRows["ColumnName"].ToString() + " = 0 Or " + myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString() + ")";
                                }
                                else
                                {
                                    SelectedColumns = SelectedColumns + " , " + myRows["ColumnName"].ToString();
                                    inputerParameters = inputerParameters + " , " + "   @org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;

                                    inputerParameters = inputerParameters + " , " + "   @PageSize " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    inputerParameters = inputerParameters + " , " + "   @PageNo " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    //inputerParameters = inputerParameters + " , " + "   @OrderBy " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    inputerParameters = inputerParameters + " , " + "   @OrderType " + myRows["ColumnType"].ToString() + Environment.NewLine;

                                    myWhereCondition = "(@org_" + myRows["ColumnName"].ToString() + " = 0 Or " + myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString() + ")";
                                }

                                OrderByColumn = myRows["ColumnName"].ToString();

                                SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Where";


                                #region "Pagination"
                                SolutionsDBQueryColumnsDAL.ParameterName = "@PageSize";
                                SolutionsDBQueryColumnsDAL.Insert();

                                SolutionsDBQueryColumnsDAL.ParameterName = "@PageNo";
                                SolutionsDBQueryColumnsDAL.Insert();

                                //SolutionsDBQueryColumnsDAL.ParameterName = "@OrderBy";
                                //SolutionsDBQueryColumnsDAL.Insert();

                                SolutionsDBQueryColumnsDAL.ParameterName = "@OrderType";
                                SolutionsDBQueryColumnsDAL.Insert();
                                #endregion

                            }


                            ColumnsNo++;

                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();

                            SolutionsDBQueryColumnsDAL.Insert();



                        }


                    }

                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  " AS " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine +
                                                  "  If (@OrderType like 'asc') " + Environment.NewLine +
                                                  "  Begin " + Environment.NewLine +
                                                  "     Select " + SelectedColumns + Environment.NewLine +
                                                  "     From       " + TableName + " " + Environment.NewLine +
                                                  "     Where " + myWhereCondition + " " + Environment.NewLine +
                                                  "     Order by " + OrderByColumn + " asc" + Environment.NewLine +
                                                  "     OFFSET @PageSize * (@PageNo - 1) ROWS " + Environment.NewLine +
                                                  "     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); " + Environment.NewLine +
                                                  "  End " + Environment.NewLine +
                                                  "Else " + Environment.NewLine +
                                                  "Begin " + Environment.NewLine +
                                                  "     Select " + SelectedColumns + Environment.NewLine +
                                                  "     From       " + TableName + " " + Environment.NewLine +
                                                  "     Where " + myWhereCondition + " " + Environment.NewLine +
                                                  "     Order by " + OrderByColumn + " desc" + Environment.NewLine +
                                                  "     OFFSET @PageSize * (@PageNo - 1) ROWS " + Environment.NewLine +
                                                  "     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); " + Environment.NewLine +
                                                  "End " + Environment.NewLine +
                                                  "End ";



                    #endregion
                }


                this.Insert_SolutionsDBQuery(TableName, SPName, "Get", "Store Procedure", QueryContent, refreshGrid);

                this.GetListTableOperation_GenerateSQLQuery(DBType, TableName, "sp" + this.cmbDBTables.Text + "ListByTableOperations", refreshGrid);
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Get Query");
            }
        }

        void GetListTableOperation_GenerateSQLQuery(string DBType, string TableName, string SPName, Boolean refreshGrid)
        {
            try
            {

                if (this.isQueryExist(TableName, SPName) == true)
                {
                    return;
                }

                string HeaderComments = "/*" + Environment.NewLine +
                                        "Name: " + SPName + Environment.NewLine +
                                        "Created By: " + this.ToolName + Environment.NewLine +
                                        "Author: " + this.Author + Environment.NewLine +
                                        "Created At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Updated At: " + DateTime.Now.ToString(this.DateTimeFormat) + Environment.NewLine +
                                        "Description : Get List by " + Environment.NewLine + " Operations " +
                                        "*/";
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string SelectedColumns = "";
                string OutputQuery = "";
                string myWhereCondition = "";

                string OrderByColumn = string.Empty;
                Boolean isIdentityInserted = false;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = this.CurrentDBID;
                SolutionsDBQueryColumnsDAL.QueryName = SPName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;



                if (DBType.ToLower() == "my sql")
                {
                    #region "My Sql"

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                        if (myCell.Value.ToString() == "1")
                        {
                            myRows = (DataRowView)myRow.DataBoundItem;

                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true)
                            {
                                if (ColumnsNo == 0)
                                {

                                    SelectedColumns = myRows["ColumnName"].ToString();
                                }
                                else
                                {

                                    if (ColumnsNo % 5 == 0)
                                    {
                                        SelectedColumns = SelectedColumns + "," + Environment.NewLine + "                " + myRows["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        if (isIdentityInserted == false)
                                        {
                                            isIdentityInserted = true;
                                            SelectedColumns = myRows["ColumnName"].ToString(); ;
                                        }
                                        else
                                        {
                                            SelectedColumns = SelectedColumns + " , " + myRows["ColumnName"].ToString(); ;
                                        }
                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Select";
                            }
                            else
                            {
                                isIdentityInserted = true;
                                if (ColumnsNo == 0)
                                {
                                    SelectedColumns = myRows["ColumnName"].ToString();
                                    inputerParameters = "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    OutputQuery = " select 1 as ReturnValue; ";// +myRows["ColumnName"].ToString() + " = LAST_INSERT_ID();";
                                    myWhereCondition = "(org_" + myRows["ColumnName"].ToString() + " = 0 Or " + myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString() + ")";
                                }
                                else
                                {
                                    SelectedColumns = SelectedColumns + " , " + myRows["ColumnName"].ToString();
                                    inputerParameters = inputerParameters + " , " + "   in org_" + myRows["ColumnName"].ToString() + " " + myRows["ColumnType"].ToString() + Environment.NewLine;
                                    myWhereCondition = "(org_" + myRows["ColumnName"].ToString() + " = 0 Or " + myRows["ColumnName"].ToString() + " = org_" + myRows["ColumnName"].ToString() + ")";
                                }

                                OrderByColumn = myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterName = "@org_" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                            }


                            ColumnsNo++;

                            SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                            SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                            SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                            SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                            SolutionsDBQueryColumnsDAL.Insert();

                        }


                    }


                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                 " DELIMITER $$ " + Environment.NewLine +
                                                 " Create procedure " + SPName + " (" + Environment.NewLine +
                                                 inputerParameters + Environment.NewLine +
                                                 ") " + Environment.NewLine +
                                                 " Begin " + Environment.NewLine +
                                                "  If (@OrderType like 'asc') " + Environment.NewLine +
                                                 "  Begin " + Environment.NewLine +
                                                 "     Select " + SelectedColumns + Environment.NewLine +
                                                 "     From       " + TableName + " " + Environment.NewLine +
                                                 "     Where " + myWhereCondition + " " + Environment.NewLine +
                                                 "     Order by " + OrderByColumn + " asc" + Environment.NewLine +
                                                 "     OFFSET @PageSize * (@PageNo - 1) ROWS " + Environment.NewLine +
                                                 "     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); " + Environment.NewLine +
                                                 "  End " + Environment.NewLine +
                                                 "Else " + Environment.NewLine +
                                                 "Begin " + Environment.NewLine +
                                                 "     Select " + SelectedColumns + Environment.NewLine +
                                                 "     From       " + TableName + " " + Environment.NewLine +
                                                 "     Where " + myWhereCondition + " " + Environment.NewLine +
                                                 "     Order by " + OrderByColumn + " desc" + Environment.NewLine +
                                                 "     Limit @PageSize * (@PageNo - 1),@PageSize ;" + Environment.NewLine +
                                                 "End " + Environment.NewLine +
                                                 " END$$ " + Environment.NewLine +
                                                 " DELIMITER ;";
                    #endregion
                }
                else if (DBType.ToLower() == "ms sql")
                {
                    #region "Ms Sql"

                    inputerParameters = "    @TableName nvarchar(120) = '" + this.cmbDBTables.Text + "' ,	" + Environment.NewLine +
                                        "    @OrderBy nvarchar(1000) = 'ID Asc',	" + Environment.NewLine +
                                        "    @PageSize int = 20,	" + Environment.NewLine +
                                        "    @PageNo int = 1,		" + Environment.NewLine +
                                        "    @SelectedColumns nvarchar(Max) = 'All',	" + Environment.NewLine +
                                        "    @WhereCondition nvarchar(1500) = 'None'" + Environment.NewLine;


                    QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                  " Create procedure " + SPName + " (" + Environment.NewLine +
                                                  inputerParameters + Environment.NewLine +
                                                  ") " + Environment.NewLine +
                                                  " AS " + Environment.NewLine +
                                                  " Begin " + Environment.NewLine +
                                                  "Declare @SqlQuery nvarchar(Max)	 " + Environment.NewLine +
                                                  "  If (@SelectedColumns like 'All') " + Environment.NewLine +
                                                  "  Begin " + Environment.NewLine +
                                                  "      Set @SqlQuery = 'Select * ' + char(13) +  " + Environment.NewLine +
                                                  "                      ' From ' + @TableName + char(13) ;  " + Environment.NewLine +
                                                  "  End  " + Environment.NewLine +
                                                  "  Else  " + Environment.NewLine +
                                                  "  Begin  " + Environment.NewLine +
                                                  "      Set @SqlQuery = 'Select ' + @SelectedColumns + char(13) +  " + Environment.NewLine +
                                                  "                      ' From ' + @TableName + char(13) ;  " + Environment.NewLine +
                                                  "  End  " + Environment.NewLine +
                                                  "   " + Environment.NewLine +
                                                  "  If (@WhereCondition <> 'None')  " + Environment.NewLine +
                                                  "  Begin  " + Environment.NewLine +
                                                  "      Set @SqlQuery = @SqlQuery + ' ' + char(13) +  " + Environment.NewLine +
                                                  "                      ' Where ' + @WhereCondition ;  " + Environment.NewLine +
                                                  "  End  " + Environment.NewLine +
                                                  "  " + Environment.NewLine +
                                                  "  if (@OrderBy <> 'None')  " + Environment.NewLine +
                                                  "  Begin  " + Environment.NewLine +
                                                  "      Set @SqlQuery = @SqlQuery + Char(13) +  " + Environment.NewLine +
                                                  "                      'Order By ' + @OrderBy  " + Environment.NewLine +
                                                  "  End  " + Environment.NewLine +
                                                  "  " + Environment.NewLine +
                                                  "  Set @SqlQuery = @SqlQuery + Char(13) +  " + Environment.NewLine +
                                                  "                  'OFFSET ' +  Cast((@PageSize * (@PageNo - 1)) as nvarchar(100)) + ' ROWS ' + cHAR(13) +  " + Environment.NewLine +
                                                  "                  'FETCH NEXT ' + Cast(@PageSize as Varchar(10))  + ' ROWS ONLY OPTION (RECOMPILE);';   " + Environment.NewLine +
                                                  "  " + Environment.NewLine +
                                                  " --print @sqlQuery  " + Environment.NewLine +
                                                  " EXECUTE sp_executesql @sqlQuery  " + Environment.NewLine +
                                                  "End ";



                    #endregion
                }


                this.Insert_SolutionsDBQuery(TableName, SPName, "Get Operational", "Store Procedure", QueryContent, refreshGrid);

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Get Query");
            }
        }



        #endregion
        public frmSQLGenerate()
        {
            InitializeComponent();
        }

        private void frmSQLGenerate_Load(object sender, EventArgs e)
        {
            try
            {
                this.dvgSolutionDBQuery.AutoGenerateColumns = false;
                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgTableColumns);
                this.dvgTableColumns.AutoGenerateColumns = false;

                this.getList_Solutions();

                this.dvgTableColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ViewAll_SolutionsDB();
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


                if (myRow != null && myRow["DBType"].ToString().ToLower() == "my sql")
                {

                    this.MySQL_Connect_GetTable();
                }
                else if (myRow != null && myRow["DBType"].ToString().ToLower() == "ms sql")
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

        private void cmdColumns_Click(object sender, EventArgs e)
        {
            try
            {
                //this.SolutionDBQuery_bindingSource.DataSource = null;
                //this.dvgSolutionDBQuery.DataBindings.Clear();

                this.getList_SolutionQueryDB(this.cmbDBTables.Text);

                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                if (myRow != null && myRow["DBType"].ToString().ToLower() == "my sql")
                {
                    this.MySql_Table_GetColumns(this.cmbDBTables.SelectedValue.ToString());
                }
                else if (myRow != null && myRow["DBType"].ToString().ToLower() == "ms sql")
                {
                    this.MSSql_Table_GetColumns(this.cmbDBTables.SelectedValue.ToString());
                }

                this.GetAutoSQLName_SolutionsDB(this.cmbDBTables.SelectedValue.ToString());

                this.GetSelectDB_TableColumns();


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Table Columns");
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

        private void cmdGenerateSQL_Insert_Click(object sender, EventArgs e)
        {
            this.Insert_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_Insert.Text, true);
        }

        private void cmdGenerateSQL_Update_Click(object sender, EventArgs e)
        {
            this.Update_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_Update.Text, true);
        }

        private void cmdGenerateSQL_Delete_Click(object sender, EventArgs e)
        {
            this.Delete_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_Delete.Text, true);
        }

        private void cmdGenerateSQL_GetRecord_Click(object sender, EventArgs e)
        {
            this.GetList_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_GetRecord.Text, true);
        }

        private void bnbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (Messages.myGeneralAskMsgBox("Execute Query", "Query ") == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                    if (myRow != null && myRow["DBType"].ToString().ToLower() == "my sql")
                    {
                        this.MySql_Query_Execute(this.txtGeneratedQuery.Text);
                    }
                    else if (myRow != null && myRow["DBType"].ToString().ToLower() == "ms sql")
                    {
                        this.MSSql_Query_Execute(this.txtGeneratedQuery.Text);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdGenerateAllSql_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkInsert.Checked)
                {
                    this.Insert_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_Insert.Text, false);
                }

                if (chkUpdate.Checked)
                {
                    this.Update_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_Update.Text, false);
                }

                if (chkDelete.Checked)
                {
                    this.Delete_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_Delete.Text, false);
                }

                if (chkGetRecord.Checked)
                {
                    this.GetList_GenerateSQLQuery(this.CurrentDBType, this.cmbDBTables.SelectedValue.ToString(), this.txtSqlName_GetRecord.Text, false);
                }

                this.getList_SolutionQueryDB(this.cmbDBTables.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbDBTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmdColumns_Click(null, null);
                this.cbkSelectAll_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
