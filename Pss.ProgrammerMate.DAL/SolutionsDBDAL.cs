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
    /// SolutionsDBDAL  class is use for All database methods and operations for table SolutionsDB
    /// </summary> 
    /// <remarks> 
    /// Author: Sajjad Yousuf Anjum 
    /// Created Date: Monday 09 Nov 2015 22:24:57
    /// Copy Rights: PakSoft Solutions 
    /// </remarks> 
    [Serializable]
    public class SolutionsDBDAL : clsDBFunctions
    {

        #region "public variables"
        string myTableName = "SolutionsDB";
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
        /// Get or Set value of Solution I D
        /// </summary>
        public int SolutionID { get; set; }


        /// <summary>
        /// Get or Set value of D B Type
        /// </summary>
        public string DBType { get; set; }


        /// <summary>
        /// Get or Set value of Server Name
        /// </summary>
        public string ServerName { get; set; }


        /// <summary>
        /// Get or Set value of D B Name
        /// </summary>
        public string DBName { get; set; }


        /// <summary>
        /// Get or Set value of User Name
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// Get or Set value of D Password
        /// </summary>
        public string DPassword { get; set; }


        /// <summary>
        /// Get or Set value of S Q L Type
        /// </summary>
        public string SQLType { get; set; }


        /// <summary>
        /// Get or Set value of S P Format
        /// </summary>
        public string SPFormat { get; set; }


        /// <summary>
        /// Get or Set value of User Id
        /// </summary>
        public int UserId { get; set; }


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
                this.myTablesFields = "SolutionID,DBType,ServerName,DBName,UserName,DPassword,SQLType,SPFormat,UserId,isActive," +
                            "CreatedOnUtc,UpdatedOnUtc";
                this.myTablesFieldsValues = "@SolutionID,@DBType,@ServerName,@DBName,@UserName,@DPassword,@SQLType,@SPFormat,@UserId,@isActive," +
                            "getDate(),getDate()";
                this.mySqlQuery = this.getInsertQuery(this.myTableName, this.myTablesFields, this.myTablesFieldsValues);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@SolutionID", SqlDbType.Int).Value = this.SolutionID;
                myPara.Add("@DBType", SqlDbType.NVarChar).Value = this.DBType;
                myPara.Add("@ServerName", SqlDbType.NVarChar).Value = this.ServerName;
                myPara.Add("@DBName", SqlDbType.NVarChar).Value = this.DBName;
                myPara.Add("@UserName", SqlDbType.NVarChar).Value = this.UserName;
                if (this.DPassword == "")
                {
                    myPara.Add("@DPassword", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                else
                {
                    myPara.Add("@DPassword", SqlDbType.NVarChar).Value = this.DPassword;
                }
                myPara.Add("@SQLType", SqlDbType.NVarChar).Value = this.SQLType;
                myPara.Add("@SPFormat", SqlDbType.NVarChar).Value = this.SPFormat;
                myPara.Add("@UserId", SqlDbType.Int).Value = this.UserId;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive;

                ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Created successfully!. and New Id is : " + ReturnIdentity;
                clsActionStatus.Return_Id = ReturnIdentity;
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Insert", "SolutionsDB", ex.ErrorCode.ToString(), ex.Message);
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
                this.myUpdateFieldsandValues = "SolutionID=@SolutionID,DBType=@DBType,ServerName=@ServerName,DBName=@DBName,UserName=@UserName,DPassword=@DPassword,SQLType=@SQLType,SPFormat=@SPFormat,UserId=@UserId,isActive=@isActive," +
                            "UpdatedOnUtc=getDate()";
                this.mySqlQuery = this.getUpdateQuery(this.myTableName, this.myUpdateFieldsandValues, this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@SolutionID", SqlDbType.Int).Value = this.SolutionID;
                myPara.Add("@DBType", SqlDbType.NVarChar).Value = this.DBType;
                myPara.Add("@ServerName", SqlDbType.NVarChar).Value = this.ServerName;
                myPara.Add("@DBName", SqlDbType.NVarChar).Value = this.DBName;
                myPara.Add("@UserName", SqlDbType.NVarChar).Value = this.UserName;
                
                if (this.DPassword == "")
                {
                    myPara.Add("@DPassword", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                else
                {
                    myPara.Add("@DPassword", SqlDbType.NVarChar).Value = this.DPassword;
                }

                myPara.Add("@SQLType", SqlDbType.NVarChar).Value = this.SQLType;
                myPara.Add("@SPFormat", SqlDbType.NVarChar).Value = this.SPFormat;
                myPara.Add("@UserId", SqlDbType.Int).Value = this.UserId;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive;

                this.mySqlCommand.ExecuteNonQuery();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Updated successfully!";
                clsActionStatus.Return_Id = this.ID.ToString();
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Update", "SolutionsDB", ex.ErrorCode.ToString(), ex.Message);
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
                clsActionStatus.Action_FailureStatus = this.Error_Description("Change Status", "SolutionsDB", ex.ErrorCode.ToString(), ex.Message);
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
                clsActionStatus.Action_FailureStatus = this.Error_Description("Delete", "SolutionsDB", ex.ErrorCode.ToString(), ex.Message);
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
            this.mySqlQuery = "Select *,(DBType + ' => ' + ServerName + ' => ' + DBName) as DBInfo " + Environment.NewLine +
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