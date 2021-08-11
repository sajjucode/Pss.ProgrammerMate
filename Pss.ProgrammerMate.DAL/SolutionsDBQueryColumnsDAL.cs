using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.DAL.COMMON;

namespace Pss.ProgrammerMate.DAL
{

    /// <summary> 
    /// SolutionsDBQueryColumnsDAL  class is use for All database methods and operations for table SolutionsDBQueryColumns
    /// </summary> 
    /// <remarks> 
    /// Author: Sajjad Yousuf Anjum 
    /// Created Date: Saturday 14 Nov 2015 03:15:04
    /// Copy Rights: PakSoft Solutions 
    /// </remarks> 
    [Serializable]
    public class SolutionsDBQueryColumnsDAL : clsDBFunctions
    {

        #region "public variables"
        string myTableName = "SolutionsDBQueryColumns";
        string myTablesFields = string.Empty;
        string myTablesFieldsValues = string.Empty;
        string myUpdateFieldsandValues = string.Empty;
        string myWhere = string.Empty;
        SqlCommand mySqlCommand;
        string mySqlQuery = string.Empty;
        string ReturnIdentity = "-1";

        #endregion

        /// <summary>
        /// Get or Set value of I D
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// Get or Set value of Solutions D B I D
        /// </summary>
        public int SolutionsDBID { get; set; }


        /// <summary>
        /// Get or Set value of Query Id
        /// </summary>
        public int QueryId { get; set; }


        /// <summary>
        /// Get or Set value of Query Name
        /// </summary>
        public string QueryName { get; set; }


        /// <summary>
        /// Get or Set value of Table Id
        /// </summary>
        public int TableId { get; set; }


        /// <summary>
        /// Get or Set value of Table Name
        /// </summary>
        public string TableName { get; set; }


        /// <summary>
        /// Get or Set value of Column Name
        /// </summary>
        public string ColumnName { get; set; }


        /// <summary>
        /// Get or Set value of Column Type
        /// </summary>
        public string ColumnType { get; set; }


        /// <summary>
        /// Get or Set value of Column Data Type
        /// </summary>
        public string ColumnDataType { get; set; }


        /// <summary>
        /// Get or Set value of Data Type
        /// </summary>
        public string DataType { get; set; }


        /// <summary>
        /// Get or Set value of C O L U M N _ K E Y
        /// </summary>
        public string COLUMN_KEY { get; set; }


        /// <summary>
        /// Get or Set value of is Identity
        /// </summary>
        public Boolean isIdentity { get; set; }


        /// <summary>
        /// Get or Set value of Allow Null
        /// </summary>
        public Boolean AllowNull { get; set; }


        /// <summary>
        /// Get or Set value of Parameter Name
        /// </summary>
        public string ParameterName { get; set; }


        /// <summary>
        /// Get or Set value of Parameter Type
        /// </summary>
        public string ParameterType { get; set; }


        /// <summary>
        /// Get or Set value of is Active
        /// </summary>
        public Boolean isActive { get; set; }


        /// <summary>
        /// Get or Set value of Created On Utc
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// Get or Set value of Updated On Utc
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }







