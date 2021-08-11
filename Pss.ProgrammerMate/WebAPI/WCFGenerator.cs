using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.DAL;
using Pss.ProgrammerMate.UI.UIGenerator;
using System.IO;

namespace Pss.ProgrammerMate.WebAPI
{
    public partial class WCFGenerator : Form
    {
        string CurrentDBType = "";
        int CurrentDBID = 0;

        string CurrentFolderName;
        int CurrentFolderId = 0;

        #region "Solutions and Solution DB"
        void getList_Solutions()
        {
            try
            {

                DataTable myDataTable_Solutions = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");                
                myDataTable_Solutions = new SolutionsDAL().getList(1000, 1, "ID", "asc");


                this.Solutions_bindingSource.DataSource = myDataTable_Solutions;
                //this.bnMain.BindingSource = this.Solutions_bindingSource;

                this.cmbSolutions.DataSource = null;

                this.cmbSolutions.DataSource = this.Solutions_bindingSource;

                this.cmbSolutions.DisplayMember = "SolutionName";
                this.cmbSolutions.ValueMember = "ID";

                this.cmbSolutions.Refresh();
                this.cmbSolutions.Update();

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions");
            }
        }

        void ViewAll_SolutionsDB()
        {
            try
            {
                if (this.cmbSolutions.DataSource == null)
                    return;


                this.cmbSolutionsDB.DataSource = null;
                this.cmbSolutionsDB.Items.Clear();

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                myDataTable_SolutionsDB = new SolutionsDBDAL().getList_Search(1000, 1, " SolutionID =" + this.cmbSolutions.SelectedValue.ToString(), "DBType");

                this.SolutionsDB_bindingSource.DataSource = myDataTable_SolutionsDB;

                this.cmbSolutionsDB.DataSource = this.SolutionsDB_bindingSource;

                if (this.SolutionsDB_bindingSource != null && this.SolutionsDB_bindingSource.Count > 0)
                {
                    this.cmbSolutionsDB.DisplayMember = "DBInfo";
                    this.cmbSolutionsDB.ValueMember = "ID";
                }
                this.cmbSolutionsDB.Refresh();
                this.cmbSolutionsDB.Update();


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Solutions DB");
            }
        }

        //void GetAutoSQLName_SolutionsDB(string TableName)
        //{
        //    try
        //    {
        //        DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

        //        if (myRow != null && myRow["SPFormat"].ToString().Length > 0)
        //        {
        //            this.txtSqlName_Insert.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Insert");
        //            this.txtSqlName_Delete.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Delete");
        //            this.txtSqlName_GetRecord.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "GetList");
        //            this.txtSqlName_Update.Text = myRow["SPFormat"].ToString().Replace("{TableName}", TableName).Replace("{Action}", "Update");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonClasses.Messages.GeneralError(ex.Message, " Format");
        //    }

        //}

        void GetSelectDB_Tables()
        {
            try
            {
                DataTable myDataTable_SolutionsDBTables = new SolutionsDBTablesDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString(), "TableName");

                if (myDataTable_SolutionsDBTables != null)
                {
                    this.SolutionsDBTables_bindingSource.DataSource = myDataTable_SolutionsDBTables;
                }

                if (this.SolutionsDBTables_bindingSource.DataSource != null)
                {
                    this.cmbDBTables.DataSource = this.SolutionsDBTables_bindingSource;
                    this.cmbDBTables.DisplayMember = "TableName";
                    this.cmbDBTables.ValueMember = "ID";
                }

                this.cmbDBTables.Refresh();
                this.cmbDBTables.Update();

                this.GetSelectDB_TableColumns();
            }
            catch (Exception ex)
            {

            }
        }

