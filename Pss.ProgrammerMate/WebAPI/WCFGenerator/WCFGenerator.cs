using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.DAL;
namespace Pss.ProgrammerMate.WebAPI.WCFGeneratorFolder
{
    public class WCFGenerator
    {
        public static string GeneratorWCFClass(string SolutionDBID, DataGridView DAMethods, string TableName, string InterfaceClassNameSpace, string BusinessEntityNameSpace, string BusinessEntityClass, string DataAccessProjectNameSpace, string DAClassNameSpace, string DAClass, string WCFNamespace, string ServiceName, string ServiceInterfaceName, string ModuleName)
        {
            try
            {
                DataTable myQueryColumns_DataTable = getSelectTable_QueryColumns(SolutionDBID, TableName);

                if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count <= 0)
                {
                    Messages.GeneralError("No column exists for Table " + TableName, "Table Columns");
                }

                string ClassHeaderReferences = "using System;" + Environment.NewLine +
                                               "using System.Collections.Generic;" + Environment.NewLine +
                                               "using System.ComponentModel;" + Environment.NewLine +
                                               "using System.Data;" + Environment.NewLine +
                                               "using System.Linq;" + Environment.NewLine +
                                               "using System.Text;" + Environment.NewLine +
                                               "using System.Threading.Tasks;" + Environment.NewLine +
                                               "using System.ServiceModel;" + Environment.NewLine +
                                               "using System.ServiceModel.Web;" + Environment.NewLine +
                                               "using " + DataAccessProjectNameSpace + ".Base.MsSql; " + Environment.NewLine +
                                               "using " + BusinessEntityNameSpace + ";" + Environment.NewLine +
                                               "using " + DAClassNameSpace + ";" + Environment.NewLine +
                                               "using " + InterfaceClassNameSpace + ";" + Environment.NewLine;
                string MethodsContent = string.Empty;
                String ActionName = string.Empty;
                String ReturnClass = string.Empty;

                #region "Get Methods Parameters"
                Boolean ParameterExists = false;
                Boolean isMethodInitialize = false;
                int Method_WhereInputParametersNo = 0;
                String MethodName = String.Empty;
                String QueryName = String.Empty;
                String MethodHeader = string.Empty;
                String MethodHeader_InputFormat = "public {ReturnType} {MethodName}({InputParameters} ) ";
                String MethodHeader_InputParameters = string.Empty;
                String Method_WhereInputParameters = string.Empty;
                String Method_WhereInputerParametersName = String.Empty;
                #endregion

                foreach (DataGridViewRow myGridRow in DAMethods.Rows)
                {
                    ParameterExists = false;
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myGridRow.Cells["clsSelect_Query"];
                    Method_WhereInputParametersNo = 0;
                    MethodName = myGridRow.Cells["clmMethod"].Value.ToString();
                    QueryName = myGridRow.Cells["clmQueryName"].Value.ToString();
                    Method_WhereInputParameters = String.Empty;
                    Method_WhereInputerParametersName = String.Empty;

                    isMethodInitialize = false;

                    foreach (DataRow myGridRow_Columns in myQueryColumns_DataTable.Select("QueryName like '" + myGridRow.Cells["clmQueryName"].Value.ToString() + "'"))
                    {
                        ParameterExists = true;
                        if (isMethodInitialize == false)
                        {
                            isMethodInitialize = true;
                            //MethodHeader = MethodHeader_Format.Replace("{MethodName}", MethodName);
                            MethodHeader_InputParameters = MethodHeader_InputFormat.Replace("{MethodName}", MethodName);
                        }

                        if (myGridRow_Columns["ParameterType"].ToString().ToLower() == "where")
                        {

                            if (Method_WhereInputParametersNo == 0)
                            {
                                Method_WhereInputParameters = myGridRow_Columns["DataType"].ToString() + " " + myGridRow_Columns["ColumnName"].ToString();
                                Method_WhereInputerParametersName = myGridRow_Columns["ColumnName"].ToString();

                            }
                            else
                            {

                                if (Method_WhereInputParametersNo % 5 == 0)
                                {
                                    Method_WhereInputParameters = Method_WhereInputParameters + Environment.NewLine + "," + myGridRow_Columns["DataType"].ToString() + " " + myGridRow_Columns["ColumnName"].ToString();
                                    Method_WhereInputerParametersName = Method_WhereInputerParametersName + Environment.NewLine + "," + myGridRow_Columns["ColumnName"].ToString();
                                }
                                else
                                {
                                    Method_WhereInputParameters = Method_WhereInputParameters + " , " + myGridRow_Columns["DataType"].ToString() + " " + myGridRow_Columns["ColumnName"].ToString();
                                    Method_WhereInputerParametersName = Method_WhereInputerParametersName + "," + myGridRow_Columns["ColumnName"].ToString();
                                }
                            }

                            Method_WhereInputParametersNo++;
                        }


                    }





                    if (ParameterExists == false)
                    {

                        MethodHeader_InputParameters = MethodHeader_InputFormat.Replace("{MethodName}", MethodName);

                    }


                    ActionName = myGridRow.Cells["clmMethod"].Value.ToString();
                    if (ActionName.ToLower() == "insert" || ActionName.ToLower() == "update"
                        || ActionName.ToLower() == "updatestatus" || ActionName.ToLower() == "delete")
                    {
                        MethodsContent = MethodsContent + Environment.NewLine +
                                        "public ActionStatus " + ActionName + "(" + BusinessEntityClass + "   " + BusinessEntityClass + " )" + Environment.NewLine +
                                        "{" + Environment.NewLine +
                                        "   try " + Environment.NewLine +
                                        "   { " + Environment.NewLine +
                                        "       return new " + DAClass + "()." + ActionName + "(" + BusinessEntityClass + " );" + Environment.NewLine +
                                        "   } " + Environment.NewLine +
                                        "   catch (Exception ex) " + Environment.NewLine +
                                        "   { " + Environment.NewLine +
                                        "     return new ActionStatus() {is_Error=true,Message =ex.Message,Return_Id = \"-1\" };  " + Environment.NewLine +
                                        "   } " + Environment.NewLine +
                                        "}";
                    }
                    else
                    {
                        #region "Get Methods"



                        MethodHeader_InputParameters = MethodHeader_InputParameters.Replace("{InputParameters}", Method_WhereInputParameters);
                        MethodHeader_InputParameters = MethodHeader_InputParameters.Replace("{ReturnType}", "DataTable");

                        Method_WhereInputerParametersName.ToString();

                        MethodsContent = MethodsContent + Environment.NewLine +
                                       "" + MethodHeader_InputParameters + Environment.NewLine +
                                       "{" + Environment.NewLine +
                                       "   try " + Environment.NewLine +
                                       "   { " + Environment.NewLine +
                                       "       return new " + DAClass + "()." + ActionName + "(" + Method_WhereInputerParametersName + " );" + Environment.NewLine +
                                       "   } " + Environment.NewLine +
                                       "   catch (Exception ex) " + Environment.NewLine +
                                       "   { " + Environment.NewLine +
                                       "     return new Base.ErrorReturns().ExceptionDataTable(1,ex.Message,\" "+ MethodName + "\");" + Environment.NewLine +
                                       "   } " + Environment.NewLine +
                                       "}";

                        //MethodData = MethodHeader_InputParameters + Environment.NewLine +
                        //           "{" + Environment.NewLine +
                        //           " try " + Environment.NewLine +
                        //           "{" + Environment.NewLine +
                        //           mySqlCommandInitial + Environment.NewLine +
                        //           Method_InputQueryParameters + Environment.NewLine +
                        //           " return  dbFunctions.SPDataTable(this.mySqlCommand);" + Environment.NewLine +
                        //           "}" + Environment.NewLine +
                        //           "catch (SqlException ex) " + Environment.NewLine +
                        //             "  { " + Environment.NewLine +
                        //             "     return dbFunctions.ExceptionDataTable(ex.ErrorCode,ex.Message ,\"" + MethodName + "\" ,\"" + TableName + "\");" + Environment.NewLine +
                        //             "  }" + Environment.NewLine +
                        //            MethodFooter + Environment.NewLine +
                        //            "}";

                        //ClassInnerData = ClassInnerData + Environment.NewLine +
                        //                 MethodData;

                        #endregion
                    }

                }

                #region "Fixed"
                MethodsContent = MethodsContent + Environment.NewLine +
                                        "public Int32 TotalRecords() " + Environment.NewLine +
                                        "{" + Environment.NewLine +
                                        "   try " + Environment.NewLine +
                                        "   { " + Environment.NewLine +
                                        "       return new " + DAClass + "().TotalRecords();" + Environment.NewLine +
                                        "   } " + Environment.NewLine +
                                        "   catch (Exception ex) " + Environment.NewLine +
                                        "   { " + Environment.NewLine +
                                        "     return 0;" + Environment.NewLine +
                                        "   } " + Environment.NewLine +
                                        "}";

                MethodsContent = MethodsContent + Environment.NewLine +
                                       "public Int32 TotalRecordsByCondition(string WhereCondition) " + Environment.NewLine +
                                       "{" + Environment.NewLine +
                                       "   try " + Environment.NewLine +
                                       "   { " + Environment.NewLine +
                                       "       return new " + DAClass + "().TotalRecords(WhereCondition);" + Environment.NewLine +
                                       "   } " + Environment.NewLine +
                                       "   catch (Exception ex) " + Environment.NewLine +
                                       "   { " + Environment.NewLine +
                                       "     return 0;" + Environment.NewLine +
                                       "   } " + Environment.NewLine +
                                       "}";

                MethodsContent = MethodsContent + Environment.NewLine +
                                       "public DataTable getList_Search(int PageSize, int PageNo, string myWhereCondition, string OrderBy, string Ordering) " + Environment.NewLine +
                                       "{" + Environment.NewLine +
                                       "   try " + Environment.NewLine +
                                       "   { " + Environment.NewLine +
                                       "       return new " + DAClass + "().getList_Search(PageSize,PageNo,myWhereCondition,OrderBy,Ordering);" + Environment.NewLine +
                                       "   } " + Environment.NewLine +
                                       "   catch (Exception ex) " + Environment.NewLine +
                                       "   { " + Environment.NewLine +
                                       "     return new Base.ErrorReturns().ExceptionDataTable(1,ex.Message,\" getList_Search \");" + Environment.NewLine +
                                       "   } " + Environment.NewLine +
                                       "}";
                #endregion



                ReturnClass = ClassHeaderReferences + Environment.NewLine +
                              "namespace " + WCFNamespace + " " + Environment.NewLine +
                              "{ " + Environment.NewLine +
                              "     public class " + ServiceName + " : " + ServiceInterfaceName + Environment.NewLine +
                              "     { " + Environment.NewLine + Environment.NewLine +
                              "     " + MethodsContent + Environment.NewLine +
                              "     } " + Environment.NewLine +
                              "}";


                return ReturnClass;
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }

