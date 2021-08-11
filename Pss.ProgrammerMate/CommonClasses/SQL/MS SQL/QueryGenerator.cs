using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pss.ProgrammerMate.CommonClasses.SQL;
using System.Data;
using Pss.ProgrammerMate.DAL;

namespace Pss.ProgrammerMate.CommonClasses.SQL.MS_SQL
{
    public class QueryGenerator
    {
        public static string InsertQuery(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Insert");
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string ColumnsName = "";
                string ColumnsValues = "";
                string OutputQuery = "";
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                foreach (DataGridViewRow myRow in TableColumnsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                    if (myCell.Value.ToString().ToLower() == "1")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;

                        if (myRows["ColumnType"].ToString().Contains("-1") == true)
                        {
                            myRows["ColumnType"] = myRows["ColumnType"].ToString().Replace("-1", "Max");
                        }

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
                            SolutionsDBQueryColumnsDAL.ParameterType = "Default";

                            ColumnsNo++;
                        }
                        else
                        {
                            OutputQuery = " Select @@Identity as ReturnValue;";
                        }




                        SolutionsDBQueryColumnsDAL.ColumnName = myRows["ColumnName"].ToString();
                        SolutionsDBQueryColumnsDAL.ColumnType = myRows["ColumnType"].ToString();
                        SolutionsDBQueryColumnsDAL.ColumnDataType = myRows["ColumnDataType"].ToString();
                        SolutionsDBQueryColumnsDAL.DataType = myRows["DataType"].ToString();
                        SolutionsDBQueryColumnsDAL.COLUMN_KEY = myRows["COLUMN_KEY"].ToString();
                        SolutionsDBQueryColumnsDAL.Insert();

                    }




                }


                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                              InitialKeyword + " procedure " + QueryName + " (" + Environment.NewLine +
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

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Insert", "Store Procedure", QueryContent, DALMethodName, ActionID);


                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }

        public static string UpdateQuery(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Update");
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string ColumnsName_Value = "";
                string OutputQuery = "";
                string myWhereCondition = "";
                Boolean AlreadyWhered = false;
                Boolean isIdentityInserted = false;
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                foreach (DataGridViewRow myRow in TableColumnsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                    if (myCell.Value.ToString().ToLower() == "1")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;

                        if (myCell.Value.ToString().ToLower() == "1")
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

                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";
                            }
                            else if (Boolean.Parse(myRows["isIdentity"].ToString()) != true && !string.IsNullOrEmpty(myRows["DefaultValue"].ToString()) && !myRows["ColumnName"].ToString().ToLower().Contains("create"))
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
                                SolutionsDBQueryColumnsDAL.ParameterType = "Default";

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

                            if (AlreadyWhered == false)
                            {
                                AlreadyWhered = true;
                                myWhereCondition = myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
                            }
                            else
                            {
                                myWhereCondition = myWhereCondition + Environment.NewLine + "           And " + myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
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

                        if (myRows["ColumnName"].ToString().ToLower().Contains("createdonutc") == false)
                        {
                            SolutionsDBQueryColumnsDAL.Insert();
                        }

                    }




                }


                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                OutputQuery = " select 1 as ReturnValue; ";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                              InitialKeyword + " Procedure " + QueryName + " (" + Environment.NewLine +
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

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Update", "Store Procedure", QueryContent, DALMethodName, ActionID);


                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }

        public static string UpdateStatusQuery(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Update Status");
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string ColumnsName_Value = "";
                string OutputQuery = "";
                string myWhereCondition = "";
                Boolean AlreadyWhered = false;
                Boolean isIdentityInserted = false;
                string InnerParameters = string.Empty;
                Boolean CanInsert = false;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                foreach (DataGridViewRow myRow in TableColumnsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                    myRows = (DataRowView)myRow.DataBoundItem;
                    CanInsert = false;

                    if (myCell.Value.ToString().ToLower() == "1")
                    {


                        if (myCell.Value.ToString().ToLower() == "1")
                        {
                            if (Boolean.Parse(myRows["isIdentity"].ToString()) != true && string.IsNullOrEmpty(myRows["DefaultValue"].ToString()) && (myRows["ColumnType"].ToString().ToLower().Contains("bool") || myRows["ColumnType"].ToString().ToLower().Contains("bit")))
                            {
                                CanInsert = true;
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

                                    }
                                }

                                SolutionsDBQueryColumnsDAL.ParameterName = "@" + myRows["ColumnName"].ToString();
                                SolutionsDBQueryColumnsDAL.ParameterType = "Set";
                            }
                            else if (Boolean.Parse(myRows["isIdentity"].ToString()) != true && !string.IsNullOrEmpty(myRows["DefaultValue"].ToString()) && !myRows["ColumnName"].ToString().ToLower().Contains("create"))
                            {
                                CanInsert = true;
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
                                SolutionsDBQueryColumnsDAL.ParameterType = "Default";

                                ColumnsNo++;
                            }
                        }


                        if (Boolean.Parse(myRows["isWhere"].ToString()) == true)
                        {
                            CanInsert = true;
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
                                myWhereCondition = myWhereCondition + Environment.NewLine + "           And " + myRows["ColumnName"].ToString() + " = @org_" + myRows["ColumnName"].ToString();
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

                        if (CanInsert == true)
                        {
                            SolutionsDBQueryColumnsDAL.Insert();
                        }

                    }




                }


                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                OutputQuery = " select 1 as ReturnValue; ";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                              InitialKeyword + " Procedure " + QueryName + " (" + Environment.NewLine +
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

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Update Status", "Store Procedure", QueryContent, DALMethodName, ActionID);


                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }

        public static string DeleteQuery(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Delete");
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string OutputQuery = "";
                string myWhereCondition = "";
                Boolean AlreadyWhered = false;
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                foreach (DataGridViewRow myRow in TableColumnsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmWhere"];

                    if (myCell.Value.ToString().ToLower() == "true")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;

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

                OutputQuery = " select 1 as ReturnValue; ";

                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                OutputQuery = " select 1 as ReturnValue; ";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                   InitialKeyword + " procedure " + QueryName + " (" + Environment.NewLine +
                                                   inputerParameters + Environment.NewLine +
                                                   ") " + Environment.NewLine +
                                                   " AS " + Environment.NewLine +
                                                   " Begin " + Environment.NewLine +
                                                   "     SET NOCOUNT ON; " + Environment.NewLine + Environment.NewLine +
                                                   "     Delete From " + TableName + Environment.NewLine +
                                                   "     Where " + myWhereCondition + " ;" + Environment.NewLine +
                                                   "     " + OutputQuery + "" + Environment.NewLine +
                                                   " END " + Environment.NewLine;

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Delete", "Store Procedure", QueryContent, DALMethodName, ActionID);

                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }
        public static string GetInfoByIDQuery(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Get Info By ID");
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string myWhereCondition = "";
                Boolean AlreadyWhered = false;
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                foreach (DataGridViewRow myRow in TableColumnsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmWhere"];

                    if (myCell.Value.ToString().ToLower() == "true")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;

                        if (Boolean.Parse(myRows["isIdentity"].ToString()) == true)
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


                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                   InitialKeyword + " procedure " + QueryName + " (" + Environment.NewLine +
                                                   inputerParameters + Environment.NewLine +
                                                   ") " + Environment.NewLine +
                                                   " AS " + Environment.NewLine +
                                                   " Begin " + Environment.NewLine +
                                                   "     SET NOCOUNT ON; " + Environment.NewLine + Environment.NewLine +
                                                   "     Select * " + Environment.NewLine +
                                                   "     From " + TableName + Environment.NewLine +
                                                   "     Where " + myWhereCondition + " ;" + Environment.NewLine +
                                                   " END " + Environment.NewLine;

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Get Info", "Store Procedure", QueryContent, DALMethodName, ActionID);

                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }

        public static string GetList(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Get List");
                string QueryContent = "";
                string inputerParameters = "";
                string myWhereCondition = "";
                string InnerParameters = string.Empty;
                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                   InitialKeyword + " procedure " + QueryName + " " + Environment.NewLine +
                                                   inputerParameters + Environment.NewLine +
                                                   " AS " + Environment.NewLine +
                                                   " Begin " + Environment.NewLine +
                                                   "     SET NOCOUNT ON; " + Environment.NewLine + Environment.NewLine +
                                                   "     Select * " + Environment.NewLine +
                                                   "     From " + TableName + " ; " + Environment.NewLine +

                                                   " END " + Environment.NewLine;

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Get List", "Store Procedure", QueryContent, DALMethodName, ActionID);

                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }

        public static string GetListPagination(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Get List Paginated");
                string QueryContent = "";
                string inputerParameters = "";
                string InnerParameters = string.Empty;
                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                inputerParameters = "    @PageSize int = 20,	" + Environment.NewLine +
                                    "    @PageNo int = 1		" + Environment.NewLine;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;
                SolutionsDBQueryColumnsDAL.ColumnType = "int";
                SolutionsDBQueryColumnsDAL.ColumnDataType = "Int";
                SolutionsDBQueryColumnsDAL.DataType = "int";
                SolutionsDBQueryColumnsDAL.COLUMN_KEY = "none";
                SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                SolutionsDBQueryColumnsDAL.ColumnName = "PageSize";
                SolutionsDBQueryColumnsDAL.ParameterName = "@PageSize";
                SolutionsDBQueryColumnsDAL.Insert();

                SolutionsDBQueryColumnsDAL.ColumnName = "PageNo";
                SolutionsDBQueryColumnsDAL.ParameterName = "@PageNo";
                SolutionsDBQueryColumnsDAL.Insert();


                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                   InitialKeyword + " procedure " + QueryName + " (" + Environment.NewLine +
                                                   inputerParameters + Environment.NewLine +
                                                   ") " + Environment.NewLine +
                                                   " AS " + Environment.NewLine +
                                                   " Begin " + Environment.NewLine +
                                                   "     SET NOCOUNT ON; " + Environment.NewLine + Environment.NewLine +
                                                   "     Select * " + Environment.NewLine +
                                                   "     From " + TableName + " " + Environment.NewLine +
                                                   "     Order By ID asc " + Environment.NewLine +
                                                   "     OFFSET (@PageSize * (@PageNo - 1)) ROWS  " + Environment.NewLine +
                                                   "     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE) ;   " + Environment.NewLine +

                                                   " END " + Environment.NewLine;

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Get List Paginated", "Store Procedure", QueryContent, DALMethodName, ActionID);

                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }

        public static string SearchQuery(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Search");
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string myWhereCondition = "";
                Boolean AlreadyWhered = false;
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;


                foreach (DataGridViewRow myRow in TableColumnsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmWhere"];

                    if (myCell.Value.ToString().ToLower() == "true")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;

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


                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                   InitialKeyword + " procedure " + QueryName + " (" + Environment.NewLine +
                                                   inputerParameters + Environment.NewLine +
                                                   ") " + Environment.NewLine +
                                                   " AS " + Environment.NewLine +
                                                   " Begin " + Environment.NewLine +
                                                   "     SET NOCOUNT ON; " + Environment.NewLine + Environment.NewLine +
                                                   "     Select * " + Environment.NewLine +
                                                   "     From " + TableName + Environment.NewLine +
                                                   "     Where " + myWhereCondition + " ;" + Environment.NewLine +
                                                   " END " + Environment.NewLine;

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Search", "Store Procedure", QueryContent, DALMethodName, ActionID);

                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }

        public static string SearchWithPaginationQuery(int SolutionsDBID, int QueryID, string TableName, string QueryName, string DALMethodName, int ActionID, DataGridView TableColumnsDataGridView, Boolean isCreate)
        {
            try
            {
                string HeaderComments = GlobalActions.SPHeaderComments(QueryName, "Search Pagination");
                string QueryContent = "";
                DataRowView myRows;
                int ColumnsNo = 0;
                string inputerParameters = "";
                string myWhereCondition = "";
                Boolean AlreadyWhered = false;
                string InnerParameters = string.Empty;

                SolutionsDBQueryColumnsDAL SolutionsDBQueryColumnsDAL = new SolutionsDBQueryColumnsDAL();

                SolutionsDBQueryColumnsDAL.QueryId = 0;
                SolutionsDBQueryColumnsDAL.SolutionsDBID = SolutionsDBID;
                SolutionsDBQueryColumnsDAL.QueryName = QueryName;
                SolutionsDBQueryColumnsDAL.TableId = 0;
                SolutionsDBQueryColumnsDAL.TableName = TableName;
                SolutionsDBQueryColumnsDAL.isActive = true;

                inputerParameters = "    @PageSize int = 20,	" + Environment.NewLine +
                                    "    @PageNo int = 1		" + Environment.NewLine;

                SolutionsDBQueryColumnsDAL.ColumnType = "int";
                SolutionsDBQueryColumnsDAL.ColumnDataType = "Int";
                SolutionsDBQueryColumnsDAL.DataType = "int";
                SolutionsDBQueryColumnsDAL.COLUMN_KEY = "none";
                SolutionsDBQueryColumnsDAL.ParameterType = "Where";

                SolutionsDBQueryColumnsDAL.ColumnName = "PageSize";
                SolutionsDBQueryColumnsDAL.ParameterName = "@PageSize";
                SolutionsDBQueryColumnsDAL.Insert();

                SolutionsDBQueryColumnsDAL.ColumnName = "PageNo";
                SolutionsDBQueryColumnsDAL.ParameterName = "@PageNo";
                SolutionsDBQueryColumnsDAL.Insert();

                ColumnsNo = 1;

                foreach (DataGridViewRow myRow in TableColumnsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmWhere"];

                    if (myCell.Value.ToString().ToLower() == "true")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;

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


                string InitialKeyword = isCreate == true ? "Create" : "Alter";

                QueryContent = HeaderComments + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                                   InitialKeyword + " procedure " + QueryName + " (" + Environment.NewLine +
                                                   inputerParameters + Environment.NewLine +
                                                   ") " + Environment.NewLine +
                                                   " AS " + Environment.NewLine +
                                                   " Begin " + Environment.NewLine +
                                                   "     SET NOCOUNT ON; " + Environment.NewLine + Environment.NewLine +
                                                   "     Select * " + Environment.NewLine +
                                                   "     From " + TableName + Environment.NewLine +
                                                   "     Where " + myWhereCondition + " " + Environment.NewLine +
                                                   "     Order By ID asc " + Environment.NewLine +
                                                   "     OFFSET (@PageSize * (@PageNo - 1)) ROWS  " + Environment.NewLine +
                                                   "     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE) ;   " + Environment.NewLine +
                                                   " END " + Environment.NewLine;

                GlobalActions.Insert_SolutionsDBQuery(SolutionsDBID, QueryID, TableName, QueryName, "Search Pagination", "Store Procedure", QueryContent, DALMethodName, ActionID);

                return QueryContent;
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }
        }
    }
}
