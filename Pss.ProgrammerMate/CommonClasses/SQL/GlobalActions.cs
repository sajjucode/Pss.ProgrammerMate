using Pss.ProgrammerMate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pss.ProgrammerMate.CommonClasses.SQL
{
    public class GlobalActions
    {
        public static string Author = "Sajjucode";
        public static string ToolName = "Chotu Programmer";
        public static string DateFormat = "dddd, dd MMMM yyyy HH:mm:ss";
        public static string SPHeaderComments(string QueryName, string ActionType)
        {
            return "-- ======================================================" + Environment.NewLine +
                   "-- Name: " + QueryName + Environment.NewLine +
                   "-- Created By: " + ToolName + Environment.NewLine +
                   "-- Author: " + Author + Environment.NewLine +
                   "-- Created At: " + DateTime.Now.ToString(DateFormat) + Environment.NewLine +
                   "-- Updated At: " + DateTime.Now.ToString(DateFormat) + Environment.NewLine +
                   "-- Description : " + ActionType + Environment.NewLine +
                   "-- ======================================================";

        }


        public static string Insert_SolutionsDBQuery(int CurrentDBID, int QueryID, string TableName, string QueryName, string ActionType, string QueryType, string QueryText,string DALMethodName,int ActionID)
        {
            try
            {
                SolutionsDBQueryDAL SolutionsDBQueryDAL = new DAL.SolutionsDBQueryDAL();

                SolutionsDBQueryDAL.ID = QueryID;
                SolutionsDBQueryDAL.SolutionsDBID = CurrentDBID;
                SolutionsDBQueryDAL.TableName = TableName;
                SolutionsDBQueryDAL.QueryName = QueryName;
                SolutionsDBQueryDAL.ActionType = ActionType;
                SolutionsDBQueryDAL.QueryType = QueryType;
                SolutionsDBQueryDAL.QueryText = QueryText;
                SolutionsDBQueryDAL.isActive = true;
                SolutionsDBQueryDAL.UserId = CommonClasses.Security.UserID;

                SolutionsDBQueryDAL.DALMethodName = DALMethodName;
                SolutionsDBQueryDAL.ActionID = ActionID;

                if (SolutionsDBQueryDAL.ID == 0)
                {
                    SolutionsDBQueryDAL.Insert();
                }
                else
                {
                    SolutionsDBQueryDAL.Update();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message; ;
            }
        }
    }
}