        Boolean isMapped_TableColumns;
        void GetSelectDB_TableColumns()
        {
            try
            {
                this.getProject_TableEntity();
                DataTable myDataTable_SolutionsDBTableColumns = new SolutionsDBTableColumnsDAL().getList_Search(10000, 1, " SolutionsDBID= " + this.cmbSolutionsDB.SelectedValue.ToString() + " and TableName like '" + this.cmbDBTables.Text + "'", "ID");

                if (myDataTable_SolutionsDBTableColumns != null)
                {
                    this.TableColumns_bindingSource.DataSource = myDataTable_SolutionsDBTableColumns;
                }

                if (isMapped_TableColumns == false)
                {
                    isMapped_TableColumns = true;
                    this.dvgTableColumns.DataSource = this.TableColumns_bindingSource;

                    this.dvgTableColumns.Columns["clmName"].DataPropertyName = "ColumnName";
                    this.dvgTableColumns.Columns["clmType"].DataPropertyName = "ColumnType";
                }
                this.dvgTableColumns.Refresh();
                this.dvgTableColumns.Update();


                foreach (DataGridViewRow myGridRow in this.dvgTableColumns.Rows)
                {
                    switch (myGridRow.Cells["clmType"].Value.ToString().ToLower())
                    {
                        //case "datetime":
                        //    myGridRow.Cells["clmControl"].Value = "ssDateTime";
                        //    myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "ssDateTime";
                        //    break;
                        //case "image":
                        //    myGridRow.Cells["clmControl"].Value = "PictureBox";
                        //    myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "PictureBox";
                        //    break;
                        //case "bit":
                        //    myGridRow.Cells["clmControl"].Value = "ssCheckBox";
                        //    myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "ssCheckBox";
                        //    break;
                        //default:
                        //    myGridRow.Cells["clmControl"].Value = "ssTextBox";
                        //    myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "ssTextBox";
                        //    break;

                        case "datetime":
                            myGridRow.Cells["clmControl"].Value = "gitDateTimePicker";
                            myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "gitDateTimePicker";
                            break;
                        case "image":
                            myGridRow.Cells["clmControl"].Value = "PictureBox";
                            myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "PictureBox";
                            break;
                        case "bit":
                            myGridRow.Cells["clmControl"].Value = "gitCheckBox";
                            myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "gitCheckBox";
                            break;
                        default:
                            myGridRow.Cells["clmControl"].Value = "gitTextBox";
                            myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "gitTextBox";
                            break;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        void SelectColumns()
        {
            try
            {
                this.getSelectedTableFolder();

                if (this.cbkSelectAll.Checked == true)
                {
                    this.cbkSelectAll.Text = "Un-select All";

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];
                        myCell.Value = 1;
                    }

                }
                else
                {
                    this.cbkSelectAll.Text = "Select All";

                    foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];
                        myCell.Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
        #region "Get Projects"

        void Projects_ComboBox()
        {
            try
            {

                DataTable myDataTable_ProjectBusinessEntity = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.cmbSolutions.SelectedValue.ToString() + " and ProjectType like 'Business Entity'", "ID", "asc");
                DataTable myDataTable_ProjectDAL = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.cmbSolutions.SelectedValue.ToString() + " and ProjectType like 'Data Access'", "ID", "asc");
                DataTable myDataTable_ProjectUIDesktop = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.cmbSolutions.SelectedValue.ToString() + " and ProjectType like 'WCF'", "ID", "asc");

                if (myDataTable_ProjectBusinessEntity != null)
                {
                    this.cmbProjectID_BusinessEntity.DataSource = this.cmbProjectNamespace_BusinessEntity.DataSource = myDataTable_ProjectBusinessEntity;
                    this.cmbProjectID_BusinessEntity.DisplayMember = "ProjectName";
                    this.cmbProjectID_BusinessEntity.ValueMember = "ID";

                    this.cmbProjectNamespace_BusinessEntity.DisplayMember = "PNameSpace";
                    this.cmbProjectNamespace_BusinessEntity.ValueMember = "PNameSpace";

                }

                if (myDataTable_ProjectDAL != null)
                {
                    this.cmbProjectID_DAL.DataSource = this.cmbProjectNamespace_DataAccess.DataSource = myDataTable_ProjectDAL;
                    this.cmbProjectID_DAL.DisplayMember = "ProjectName";
                    this.cmbProjectID_DAL.ValueMember = "ID";

                    this.cmbProjectNamespace_DataAccess.DisplayMember = "PNameSpace";
                    this.cmbProjectNamespace_DataAccess.ValueMember = "PNameSpace";

                }

                if (myDataTable_ProjectUIDesktop != null)
                {
                    this.cmbProjectID_UIDesktop.DataSource = myDataTable_ProjectUIDesktop;
                    this.cmbProjectID_UIDesktop.DisplayMember = "ProjectName";
                    this.cmbProjectID_UIDesktop.ValueMember = "ID";

                }



                this.cmbProjectID_BusinessEntity.Update();
                this.cmbProjectID_BusinessEntity.Refresh();

                this.cmbProjectID_DAL.Update();
                this.cmbProjectID_DAL.Refresh();

                this.cmbProjectID_UIDesktop.Update();
                this.cmbProjectID_UIDesktop.Refresh();
            }
            catch (Exception ex)
            {

                Messages.GeneralError(ex.Message, "Project Combox");
            }
        }

        Boolean isProjectMapped;
        void ViewAll_Projects()
        {
            try
            {

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                myDataTable_SolutionsDB = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.cmbSolutions.SelectedValue.ToString() + " and ProjectType like 'WCF'", "ID", "asc");




                this.Projects_bindingSource.DataSource = myDataTable_SolutionsDB;

                if (this.Projects_bindingSource.DataSource != null && this.isProjectMapped == false)
                {
                    this.isProjectMapped = true;

                    this.txtBaseFolder.DataBindings.Add("Text", this.Projects_bindingSource, "BaseFolder", false);
                    this.txtProjectNamespace.DataBindings.Add("Text", this.Projects_bindingSource, "PNameSpace", false);
                }
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project");
            }
        }
        #endregion

