using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.DAL;
using System.IO;

namespace Pss.ProgrammerMate
{
    public partial class frmDataAccess : Form
    {
        string CurrentDBType = "";
        int CurrentDBID = 0;

        string CurrentFolderName;
        int CurrentFolderId = 0;

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
                DataTable myDataTable_SolutionsDBTables = new SolutionsDBTablesDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString(), "TableName");

                if (myDataTable_SolutionsDBTables != null)
                {
                    this.SolutionsDBTables_bindingSource.DataSource = myDataTable_SolutionsDBTables;
                }

                if (this.SolutionsDBTables_bindingSource.DataSource != null)
                {
                    this.cmbDBTables.DataSource = this.SolutionsDBTables_bindingSource;
                    this.cmbDBTables.DisplayMember = "TableName";
                    this.cmbDBTables.ValueMember = "ID";
                }

                this.cmbDBTables.Refresh();
                this.cmbDBTables.Update();

                this.GetSelectDB_TableColumns();
            }
            catch (Exception ex)
            {

            }
        }

        Boolean isMapped_TableColumns;
        void GetSelectDB_TableColumns()
        {
            try
            {
                this.getProject_TableEntity();
                DataTable myDataTable_SolutionsDBTableColumns = new SolutionsDBTableColumnsDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString() + " and TableName like '" + this.cmbDBTables.Text + "'", "ID");

                if (myDataTable_SolutionsDBTableColumns != null)
                {
                    this.TableColumns_bindingSource.DataSource = myDataTable_SolutionsDBTableColumns;
                }

                if (isMapped_TableColumns == false)
                {
                    isMapped_TableColumns = true;
                    this.dvgTableColumns.DataSource = this.TableColumns_bindingSource;

                    this.dvgTableColumns.Columns["clmName"].DataPropertyName = "ColumnName";
                    this.dvgTableColumns.Columns["clmType"].DataPropertyName = "ColumnType";
                }
                this.dvgTableColumns.Refresh();
                this.dvgTableColumns.Update();


            }
            catch (Exception ex)
            {

            }
        }

        void SelectColumns()
        {
            try
            {
                this.getSelectedTableFolder();

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

        #endregion

        #region "Get Projects"

        Boolean isProjectMapped;
        void ViewAll_Projects()
        {
            try
            {

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                myDataTable_SolutionsDB = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.cmbSolutions.SelectedValue.ToString() + " and ProjectType like 'Data Access'", "ID", "asc");




                this.Projects_bindingSource.DataSource = myDataTable_SolutionsDB;

                if (this.Projects_bindingSource.DataSource != null && this.isProjectMapped == false)
                {
                    this.isProjectMapped = true;

                    this.txtBaseFolder.DataBindings.Add("Text", this.Projects_bindingSource, "BaseFolder", false);
                    this.txtProjectNamespace.DataBindings.Add("Text", this.Projects_bindingSource, "PNameSpace", false);
                }

                this.cmbProjects.DataSource = this.Projects_bindingSource;
                this.cmbProjects.DisplayMember = "ProjectName";
                this.cmbProjects.ValueMember = "ID";

                this.cmbProjects.Update();
                this.cmbProjects.Refresh();





                myDataTable_SolutionsDB = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.cmbSolutions.SelectedValue.ToString() + " and ProjectType like 'Business Entity'", "ID", "asc");


                this.cmbProjectID_BusinessEntity.DataSource = myDataTable_SolutionsDB;
                this.cmbProjectID_BusinessEntity.DisplayMember = "ProjectName";
                this.cmbProjectID_BusinessEntity.ValueMember = "ID";

                this.cmbProjectID_BusinessEntity.Update();
                this.cmbProjectID_BusinessEntity.Refresh();
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project");
            }
        }
        #endregion

        #region "Solution & Table Folder"
        void getSelectedTableFolder()
        {
            try
            {
                DataTable myDataTable_TableFolder = new SolutionFolders_TablesDAL().getTableFolderInfo(int.Parse(this.cmbSolutions.SelectedValue.ToString()), this.cmbDBTables.Text);

                if (myDataTable_TableFolder != null && myDataTable_TableFolder.Rows.Count > 0)
                {
                    DataRow myRow = myDataTable_TableFolder.Rows[0];

                    this.CurrentFolderName = myRow["FolderName"].ToString();
                    this.CurrentFolderId = int.Parse(myRow["FolderId"].ToString());

                    this.txtGenerateDALSaveIn.Text = myRow["NamespaceFormat"].ToString().Replace(".", "\\").Replace("{Parent}", this.txtBaseFolder.Text).Replace("{FolderName}", myRow["FolderName"].ToString()); // this.txtBaseFolder.Text + "\\" + myRow["FolderName"].ToString();
                    this.txtGenerateBENamespace.Text = myRow["NamespaceFormat"].ToString().Replace("{Parent}", this.txtProjectNamespace.Text).Replace("{FolderName}", myRow["FolderName"].ToString());

                    this.txtClassName.Text = this.cmbDBTables.Text + ".cs";
                    this.txtInterfaceName.Text = "I" + this.cmbDBTables.Text + ".cs";

                    this.txtClassName.Text = this.cmbDBTables.Text + "DAL.cs";
                    this.txtInterfaceName.Text = "I" + this.cmbDBTables.Text + "DAL.cs";


                    this.txtInterfaceSaveAs.Text = myRow["InterfaceNamespaceFormat"].ToString().Replace(".", "\\").Replace("{Parent}", this.txtBaseFolder.Text).Replace("{FolderName}", myRow["FolderName"].ToString()); // this.txtBaseFolder.Text + "\\" + myRow["FolderName"].ToString();
                    this.txtInterfaceNamespace.Text = myRow["InterfaceNamespaceFormat"].ToString().Replace("{Parent}", this.txtProjectNamespace.Text).Replace("{FolderName}", myRow["FolderName"].ToString());


                }

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Solutions DB Query"
        Boolean isMapped_SolutionDBQuery;
        void getDBQuery_SelectedTable(string TableName)
        {
            try
            {
                DataTable myDataTable_SolutionsDBQuery = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");
                myDataTable_SolutionsDBQuery = new SolutionsDBQueryDAL().getList_Search(100000, 1, " SolutionsDBID=" + this.cmbSolutionsDB.SelectedValue.ToString() + " and TableName like '" + TableName + "'", "ID", "asc");

                if (myDataTable_SolutionsDBQuery != null)
                {
                    this.SolutionsDBQuery_bindingSource.DataSource = myDataTable_SolutionsDBQuery;
                }

                if (this.isMapped_SolutionDBQuery == false)
                {
                    this.isMapped_SolutionDBQuery = true;
                    this.dgvTableStoreProcedures.DataSource = this.SolutionsDBQuery_bindingSource;

                    this.dgvTableStoreProcedures.Columns["clmQueryName"].DataPropertyName = "QueryName";
                    this.dgvTableStoreProcedures.Columns["clmQueryType"].DataPropertyName = "QueryType";
                    this.dgvTableStoreProcedures.Columns["clmActionType"].DataPropertyName = "ActionType";
                    this.dgvTableStoreProcedures.Columns["clmMethod"].DataPropertyName = "DALMethodName";

                }


                this.dgvTableStoreProcedures.Refresh();

                this.getDBQuery_MethodName();
                this.SelectColumn_SQLDBQuery();

                this.chkSelectAll_DBQuery.Checked = true;



            }
            catch (Exception ex)
            {

            }
        }

        void getDBQuery_MethodName()
        {
            try
            {
                String MethodName = string.Empty;
                int LastIndex = 0;
                foreach (DataGridViewRow myRow in this.dgvTableStoreProcedures.Rows)
                {
                    LastIndex = myRow.Cells["clmQueryName"].Value.ToString().LastIndexOf("_");

                    if (LastIndex > 0)
                    {
                        //myRow.Cells["clmMethod"].Value = myRow.Cells["clmQueryName"].Value.ToString().Substring(LastIndex + 1);
                    }



                }
            }
            catch (Exception ex)
            {

            }
        }

        void SelectColumn_SQLDBQuery()
        {
            try
            {
                this.getSelectedTableFolder();

                if (this.chkSelectAll_DBQuery.Checked == true)
                {
                    this.chkSelectAll_DBQuery.Text = "Un-select All";

                    foreach (DataGridViewRow myRow in this.dgvTableStoreProcedures.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clsSelect_Query"];
                        myCell.Value = 1;
                    }

                }
                else
                {
                    this.chkSelectAll_DBQuery.Text = "Select All";

                    foreach (DataGridViewRow myRow in this.dgvTableStoreProcedures.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clsSelect_Query"];
                        myCell.Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }
        #endregion

        #region "Data Access"
        string DateTimeFormat = CommonClasses.CommonVariables.FullDateFormat;
        void Generate_DataAccess()
        {
            try
            {
                DataTable myQueryColumns_DataTable = this.getSelectTable_QueryColumns(this.cmbDBTables.Text);

                if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count <= 0)
                {
                    Messages.GeneralError("No column exists for Table " + this.cmbDBTables.Text, "Table Columns");
                }

                string ClassReferences = "using System; " + Environment.NewLine +
                                         "using System.Collections.Generic; " + Environment.NewLine +
                                         "using System.Linq; " + Environment.NewLine +
                                         "using System.Text; " + Environment.NewLine +
                                         "using System.Threading.Tasks;" + Environment.NewLine +
                                         "using System.Data;" + Environment.NewLine +
                                         "using " + this.txtProjectNamespace.Text + ".Base;";

                string IClassReferences = "using System; " + Environment.NewLine +
                                         "using System.Collections.Generic; " + Environment.NewLine +
                                         "using System.Linq; " + Environment.NewLine +
                                         "using System.Text; " + Environment.NewLine +
                                         "using System.Threading.Tasks;" + Environment.NewLine +
                                         "using System.Data;" + Environment.NewLine +
                                         "using " + this.txtProjectNamespace.Text + ".Base;";

                string HeaderCommand = "/// <summary> " + Environment.NewLine +
                                       "/// Data Access for Table " + this.cmbDBTables.Text + Environment.NewLine +
                                       "  /// </summary>  " + Environment.NewLine +
                                       "  /// <remarks>  " + Environment.NewLine +
                                       "  /// Tool: Programmer Mate  " + Environment.NewLine +
                                       "  /// Author: Sajjucode  " + Environment.NewLine +
                                       "  /// Created Date: " + DateTime.Now.ToString(DateTimeFormat) + Environment.NewLine +
                                       "  /// Copy Rights: PakSoft Solutions  " + Environment.NewLine +
                                       "/// </remarks> ";

                string PublicVariables = "public String myTableName = \"" + this.cmbDBTables.Text + "\";" + Environment.NewLine +
                                         " String mySqlQuery = string.Empty;" + Environment.NewLine +
                                         "ActionStatus return_ActionStatus = new ActionStatus();" + Environment.NewLine +
                                         "dbFunctions dbFunctions = new dbFunctions();" + Environment.NewLine +
                                         "string ReturnIdentity = \"-1\";";


                #region "Business Entity"

                string BusinessEntityName = this.cmbDBTables.Text;
                string BusinessEntityInterface = "I" + this.cmbDBTables.Text;
                string BusinessEntity_ReferenceClass = string.Empty;
                string BusinessEntity_ReferenceInterface = string.Empty;
                DataRowView myRow_BEClass = (DataRowView)this.BusinessEntityClass_bindingSource.Current;
                DataRowView myRow_BEInterface = (DataRowView)this.BusinessEntityInterface_bindingSource.Current;

                if (myRow_BEClass != null)
                {
                    BusinessEntityName = myRow_BEClass["SaveAs"].ToString().Replace(".cs", "");
                    BusinessEntity_ReferenceClass = myRow_BEClass["FNameSpace"].ToString();
                }

                if (myRow_BEInterface != null)
                {
                    BusinessEntityInterface = myRow_BEInterface["SaveAs"].ToString().Replace(".cs", "");
                    BusinessEntity_ReferenceInterface = myRow_BEInterface["FNameSpace"].ToString();
                }

                ClassReferences = ClassReferences + Environment.NewLine +
                                  "using " + BusinessEntity_ReferenceClass + ";";

                IClassReferences = IClassReferences + Environment.NewLine +
                                  "using " + BusinessEntity_ReferenceInterface + ";";


                #endregion




                string MethodHeader_Format = "public ActionStatus {MethodName}(" + BusinessEntityName + " " + BusinessEntityName + " ) ";
                string MethodHeader_InputFormat = "public {ReturnType} {MethodName}({InputParameters} ) ";
                string MethodHeader = string.Empty;
                string MethodHeader_InputParameters = string.Empty;
                string MethodException = "";
                string MethodFooter = "finally " + Environment.NewLine +
                                      "  { " + Environment.NewLine +
                                      "      this.mySqlCommand.Dispose(); " + Environment.NewLine +
                                      "      dbFunctions.CloseConnection(); " + Environment.NewLine +
                                      "  } " + Environment.NewLine +
                                      "  return return_ActionStatus; ";
                string mySqlCommandInitial = string.Empty;



                string ClassName = this.txtClassName.Text.Replace(".cs", ""); //this.cmbDBTables.Text;// +".cs";
                string IClassName = this.txtInterfaceName.Text.Replace(".cs", ""); //"I" + this.cmbDBTables.Text;// +".cs";


                string Interface_MethodName;
                string MethodData;

                string ClassData = string.Empty;
                string ClassInnerData = string.Empty;

                String TableName = this.cmbDBTables.Text;
                String MethodName;
                String Method_QueryParameters = string.Empty;
                String Method_InputQueryParameters = string.Empty;
                string Method_WhereInputParameters = string.Empty;
                int Method_WhereInputParametersNo = 0;
                string QueryName = string.Empty;
                Boolean ParameterExists = false;



                if (this.CurrentDBType.ToLower() == "my sql")
                {
                    PublicVariables = PublicVariables + Environment.NewLine +
                                      "MySqlCommand mySqlCommand;";

                    ClassReferences = ClassReferences + Environment.NewLine +
                                     "using " + this.txtProjectNamespace.Text + ".Base.MySql;" + Environment.NewLine +
                                      "using MySql.Data.MySqlClient;";
                    MethodException = "catch (MySqlException ex) " + Environment.NewLine +
                                      "  { " + Environment.NewLine +
                                      "     return_ActionStatus.is_Error = true; " + Environment.NewLine +
                                      "     return_ActionStatus.Message = \"Record not {ActionName} because \" + ex.Message ;" + Environment.NewLine +
                                      "  }";
                }
                else if (this.CurrentDBType.ToLower() == "ms sql")
                {
                    PublicVariables = PublicVariables + Environment.NewLine +
                                      "SqlCommand mySqlCommand;";
                    ClassReferences = ClassReferences = ClassReferences + Environment.NewLine +
                                     "using " + this.txtProjectNamespace.Text + ".Base.MsSql;" + Environment.NewLine +
                                      "using System.Data.SqlClient;";
                    MethodException = "catch (SqlException ex) " + Environment.NewLine +
                                     "  { " + Environment.NewLine +
                                     "     return_ActionStatus.is_Error = true; " + Environment.NewLine +
                                     "     return_ActionStatus.Message = \"Record not {ActionName} because \" + ex.Message ;" + Environment.NewLine +
                                     "  }";
                }

                Boolean isMethodInitialize;

                foreach (DataGridViewRow myRow in this.dgvTableStoreProcedures.Rows)
                {
                    ParameterExists = false;
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clsSelect_Query"];
                    Method_WhereInputParametersNo = 0;
                    MethodName = myRow.Cells["clmMethod"].Value.ToString();
                    QueryName = myRow.Cells["clmQueryName"].Value.ToString();

                    if (myCell.Value.ToString() == "1")
                    {
                        isMethodInitialize = false;

                        foreach (DataRow myRow_Columns in myQueryColumns_DataTable.Select("QueryName like '" + myRow.Cells["clmQueryName"].Value.ToString() + "'"))
                        {
                            ParameterExists = true;
                            if (isMethodInitialize == false)
                            {
                                isMethodInitialize = true;
                                MethodHeader = MethodHeader_Format.Replace("{MethodName}", MethodName);
                                MethodHeader_InputParameters = MethodHeader_InputFormat.Replace("{MethodName}", MethodName);
                                Method_QueryParameters = "var commandParameters = mySqlCommand.Parameters;" + Environment.NewLine;
                                Method_InputQueryParameters = "var commandParameters = mySqlCommand.Parameters;" + Environment.NewLine;
                            }

                            if (this.CurrentDBType.ToLower() == "my sql")
                            {
                                Method_QueryParameters = Method_QueryParameters + Environment.NewLine +
                                                        "commandParameters.Add(\"" + myRow_Columns["ParameterName"].ToString() +
                                                        "\", MySqlDbType." + SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()) +
                                                        ").Value =" + BusinessEntityName + "." + myRow_Columns["ColumnName"].ToString() + ";";

                                Method_InputQueryParameters = Method_InputQueryParameters + Environment.NewLine +
                                                             "commandParameters.Add(\"" + myRow_Columns["ParameterName"].ToString() +
                                                             "\", MySqlDbType." + SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()) +
                                                             ").Value =" + myRow_Columns["ColumnName"].ToString() + ";";
                            }
                            else if (this.CurrentDBType.ToLower() == "ms sql" && myRow_Columns["ParameterType"].ToString().ToLower() != "default")
                            {
                                if (SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()).ToLower() == "image")
                                {
                                    Method_QueryParameters = Method_QueryParameters + Environment.NewLine + Environment.NewLine +
                                                            " if (" + BusinessEntityName + "." + myRow_Columns["ColumnName"].ToString() + " == null)" + Environment.NewLine +
                                                            " { " + Environment.NewLine +
                                                            "commandParameters.Add(\"" + myRow_Columns["ParameterName"].ToString() +
                                                            "\", SqlDbType." + SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()) +
                                                            ").Value = DBNull.Value;" + Environment.NewLine +
                                                            "} " + Environment.NewLine +
                                                            " else " + Environment.NewLine +
                                                            " { " + Environment.NewLine +
                                                            "commandParameters.Add(\"" + myRow_Columns["ParameterName"].ToString() +
                                                            "\", SqlDbType." + SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()) +
                                                            ").Value =" + BusinessEntityName + "." + myRow_Columns["ColumnName"].ToString() + ";" + Environment.NewLine +
                                                            "} " + Environment.NewLine;

                                    Method_InputQueryParameters = Method_InputQueryParameters + Environment.NewLine +
                                                            "commandParameters.Add(\"" + myRow_Columns["ParameterName"].ToString() +
                                                            "\", SqlDbType." + SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()) +
                                                            ").Value =" + myRow_Columns["ColumnName"].ToString() + ";";
                                }
                                else
                                {
                                    Method_QueryParameters = Method_QueryParameters + Environment.NewLine +
                                                        "commandParameters.Add(\"" + myRow_Columns["ParameterName"].ToString() +
                                                        "\", SqlDbType." + SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()) +
                                                        ").Value =" + BusinessEntityName + "." + myRow_Columns["ColumnName"].ToString() + ";";

                                    Method_InputQueryParameters = Method_InputQueryParameters + Environment.NewLine +
                                                            "commandParameters.Add(\"" + myRow_Columns["ParameterName"].ToString() +
                                                            "\", SqlDbType." + SQLDataTypeConversion.getParametersDataType_MsSql(myRow_Columns["ColumnDataType"].ToString()) +
                                                            ").Value =" + myRow_Columns["ColumnName"].ToString() + ";";
                                }

                            }


                            if (myRow_Columns["ParameterType"].ToString().ToLower() == "where")
                            {

                                if (Method_WhereInputParametersNo == 0)
                                {
                                    Method_WhereInputParameters = myRow_Columns["DataType"].ToString() + " " + myRow_Columns["ColumnName"].ToString();

                                }
                                else
                                {

                                    if (Method_WhereInputParametersNo % 5 == 0)
                                    {
                                        Method_WhereInputParameters = Method_WhereInputParameters + Environment.NewLine + "," + myRow_Columns["DataType"].ToString() + " " + myRow_Columns["ColumnName"].ToString();
                                    }
                                    else
                                    {
                                        Method_WhereInputParameters = Method_WhereInputParameters + " , " + myRow_Columns["DataType"].ToString() + " " + myRow_Columns["ColumnName"].ToString();
                                    }
                                }

                                Method_WhereInputParametersNo++;
                            }


                        }



                    }


                    if (this.CurrentDBType.ToLower() == "my sql")
                    {
                        mySqlCommandInitial = " this.mySqlCommand = new MySqlCommand(\"" + QueryName + "\", dbFunctions.OpenConnection());";
                    }
                    else if (this.CurrentDBType.ToLower() == "ms sql")
                    {
                        mySqlCommandInitial = " this.mySqlCommand = new SqlCommand(\"" + QueryName + "\", dbFunctions.OpenConnection());" + Environment.NewLine +
                                              " this.mySqlCommand.CommandType = CommandType.StoredProcedure;";

                    }

                    if (ParameterExists == false)
                    {
                        Method_QueryParameters = string.Empty;
                        MethodHeader = MethodHeader_Format.Replace("{MethodName}", MethodName);
                        MethodHeader_InputParameters = MethodHeader_InputFormat.Replace("{MethodName}", MethodName);
                        Method_WhereInputParameters = string.Empty;
                        Method_InputQueryParameters = string.Empty;
                    }


                    if (myRow.Cells["clmActionType"].Value.ToString().ToLower() == "insert" || myRow.Cells["clmActionType"].Value.ToString().ToLower() == "update status" || myRow.Cells["clmActionType"].Value.ToString().ToLower() == "update" || myRow.Cells["clmActionType"].Value.ToString().ToLower() == "delete")
                    {

                        MethodData = MethodHeader + Environment.NewLine +
                                    "{" + Environment.NewLine +
                                    " try " + Environment.NewLine +
                                    "{" + Environment.NewLine +
                                    mySqlCommandInitial + Environment.NewLine +
                                    Method_QueryParameters + Environment.NewLine +
                                    "ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();" + Environment.NewLine +
                                    "return_ActionStatus.is_Error = false; " + Environment.NewLine +
                                    "return_ActionStatus.Message =\"Record " + myRow.Cells["clmActionType"].Value.ToString() + " successfully. and New Id is : \" + ReturnIdentity; " + Environment.NewLine +
                                    "return_ActionStatus.Return_Id = ReturnIdentity;" + Environment.NewLine +
                                    "}" + Environment.NewLine +
                                    MethodException.Replace("{ActionName}", myRow.Cells["clmActionType"].Value.ToString()) + Environment.NewLine +
                                    MethodFooter + Environment.NewLine +
                                    "}";

                        ClassInnerData = ClassInnerData + Environment.NewLine +
                                         MethodData;

                    }
                    else // (myRow.Cells["clmActionType"].Value.ToString().ToLower() == "get info")
                    {
                        //MethodHeader_InputParameters = MethodHeader_InputParameters.Replace("{InputParameters}", Method_WhereInputParameters);

                        //MethodData = MethodHeader_InputParameters + Environment.NewLine +
                        //           "{" + Environment.NewLine +
                        //           " try " + Environment.NewLine +
                        //           "{" + Environment.NewLine +
                        //           mySqlCommandInitial + Environment.NewLine +
                        //           Method_InputQueryParameters + Environment.NewLine +
                        //           "ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();" + Environment.NewLine +
                        //           "return_ActionStatus.is_Error = false; " + Environment.NewLine +
                        //           "return_ActionStatus.Message =\"Record " + myRow.Cells["clmActionType"].Value.ToString() + " successfully. and New Id is : \" + ReturnIdentity; " + Environment.NewLine +
                        //           "return_ActionStatus.Return_Id = ReturnIdentity;" + Environment.NewLine +
                        //           "}" + Environment.NewLine +
                        //           MethodException + Environment.NewLine +
                        //           MethodFooter + Environment.NewLine +
                        //           "}";

                        //ClassInnerData = ClassInnerData + Environment.NewLine +
                        //                 MethodData;

                        MethodFooter = "finally " + Environment.NewLine +
                                     "  { " + Environment.NewLine +                                     
                                     "      dbFunctions.CloseConnection(); " + Environment.NewLine +
                                     "  } " + Environment.NewLine;


                        MethodHeader_InputParameters = MethodHeader_InputParameters.Replace("{InputParameters}", Method_WhereInputParameters);
                        MethodHeader_InputParameters = MethodHeader_InputParameters.Replace("{ReturnType}", "DataTable");

                        MethodData = MethodHeader_InputParameters + Environment.NewLine +
                                   "{" + Environment.NewLine +
                                   " try " + Environment.NewLine +
                                   "{" + Environment.NewLine +
                                   mySqlCommandInitial + Environment.NewLine +
                                   Method_InputQueryParameters + Environment.NewLine +
                                   " return  dbFunctions.SPDataTable(this.mySqlCommand);" + Environment.NewLine +
                                   "}" + Environment.NewLine +
                                   "catch (SqlException ex) " + Environment.NewLine +
                                     "  { " + Environment.NewLine +
                                     "     return dbFunctions.ExceptionDataTable(ex.ErrorCode,ex.Message ,\"" + MethodName + "\" ,\"" + TableName + "\");" + Environment.NewLine +
                                     "  }" + Environment.NewLine +
                                    MethodFooter + Environment.NewLine +
                                    "}";

                        ClassInnerData = ClassInnerData + Environment.NewLine +
                                         MethodData;
                    }




                }

                #region "Fixed Methods"
                MethodData = "  public Int32 TotalRecords()" + Environment.NewLine +
                                  "{" + Environment.NewLine +
                                   " try " + Environment.NewLine +
                                   "{" + Environment.NewLine +
                                   " return  dbFunctions.TotalRecords(this.myTableName);" + Environment.NewLine +
                                   "}" + Environment.NewLine +
                                   "catch (SqlException ex) " + Environment.NewLine +
                                     "  { " + Environment.NewLine +
                                     "     return 0;" + Environment.NewLine +
                                     "  }" + Environment.NewLine +
                                    MethodFooter + Environment.NewLine +
                                    "}";

                ClassInnerData = ClassInnerData + Environment.NewLine +
                                 "/// <summary> " + Environment.NewLine +
                                 " /// Use to Get Total Records " + Environment.NewLine +
                                 "  /// </summary> " + Environment.NewLine +
                                 "/// <returns></returns> " + Environment.NewLine +
                                 MethodData;


                MethodData = "  public Int32 TotalRecords(string WhereCondition)" + Environment.NewLine +
                                  "{" + Environment.NewLine +
                                   " try " + Environment.NewLine +
                                   "{" + Environment.NewLine +
                                   " return  dbFunctions.TotalRecords(this.myTableName,WhereCondition);" + Environment.NewLine +
                                   "}" + Environment.NewLine +
                                   "catch (SqlException ex) " + Environment.NewLine +
                                     "  { " + Environment.NewLine +
                                     "     return 0;" + Environment.NewLine +
                                     "  }" + Environment.NewLine +
                                    MethodFooter + Environment.NewLine +
                                    "}";

                ClassInnerData = ClassInnerData + Environment.NewLine +
                                 "/// <summary> " + Environment.NewLine +
                                 " /// Use to Get Total Records by Where Condition " + Environment.NewLine +
                                 "  /// </summary> " + Environment.NewLine +
                                 "/// <returns></returns> " + Environment.NewLine +
                                 MethodData;

                #region "Search"

                string return_FunctionString = "public DataTable getList_Search(int PageSize, int PageNo,string myWhereCondition,string OrderBy,string Ordering=\"Asc\")";
                string SqlQuery = "this.mySqlQuery = \"Select * \" + Environment.NewLine +" + Environment.NewLine +
                                  "\"  from  (  \" + Environment.NewLine +" + Environment.NewLine +
                                  "\"          Select *, ROW_NUMBER() over (Order By \" + OrderBy + \" \" + Ordering + \") as MyRecordNo \" + Environment.NewLine +" + Environment.NewLine +
                                  "\"          from \" + this.myTableName + \" \" + Environment.NewLine +" + Environment.NewLine +
                                  "\"          Where \" + myWhereCondition  + Environment.NewLine + " + Environment.NewLine +
                                  "\"          ) as myTable \" + Environment.NewLine +" + Environment.NewLine +
                                  "\"          Where myTable.MyRecordNo BETWEEN (\" + PageSize + \"*(\" + PageNo + \"-1))+1 AND (\" + PageSize + \"*\" + PageNo + \") \";";
                string Ending_Lines = Environment.NewLine + " return this.dbFunctions.getAllRecords_CustomizeQuery_DataTable(this.mySqlQuery); " + Environment.NewLine +
                                  "}" + Environment.NewLine;


                MethodData = return_FunctionString + Environment.NewLine +
                                 "{" + Environment.NewLine +
                                  " try " + Environment.NewLine +
                                  "{" + Environment.NewLine +                                  
                                  "     " + SqlQuery + Environment.NewLine +
                                  Ending_Lines + Environment.NewLine +
                                  "catch (SqlException ex) " + Environment.NewLine +
                                    "  { " + Environment.NewLine +
                                    "     return dbFunctions.ExceptionDataTable(ex.ErrorCode,ex.Message ,\"getList_Search\" ,\"" + TableName + "\");" + Environment.NewLine +
                                    "  }" + Environment.NewLine +
                                   MethodFooter + Environment.NewLine +
                                   "}";

                ClassInnerData = ClassInnerData + Environment.NewLine +
                                 "/// <summary> " + Environment.NewLine +
                                 " /// Use to Get List of Records by Where Condition " + Environment.NewLine +
                                 "  /// </summary> " + Environment.NewLine +
                                 "/// <returns></returns> " + Environment.NewLine +
                                 MethodData;
                #endregion

                #endregion



                ClassData = ClassReferences + Environment.NewLine +
                            "namespace " + this.txtGenerateBENamespace.Text + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "public class " + ClassName + Environment.NewLine +
                            "{" + Environment.NewLine +
                            PublicVariables + Environment.NewLine +
                            ClassInnerData + Environment.NewLine +
                            "}" + Environment.NewLine +
                            "}";

                this.txtFileData.Text = ClassData; //ClassInnerData;

                this.ProjectFile_Insert(ClassData, "class", this.txtGenerateBENamespace.Text, this.txtClassName.Text);

                this.GetList_ProjectFiles();

                if (this.chkisSavedOnGenerate.Checked == true)
                {
                    File.WriteAllText(this.txtGenerateDALSaveIn.Text + "\\" + this.txtClassName.Text, ClassData);
                }

                Messages.SuccessMessage(this.txtClassName.Text + " Generated Successfully!", "Action Performed");

                this.cmbDBTables.Focus();

            }
            catch (Exception ex)
            {
                Messages.GeneralError(ex.Message, "Generate Data Access");
            }
        }
        #endregion

        #region "Solution DB Table Columns"
        DataTable getSelectTable_QueryColumns(string TableName)
        {
            try
            {
                return new SolutionsDBQueryColumnsDAL().getList_Search(10000, 1, " SolutionsDBID=" + this.cmbSolutionsDB.SelectedValue.ToString() + " and TableName like '" + TableName + "'", "ID");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region "Project Entity"

        Boolean isMapped_BEClass, isMapped_BEInterface;
        void getProject_TableEntity()
        {
            try
            {
                DataTable myDataTable_BusinessEntityClass = new ProjectFilesDAL().getProjectBusinessEntity_TableName(int.Parse(this.cmbProjectID_BusinessEntity.SelectedValue.ToString()), this.cmbDBTables.Text, "Class");
                DataTable myDataTable_BusinessEntityInterface = new ProjectFilesDAL().getProjectBusinessEntity_TableName(int.Parse(this.cmbProjectID_BusinessEntity.SelectedValue.ToString()), this.cmbDBTables.Text, "Interface");

                if (myDataTable_BusinessEntityClass != null)
                {
                    this.BusinessEntityClass_bindingSource.DataSource = myDataTable_BusinessEntityClass;

                }

                if (myDataTable_BusinessEntityClass != null)
                {
                    this.BusinessEntityInterface_bindingSource.DataSource = myDataTable_BusinessEntityInterface;
                }

                if (isMapped_BEClass == false)
                {
                    isMapped_BEClass = true;
                    this.cmbBusinessEntityClass.DataSource = this.BusinessEntityClass_bindingSource;
                    this.cmbBusinessEntityClass.DisplayMember = "SaveAs";
                    this.cmbBusinessEntityClass.ValueMember = "ID";
                }

                if (isMapped_BEInterface == false)
                {
                    isMapped_BEClass = true;
                    this.cmbBusinessEntityInterface.DataSource = this.BusinessEntityInterface_bindingSource;
                    this.cmbBusinessEntityInterface.DisplayMember = "SaveAs";
                    this.cmbBusinessEntityInterface.ValueMember = "ID";
                }

                this.cmbBusinessEntityClass.Refresh();
                this.cmbBusinessEntityInterface.Refresh();


            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Project Files "
        Boolean isMapped_ProjectFiles;
        void ProjectFile_Insert(string ClassContent, string ClassType, string NameSpace, string SaveAs)
        {
            try
            {
                ProjectFilesDAL ProjectFiilesDAL = new ProjectFilesDAL();

                ProjectFiilesDAL.ProjectId = int.Parse(this.cmbProjects.SelectedValue.ToString());

                ProjectFiilesDAL.ClassType = ClassType;

                if (ClassType.ToLower() == "interface")
                {
                    //ProjectFiilesDAL.FullPath = this.txtGenerateBESaveIn.Text + "\\Interface\\" + SaveAs;
                    ProjectFiilesDAL.FullPath = this.txtInterfaceSaveAs.Text + "\\" + SaveAs;
                }
                else
                {
                    ProjectFiilesDAL.FullPath = this.txtGenerateDALSaveIn.Text + "\\" + SaveAs;
                }

                ProjectFiilesDAL.FolderId = this.CurrentFolderId;
                ProjectFiilesDAL.FolderName = this.CurrentFolderName;
                ProjectFiilesDAL.FNameSpace = NameSpace; //this.txtGenerateBENamespace.Text;
                ProjectFiilesDAL.SaveAs = SaveAs; //this.cmbDBTables.Text + ".cs";

                ProjectFiilesDAL.isGenerated = chkisSavedOnGenerate.Checked;

                ProjectFiilesDAL.FileData = ClassContent;// this.txtGeneratedClass.Text;
                ProjectFiilesDAL.isActive = true;
                ProjectFiilesDAL.UserId = Security.UserID;

                ProjectFiilesDAL.TableName = this.cmbDBTables.Text;

                if (ProjectFiilesDAL.isGenerated == true)
                {
                    FileInfo myFile = new FileInfo(ProjectFiilesDAL.FullPath);

                    if (myFile.Exists == false)
                    {
                        Directory.CreateDirectory(myFile.Directory.FullName);
                    }

                    File.WriteAllText(ProjectFiilesDAL.FullPath, ProjectFiilesDAL.FileData);
                }

                ProjectFiilesDAL.Insert();

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project File");
            }
        }

        void GetList_ProjectFiles()
        {
            try
            {

                DataTable myDataTable_ProjectFiles = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                myDataTable_ProjectFiles = new ProjectFilesDAL().getList_Search(100000, 1, " ProjectId=" + this.cmbProjects.SelectedValue.ToString(), "SaveAs", "asc");




                this.ProjectFiles_bindingSource.DataSource = myDataTable_ProjectFiles;

                if (this.ProjectFiles_bindingSource.DataSource != null && this.isMapped_ProjectFiles == false)
                {
                    this.isMapped_ProjectFiles = true;

                    this.txtID.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "ID", false);
                    this.txtClassType.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "ClassType", false);
                    this.txtFolderName.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FolderName", false);
                    this.txtSaveAs.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "SaveAs", false);
                    this.txtFNameSpace.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FNameSpace", false);
                    this.txtFullPath.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FullPath", false);
                    this.txtFileData.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FileData", false);

                    this.cbkisActive.DataBindings.Add("Checked", this.ProjectFiles_bindingSource, "isActive", true);
                    this.chkisGenerated.DataBindings.Add("Checked", this.ProjectFiles_bindingSource, "isGenerated", true);

                    this.dvgProjectFiles.DataSource = this.ProjectFiles_bindingSource;

                    this.dvgProjectFiles.Columns["clsSaveAs"].DataPropertyName = "SaveAs";

                    this.bnMain.BindingSource = this.ProjectFiles_bindingSource;

                }

                //this.cmbProjects.DataSource = this.Projects_bindingSource;
                //this.cmbProjects.DisplayMember = "ProjectName";
                //this.cmbProjects.ValueMember = "ID";

                this.dvgProjectFiles.Update();
                this.dvgProjectFiles.Refresh();
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project Files");
            }
        }

        #endregion

        public frmDataAccess()
        {
            InitializeComponent();
        }

        private void frmDataAccess_Load(object sender, EventArgs e)
        {
            try
            {
                this.dvgProjectFiles.AutoGenerateColumns = false;
                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgTableColumns);
                this.dvgTableColumns.AutoGenerateColumns = false;
                this.dgvTableStoreProcedures.AutoGenerateColumns = false;

                this.getList_Solutions();

                this.dvgTableColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
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
                this.ViewAll_Projects();

                if (this.cmbProjects != null && this.cmbProjects.Text != string.Empty && this.cmbProjects.Text.Length > 1)
                {
                    this.GetList_ProjectFiles();
                }
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

                this.cbkSelectAll.Checked = true;

                this.SelectColumns();
                //this.GetSelectedDB_Folders();

                //this.getMappedTables();


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

                this.GetSelectDB_TableColumns();

                this.cbkSelectAll.Checked = true;

                this.SelectColumns();
                this.getDBQuery_SelectedTable(this.cmbDBTables.Text);


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Table Columns");
            }
        }

        private void cmbDBTables_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbDBTables != null && this.cmbDBTables.Text != string.Empty && this.cmbDBTables.Text.Length > 0)
            {

                this.GetSelectDB_TableColumns();

                this.cbkSelectAll.Checked = true;

                this.SelectColumns();
                this.getDBQuery_SelectedTable(this.cmbDBTables.Text);
            }
        }

        private void cbkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            this.SelectColumns();
        }

        private void dgvTableStoreProcedures_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void chkSelectAll_DBQuery_CheckedChanged(object sender, EventArgs e)
        {
            this.SelectColumn_SQLDBQuery();
        }

        private void cmdGenerateBE_Click(object sender, EventArgs e)
        {
            this.Generate_DataAccess();
        }

        private void txtCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtFileData.Text);
            CommonClasses.Messages.SuccessMessage("Copy successfully.", "Copy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbProjects != null && this.cmbProjects.Text != string.Empty && this.cmbProjects.Text.Length > 1)
                {
                    this.GetList_ProjectFiles();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