        /// <summary> 
        /// Add New Record but first fill the properties. and Id should be 0 
        /// </summary> 
        /// <returns></returns> 
        public clsActionStatus Insert()
        {
            clsActionStatus clsActionStatus = new clsActionStatus();

            try
            {
                this.myTablesFields = "SolutionsDBID,QueryId,QueryName,TableId,TableName,ColumnName,ColumnType,ColumnDataType,DataType,COLUMN_KEY," +
                                      "isIdentity,AllowNull,ParameterName,ParameterType,isActive,CreatedOnUtc,UpdatedOnUtc";
                this.myTablesFieldsValues = "@SolutionsDBID,@QueryId,@QueryName,@TableId,@TableName,@ColumnName,@ColumnType,@ColumnDataType,@DataType,@COLUMN_KEY," +
                                       "@isIdentity,@AllowNull,@ParameterName,@ParameterType,@isActive,getDate(),getDate()";

                this.myWhere = " SolutionsDBID=@SolutionsDBID , QueryName=@QueryName , TableName=@TableName  ";

                this.mySqlQuery = this.getInsertQuery(this.myTableName, this.myTablesFields, this.myTablesFieldsValues);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@SolutionsDBID", SqlDbType.Int).Value = this.SolutionsDBID;
                myPara.Add("@QueryId", SqlDbType.Int).Value = this.QueryId;
                myPara.Add("@QueryName", SqlDbType.NVarChar).Value = this.QueryName;
                myPara.Add("@TableId", SqlDbType.Int).Value = this.TableId;
                myPara.Add("@TableName", SqlDbType.NVarChar).Value = this.TableName;
                myPara.Add("@ColumnName", SqlDbType.NVarChar).Value = this.ColumnName;
                myPara.Add("@ColumnType", SqlDbType.NVarChar).Value = this.ColumnType;
                myPara.Add("@ColumnDataType", SqlDbType.NVarChar).Value = this.ColumnDataType;
                myPara.Add("@DataType", SqlDbType.NVarChar).Value = this.DataType;
                myPara.Add("@COLUMN_KEY", SqlDbType.NVarChar).Value = this.COLUMN_KEY;
                myPara.Add("@isIdentity", SqlDbType.Bit).Value = this.isIdentity;
                myPara.Add("@AllowNull", SqlDbType.Bit).Value = this.AllowNull;
                myPara.Add("@ParameterName", SqlDbType.NVarChar).Value = this.ParameterName;
                myPara.Add("@ParameterType", SqlDbType.NVarChar).Value = this.ParameterType;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive; 


                ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Created successfully!. and New Id is : " + ReturnIdentity;
                clsActionStatus.Return_Id = ReturnIdentity;
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Insert", "SolutionsDBQueryColumns", ex.ErrorCode.ToString(), ex.Message);
            }
            finally
            {
                this.mySqlCommand.Dispose();
                this.CloseSqlConnection();
            }
            return clsActionStatus;
        }