        public static string GeneratorWCFInterface(string SolutionDBID, DataGridView DAMethods, string TableName, string DataAccessProjectNameSpace, string InterfaceClassNameSpace, string BusinessEntityNameSpace, string BusinessEntityClass, string WCFNamespace, string ServiceInterfaceName, string ModuleName)
        {
            try
            {

                DataTable myQueryColumns_DataTable = getSelectTable_QueryColumns(SolutionDBID, TableName);

                if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count <= 0)
                {
                    Messages.GeneralError("No column exists for Table " + TableName, "Table Columns");
                }

                string ClassHeaderReferences = "using System;" + Environment.NewLine +
                                               "using System.Collections.Generic;" + Environment.NewLine +
                                               "using System.ComponentModel;" + Environment.NewLine +
                                               "using System.Data;" + Environment.NewLine +
                                               "using System.Linq;" + Environment.NewLine +
                                               "using System.Text;" + Environment.NewLine +
                                               "using System.Threading.Tasks;" + Environment.NewLine +
                                               "using System.ServiceModel;" + Environment.NewLine +
                                               "using System.ServiceModel.Web;" + Environment.NewLine +
                                               "using " + DataAccessProjectNameSpace + ".Base.MsSql; " + Environment.NewLine +
                                               "using " + BusinessEntityNameSpace + ";" + Environment.NewLine;

                string MethodsContent = string.Empty;
                String ActionName = string.Empty;
                String ReturnClass = string.Empty;

                #region "Get Methods Parameters"
                Boolean ParameterExists = false;
                Boolean isMethodInitialize = false;
                int Method_WhereInputParametersNo = 0;
                String MethodName = String.Empty;
                String QueryName = String.Empty;
                String MethodHeader = string.Empty;
                String MethodHeader_InputFormat = "{ReturnType} {MethodName}({InputParameters} ); ";
                String MethodHeader_InputParameters = string.Empty;
                String Method_WhereInputParameters = string.Empty;
                String Method_WhereInputerParametersName = String.Empty;
                #endregion

                foreach (DataGridViewRow myGridRow in DAMethods.Rows)
                {
                    #region"Where parameters"
                    ParameterExists = false;
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myGridRow.Cells["clsSelect_Query"];
                    Method_WhereInputParametersNo = 0;
                    MethodName = myGridRow.Cells["clmMethod"].Value.ToString();
                    QueryName = myGridRow.Cells["clmQueryName"].Value.ToString();
                    Method_WhereInputParameters = String.Empty;
                    Method_WhereInputerParametersName = String.Empty;

                    isMethodInitialize = false;

                    foreach (DataRow myGridRow_Columns in myQueryColumns_DataTable.Select("QueryName like '" + myGridRow.Cells["clmQueryName"].Value.ToString() + "'"))
                    {
                        ParameterExists = true;
                        if (isMethodInitialize == false)
                        {
                            isMethodInitialize = true;
                            //MethodHeader = MethodHeader_Format.Replace("{MethodName}", MethodName);
                            MethodHeader_InputParameters = MethodHeader_InputFormat.Replace("{MethodName}", MethodName);
                        }

                        if (myGridRow_Columns["ParameterType"].ToString().ToLower() == "where")
                        {

                            if (Method_WhereInputParametersNo == 0)
                            {
                                Method_WhereInputParameters = myGridRow_Columns["DataType"].ToString() + " " + myGridRow_Columns["ColumnName"].ToString();
                                Method_WhereInputerParametersName = myGridRow_Columns["ColumnName"].ToString();

                            }
                            else
                            {

                                if (Method_WhereInputParametersNo % 5 == 0)
                                {
                                    Method_WhereInputParameters = Method_WhereInputParameters + Environment.NewLine + "," + myGridRow_Columns["DataType"].ToString() + " " + myGridRow_Columns["ColumnName"].ToString();
                                    Method_WhereInputerParametersName = Method_WhereInputerParametersName + Environment.NewLine + "," + myGridRow_Columns["ColumnName"].ToString();
                                }
                                else
                                {
                                    Method_WhereInputParameters = Method_WhereInputParameters + " , " + myGridRow_Columns["DataType"].ToString() + " " + myGridRow_Columns["ColumnName"].ToString();
                                    Method_WhereInputerParametersName = Method_WhereInputerParametersName + "," + myGridRow_Columns["ColumnName"].ToString();
                                }
                            }

                            Method_WhereInputParametersNo++;
                        }


                    }





                    if (ParameterExists == false)
                    {

                        MethodHeader_InputParameters = MethodHeader_InputFormat.Replace("{MethodName}", MethodName);

                    }
                    #endregion

                    ActionName = myGridRow.Cells["clmMethod"].Value.ToString();
                    if (ActionName.ToLower() == "insert" || ActionName.ToLower() == "update"
                        || ActionName.ToLower() == "updatestatus" || ActionName.ToLower() == "delete")
                    {
                        MethodsContent = MethodsContent + Environment.NewLine +
                                        "[OperationContract]" + Environment.NewLine +
                                         " ActionStatus " + ActionName + "(" + BusinessEntityClass + "   " + BusinessEntityClass + " );";
                    }
                    else
                    {
                        #region "Get Methods"

                        MethodHeader_InputParameters = MethodHeader_InputParameters.Replace("{InputParameters}", Method_WhereInputParameters);
                        MethodHeader_InputParameters = MethodHeader_InputParameters.Replace("{ReturnType}", "DataTable");                       

                        MethodsContent = MethodsContent + Environment.NewLine +
                                       "[OperationContract]" + Environment.NewLine  + MethodHeader_InputParameters + Environment.NewLine;
                       
                        #endregion
                    }

                }


                #region "Fixed"
                MethodsContent = MethodsContent + Environment.NewLine +
                                 "[OperationContract]" + Environment.NewLine +
                                 "Int32 TotalRecords(); ";

                MethodsContent = MethodsContent + Environment.NewLine +
                                 "[OperationContract]" + Environment.NewLine +
                                 "Int32 TotalRecordsByCondition(string WhereCondition); ";

                MethodsContent = MethodsContent + Environment.NewLine +
                                "[OperationContract]" + Environment.NewLine +
                                 "DataTable getList_Search(int PageSize, int PageNo, string myWhereCondition, string OrderBy, string Ordering); ";
                #endregion

                ReturnClass = ClassHeaderReferences + Environment.NewLine +
                              "namespace " + WCFNamespace + " " + Environment.NewLine +
                              "{ " + Environment.NewLine +
                              "     [ServiceContract] " + Environment.NewLine +
                              "     public interface I" + ServiceInterfaceName + Environment.NewLine +
                              "     { " + Environment.NewLine +
                              "     " + MethodsContent + Environment.NewLine +
                              "     } " + Environment.NewLine +
                              "}";


                return ReturnClass;
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }


        #region "Fixed"
        static DataTable getSelectTable_QueryColumns(string SolutionID, string TableName)
        {
            try
            {
                return new SolutionsDBQueryColumnsDAL().getList_Search(10000, 1, " SolutionsDBID=" + SolutionID + " and TableName like '" + TableName + "'", "ID");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
