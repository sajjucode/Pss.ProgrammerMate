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
    /// SolutionsDBQueryDAL  class is use for All database methods and operations for table SolutionsDBQuery
    /// </summary> 
    /// <remarks> 
    /// Author: Sajjad Yousuf Anjum 
    /// Created Date: Monday 09 Nov 2015 22:25:03
    /// Copy Rights: PakSoft Solutions 
    /// </remarks> 
    [Serializable]
    public class SolutionsDBQueryDAL : clsDBFunctions
    {

        #region "public variables"
        string myTableName = "SolutionsDBQuery";
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

        public string TableName { get; set; }


        /// <summary>
        /// Get or Set value of Query Type
        /// </summary>
        public string QueryType { get; set; }


        /// <summary>
        /// Get or Set value of Action Type
        /// </summary>
        public string ActionType { get; set; }


        /// <summary>
        /// Get or Set value of Query Name
        /// </summary>
        public string QueryName { get; set; }


        /// <summary>
        /// Get or Set value of Query Text
        /// </summary>
        public string QueryText { get; set; }


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

        public string DALMethodName { get; set; }
        public int ActionID { get; set; }


        /// <summary> 
        /// Add New Record but first fill the properties. and Id should be 0 
        /// </summary> 
        /// <returns></returns> 
        public clsActionStatus Insert()
        {
            clsActionStatus clsActionStatus = new clsActionStatus();

            try
            {
                this.myTablesFields = "SolutionsDBID,TableName,QueryType,ActionType,QueryName,QueryText,UserId,isActive,CreatedOnUtc,UpdatedOnUtc,DALMethodName,ActionID";
                this.myTablesFieldsValues = "@SolutionsDBID,@TableName,@QueryType,@ActionType,@QueryName,@QueryText,@UserId,@isActive,getDate(),getDate(),@DALMethodName,@ActionID";
                this.myWhere = "TableName like @TableName and QueryName like @QueryName";
                this.mySqlQuery = this.getInsertQuery(this.myTableName, this.myTablesFields, this.myTablesFieldsValues,this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@SolutionsDBID", SqlDbType.Int).Value = this.SolutionsDBID;
                myPara.Add("@TableName", SqlDbType.NVarChar).Value = this.TableName;
                myPara.Add("@QueryType", SqlDbType.NVarChar).Value = this.QueryType;
                myPara.Add("@ActionType", SqlDbType.NVarChar).Value = this.ActionType;
                myPara.Add("@QueryName", SqlDbType.NVarChar).Value = this.QueryName;
                myPara.Add("@QueryText", SqlDbType.NVarChar).Value = this.QueryText;
                myPara.Add("@UserId", SqlDbType.Int).Value = this.UserId;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive;

                myPara.Add("@DALMethodName", SqlDbType.NVarChar).Value = this.DALMethodName;
                myPara.Add("@ActionID", SqlDbType.Int).Value = this.ActionID;

                ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Created successfully!. and New Id is : " + ReturnIdentity;
                clsActionStatus.Return_Id = ReturnIdentity;
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Insert", "SolutionsDBQuery", ex.ErrorCode.ToString(), ex.Message);
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
                this.myUpdateFieldsandValues = "SolutionsDBID=@SolutionsDBID,TableName=@TableName,QueryType=@QueryType,ActionType=@ActionType," + Environment.NewLine +
                                               " QueryName=@QueryName,QueryText=@QueryText,UserId=@UserId,isActive=@isActive,UpdatedOnUtc=getDate(),DALMethodName=@DALMethodName,ActionID=@ActionID";
                this.mySqlQuery = this.getUpdateQuery(this.myTableName, this.myUpdateFieldsandValues, this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@SolutionsDBID", SqlDbType.Int).Value = this.SolutionsDBID;
                myPara.Add("@TableName", SqlDbType.NVarChar).Value = this.TableName;
                myPara.Add("@QueryType", SqlDbType.NVarChar).Value = this.QueryType;
                myPara.Add("@ActionType", SqlDbType.NVarChar).Value = this.ActionType;
                myPara.Add("@QueryName", SqlDbType.NVarChar).Value = this.QueryName;
                myPara.Add("@QueryText", SqlDbType.NVarChar).Value = this.QueryText;
                myPara.Add("@UserId", SqlDbType.Int).Value = this.UserId;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive;

                myPara.Add("@DALMethodName", SqlDbType.NVarChar).Value = this.DALMethodName;
                myPara.Add("@ActionID", SqlDbType.Int).Value = this.ActionID;

                this.mySqlCommand.ExecuteNonQuery();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Updated successfully!";
                clsActionStatus.Return_Id = this.ID.ToString();
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Update", "SolutionsDBQuery", ex.ErrorCode.ToString(), ex.Message);
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
                clsActionStatus.Action_FailureStatus = this.Error_Description("Change Status", "SolutionsDBQuery", ex.ErrorCode.ToString(), ex.Message);
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
                clsActionStatus.Action_FailureStatus = this.Error_Description("Delete", "SolutionsDBQuery", ex.ErrorCode.ToString(), ex.Message);
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

        public DataTable getList(string SolutionDBID , string TableName)
        {
            this.mySqlQuery = " Select isnull(SDQ.ID,0) as ID , isnull(SolutionsDBID,0) as SolutionsDBID,TableName,SDQ.QueryType, isnull(SDQ.ActionType,DA.ActionType) as ActionType, " + Environment.NewLine +
	                          " SDQ.QueryName,QueryText,SDQ.UserId,SDQ.isActive,SDQ.CreatedOnUtc,SDQ.UpdatedOnUtc,isnull(SDQ.DALMethodName,DA.DALMethodName) as DALMethodName, " + Environment.NewLine +
	                          " isnull(SDQ.ActionID,DA.ID) as ActionID " + Environment.NewLine +
                              " From DBActions DA " + Environment.NewLine +
	                          " Left Join " + Environment.NewLine +
	                          " SolutionsDBQuery SDQ on DA.ID = SDQ.ActionID and SDQ.SolutionsDBID =" + SolutionDBID + " and SDQ.TableName like '" + TableName + "' " + Environment.NewLine +
                              "  Union All " + Environment.NewLine +
                              "  Select isnull(SDQ.ID,0) as ID , isnull(SolutionsDBID,0) as SolutionsDBID,TableName,SDQ.QueryType,SDQ.ActionType, " + Environment.NewLine +
	                          "         SDQ.QueryName,QueryText,SDQ.UserId,SDQ.isActive,SDQ.CreatedOnUtc,SDQ.UpdatedOnUtc,SDQ.DALMethodName, " + Environment.NewLine +
	                          "         isnull(SDQ.ActionID,0) as ActionID " + Environment.NewLine +
                              "  From SolutionsDBQuery SDQ " + Environment.NewLine +
                              "  Where SDQ.SolutionsDBID =" + SolutionDBID + " and SDQ.TableName like '" + TableName + "' And SDQ.ActionID not in (Select SDQ1.ActionID From SolutionsDBQuery SDQ1 where SDQ1.SolutionsDBID =" + SolutionDBID + " and SDQ1.TableName like '" + TableName + "'  and SDQ1.ActionID is not null)";
            return this.getAllRecords_CustomizeQuery_DataTable(this.mySqlQuery);
        }


        public Boolean isQueryExist(Int64 SolutionsDBID,string TableName, string QueryName)
        {
            this.myWhere = " SolutionsDBID=" + SolutionsDBID + " and TableName like '" + TableName + "' and QueryName like '" + QueryName + "'";
            return this.isRecordExists(this.myTableName, this.myWhere);
        }

    }
}