        /// <summary> 
        /// Update Record but first fill the properties. and Id will be use as where condition 
        /// </summary> 
        /// <returns></returns> 
        public clsActionStatus Update()
        {
            clsActionStatus clsActionStatus = new clsActionStatus();

            try
            {
                this.myWhere = " ID=" + this.ID.ToString();
                this.myUpdateFieldsandValues = "SolutionsDBID=@SolutionsDBID,QueryId=@QueryId,QueryName=@QueryName,TableId=@TableId,TableName=@TableName,ColumnName=@ColumnName,ColumnType=@ColumnType,ColumnDataType=@ColumnDataType,DataType=@DataType,COLUMN_KEY=@COLUMN_KEY," +
                                                "isIdentity=@isIdentity,AllowNull=@AllowNull,ParameterName=@ParameterName,ParameterType=@ParameterType,isActive=@isActive,UpdatedOnUtc=getDate()"; 
                this.mySqlQuery = this.getUpdateQuery(this.myTableName, this.myUpdateFieldsandValues, this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@SolutionsDBID", SqlDbType.Int).Value = this.SolutionsDBID;
                myPara.Add("@QueryId", SqlDbType.Int).Value = this.QueryId;
                myPara.Add("@QueryName", SqlDbType.NVarChar).Value = this.QueryName;
                myPara.Add("@TableId", SqlDbType.Int).Value = this.TableId;
                myPara.Add("@TableName", SqlDbType.NVarChar).Value = this.TableName;
                myPara.Add("@ColumnName", SqlDbType.NVarChar).Value = this.ColumnName;
                myPara.Add("@ColumnType", SqlDbType.NVarChar).Value = this.ColumnType;
                myPara.Add("@ColumnDataType", SqlDbType.NVarChar).Value = this.ColumnDataType;
                myPara.Add("@DataType", SqlDbType.NVarChar).Value = this.DataType;
                myPara.Add("@COLUMN_KEY", SqlDbType.NVarChar).Value = this.COLUMN_KEY;
                myPara.Add("@isIdentity", SqlDbType.Bit).Value = this.isIdentity;
                myPara.Add("@AllowNull", SqlDbType.Bit).Value = this.AllowNull;
                myPara.Add("@ParameterName", SqlDbType.NVarChar).Value = this.ParameterName;
                myPara.Add("@ParameterType", SqlDbType.NVarChar).Value = this.ParameterType;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive; 

                this.mySqlCommand.ExecuteNonQuery();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Updated successfully!";
                clsActionStatus.Return_Id = this.ID.ToString();
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Update", "SolutionsDBQueryColumns", ex.ErrorCode.ToString(), ex.Message);
            }
            finally
            {
                this.mySqlCommand.Dispose();
                this.CloseSqlConnection();
            }
            return clsActionStatus;
        }

        /// <summary> 
        /// Change  Record Status for active or disable but first fill the properties. and Id will be use as where condition 
        /// </summary> 
        /// <returns></returns> 
        public clsActionStatus ChangeStatus()
        {
            clsActionStatus clsActionStatus = new clsActionStatus();

            try
            {
                this.myWhere = " ID=" + this.ID.ToString();
                this.myUpdateFieldsandValues = "isActive=@isActive";
                this.mySqlQuery = this.getUpdateQuery(this.myTableName, this.myUpdateFieldsandValues, this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive;

                this.mySqlCommand.ExecuteNonQuery();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Status updated successfully!";
                clsActionStatus.Return_Id = this.ID.ToString();
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Change Status", "SolutionsDBQueryColumns", ex.ErrorCode.ToString(), ex.Message);
            }
            finally
            {
                this.mySqlCommand.Dispose();
                this.CloseSqlConnection();
            }
            return clsActionStatus;
        }

        /// <summary> 
        /// Delete Record but first fill the properties. and Id will be use as where condition 
        /// </summary> 
        /// <returns></returns> 
        public clsActionStatus Delete()
        {
            clsActionStatus clsActionStatus = new clsActionStatus();

            try
            {
                this.myWhere = " ID=" + this.ID.ToString();
                this.mySqlQuery = this.getDeleteQuery(this.myTableName, this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());

                this.mySqlCommand.ExecuteNonQuery();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Deleted successfully!";
                clsActionStatus.Return_Id = this.ID.ToString();
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Delete", "SolutionsDBQueryColumns", ex.ErrorCode.ToString(), ex.Message);
            }
            finally
            {
                this.mySqlCommand.Dispose();
                this.CloseSqlConnection();
            }
            return clsActionStatus;
        }

        /// <summary> 
        /// Use to Get Total Records 
        /// </summary> 
        /// <returns></returns> 
        public Int64 getTotalNumberOfRecords(int PageSize, int PageNo, string OrderBy, string Ordering = "Asc")
        {
            return this.TotalRecords(this.myTableName);


        }

        /// <summary> 
        /// Get Detail of Record by Id 
        /// </summary> 
        /// <returns></returns> 
        public DataTable getInfo(Int64 Org_Id)
        {
            try
            {
                this.myWhere = " ID=" + Org_Id;
                return this.getAllRecords_DataTable(this.myTableName, this.myWhere, " Id asc");
            }
            catch (SqlException ex)
            {
                return null;
            }


        }
        /// <summary> 
        /// Use to Get List of Records by Page Size and Page No 
        /// </summary> 
        /// <returns></returns> 
        public DataTable getList(int PageSize, int PageNo, string OrderBy, string Ordering = "Asc")
        {
            this.mySqlQuery = "Select * " + Environment.NewLine +
            "  from  (  " + Environment.NewLine +
            "          Select *, ROW_NUMBER() over (Order By " + OrderBy + " " + Ordering + ") as MyRecordNo " + Environment.NewLine +
            "          from " + this.myTableName + " " + Environment.NewLine +
            "          ) as myTable " + Environment.NewLine +
            "          Where myTable.MyRecordNo BETWEEN (" + PageSize + "*(" + PageNo + "-1))+1 AND (" + PageSize + "*" + PageNo + ") ";


            return this.getAllRecords_CustomizeQuery_DataTable(this.mySqlQuery);
        }

        /// <summary> 
        /// Use to Get List of Records by Search and by Page Size and Page No 
        /// </summary> 
        /// <returns></returns> 
        public DataTable getList_Search(int PageSize, int PageNo, string myWhereCondition, string OrderBy, string Ordering = "Asc")
        {
            this.mySqlQuery = "Select * " + Environment.NewLine +
            "  from  (  " + Environment.NewLine +
            "          Select *, ROW_NUMBER() over (Order By " + OrderBy + " " + Ordering + ") as MyRecordNo " + Environment.NewLine +
            "          from " + this.myTableName + " " + Environment.NewLine +
            "          Where " + myWhereCondition + Environment.NewLine +
            "          ) as myTable " + Environment.NewLine +
            "          Where myTable.MyRecordNo BETWEEN (" + PageSize + "*(" + PageNo + "-1))+1 AND (" + PageSize + "*" + PageNo + ") ";


            return this.getAllRecords_CustomizeQuery_DataTable(this.mySqlQuery);
        }

    }
}