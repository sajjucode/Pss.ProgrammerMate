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
    /// ProjectFilesDAL  class is use for All database methods and operations for table ProjectFiles
    /// </summary> 
    /// <remarks> 
    /// Author: Sajjad Yousuf Anjum 
    /// Created Date: Monday 09 Nov 2015 22:24:52
    /// Copy Rights: PakSoft Solutions 
    /// </remarks> 
    [Serializable]
    public class ProjectFilesDAL : clsDBFunctions
    {

        #region "public variables"
        string myTableName = "ProjectFiles";
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
        /// Get or Set value of Project Id
        /// </summary>
        public int ProjectId { get; set; }


        /// <summary>
        /// Get or Set value of Folder Id
        /// </summary>
        public int FolderId { get; set; }


        /// <summary>
        /// Get or Set value of Folder Name
        /// </summary>
        public string FolderName { get; set; }


        /// <summary>
        /// Get or Set value of F Name Space
        /// </summary>
        public string FNameSpace { get; set; }


        /// <summary>
        /// Get or Set value of Save As
        /// </summary>
        public string SaveAs { get; set; }


        /// <summary>
        /// Get or Set value of Full Path
        /// </summary>
        public string FullPath { get; set; }


        /// <summary>
        /// Get or Set value of File Data
        /// </summary>
        public string FileData { get; set; }


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
        /// Get or Set value of Class Type
        /// </summary>
        public string ClassType { get; set; }


        /// <summary>
        /// Get or Set value of is Generated
        /// </summary>
        public Boolean isGenerated { get; set; }

        /// <summary>
        /// Get or Set value of Table Name
        /// </summary>
        public string TableName { get; set; }





        /// <summary> 
        /// Add New Record but first fill the properties. and Id should be 0 
        /// </summary> 
        /// <returns></returns> 
        public clsActionStatus Insert()
        {
            clsActionStatus clsActionStatus = new clsActionStatus();

            try
            {
                this.myTablesFields = "ProjectId,FolderId,FolderName,FNameSpace,SaveAs,FullPath,FileData,UserId,isActive,CreatedOnUtc," +
                                      "UpdatedOnUtc,ClassType,isGenerated,TableName";
                this.myTablesFieldsValues = "@ProjectId,@FolderId,@FolderName,@FNameSpace,@SaveAs,@FullPath,@FileData,@UserId,@isActive,getDate()," +
                                            "getDate(),@ClassType,@isGenerated,@TableName";
                this.myWhere = " ProjectId = @ProjectId and FolderName=@FolderName and SaveAs=@SaveAs and ClassType=@ClassType  ";
                this.mySqlQuery = this.getInsertQuery(this.myTableName, this.myTablesFields, this.myTablesFieldsValues, this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@ProjectId", SqlDbType.Int).Value = this.ProjectId;
                myPara.Add("@FolderId", SqlDbType.Int).Value = this.FolderId;
                myPara.Add("@FolderName", SqlDbType.NVarChar).Value = this.FolderName;
                myPara.Add("@FNameSpace", SqlDbType.NVarChar).Value = this.FNameSpace;
                myPara.Add("@SaveAs", SqlDbType.NVarChar).Value = this.SaveAs;
                myPara.Add("@FullPath", SqlDbType.NVarChar).Value = this.FullPath;
                myPara.Add("@FileData", SqlDbType.NVarChar).Value = this.FileData;
                myPara.Add("@UserId", SqlDbType.Int).Value = this.UserId;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive;
                myPara.Add("@ClassType", SqlDbType.NVarChar).Value = this.ClassType;
                myPara.Add("@isGenerated", SqlDbType.Bit).Value = this.isGenerated;
                myPara.Add("@TableName", SqlDbType.NVarChar).Value = this.TableName; 

                

                ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Created successfully!. and New Id is : " + ReturnIdentity;
                clsActionStatus.Return_Id = ReturnIdentity;
            }
            catch (SqlException ex)
            {
                
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Insert", "ProjectFiles", ex.ErrorCode.ToString(), ex.Message);
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
                this.myUpdateFieldsandValues = "ProjectId=@ProjectId,FolderId=@FolderId,FolderName=@FolderName,FNameSpace=@FNameSpace,SaveAs=@SaveAs,FullPath=@FullPath,FileData=@FileData,UserId=@UserId,isActive=@isActive,UpdatedOnUtc=getDate(),ClassType=@ClassType,isGenerated=@isGenerated,TableName=@TableName"; 
                this.mySqlQuery = this.getUpdateQuery(this.myTableName, this.myUpdateFieldsandValues, this.myWhere);
                this.mySqlCommand = new SqlCommand(this.mySqlQuery, this.getSQLConnection());
                var myPara = this.mySqlCommand.Parameters;

                myPara.Add("@ProjectId", SqlDbType.Int).Value = this.ProjectId;
                myPara.Add("@FolderId", SqlDbType.Int).Value = this.FolderId;
                myPara.Add("@FolderName", SqlDbType.NVarChar).Value = this.FolderName;
                myPara.Add("@FNameSpace", SqlDbType.NVarChar).Value = this.FNameSpace;
                myPara.Add("@SaveAs", SqlDbType.NVarChar).Value = this.SaveAs;
                myPara.Add("@FullPath", SqlDbType.NVarChar).Value = this.FullPath;
                myPara.Add("@FileData", SqlDbType.NVarChar).Value = this.FileData;
                myPara.Add("@UserId", SqlDbType.Int).Value = this.UserId;
                myPara.Add("@isActive", SqlDbType.Bit).Value = this.isActive;
                myPara.Add("@ClassType", SqlDbType.NVarChar).Value = this.ClassType;
                myPara.Add("@isGenerated", SqlDbType.Bit).Value = this.isGenerated;
                myPara.Add("@TableName", SqlDbType.NVarChar).Value = this.TableName; 

                this.mySqlCommand.ExecuteNonQuery();
                clsActionStatus.is_Error = false;
                clsActionStatus.Action_SuccessStatus = "Record Updated successfully!";
                clsActionStatus.Return_Id = this.ID.ToString();
            }
            catch (SqlException ex)
            {
                clsActionStatus.is_Error = true;
                clsActionStatus.Action_FailureStatus = this.Error_Description("Update", "ProjectFiles", ex.ErrorCode.ToString(), ex.Message);
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
                clsActionStatus.Action_FailureStatus = this.Error_Description("Change Status", "ProjectFiles", ex.ErrorCode.ToString(), ex.Message);
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
                clsActionStatus.Action_FailureStatus = this.Error_Description("Delete", "ProjectFiles", ex.ErrorCode.ToString(), ex.Message);
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

        public DataTable getInfo(string FileName , string TableName)
        {
            try
            {
                this.myWhere = " SaveAs like '" + FileName + "' And TableName like '" + TableName + "'";
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

        public DataTable getProjectBusinessEntity_TableName(int BusinessEntity_ProjectID , string TableName , string ClassType)
        {
            this.mySqlQuery = " Select PF.* " + Environment.NewLine +
                              " From " + Environment.NewLine +
                              " Projects P " + Environment.NewLine +
                              " Inner Join " + Environment.NewLine +
                              " ProjectFiles PF On PF.ProjectId = P.ID and PF.TableName like '" + TableName + "' " + Environment.NewLine +
                              " Where PF.ClassType like '" + ClassType + "' and P.ID=" + BusinessEntity_ProjectID ;

            return this.getAllRecords_CustomizeQuery_DataTable(this.mySqlQuery);
        }


    }
}