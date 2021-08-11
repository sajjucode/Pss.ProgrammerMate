using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DAL.COMMON
{
    public class clsCommonMethod : IDisposable
    {
        private bool disposed = false;

        //Dispose Resources.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        ~clsCommonMethod()
        {
            Dispose(false);
        }


        public string DateTimeFormat = "MM/dd/yyyy HH:mm:ss";

        #region "Public Variables"
        public Boolean is_Error = false;
        public string Action_SuccessStatus = string.Empty;
        public string Action_FailureStatus = string.Empty;
        #endregion

        #region "Exceptions Messages"

        public string Insert_ActionName = "Insert";
        public string Update_ActionName = "Update";
        public string Delete_ActionName = "Delete";
        public string Edit_ActionName = "Edit";
        public string Search_ActionName = "Search";
        public string List_ActionName = "List";

        public string ErrorDescription(string ModuleName, string ActionName, string ErrorCode, string ErrorMessage)
        {
            return ModuleName + " not " + ActionName + " because " + Environment.NewLine + " Error Code: " + ErrorCode + Environment.NewLine + " Message : " + ErrorMessage;
        }

        #endregion
    }
}
