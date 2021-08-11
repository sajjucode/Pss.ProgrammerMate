using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pss.ProgrammerMate.UI.UIGenerator
{
    public class WinFormGenerator
    {

        public static string GeneratorFormClass(string SolutionDBID, DataGridView TableColumns, string TableName, string BusinessEntityClass, string DAClass, string UINamespace, string FormName, string MethodKeyName, string ModuleName)
        {
            try
            {
                String ClassHeaderReferences = "using System;" + Environment.NewLine +
                                               "using System.Collections.Generic;" + Environment.NewLine +
                                               "using System.ComponentModel;" + Environment.NewLine +
                                               "using System.Data;" + Environment.NewLine +
                                               "using System.Drawing;" + Environment.NewLine +
                                               "using System.Linq;" + Environment.NewLine +
                                               "using System.Text;" + Environment.NewLine +
                                               "using System.Threading.Tasks;" + Environment.NewLine +
                                               "using System.Windows.Forms;";
                try
                {


                    foreach (DataRow myRow in new ProjectFilesDAL().getInfo(BusinessEntityClass, TableName).Rows)
                    {
                        ClassHeaderReferences = ClassHeaderReferences + Environment.NewLine +
                                                "using " + myRow["FNameSpace"].ToString() + ";";
                    }
                }
                catch (Exception ex)
                {

                    Messages.GeneralError(ex.Message, "Business Entity Namespace");
                }

                try
                {


                    foreach (DataRow myRow in new ProjectFilesDAL().getInfo(DAClass, TableName).Rows)
                    {
                        ClassHeaderReferences = ClassHeaderReferences + Environment.NewLine +
                                                "using " + myRow["FNameSpace"].ToString() + ";";
                    }
                }
                catch (Exception ex)
                {

                    Messages.GeneralError(ex.Message, "Business Entity Namespace");
                }


                string BindingSourceName = MethodKeyName + "BindingSource";
                String BindingParameters = string.Empty;

                BusinessEntityClass = BusinessEntityClass.Replace(".cs", "");
                DAClass = DAClass.Replace(".cs", "");
                string Return_GeneratedClass = string.Empty;

                DataTable myQueryColumns_DataTable = getSelectTable_QueryColumns(SolutionDBID, TableName);
                if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count <= 0)
                {
                    Messages.GeneralError("No column exists for Table " + TableColumns, "Table Columns");
                }

                string PublicVariables = "private Boolean isMapped_" + MethodKeyName + ", isSearch_" + MethodKeyName + ";" + Environment.NewLine +
                                         " int TotalRecords_" + MethodKeyName + "  = 1000000;" + Environment.NewLine +
                                         " int PageSize_" + MethodKeyName + "  = 1000000;" + Environment.NewLine +
                                         " int PageNo_" + MethodKeyName + "  = 1;" + Environment.NewLine +
                                         " String mySqlQuery = string.Empty;" + Environment.NewLine +
                                         "ActionStatus ActionStatus_" + MethodKeyName + " = new ActionStatus();" + Environment.NewLine +
                                          DAClass + " " + DAClass + " = new " + DAClass + "();" + Environment.NewLine +
                                          BusinessEntityClass + " " + BusinessEntityClass + " = new " + BusinessEntityClass + "();" + Environment.NewLine +
                                         "DataRowView myRow_" + MethodKeyName + ";" + Environment.NewLine;

               

                string PictureBoxAssigning = "if (this.{ColumnName}OpenFileDialog.FileName != null && this.{ColumnName}OpenFileDialog.FileName != string.Empty && System.IO.File.Exists(this.{ColumnName}OpenFileDialog.FileName)) " + Environment.NewLine +
                                             "   { " + Environment.NewLine +
                                             " " + Environment.NewLine +
                                             "       byte[] {ColumnName}Image; " + Environment.NewLine +
                                             "       {ColumnName}Image = System.IO.File.ReadAllBytes(this.{ColumnName}OpenFileDialog.FileName); " + Environment.NewLine +
                                             "       this.myRow_" + MethodKeyName + "[\"{ColumnName}\"] = {BusinessEntity}.{ColumnName} = {ColumnName}Image; " + Environment.NewLine +
                                             " " + Environment.NewLine +
                                             "   } " + Environment.NewLine +
                                             "   else " + Environment.NewLine +
                                             "   { " + Environment.NewLine +
                                             "       this.myRow_" + MethodKeyName + "[\"{ColumnName}\"] = {BusinessEntity}.{ColumnName} = null; " + Environment.NewLine +
                                             "   }";

                #region "Update"

                string UpdateParameters = string.Empty;
                string IDColumn = string.Empty;
                string IDTextBox = string.Empty;


                if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count > 0)
                {
                    UpdateParameters = "this." + BusinessEntityClass + " = new " + BusinessEntityClass + "();" + Environment.NewLine;

                    foreach (DataGridViewRow myGridRow in TableColumns.Rows)
                    {
                        if (myGridRow.Cells["clmName"].Value.ToString().ToLower() == "id")
                        {
                            IDColumn = myGridRow.Cells["clmName"].Value.ToString();
                            IDTextBox = myGridRow.Cells["clmControlName"].Value.ToString();
                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text == CommonVariables.New_IntialValue ? 0 : int.Parse(this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text);" + Environment.NewLine;

                            BindingParameters = BindingParameters + Environment.NewLine + "this." + IDTextBox + ".DataBindings.Add(\"Text\", this." + BindingSourceName + " , \"" + IDColumn + "\", false, DataSourceUpdateMode.Never, \"new\");";
                        }
                        else
                        {
                            foreach (DataRow myRow_Columns in myQueryColumns_DataTable.Select("(QueryName like '%Insert') and TableName like '" + TableName + "' and ColumnName like '" + myGridRow.Cells["clmName"].Value + "'"))
                            {



                                switch (myGridRow.Cells["clmControl"].Value.ToString().ToLower())
                                {
                                    case "datetimepicker":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Value;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Value\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "ssdatetime":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Value;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Value\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "checkbox":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Checked;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Checked\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "sscheckbox":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Checked;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Checked\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "sscombobox":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".SelectedValue.ToString();" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"SelectedValue\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;

                                    #region "git Controls"
                                    case "gitdatetimepicker":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Value;" + Environment.NewLine;
                                        }
                                        else
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Value;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Value\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "gitradiobutton":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Checked;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Checked\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "gitcheckbox":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Checked;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Checked\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "gitcombobox":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".SelectedValue.ToString();" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"SelectedValue\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "gittextbox":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            switch (myRow_Columns["ColumnType"].ToString ().ToLower ())
                                            {
                                                case "int":
                                                    UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = Conversion.ConvertToInt(this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text);" + Environment.NewLine;
                                                    break;
                                                case "bigint":
                                                    UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = Conversion.ConvertToInt64(this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text);" + Environment.NewLine;
                                                    break;
                                                case "decimal":
                                                    UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " =Conversion.ConvertToDecimal( this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text);" + Environment.NewLine;
                                                    break;
                                                default:
                                                    UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text;" + Environment.NewLine;
                                                    break;

                                            }
                                            //UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Text\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    case "gitdatetimemask":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".value;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"value\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    #endregion
                                    case "picturebox":
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            //UpdateParameters = UpdateParameters + PictureBoxAssigning.Replace("{ColumnName}", myGridRow.Cells["clmName"].Value.ToString()).Replace("{BusinessEntity}", BusinessEntityClass) + Environment.NewLine;
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = CommonVariables.ImageToByteArray(this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Image);" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Image\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", true);";
                                        break;
                                    default:
                                        if (myRow_Columns["ParameterName"].ToString().ToLower() != "default")
                                        {
                                            UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text;" + Environment.NewLine;
                                        }
                                        BindingParameters = BindingParameters + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".DataBindings.Add(\"Text\", this." + BindingSourceName + " , \"" + myGridRow.Cells["clmName"].Value.ToString() + "\", false);";
                                        break;
                                }

                                //if (myRow_Columns)

                                //    UpdateParameters = UpdateParameters + "this.myRow_Member[\"ID\"] = MemberHeadDAL.ID = this.txtID.Text == CommonVariables.New_IntialValue ? 0 : int.Parse(this.txtID.Text);" + Environment.NewLine;
                                // UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text;" + Environment.NewLine;
                            }
                        }
                    }
                }

                String UpdateMethod = "void Update_" + MethodKeyName +  "()" + Environment.NewLine +
                                      "{ " + Environment.NewLine +
                                     "  try  " + Environment.NewLine +
                                     "  { " + Environment.NewLine + Environment.NewLine +
                                     "       this.myRow_" + MethodKeyName + " = (DataRowView)this." + BindingSourceName + ".Current; " + Environment.NewLine + Environment.NewLine +
                                     "       " + UpdateParameters + " " + Environment.NewLine +
                                     "       if (this." + BusinessEntityClass + "." + IDColumn + " > 0) " + Environment.NewLine +
                                     "       {" + Environment.NewLine +
                                     "           ActionStatus_" + MethodKeyName + " = this." + DAClass + ".Update(this." + BusinessEntityClass +");" + Environment.NewLine +
                                     "       }" + Environment.NewLine +
                                     "       else" + Environment.NewLine +
                                     "       {" + Environment.NewLine +
                                     "           ActionStatus_" + MethodKeyName + " = this." + DAClass + ".Insert(this." + BusinessEntityClass + ");" + Environment.NewLine +
                                     "       }" + Environment.NewLine +
                                     " if (ActionStatus_" + MethodKeyName +".is_Error == false)" + Environment.NewLine +
                                     "  {" + Environment.NewLine +
                                     "       this." + BindingSourceName + ".EndEdit();" + Environment.NewLine +
                                     " " + Environment.NewLine +                                     
                                     " " + Environment.NewLine +
                                     "       if (this." + BusinessEntityClass +".ID <= 0) " + Environment.NewLine +
                                     "       { " + Environment.NewLine +
                                     "       this." + IDTextBox + ".Text = ActionStatus_" + MethodKeyName + ".Return_Id;" + Environment.NewLine +
                                     "           myRow_" + MethodKeyName + "[\"" + IDColumn + "\"] = this." + IDTextBox +".Text = this.ActionStatus_" + MethodKeyName +".Return_Id; " + Environment.NewLine +
                                     "          if (Messages.SuccessMessageWithAddMore(ActionStatus_" + MethodKeyName + ".Message + \" Do you want add more?\",\"" + MethodKeyName + " \")== System.Windows.Forms.DialogResult.Yes) " + Environment.NewLine +
                                     "           { " + Environment.NewLine +
                                     "               this.New_" + MethodKeyName + "(); " + Environment.NewLine +
                                     "           } " + Environment.NewLine +
                                     //"           Messages.SuccessMessage(ActionStatus_" + MethodKeyName + ".Message, \"" + MethodKeyName + "\"); " + Environment.NewLine +
                                     "       } " + Environment.NewLine +
                                     "       else " + Environment.NewLine +
                                     "       { " + Environment.NewLine +
                                     "           Messages.SuccessMessage(ActionStatus_" + MethodKeyName + ".Message, \"" + MethodKeyName + "\"); " + Environment.NewLine +
                                     "       } " + Environment.NewLine +
                                     "   } " + Environment.NewLine +
                                     "   else " + Environment.NewLine +
                                     "   { " + Environment.NewLine +
                                     "       Messages.GeneralError(ActionStatus_" + MethodKeyName + ".Message, \"" + MethodKeyName + "\"); " + Environment.NewLine +
                                     "   } " + Environment.NewLine +
                                     "   } " + Environment.NewLine + Environment.NewLine +
                                     "   catch (Exception ex) " + Environment.NewLine +
                                     "   { " + Environment.NewLine +
                                     "       Messages.GeneralError(ex.Message, \"" + ModuleName + " ->Update \"); " + Environment.NewLine +
                                     "   } " + Environment.NewLine +
                                    "}";

                #endregion

                #region "New"
                string NewMethod = "void New_" + MethodKeyName + "()" + Environment.NewLine +
                                   "{ " + Environment.NewLine +
                                    "  try  " + Environment.NewLine +
                                    "  { " + Environment.NewLine +
                                    "       this.myRow_" + MethodKeyName + " = (DataRowView)this." + BindingSourceName + ".AddNew(); " + Environment.NewLine +
                                    "       new SetFocusBlur_Color().ClearAllControl(this); " + Environment.NewLine +
                                    "       this." + IDTextBox +".Text = CommonVariables.New_IntialValue; " + Environment.NewLine +
                                    "   } " + Environment.NewLine +
                                    "   catch (Exception ex) " + Environment.NewLine +
                                    "   { " + Environment.NewLine +
                                    "       Messages.GeneralError(ex.Message, \"" + ModuleName + " \"); " + Environment.NewLine +
                                    "   } " + Environment.NewLine +
                                   "}";
                #endregion

                #region "Cancel"
                String CancelMethod = " void Cancel_" + MethodKeyName + "()  " + Environment.NewLine +
                                     "   {  " + Environment.NewLine +
                                     "       try  " + Environment.NewLine +
                                     "       {  " + Environment.NewLine +
                                     "           if (Messages.myCancelMsgBox(\"" + MethodKeyName + "\") == System.Windows.Forms.DialogResult.Yes)  " + Environment.NewLine +
                                     "           {  " + Environment.NewLine +
                                     "   " + Environment.NewLine +
                                     "               this." + BindingSourceName + ".CancelEdit();  " + Environment.NewLine +
                                     "           }   " + Environment.NewLine +
                                     "       }   " + Environment.NewLine +
                                     "       catch (Exception ex)   " + Environment.NewLine +
                                     "       {   " + Environment.NewLine +
                                     "           Messages.GeneralError(ex.Message, \" " + MethodKeyName + "\");   " + Environment.NewLine +
                                     "       }   " + Environment.NewLine +
                                     "   }";
                #endregion

                #region "Delete"
                string DeleteMethod = "void Delete_" + MethodKeyName + "() " + Environment.NewLine +
                                      "  { " + Environment.NewLine +
                                      "      try " + Environment.NewLine +
                                      "      { " + Environment.NewLine +
                                      "          if (Messages.myDeleteMsgBox(\"" + MethodKeyName + "\", this." + IDTextBox + ".Text) == System.Windows.Forms.DialogResult.Yes)  " + Environment.NewLine +
                                      "          {  " + Environment.NewLine +
                                      "              ActionStatus_" + MethodKeyName + " = new ActionStatus();  " + Environment.NewLine +
                                      "  " + Environment.NewLine +
                                      "              " + BusinessEntityClass + ".ID = int.Parse(this." + IDTextBox + ".Text);  " + Environment.NewLine +
                                      "  " + Environment.NewLine +
                                      "              ActionStatus_" + MethodKeyName + " = " + DAClass + ".Delete(this." + BusinessEntityClass + ");  " + Environment.NewLine +
                                      "  " + Environment.NewLine +
                                      "              if (ActionStatus_" + MethodKeyName + ".is_Error == false)  " + Environment.NewLine +
                                      "              {  " + Environment.NewLine +
                                      "                  Messages.DeletionMessage(ActionStatus_" + MethodKeyName + ".Message, \"" + MethodKeyName + "\");  " + Environment.NewLine +
                                      "  " + Environment.NewLine +
                                      "                  this." + BindingSourceName + ".RemoveCurrent();  " + Environment.NewLine +
                                      "  " + Environment.NewLine +
                                      "              }  " + Environment.NewLine +
                                      "              else  " + Environment.NewLine +
                                      "              {  " + Environment.NewLine +
                                      "                  Messages.DeletionMessage(ActionStatus_" + MethodKeyName + ".Message, \"" + MethodKeyName + "\");  " + Environment.NewLine +
                                      "              }  " + Environment.NewLine +
                                      "  " + Environment.NewLine +
                                      "  " + Environment.NewLine +
                                      "          }  " + Environment.NewLine +
                                      "      }  " + Environment.NewLine +
                                      "      catch (Exception ex)  " + Environment.NewLine +
                                      "      {  " + Environment.NewLine +
                                      "          Messages.GeneralError(ex.Message, \"" + MethodKeyName + " ->Deletion \");  " + Environment.NewLine +
                                      "      }  " + Environment.NewLine +
                                      "  }" + Environment.NewLine;
                #endregion

                #region "Binding"

                string BindingMethod = " void Binding_" + MethodKeyName + "() " + Environment.NewLine +
                                       " { " + Environment.NewLine +
                                       "     try " + Environment.NewLine +
                                       "     { " + Environment.NewLine +
                                       "        " + BindingParameters + " " + Environment.NewLine +
                                       " }" + Environment.NewLine +
                                       " catch (Exception ex)" + Environment.NewLine +
                                       " { " + Environment.NewLine +
                                       "     Messages.GeneralError(ex.Message, \"" + MethodKeyName + " => Binding\");" + Environment.NewLine +
                                       " }" + Environment.NewLine +
                                       "}";

                #endregion

                #region "View All"
                string ViewAllMethod = "public void ViewAll_" + MethodKeyName + "(Boolean isSearch = false, string SearchText = \"\", Boolean isSearchById = false) " + Environment.NewLine +
                                        "{ " + Environment.NewLine +
                                        "    try " + Environment.NewLine +
                                        "    { " + Environment.NewLine +
                                        "        DataTable myDataTable_" + MethodKeyName + " = new DataTable();" + Environment.NewLine +
                                        "  " + Environment.NewLine +
                                        "        if (isSearchById == true)  " + Environment.NewLine +
                                        "        { " + Environment.NewLine +
                                        "            myDataTable_" + MethodKeyName + " = new " + DAClass + "().getList_Search(PageSize_" + MethodKeyName + ", PageNo_" + MethodKeyName + ", \" ( ID =\" + SearchText + \" )\", \"ID\", \"asc\"); " + Environment.NewLine +
                                        "        } " + Environment.NewLine +
                                        "        else  " + Environment.NewLine +
                                        "        {  " + Environment.NewLine +
                                        "            myDataTable_" + MethodKeyName + " = new " + DAClass + "().getList_Search(PageSize_" + MethodKeyName + ", PageNo_" + MethodKeyName + ", \" ( 1=1 )\", \"ID\", \"asc\"); " + Environment.NewLine +
                                        "        }   " + Environment.NewLine +
                                        "        this." + BindingSourceName + ".DataSource = myDataTable_" + MethodKeyName + " ;   " + Environment.NewLine +
                                        "     " + Environment.NewLine +
                                        "        if (this.isMapped_" + MethodKeyName + " == false)   " + Environment.NewLine +
                                        "        {   " + Environment.NewLine +
                                        "   " + Environment.NewLine +
                                        "            this.Binding_" + MethodKeyName + "();   " + Environment.NewLine +
                                        "            this.isMapped_" + MethodKeyName + " = true;   " + Environment.NewLine +
                                        "   " + Environment.NewLine +
                                        "        }   " + Environment.NewLine +
                                        "    }   " + Environment.NewLine +
                                        "    catch (Exception ex)   " + Environment.NewLine +
                                        "    {   " + Environment.NewLine +
                                        "   " + Environment.NewLine +
                                        "        Messages.GeneralError(ex.Message, \"" + MethodKeyName + " -> View All\");   " + Environment.NewLine +
                                        "    }    " + Environment.NewLine +
                                        "}";
                #endregion

                BindingParameters.ToString();

                Return_GeneratedClass = ClassHeaderReferences + Environment.NewLine +
                                        "namespace " + UINamespace + Environment.NewLine +
                                        "{" + Environment.NewLine +
                                        "public partial class " + FormName + " : Form  " + Environment.NewLine +
                                        "    { " + Environment.NewLine +
                                        "           " + Environment.NewLine +
                                        "            #region \"" + MethodKeyName + " \" " + Environment.NewLine +
                                        "       " + PublicVariables + Environment.NewLine +
                                        "       " + NewMethod + " " + Environment.NewLine +
                                        "       " + UpdateMethod + " " + Environment.NewLine +
                                        "       " + CancelMethod + " " + Environment.NewLine +
                                        "       " + DeleteMethod + " " + Environment.NewLine +
                                        "       " + BindingMethod + " " + Environment.NewLine +
                                        "       " + ViewAllMethod + " " + Environment.NewLine +
                                        "           #endregion " + Environment.NewLine +
                                        "        public " + FormName + "()  " + Environment.NewLine +
                                        "        {  " + Environment.NewLine +
                                        "            InitializeComponent(); " + Environment.NewLine +
                                        "        }   " + Environment.NewLine +
                                        "        private void Form1_Load(object sender, EventArgs e) " + Environment.NewLine +
                                        "        {              " + Environment.NewLine +
                                        "        }  " + Environment.NewLine +
                                        "    }" + Environment.NewLine +
                                        "} " + Environment.NewLine;
                                        



                UpdateMethod.ToString();

                return Return_GeneratedClass;
            }
            catch (Exception ex)
            {

                return null;
            }

        }


        public static string GeneratorFormDesignerClass(string SolutionDBID, DataGridView TableColumns, string TableName, string BusinessEntityClass, string DAClass, string UINamespace, string FormName, string MethodKeyName, string ModuleName)
        {
            try
            {

                string BindingSourceName = MethodKeyName + "BindingSource";
                String BindingSourceDeclaration = "private System.Windows.Forms.BindingSource " + BindingSourceName + ";";
                String BindingSourceInitlizer = "this." + BindingSourceName + "  = new System.Windows.Forms.BindingSource();";

                BusinessEntityClass = BusinessEntityClass.Replace(".cs", "");
                DAClass = DAClass.Replace(".cs", "");
                string Return_GeneratedClass = string.Empty;

                DataTable myQueryColumns_DataTable = getSelectTable_QueryColumns(SolutionDBID, TableName);
                if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count <= 0)
                {
                    Messages.GeneralError("No column exists for Table " + TableColumns, "Table Columns");
                }

                string PublicVariables_Header = "/// <summary> " + Environment.NewLine +
                                                "/// Required designer variable. " + Environment.NewLine +
                                                "/// </summary> " + Environment.NewLine +
                                                "private System.ComponentModel.IContainer components = null; " + Environment.NewLine + Environment.NewLine;

                string Dispose = "/// <summary>" + Environment.NewLine +
                                 "/// Clean up any resources being used." + Environment.NewLine +
                                 "/// </summary>" + Environment.NewLine +
                                 "/// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param> " + Environment.NewLine +
                                 "   protected override void Dispose(bool disposing) " + Environment.NewLine +
                                 "   { " + Environment.NewLine +
                                 "       if (disposing && (components != null)) " + Environment.NewLine +
                                 "       { " + Environment.NewLine +
                                 "           components.Dispose(); " + Environment.NewLine +
                                 "       } " + Environment.NewLine +
                                 "       base.Dispose(disposing); " + Environment.NewLine +
                                 "   }";

                string ControlInitilizer = string.Empty;
                string Control_Proerties = string.Empty;
                string ControlLabelInitilizer = string.Empty;
                string ControlLabel_Properties = string.Empty;
                string ControlDeclaration = string.Empty;
                string AddControlsInForm = string.Empty;

                int Location_X = 10, Location_Y = 10;


                string UpdateParameters = string.Empty;
                string IDColumn = string.Empty;
                string IDTextBox = string.Empty;
                int ControlNo = 0;


                if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count > 0)
                {

                    foreach (DataGridViewRow myGridRow in TableColumns.Rows)
                    {
                        ControlNo++;

                        if (ControlNo % 3 == 0)
                        {
                            Location_X = 10;
                            Location_Y = Location_Y + 20;
                        }

                        ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label  = new System.Windows.Forms.Label();";
                        AddControlsInForm = AddControlsInForm + Environment.NewLine + "this.Controls.Add (this." + myGridRow.Cells["clmName"].Value.ToString() + "Label" + ");";
                        AddControlsInForm = AddControlsInForm + Environment.NewLine + "this.Controls.Add (this." + myGridRow.Cells["clmControlName"].Value.ToString() +  ");";

                        switch (myGridRow.Cells["clmControl"].Value.ToString().ToLower())
                        {
                            case "datetimepicker":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new DateTimePicker();";

                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private DateTimePicker " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";

                                Location_X = Location_X + 150;

                                break;
                            case "ssdatetime":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new SS.Controls.ssDateTimePicker();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private Controls.ssDateTimePicker " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";


                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            #region "SS Controls"
                            case "sscombobox":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new SS.Controls.ssComboBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private Controls.ssComboBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";


                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            case "checkbox":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new CheckBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private CheckBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            case "sscheckbox":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new SS.Controls.ssCheckBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private Controls.ssCheckBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            case "picturebox":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new System.Windows.Forms.PictureBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private System.Windows.Forms.PictureBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            #endregion
                            #region "GIT Controls"
                            case "gitdatetimepicker":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new GIT.Winform.Controls.gitDateTimePicker();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private GIT.Winform.Controls.gitDateTimePicker " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";


                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            case "gitcombobox":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new GIT.Winform.Controls.gitComboBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private GIT.Winform.Controls.gitComboBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";


                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            case "gitradiobutton":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new GIT.Winform.Controls.gitRadioButton();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private CheckBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private GIT.Winform.Controls.gitRadioButton " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            case "gitcheckbox":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new GIT.Winform.Controls.gitCheckBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private GIT.Winform.Controls.gitCheckBox  " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;                           
                            case "gitdatetimemask":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new GIT.Winform.Controls.gitDateTimeMask();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private GIT.Winform.Controls.gitDateTimeMask " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            case "gittextbox":
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new GIT.Winform.Controls.gitTextBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private GIT.Winform.Controls.gitTextBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                            #endregion
                            default:
                                ControlDeclaration = ControlDeclaration + Environment.NewLine + "this." + myGridRow.Cells["clmControlName"].Value.ToString() + "  = new SS.Controls.ssTextBox();";
                                ControlInitilizer = ControlInitilizer + Environment.NewLine + "private Controls.ssTextBox " + myGridRow.Cells["clmControlName"].Value.ToString() + " ;";
                                ControlLabelInitilizer = ControlLabelInitilizer + Environment.NewLine + "private System.Windows.Forms.Label " + myGridRow.Cells["clmName"].Value.ToString() + "Label ;";

                                ControlLabel_Properties = ControlLabel_Properties + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "// " + myGridRow.Cells["clmName"].Value.ToString() + "Label" + Environment.NewLine +
                                                   "//  " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Name = \"" + myGridRow.Cells["clmName"].Value.ToString() + "Label\";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Size = new System.Drawing.Size(100, 20); " + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.TabIndex = " + ControlNo + 1 + ";" + Environment.NewLine +
                                                   "this." + myGridRow.Cells["clmName"].Value.ToString() + "Label.Text = \"" + myGridRow.Cells["clmName"].Value.ToString() + ":\";" + Environment.NewLine +
                                                   "// ";

                                Location_X = Location_X + 100;

                                Control_Proerties = Control_Proerties + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "// " + myGridRow.Cells["clmControlName"].Value.ToString() + Environment.NewLine +
                                                    "//  " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Location = new System.Drawing.Point(" + Location_X + " , " + Location_Y + " ); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Name = \"" + myGridRow.Cells["clmControlName"].Value.ToString() + "\";" + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Size = new System.Drawing.Size(150, 20); " + Environment.NewLine +
                                                    "this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".TabIndex = " + ControlNo + 2 + ";" + Environment.NewLine +
                                                    "// ";
                                Location_X = Location_X + 150;
                                break;
                        }

                        //if (myRow_Columns)

                        //    UpdateParameters = UpdateParameters + "this.myRow_Member[\"ID\"] = MemberHeadDAL.ID = this.txtID.Text == CommonVariables.New_IntialValue ? 0 : int.Parse(this.txtID.Text);" + Environment.NewLine;
                        // UpdateParameters = UpdateParameters + "this.myRow_" + MethodKeyName + "[\"" + myGridRow.Cells["clmName"].Value.ToString() + "\"] = " + BusinessEntityClass + "." + myGridRow.Cells["clmName"].Value.ToString() + " = this." + myGridRow.Cells["clmControlName"].Value.ToString() + ".Text;" + Environment.NewLine;

                    }
                }



                Return_GeneratedClass = "namespace " + UINamespace + Environment.NewLine +
                                        "{" + Environment.NewLine +
                                        "partial class " + FormName + Environment.NewLine +
                                        "    { " + Environment.NewLine +
                                        "           " + Environment.NewLine +
                                        "   " + PublicVariables_Header + Environment.NewLine +
                                        "   " + Dispose + Environment.NewLine +
                                        "            #region \" Chotu Programmer Form Designer Generated Code \" " + Environment.NewLine +
                                        "/// <summary> " + Environment.NewLine +
                                        "/// Required method for Designer support - do not modify " + Environment.NewLine +
                                        "/// the contents of this method with the code editor. " + Environment.NewLine +
                                        "/// </summary> " + Environment.NewLine +
                                        "private void InitializeComponent() " + Environment.NewLine +
                                        "{ " + Environment.NewLine +
                                        "   this.components = new System.ComponentModel.Container(); " + Environment.NewLine +
                                        " " + ControlDeclaration + " " + Environment.NewLine +
                                        " " + BindingSourceInitlizer + " " + Environment.NewLine +
                                        " " + ControlLabel_Properties + Environment.NewLine +
                                        " " + Control_Proerties + Environment.NewLine +
                                        "    // " + Environment.NewLine +
                                        "   // " + FormName + ";   " + Environment.NewLine +
                                        "   //  " + Environment.NewLine +
                                        "   this.ClientSize = new System.Drawing.Size(1000, 700); " + Environment.NewLine +
                                        "    this.Name = \"" + FormName + "\"; " + Environment.NewLine +
                                        "    this.Text = \"" + MethodKeyName + "\"; " + Environment.NewLine +
                                        "    ((System.ComponentModel.ISupportInitialize)(this." + BindingSourceName + ")).EndInit(); " + Environment.NewLine +
                                        "    this.ResumeLayout(false);  " + Environment.NewLine +
                                        "     " + AddControlsInForm  + " " + Environment.NewLine +
                                        " } " + Environment.NewLine +
                                        " #endregion " + Environment.NewLine +
                                        " " + Environment.NewLine + ControlInitilizer + Environment.NewLine +
                                        " " + Environment.NewLine + ControlLabelInitilizer + Environment.NewLine +
                                        " " + Environment.NewLine + BindingSourceDeclaration + Environment.NewLine +
                                        "} " + Environment.NewLine +
                                        "} ";





                

                return Return_GeneratedClass;
            }
            catch (Exception ex)
            {

                return null;
            }

        }


        static DataTable getSelectTable_QueryColumns(string SolutionDBID, string TableName)
        {
            try
            {
                return new SolutionsDBQueryColumnsDAL().getList_Search(10000, 1, " SolutionsDBID=" + SolutionDBID + " and TableName like '" + TableName + "'", "ID");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