        #region "Solution & Table Folder"
        void getSelectedTableFolder()
        {
            try
            {
                DataTable myDataTable_TableFolder = new SolutionFolders_TablesDAL().getTableFolderInfo(int.Parse(this.cmbSolutions.SelectedValue.ToString()), this.cmbDBTables.Text);

                if (myDataTable_TableFolder != null && myDataTable_TableFolder.Rows.Count > 0)
                {
                    DataRow myRow = myDataTable_TableFolder.Rows[0];

                    this.CurrentFolderName = myRow["FolderName"].ToString();
                    this.CurrentFolderId = int.Parse(myRow["FolderId"].ToString());

                    this.txtWCFClassSaveIn.Text = myRow["NamespaceFormat"].ToString().Replace(".", "\\").Replace("{Parent}", this.txtBaseFolder.Text).Replace("{FolderName}", myRow["FolderName"].ToString()) + "\\Model"; // this.txtBaseFolder.Text + "\\" + myRow["FolderName"].ToString();
                    this.txtWCFInterfaceSavein.Text = myRow["NamespaceFormat"].ToString().Replace(".", "\\").Replace("{Parent}", this.txtBaseFolder.Text).Replace("{FolderName}", myRow["FolderName"].ToString()) + "\\Interface"; // this.txtBaseFolder.Text + "\\" + myRow["FolderName"].ToString();

                    this.txtWCFClassNamespace.Text = myRow["NamespaceFormat"].ToString().Replace("{Parent}", this.txtProjectNamespace.Text).Replace("{FolderName}", myRow["FolderName"].ToString()) + ".Model";
                    this.txtWCFInterfaceNamespace.Text = myRow["NamespaceFormat"].ToString().Replace("{Parent}", this.txtProjectNamespace.Text).Replace("{FolderName}", myRow["FolderName"].ToString()) + ".Interface";

                    //this.txtModuleName.Text = this.cmbDBTables.Text + ".cs";
                    //this.txtInterfaceName.Text = "I" + this.cmbDBTables.Text + ".cs";



                    string myTableName = this.cmbDBTables.Text;

                    if (myTableName.IndexOf("_") > 0)
                    {
                        myTableName = myTableName.Substring(myTableName.IndexOf("_") + 1);
                    }

                    myTableName = myTableName.Replace(" ", "");

                    this.txtWCFClassName.Text = myTableName;   //myRow["InterfaceNamespaceFormat"].ToString().Replace(".", "\\").Replace("{Parent}", this.txtBaseFolder.Text).Replace("{FolderName}", myRow["FolderName"].ToString()); // this.txtBaseFolder.Text + "\\" + myRow["FolderName"].ToString();
                    //this.txtWCFInterfaceSavein.Text = myTableName;// myRow["InterfaceNamespaceFormat"].ToString().Replace("{Parent}", this.txtProjectNamespace.Text).Replace("{FolderName}", myRow["FolderName"].ToString());

                    this.txtWCFInterfaceName.Text = "I" + myTableName;

                    this.txtWCFClassSaveIn.Text = this.txtWCFClassSaveIn.Text.Replace("\\Model\\Model", "Model");


                }

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Solutions DB Query"
        Boolean isMapped_SolutionDBQuery;
        void getDBQuery_SelectedTable(string TableName)
        {
            try
            {
                DataTable myDataTable_SolutionsDBQuery = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");
                myDataTable_SolutionsDBQuery = new SolutionsDBQueryDAL().getList_Search(100000, 1, " SolutionsDBID=" + this.cmbSolutionsDB.SelectedValue.ToString() + " and TableName like '" + TableName + "'", "ID", "asc");

                if (myDataTable_SolutionsDBQuery != null)
                {
                    this.SolutionsDBQuery_bindingSource.DataSource = myDataTable_SolutionsDBQuery;
                }

                if (this.isMapped_SolutionDBQuery == false)
                {
                    this.isMapped_SolutionDBQuery = true;
                    this.dgvTableStoreProcedures.DataSource = this.SolutionsDBQuery_bindingSource;

                    this.dgvTableStoreProcedures.Columns["clmQueryName"].DataPropertyName = "QueryName";
                    this.dgvTableStoreProcedures.Columns["clmQueryType"].DataPropertyName = "QueryType";
                    this.dgvTableStoreProcedures.Columns["clmActionType"].DataPropertyName = "ActionType";
                    this.dgvTableStoreProcedures.Columns["clmMethod"].DataPropertyName = "DALMethodName";

                }


                this.dgvTableStoreProcedures.Refresh();

                this.getDBQuery_MethodName();
                this.SelectColumn_SQLDBQuery();

                this.chkSelectAll_DBQuery.Checked = true;



            }
            catch (Exception ex)
            {

            }
        }

        void getDBQuery_MethodName()
        {
            try
            {
                String MethodName = string.Empty;
                int LastIndex = 0;
                foreach (DataGridViewRow myRow in this.dgvTableStoreProcedures.Rows)
                {
                    LastIndex = myRow.Cells["clmQueryName"].Value.ToString().LastIndexOf("_");

                    if (LastIndex > 0)
                    {
                        //myRow.Cells["clmMethod"].Value = myRow.Cells["clmQueryName"].Value.ToString().Substring(LastIndex + 1);
                    }



                }
            }
            catch (Exception ex)
            {

            }
        }

        void SelectColumn_SQLDBQuery()
        {
            try
            {
                this.getSelectedTableFolder();

                if (this.chkSelectAll_DBQuery.Checked == true)
                {
                    this.chkSelectAll_DBQuery.Text = "Un-select All";

                    foreach (DataGridViewRow myRow in this.dgvTableStoreProcedures.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clsSelect_Query"];
                        myCell.Value = 1;
                    }

                }
                else
                {
                    this.chkSelectAll_DBQuery.Text = "Select All";

                    foreach (DataGridViewRow myRow in this.dgvTableStoreProcedures.Rows)
                    {
                        DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clsSelect_Query"];
                        myCell.Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }
        #endregion

        #region "WCF"
        string DateTimeFormat = CommonClasses.CommonVariables.FullDateFormat;
        void Generate_WCF()
        {
            try
            {
                string GenerateredECFClass = string.Empty;
                string GenerateredECFInterface = string.Empty;

                GenerateredECFClass = WCFGeneratorFolder.WCFGenerator.GeneratorWCFClass(this.cmbSolutionsDB.SelectedValue.ToString(),this.dgvTableStoreProcedures, this.cmbDBTables.Text,
                                                    this.txtWCFInterfaceNamespace.Text, this.cmbBusinessEntityClassNamesapce.Text, this.cmbBusinessEntityClass.Text.Replace (".cs",""), this.cmbProjectNamespace_DataAccess.Text,
                                                    this.cmbDataAccessNamespace.Text, this.cmbClassNameDAL.Text.Replace (".cs",""), this.txtWCFClassNamespace.Text, this.txtWCFClassName.Text, this.txtWCFInterfaceName .Text, this.txtWCFInterfaceNamespace.Text);

                GenerateredECFInterface = WCFGeneratorFolder.WCFGenerator.GeneratorWCFInterface(this.cmbSolutionsDB.SelectedValue.ToString(), this.dgvTableStoreProcedures, this.cmbDBTables.Text,
                                                    this.cmbProjectNamespace_DataAccess.Text, this.txtWCFInterfaceNamespace.Text, this.cmbBusinessEntityClassNamesapce.Text, this.cmbBusinessEntityClass.Text.Replace (".cs",""),
                                                    this.txtWCFInterfaceNamespace.Text, this.txtWCFClassName.Text, this.txtWCFClassName.Text);

                //return;
                //DataTable myQueryColumns_DataTable = this.getSelectTable_QueryColumns(this.cmbDBTables.Text);

                //if (myQueryColumns_DataTable != null && myQueryColumns_DataTable.Rows.Count <= 0)
                //{
                //    Messages.GeneralError("No column exists for Table " + this.cmbDBTables.Text, "Table Columns");
                //}


                this.txtFileData.Text = GenerateredECFClass; //ClassInnerData;

                this.ProjectFile_Insert(GenerateredECFClass, "WCF Class", this.txtProjectNamespace.Text, this.txtWCFClassName.Text + ".svc.cs" );
                this.ProjectFile_Insert(GenerateredECFInterface, "WCF Interface", this.txtWCFInterfaceNamespace .Text, this.txtWCFInterfaceName.Text + ".cs");

                string SVCClass = "<%@ ServiceHost Language=\"C#\" Debug=\"true\" Service=\"" + this.txtWCFClassNamespace.Text + "." + this.txtWCFClassName.Text +"\" CodeBehind=\"" + this.txtWCFClassName.Text +".svc.cs\" %>";
                this.ProjectFile_Insert(GenerateredECFClass, "WCF Service", this.txtProjectNamespace.Text, this.txtWCFClassName.Text + ".svc");

                this.GetList_ProjectFiles();

                if (this.chkisSavedOnGenerate.Checked == true)
                {
                    File.WriteAllText(this.txtWCFClassSaveIn.Text + "\\" + this.txtWCFClassName.Text + ".svc", SVCClass);
                    File.WriteAllText(this.txtWCFClassSaveIn.Text + "\\" + this.txtWCFClassName.Text + ".svc.cs", GenerateredECFClass);
                    File.WriteAllText(this.txtWCFInterfaceSavein.Text + "\\" + this.txtWCFInterfaceName.Text + ".cs", GenerateredECFInterface);
                    //File.WriteAllText(this.txtGenerateDALSaveIn.Text + "\\" + this.txtModuleName.Text, GenerateredFormCode);
                }

                Messages.SuccessMessage(this.txtWCFClassName.Text + " Generated Successfully!", "Action Performed");

                this.cmbDBTables.Focus();

            }
            catch (Exception ex)
            {
                Messages.GeneralError(ex.Message, "Generate Data Access");
            }
        }
        #endregion

        #region "Solution DB Table Columns"
        DataTable getSelectTable_QueryColumns(string TableName)
        {
            try
            {
                return new SolutionsDBQueryColumnsDAL().getList_Search(10000, 1, " SolutionsDBID=" + this.cmbSolutionsDB.SelectedValue.ToString() + " and TableName like '" + TableName + "'", "ID");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region "Project Entity"

        Boolean isMapped_BEClass, isMapped_BEInterface;
        void getProject_TableEntity()
        {
            try
            {
                DataTable myDataTable_BusinessEntityClass = new ProjectFilesDAL().getProjectBusinessEntity_TableName(int.Parse(this.cmbProjectID_BusinessEntity.SelectedValue.ToString()), this.cmbDBTables.Text, "Class");
                DataTable myDataTable_BusinessEntityInterface = new ProjectFilesDAL().getProjectBusinessEntity_TableName(int.Parse(this.cmbProjectID_BusinessEntity.SelectedValue.ToString()), this.cmbDBTables.Text, "Interface");

                if (myDataTable_BusinessEntityClass != null)
                {
                    this.BusinessEntityClass_bindingSource.DataSource = myDataTable_BusinessEntityClass;

                }

                if (myDataTable_BusinessEntityClass != null)
                {
                    this.BusinessEntityInterface_bindingSource.DataSource = myDataTable_BusinessEntityInterface;
                }

                if (isMapped_BEClass == false)
                {
                    isMapped_BEClass = true;
                    this.cmbBusinessEntityClass.DataSource = this.cmbBusinessEntityClassNamesapce.DataSource = this.BusinessEntityClass_bindingSource;
                    this.cmbBusinessEntityClass.DisplayMember = "SaveAs";
                    this.cmbBusinessEntityClass.ValueMember = "ID";

                    this.cmbBusinessEntityClassNamesapce.DisplayMember = "FNameSpace";
                    this.cmbBusinessEntityClassNamesapce.ValueMember = "FNameSpace";

                }

                if (isMapped_BEInterface == false)
                {
                    isMapped_BEClass = true;
                    this.cmbBusinessEntityInterface.DataSource = this.BusinessEntityInterface_bindingSource;
                    this.cmbBusinessEntityInterface.DisplayMember = "SaveAs";
                    this.cmbBusinessEntityInterface.ValueMember = "ID";
                }

                this.cmbBusinessEntityClass.Refresh();
                this.cmbBusinessEntityInterface.Refresh();


                DataTable myDataTable_DALCLass = new ProjectFilesDAL().getProjectBusinessEntity_TableName(int.Parse(this.cmbProjectID_DAL.SelectedValue.ToString()), this.cmbDBTables.Text, "Class");

                if (myDataTable_DALCLass != null)
                {
                    this.cmbClassNameDAL.DataSource = this.cmbDataAccessNamespace.DataSource = myDataTable_DALCLass;
                    this.cmbClassNameDAL.DisplayMember = "SaveAs";
                    this.cmbClassNameDAL.ValueMember = "ID";

                    this.cmbDataAccessNamespace.DisplayMember = "FNameSpace";
                    this.cmbDataAccessNamespace.ValueMember = "FNameSpace";
                }
                else
                {
                    this.cmbClassNameDAL.DataSource = null;
                }

                this.cmbClassNameDAL.Refresh();
                this.cmbClassNameDAL.Update();

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Project Files "
        Boolean isMapped_ProjectFiles;
        void ProjectFile_Insert(string ClassContent, string ClassType, string NameSpace, string SaveAs)
        {
            try
            {
                ProjectFilesDAL ProjectFiilesDAL = new ProjectFilesDAL();

                ProjectFiilesDAL.ProjectId = int.Parse(this.cmbProjectID_UIDesktop.SelectedValue.ToString());

                ProjectFiilesDAL.ClassType = ClassType;

                if (ClassType.ToLower() == "interface")
                {
                    //ProjectFiilesDAL.FullPath = this.txtGenerateBESaveIn.Text + "\\Interface\\" + SaveAs;
                    ProjectFiilesDAL.FullPath = this.txtWCFClassName.Text + "\\" + SaveAs;
                }
                else
                {
                    ProjectFiilesDAL.FullPath = this.txtWCFClassSaveIn.Text + "\\" + SaveAs;
                }

                ProjectFiilesDAL.FolderId = this.CurrentFolderId;
                ProjectFiilesDAL.FolderName = this.CurrentFolderName;
                ProjectFiilesDAL.FNameSpace = NameSpace; //this.txtGenerateBENamespace.Text;
                ProjectFiilesDAL.SaveAs = SaveAs; //this.cmbDBTables.Text + ".cs";

                ProjectFiilesDAL.isGenerated = chkisSavedOnGenerate.Checked;

                ProjectFiilesDAL.FileData = ClassContent;// this.txtGeneratedClass.Text;
                ProjectFiilesDAL.isActive = true;
                ProjectFiilesDAL.UserId = Security.UserID;

                ProjectFiilesDAL.TableName = this.cmbDBTables.Text;

                if (ProjectFiilesDAL.isGenerated == true)
                {
                    FileInfo myFile = new FileInfo(ProjectFiilesDAL.FullPath);

                    if (myFile.Exists == false)
                    {
                        Directory.CreateDirectory(myFile.Directory.FullName);
                    }

                    //File.WriteAllText(ProjectFiilesDAL.FullPath, ProjectFiilesDAL.FileData);
                }

                ProjectFiilesDAL.Insert();

            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project File");
            }
        }

        void GetList_ProjectFiles()
        {
            try
            {

                DataTable myDataTable_ProjectFiles = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                myDataTable_ProjectFiles = new ProjectFilesDAL().getList_Search(100000, 1, " ProjectId=" + this.cmbProjectID_UIDesktop.SelectedValue.ToString(), "ID", "Desc");

                this.ProjectFiles_bindingSource.DataSource = myDataTable_ProjectFiles;

                if (this.ProjectFiles_bindingSource.DataSource != null && this.isMapped_ProjectFiles == false)
                {
                    this.isMapped_ProjectFiles = true;

                    this.txtID.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "ID", false);
                    this.txtClassType.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "ClassType", false);
                    this.txtFolderName.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FolderName", false);
                    this.txtSaveAs.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "SaveAs", false);
                    this.txtFNameSpace.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FNameSpace", false);
                    this.txtFullPath.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FullPath", false);
                    this.txtFileData.DataBindings.Add("Text", this.ProjectFiles_bindingSource, "FileData", false);

                    this.cbkisActive.DataBindings.Add("Checked", this.ProjectFiles_bindingSource, "isActive", true);
                    this.chkisGenerated.DataBindings.Add("Checked", this.ProjectFiles_bindingSource, "isGenerated", true);

                    this.dvgProjectFiles.DataSource = this.ProjectFiles_bindingSource;

                    this.dvgProjectFiles.Columns["clsSaveAs"].DataPropertyName = "SaveAs";

                    this.bnMain.BindingSource = this.ProjectFiles_bindingSource;

                }

                //this.cmbProjects.DataSource = this.Projects_bindingSource;
                //this.cmbProjects.DisplayMember = "ProjectName";
                //this.cmbProjects.ValueMember = "ID";

                this.dvgProjectFiles.Update();
                this.dvgProjectFiles.Refresh();
            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project Files");
            }
        }

        #endregion

        public WCFGenerator()
        {
            InitializeComponent();
        }

        private void WCFGenerator_Load(object sender, EventArgs e)
        {
            try
            {
                this.dvgProjectFiles.AutoGenerateColumns = false;
                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgTableColumns);
                this.dvgTableColumns.AutoGenerateColumns = false;
                this.dgvTableStoreProcedures.AutoGenerateColumns = false;

                this.getList_Solutions();

                this.dvgTableColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.ViewAll_SolutionsDB();
                this.Projects_ComboBox();
                this.ViewAll_Projects();

                if (this.cmbProjectID_UIDesktop != null && this.cmbProjectID_UIDesktop.Text != string.Empty && this.cmbProjectID_UIDesktop.Text.Length > 1)
                {
                    this.GetList_ProjectFiles();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdColumns_Click(object sender, EventArgs e)
        {
            try
            {
                //this.SolutionDBQuery_bindingSource.DataSource = null;
                //this.dvgSolutionDBQuery.DataBindings.Clear();

                this.GetSelectDB_TableColumns();

                this.cbkSelectAll.Checked = true;

                this.SelectColumns();
                this.getDBQuery_SelectedTable(this.cmbDBTables.Text);


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Table Columns");
            }
        }

        private void WinForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.dvgProjectFiles.AutoGenerateColumns = false;
                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgTableColumns);
                this.dvgTableColumns.AutoGenerateColumns = false;
                this.dgvTableStoreProcedures.AutoGenerateColumns = false;

                this.getList_Solutions();

                this.dvgTableColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView myRow = (DataRowView)this.SolutionsDB_bindingSource.Current;

                if (myRow != null)
                {
                    this.CurrentDBType = myRow["DBType"].ToString();
                    this.CurrentDBID = int.Parse(myRow["ID"].ToString());
                }

                this.GetSelectDB_Tables();

                this.cbkSelectAll.Checked = true;

                this.SelectColumns();
                //this.GetSelectedDB_Folders();

                //this.getMappedTables();

                this.cmdColumns_Click(null, null);


            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbProjectID_UIDesktop != null && this.cmbProjectID_UIDesktop.Text != string.Empty && this.cmbProjectID_UIDesktop.Text.Length > 1)
                {
                    this.GetList_ProjectFiles();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdGenerateBE_Click(object sender, EventArgs e)
        {
            this.Generate_WCF();
        }

        private void dvgTableColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //myGridRow.Cells["clmControlName"].Value = myGridRow.Cells["clmName"].Value.ToString() + "clmControl";
                if (e.RowIndex >= 0 && e.ColumnIndex > 2)
                {
                    this.dvgTableColumns.Rows[e.RowIndex].Cells["clmControlName"].Value = this.dvgTableColumns.Rows[e.RowIndex].Cells["clmName"].Value.ToString() + this.dvgTableColumns.Rows[e.RowIndex].Cells["clmControl"].Value.ToString();
                }

            }
            catch (Exception ex)
            {

                Messages.GeneralError(ex.Message, "Change");
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void cmbBusinessEntityInterface_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDBTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmdColumns_Click(sender, e);
            }
            catch (Exception ex)
            {
                
                
            }
        }

        private void cmbDBTables_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter )
            {
                this.cmdColumns_Click(sender, e);
            }
        }
    }
}
