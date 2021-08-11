using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Pss.ProgrammerMate.DataAccess.MySql
{
    public class mySqlDBFunctions
    {
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
        private MySqlConnection mySqlConnection = new MySqlConnection();

        public MySqlConnection getConnection()
        {
            try
            {
                if (this.mySqlConnection.State != null && this.mySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    return mySqlConnection;
                }
                else
                {
                    MySqlConnectionStringBuilder mySqlConnectionString = new MySqlConnectionStringBuilder();
                    mySqlConnectionString.Server = this.Server;
                    mySqlConnectionString.Database = this.DatabaseName;
                    mySqlConnectionString.UserID = this.DBUserName;
                    mySqlConnectionString.Password = this.DBPassword;
                    mySqlConnectionString.Pooling = true;
                    mySqlConnectionString.MaximumPoolSize = 200;

                    this.mySqlConnection.ConnectionString = mySqlConnectionString.ConnectionString;

                    this.mySqlConnection.Open();

                }



                return mySqlConnection;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable getTablesList()
        {
            try
            {
                var Query = "Show Tables";
                DataTable returnDataTable = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(Query, getConnection());

                mySqlDataAdapter.Fill(returnDataTable);

                if (returnDataTable != null && returnDataTable.Rows.Count > 0)
                {
                    returnDataTable.Columns[0].ColumnName = "Tables";
                }

                mySqlDataAdapter.Dispose();
                this.closeConnection();

                return returnDataTable;
            }
            catch (MySqlException ex)
            {
                return null;
            }

        }

        public string ExecuteQuery(string SqlQuery)
        {
            try
            {
                SqlQuery = SqlQuery.Replace("DELIMITER ;", "");
                SqlQuery = SqlQuery.Replace("DELIMITER $$", "");
                SqlQuery = SqlQuery.Replace("$$", "");

                MySqlCommand mySqlCommand = new MySqlCommand(SqlQuery, this.getConnection());

                var commandParameters = mySqlCommand.Parameters;

                commandParameters.Add("@Id", MySqlDbType.Int16).Value = 1;

                //mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.ExecuteNonQuery();

                this.closeConnection();

                return "Query Executed successfully";
            }
            catch (Exception ex)
            {
                return "Error:Query not executed  because " + ex.Message;
            }
        }

        public DataTable getTablesColumns(string DBName, string TableName)
        {
            try
            {
                DBName = DBName.Replace("'", "''");
                TableName = TableName.Replace("'", "''");


                var Query = " SELECT *  " + Environment.NewLine +
                            " FROM INFORMATION_SCHEMA.COLUMNS  " + Environment.NewLine +
                            " WHERE TABLE_SCHEMA = '" + DBName + "' AND TABLE_NAME = '" + TableName + "';";
                DataTable returnDataTable = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(Query, getConnection());

                mySqlDataAdapter.Fill(returnDataTable);

                mySqlDataAdapter.Dispose();
                this.closeConnection();

                return returnDataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void closeConnection()
        {
            try
            {
                if (this.mySqlConnection.State != null && this.mySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
