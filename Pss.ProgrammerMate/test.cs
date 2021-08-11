using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using VConnect247.DAL.Base;
using Vconnect247.BusinessEntity.Model.Feed;
using VConnect247.DAL.Base.MsSql;
using System.Data.SqlClient;
namespace VConnect247.DAL.Model.Feed
{
    public class MethodologyDAL
    {
        ActionStatus return_ActionStatus = new ActionStatus();
        dbFunctions dbFunctions = new dbFunctions();
        string ReturnIdentity = "-1";
        SqlCommand mySqlCommand;

        public ActionStatus Insert(Methodology Methodology)
        {
            try
            {
                this.mySqlCommand = new SqlCommand("sp_Methodology_Insert", dbFunctions.OpenConnection());
                var commandParameters = mySqlCommand.Parameters;

                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();
                return_ActionStatus.is_Error = false;
                return_ActionStatus.Message = "Record Insert successfully. and New Id is : " + ReturnIdentity;
                return_ActionStatus.Return_Id = ReturnIdentity;
            }
            catch (SqlException ex)
            {
                return_ActionStatus.is_Error = true;
                return_ActionStatus.Message = "Record not {ActionName} because " + ex.Message;
            }
            finally
            {
                this.mySqlCommand.Dispose();
                dbFunctions.CloseConnection();
            }
            return return_ActionStatus;
        }
        public ActionStatus Update(Methodology Methodology)
        {
            try
            {
                this.mySqlCommand = new SqlCommand("sp_Methodology_Update", dbFunctions.OpenConnection());
                var commandParameters = mySqlCommand.Parameters;

                commandParameters.Add("@org_ID", SqlDbType.Int).Value = Methodology.ID;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_ID", SqlDbType.Int).Value = Methodology.ID;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_ID", SqlDbType.Int).Value = Methodology.ID;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_ID", SqlDbType.Int).Value = Methodology.ID;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_ID", SqlDbType.Int).Value = Methodology.ID;
                commandParameters.Add("@Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();
                return_ActionStatus.is_Error = false;
                return_ActionStatus.Message = "Record Update successfully. and New Id is : " + ReturnIdentity;
                return_ActionStatus.Return_Id = ReturnIdentity;
            }
            catch (SqlException ex)
            {
                return_ActionStatus.is_Error = true;
                return_ActionStatus.Message = "Record not {ActionName} because " + ex.Message;
            }
            finally
            {
                this.mySqlCommand.Dispose();
                dbFunctions.CloseConnection();
            }
            return return_ActionStatus;
        }
        public ActionStatus Delete(Methodology Methodology)
        {
            try
            {
                this.mySqlCommand = new SqlCommand("sp_Methodology_Delete", dbFunctions.OpenConnection());
                var commandParameters = mySqlCommand.Parameters;

                commandParameters.Add("@org_Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@org_PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@org_UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@org_isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@org_CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@org_UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@org_PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@org_UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@org_isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@org_CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@org_UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@org_PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@org_UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@org_isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@org_CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@org_UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@org_PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@org_UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@org_isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@org_CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@org_UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                commandParameters.Add("@org_Name", SqlDbType.NVarChar).Value = Methodology.Name;
                commandParameters.Add("@org_PDescription", SqlDbType.NVarChar).Value = Methodology.PDescription;
                commandParameters.Add("@org_UserId", SqlDbType.Int).Value = Methodology.UserId;
                commandParameters.Add("@org_isActive", SqlDbType.Bit).Value = Methodology.isActive;
                commandParameters.Add("@org_CreatedOnUtc", SqlDbType.DateTime).Value = Methodology.CreatedOnUtc;
                commandParameters.Add("@org_UpdatedOnUtc", SqlDbType.DateTime).Value = Methodology.UpdatedOnUtc;
                ReturnIdentity = this.mySqlCommand.ExecuteScalar().ToString();
                return_ActionStatus.is_Error = false;
                return_ActionStatus.Message = "Record Delete successfully. and New Id is : " + ReturnIdentity;
                return_ActionStatus.Return_Id = ReturnIdentity;
            }
            catch (SqlException ex)
            {
                return_ActionStatus.is_Error = true;
                return_ActionStatus.Message = "Record not {ActionName} because " + ex.Message;
            }
            finally
            {
                this.mySqlCommand.Dispose();
                dbFunctions.CloseConnection();
            }
            return return_ActionStatus;
        }
    }
}