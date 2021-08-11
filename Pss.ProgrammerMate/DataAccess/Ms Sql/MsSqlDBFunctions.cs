using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Pss.ProgrammerMate.DataAccess.Ms_Sql
{
    public class MsSqlDBFunctions
    {
        private string RootDirectory = Environment.CurrentDirectory;
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        private String SqlQuery = string.Empty;

        private SqlConnection SQlConnection = new SqlConnection();

        public SqlConnection getSQLConnection()
        {
            try
            {

                if (SQlConnection.State != null && SQlConnection.State == ConnectionState.Open)
                {
                    return SQlConnection;
                }
                else
                {
                    SQlConnection.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=True;connection reset=false;Pooling=True;min pool size=1;max pool size=200;User ID=" + UserName + "; Password=" + UserPassword;
                    SQlConnection.Open();

                    return SQlConnection;

                }
            }
            catch (SqlException ex)
            {
                
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
                ////WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "SQL Connection Close");
            }
        }


        public DataTable getTablesList()
        {
            try
            {
                string mySQLQuery = "Select *,TABLE_NAME as Tables from information_schema.tables";
                DataTable myDataTable = new DataTable();
                myDataTable = this.getAllRecords_CustomizeQuery_DataTable(mySQLQuery);

                this.CloseSqlConnection();

                return myDataTable;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable getTablesColumns(string DBName, string TableName)
        {
            try
            {
                DBName = DBName.Replace("'", "''");
                TableName = TableName.Replace("'", "''");


                //var Query = " SELECT *  " + Environment.NewLine +
                //            " FROM INFORMATION_SCHEMA.COLUMNS  " + Environment.NewLine +
                //            " WHERE TABLE_CATALOG = '" + DBName + "' AND TABLE_NAME = '" + TableName + "';";

                var Query = " SELECT t.name AS table_name, " + Environment.NewLine +
                            "    SCHEMA_NAME(schema_id) AS schema_name, " + Environment.NewLine +
                            "    c.name AS column_name,c.is_identity, " + Environment.NewLine +
                            "    SC.DATA_TYPE, " + Environment.NewLine +
                            "    isnull(CC.CONSTRAINT_NAME,'none') as COLUMN_KEY, " + Environment.NewLine +
                            "    Case " + Environment.NewLine +
                            "        When SC.CHARACTER_MAXIMUM_LENGTH is null or DATA_TYPE like 'image' then SC.DATA_TYPE " + Environment.NewLine +                            
                            "        else " + Environment.NewLine +
                            "        SC.DATA_TYPE + '(' + CONVERT(varchar(20),SC.CHARACTER_MAXIMUM_LENGTH) + ')' " + Environment.NewLine +
                            "    End as ColumnType " + Environment.NewLine +
                            "    FROM sys.tables AS t " + Environment.NewLine +
                            "    INNER JOIN sys.columns c ON t.OBJECT_ID = c.OBJECT_ID  " + Environment.NewLine +
                            "    Inner Join " + Environment.NewLine +
                            "    INFORMATION_SCHEMA.COLUMNS SC on SC.TABLE_NAME = t.name and SC.COLUMN_NAME = c.name " + Environment.NewLine +
                            "    Left Join " + Environment.NewLine +
                            "    INFORMATION_SCHEMA.KEY_COLUMN_USAGE CC on  t.name = CC.TABLE_NAME and CC.TABLE_CATALOG = '" + DBName + "' and CC.COLUMN_NAME = C.name " + Environment.NewLine +
                            "    Where t.name like '" + TableName +"' " + Environment.NewLine +
                            "    ORDER BY schema_name, table_name;";

                DataTable returnDataTable = new DataTable();

                returnDataTable = this.getAllRecords_CustomizeQuery_DataTable(Query);


                this.CloseSqlConnection();

                return returnDataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ExecuteQuery(string SqlQuery)
        {
            try
            {
                //SqlQuery = SqlQuery.Replace("DELIMITER ;", "");
                //SqlQuery = SqlQuery.Replace("DELIMITER $$", "");
                //SqlQuery = SqlQuery.Replace("$$", "");                

                SqlCommand mySqlCommand = new SqlCommand(SqlQuery, this.getSQLConnection());

                //mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.ExecuteNonQuery();

                this.CloseSqlConnection();

                return "Query Executed successfully";
            }
            catch (Exception ex)
            {
                return "Error:Query not executed  because " + ex.Message;
            }
        }


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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_DataAdapter(string TableName, string myWhere, string OrderBy)
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

                SqlQuery = " Select * from " + TableName + " Where " + myWhere + OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_SelectColumns_DataAdapter(string TableName, string ColumnsName)
        {
            try
            {
                SqlQuery = " Select " + ColumnsName + " from " + TableName;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
                return null;
            }
        }

        public SqlDataAdapter getAllRecords_SelectColumns_DataAdapter(string TableName, string ColumnsName, string OrderBy)
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

                SqlQuery = " Select " + ColumnsName + " from " + TableName + OrderBy;
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(SqlQuery, getSQLConnection());
                return mySqlAdapter;
            }
            catch (SqlException ex)
            {
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataAdapter");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
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
                //WriteError(ex.Message.ToString() + Environment.NewLine + ex.Source.ToString(), "Get All Records DataTable");
                return null;
            }
        }





        #endregion

    }
}
