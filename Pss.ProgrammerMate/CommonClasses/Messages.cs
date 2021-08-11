using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pss.ProgrammerMate.CommonClasses
{
    public static class Messages
    {
        public static DialogResult myAddMore(string ModuleName)
        {
            try
            {
                return MessageBox.Show("Do you Add more " + ModuleName + "?", ModuleName + " Add More", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult myDeleteMsgBox(string ModuleName, string Id)
        {
            try
            {
                return MessageBox.Show("Do you realy want to delete \" " + ModuleName + " \" with ID = " + Id + " ?", ModuleName + " Deletion Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult myGeneralAskMsgBox(string AskQuestion, string ModuleName)
        {
            try
            {
                return MessageBox.Show("Do you realy want to \" " + AskQuestion + " \" ?", ModuleName + " Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult myCancelMsgBox(string ModuleName)
        {
            try
            {
                return MessageBox.Show("Do you ready want to cancel current action?", ModuleName + " Cancelation Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult GeneralError(string Error, string ModuleName)
        {
            try
            {
                return MessageBox.Show(Error, "Error:" + ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult Edit_New_error(string ModuleName)
        {
            try
            {
                return MessageBox.Show("Please new or edit to create or edit record.", "Error:" + ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult SuccessMessage(string Message, string ModuleName)
        {
            try
            {
                return MessageBox.Show(Message, "Updated:" + ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult DeletionMessage(string Message, string ModuleName)
        {
            try
            {
                return MessageBox.Show(Message, "Delete:" + ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                return DialogResult.Cancel;
            }
        }


        #region " Numeric"
        public static string Numeric_Allowed = "Only numeric value allowed!";
        #endregion
    }
}
