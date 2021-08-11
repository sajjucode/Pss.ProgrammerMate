/*
 * Created By:      Sajjucode
 * Creation Date:   Tuesday,19th Feb.2013
 * Copy Right:      PakSoft Solutions
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;


namespace PSS.DAL.COMMON
{
    public class clsDBFunctions
    {
        private string RootDirectory = Environment.CurrentDirectory;
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        private String SqlQuery = string.Empty;

        public static string Table_Prefix = "pss_";

        private SqlConnection SQlConnection = new SqlConnection();

        public void ReadConnectionSetting()
        {
            try
            {

                DataSet myDataset = new DataSet();
                string FilePath = "DBConnectionSetting.xml";
                string path;
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                myDataset.ReadXml(path + "\\" + FilePath);

                if (myDataset.Tables[0] != null)
                {
                    this.ServerName = myDataset.Tables[0].Rows[0]["ServerName"].ToString();
                    this.DatabaseName = myDataset.Tables[0].Rows[0]["DatabaseName"].ToString();
                    this.UserName = myDataset.Tables[0].Rows[0]["UserName"].ToString();
                    this.UserPassword = myDataset.Tables[0].Rows[0]["UserPassword"].ToString();

                    myDataset.Dispose();
                }




            }
            catch (Exception ex)
            {
            }
        }

        public SqlConnection getSQLConnection()
        {
            try
            {
                this.ReadConnectionSetting();

                if (SQlConnection.State != null && SQlConnection.State == ConnectionState.Open)
                {
                    return SQlConnection;
                }
                else
                {
                    SQlConnection.ConnectionString = "Data Source=" + ServerName  + ";Initial Catalog=" + DatabaseName  + ";Persist Security Info=True;connection reset=false;Pooling=True;min pool size=1;max pool size=200;User ID=" + UserName  + "; Password=" + UserPassword;
                    SQlConnection.Open();

                    return SQlConnection;

                }
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(),"SQL Connection Open");
                return null;
            }

        }

        public void CloseSqlConnection()
        {
            try
            {
                if (SQlConnection.State != null && SQlConnection.State == ConnectionState.Open)
                {
                    SQlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "SQL Connection Close");
            }
        }


        public void setDBConnectionParameters()
        {
            try
            {
                //this.ServerName = "PSSDEVSERVER1\\PSSDEVSERVER12";
                ////this.DatabaseName = "MasterSalalah";
                //this.DatabaseName = "MasterPayroll";
                ////this.DatabaseName = "MasterWebHotel";

                //this.UserName = "PakSoft";
                //this.UserPassword = "patanahi";

                this.ReadConnectionSetting();

            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "SQL Connection Open");

            }

        }

        #region "get SQl Querys"

        public string getInsertQuery(string TableName, string FieldsName, string FieldsValues)
        {
            try
            {
                return " INSERT INTO " + TableName + "(" + FieldsName + ") VALUES (" + FieldsValues + "); Select @@Identity";
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get Insert Query");
                return string.Empty;
            }
        }

        public string getInsertQuery(string TableName, string FieldsName, string FieldsValues, string myWhere)
        {
            try
            {
                //SqlQuery = " If Not Exists(Select * from " + TableName + " Where " + myWhere + Environment.NewLine +
                //           " Begin " + Environment.NewLine +
                //           "    INSERT INTO " + TableName + "(" + FieldsName + ") VALUES (" + FieldsValues + ") " + Environment.NewLine +
                //           " End";


                SqlQuery = " INSERT INTO " + TableName + "(" + FieldsName + ") " + Environment.NewLine +
                            " Select " + FieldsValues + " " + Environment.NewLine +
                            " Where Not Exists(Select * from " + TableName + " Where " + myWhere + " ); Select @@Identity; " + Environment.NewLine;
                           

                return SqlQuery;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get Insert With Condition Query");
                return string.Empty;
            }
        }

        public string getUpdateQuery(string TableName, string FieldsandValues, string myWhere)
        {
            try
            {
                

                return " Update " + TableName  + " SET " + FieldsandValues + " Where " + myWhere ;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get Update Query");
                return string.Empty;
            }
        }

        public string getDeleteQuery(string TableName, string myWhere)
        {
            try
            {
                return " Delete From " + TableName + " Where " + myWhere;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get Delete Query");
                return string.Empty;
            }
        }

        public string getDeleteAllQuery(string TableName)
        {
            try
            {


                return " Delete From " + TableName;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get Delete All Query");
                return string.Empty;
            }

        }


        #endregion

        #region " Retrieve Data"
        public SqlDataAdapter getAllRecords_DataAdapter(string TableName)
        {
            try
            {
                SqlQuery = " Select * from " + TableName;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_DataAdapter(string TableName, string OrderBy)
        {
            try
            {
                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

               
                    SqlQuery = " Select * from " + TableName + "  " + OrderBy;
               
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_DataAdapter(string TableName,string myWhere, string OrderBy)
        {
            try
            {
                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

                SqlQuery = " Select * from " + TableName + " Where " + myWhere +  OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_SelectColumns_DataAdapter(string TableName,string ColumnsName)
        {
            try
            {
                SqlQuery = " Select " + ColumnsName + " from " + TableName;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_SelectColumns_DataAdapter(string TableName, string ColumnsName,string OrderBy)
        {
            try
            {
                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

                SqlQuery = " Select " + ColumnsName + " from " + TableName +  OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_SelectColumns_DataAdapter(string TableName, string ColumnsName, string myWhere, string OrderBy)
        {
            try
            {
                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

                SqlQuery = " Select " + ColumnsName + " from " + TableName + " Where " + myWhere + "  " + OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_CustomizeQuery_DataAdapeter(string mySqlQuery)
        {
            try
            {

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(mySqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }



        public DataTable getAllRecords_DataTable(string TableName)
        {
            try
            {
                DataTable myDataTable = new DataTable("myReturnDataTable");
                SqlQuery = " Select * from " + TableName;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());

                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();
                this.CloseSqlConnection();
                return myDataTable;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
        }

        public DataTable getAllRecords_DataTable(string TableName, string OrderBy)
        {
            try
            {
                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

                DataTable myDataTable = new DataTable("myReturnDataTable");

                SqlQuery = " Select * from " + TableName + "  " + OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());

                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();
                this.CloseSqlConnection();
                return myDataTable;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
        }

        public DataTable getAllRecords_DataTable(string TableName, string myWhere, string OrderBy)
        {
            try
            {

                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

                DataTable myDataTable = new DataTable("myReturnDataTable");

                SqlQuery = " Select * from " + TableName + " Where " + myWhere + "  " + OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());

                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();
                this.CloseSqlConnection();
                return myDataTable;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
        
        }

        public DataTable getAllRecords_SelectColumns_DataTable(string TableName, string ColumnsName)
        {
            try
            {

                DataTable myDataTable = new DataTable("myReturnDataTable");

                SqlQuery = " Select " + ColumnsName + " from " + TableName;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());

                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();

                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();
                this.CloseSqlConnection();
                return myDataTable;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
            
        }

        public DataTable getAllRecords_SelectColumns_DataTable(string TableName, string ColumnsName, string OrderBy)
        {
            try
            {
                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

                DataTable myDataTable = new DataTable("myReturnDataTable");

                SqlQuery = " Select " + ColumnsName + " from " + TableName + "  " + OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());

                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();
                this.CloseSqlConnection();
                return myDataTable;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
        }

        public DataTable getAllRecords_SelectColumns_DataTable(string TableName, string ColumnsName, string myWhere, string OrderBy)
        {
            try
            {
                if (OrderBy != string.Empty && OrderBy.Length > 3)
                {
                    OrderBy = " Order By " + OrderBy;
                }
                else
                {
                    OrderBy = string.Empty;
                }

                DataTable myDataTable = new DataTable("myReturnDataTable");

                SqlQuery = " Select " + ColumnsName + " from " + TableName + " Where " + myWhere + "  " + OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());

                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();
                this.CloseSqlConnection();
                return myDataTable;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
        }

        public DataTable getAllRecords_CustomizeQuery_DataTable(string mySqlQuery)
        {
            try
            {
                DataTable myDataTable = new DataTable("myReturnDataTable");
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(mySqlQuery, getSQLConnection());
                
                mySqlAdapter.Fill(myDataTable);
                mySqlAdapter.Dispose();
                this.CloseSqlConnection();
                return myDataTable;
            }
            catch (SqlException ex)
            {
                WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
        }


        


        #endregion

        #region "Get One Value Function
        public Int32 TotalRecords(string TableName)
        {
            try
            {
                Int32 TotalRecord = 0;
                SqlQuery = " Select count(*) from " + TableName;
                SqlCommand mySqlCommand = new SqlCommand(SqlQuery, this.getSQLConnection());
                Int32.TryParse (mySqlCommand.ExecuteScalar().ToString(),out TotalRecord );
                this.CloseSqlConnection();
                return TotalRecord;
            }
            catch (SqlException ex)
            {
                return 0;
            }
        
        }

        public Int64 TotalRecords(string TableName,string myWhereCondition)
        {
            try
            {
                Int64 TotalRecord = 0;
                SqlQuery = " Select count(*) from " + TableName;

                if (myWhereCondition != "" || myWhereCondition.Length > 0)
                {
                    SqlQuery = SqlQuery + " Where " + myWhereCondition;
                }
                SqlCommand mySqlCommand = new SqlCommand(SqlQuery, this.getSQLConnection());
                Int64.TryParse(mySqlCommand.ExecuteScalar().ToString(), out TotalRecord);
                this.CloseSqlConnection();
                return TotalRecord;
            }
            catch (SqlException ex)
            {
                return 0;
            }

        }

        public Boolean isRecordExists(string TableName, string myWHere)
        {
            try
            {
                DataTable myDataTable = getAllRecords_DataTable(TableName, myWHere, "");

                if (myDataTable != null && myDataTable.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string getMaxNumber(string TableName, string ColumnName)
        {
            try
            {
                SqlQuery = " Select isnull(Max(" + ColumnName + "),0)+1 from " + TableName;
                SqlCommand mySqlCommand = new SqlCommand(SqlQuery, this.getSQLConnection());
                this.CloseSqlConnection();
                return mySqlCommand.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                return "1";
            }
        }

        public string getMaxNumber(string TableName, string ColumnName,string myWhere)
        {
            try
            {
                if (myWhere != string.Empty && myWhere.Length > 3)
                {
                    myWhere = " Where " + myWhere;
                }
                else
                {
                    myWhere = string.Empty;
                }

                SqlQuery = " Select Max(" + ColumnName + ") from " + TableName + " " + myWhere;
                SqlCommand mySqlCommand = new SqlCommand(SqlQuery, this.getSQLConnection());

                return mySqlCommand.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                return "0";
            }
            finally
            {
                this.CloseSqlConnection();
            }
        }

        #endregion

        #region "Get Errors"
        /// <summary>
        /// Return formated Insert error.
        /// </summary>
        /// <param name="RecordName">e.g. Category Name</param>
        /// <param name="ErrorCode">e.g. 101</param>
        /// <param name="ErrorMessage">e.g. Primary Key</param>
        /// /// <param name="ActionName">e.g. Inserted,Updated</param>
        /// <returns>Formated String.</returns>
        public string Error_Description(string ActionName, string RecordName, string ErrorCode, string ErrorMessage)
        {
            return RecordName + " not " + ActionName +" because: " + ErrorCode + ":" + Error_Desc(ErrorCode, ErrorMessage);
        }

        public string Error_Desc(string ErrorCode, string ErrorMessage)
        {
            try
            {
                //String ErrorDescription = string.Empty;

                //switch (ErrorCode)
                //{
                //    case "-2146232060":
                //        ErrorMessage = " Record Duplication not allowed";
                //        break;
                    
                //}

                return ErrorMessage;
            }
            catch (Exception ex)
            {
                return ErrorMessage;
            }
        }



        #endregion

        public void WriteError(string ErrorText, string ErrorFrom)
        {

        }


        public void runSQLQuery(string SQLQuery)
        {
            try
            {
                SqlCommand mySqlCOmmand = new SqlCommand(SqlQuery, this.getSQLConnection());

                mySqlCOmmand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
        }

    }
}
