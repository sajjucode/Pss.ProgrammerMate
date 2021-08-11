using Pss.ProgrammerMate.CommonClasses;
using Pss.ProgrammerMate.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pss.ProgrammerMate
{
    public partial class frmBusinessEntity : Form
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

        Boolean isProjectMapped;
        void ViewAll_Projects()
        {
            try
            {

                DataTable myDataTable_SolutionsDB = new DataTable();// = new JobStatusHeadDAL().getList(1000, 1, "Id", "asc");

                myDataTable_SolutionsDB = new ProjectsDAL().getList_Search(1000, 1, " SolutionID=" + this.cmbSolutions.SelectedValue.ToString() + " and ProjectType like 'Business Entity'", "ID", "asc");




                this.Projects_bindingSource.DataSource = myDataTable_SolutionsDB;

                if (this.Projects_bindingSource.DataSource != null && this.isProjectMapped == false)
                {
                    this.isProjectMapped = true;

                    this.txtBaseFolder.DataBindings.Add("Text", this.Projects_bindingSource, "BaseFolder", false);
                    this.txtProjectNamespace.DataBindings.Add("Text", this.Projects_bindingSource, "PNameSpace", false);
                }

                this.cmbProjects.DataSource = this.Projects_bindingSource;
                this.cmbProjects.DisplayMember = "ProjectName";
                this.cmbProjects.ValueMember = "ID";

                this.cmbProjects.Update();
                this.cmbProjects.Refresh();
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

                    this.txtGenerateBESaveIn.Text = myRow["NamespaceFormat"].ToString().Replace(".", "\\").Replace("{Parent}", this.txtBaseFolder.Text).Replace("{FolderName}", myRow["FolderName"].ToString()); // this.txtBaseFolder.Text + "\\" + myRow["FolderName"].ToString();
                    this.txtGenerateBENamespace.Text = myRow["NamespaceFormat"].ToString().Replace("{Parent}", this.txtProjectNamespace.Text).Replace("{FolderName}", myRow["FolderName"].ToString());

                    this.txtClassName.Text = this.cmbDBTables.Text + "BE.cs";
                    this.txtInterfaceName.Text = "I" + this.cmbDBTables.Text + "BE.cs";


                    this.txtInterfaceSaveAs.Text = myRow["InterfaceNamespaceFormat"].ToString().Replace(".", "\\").Replace("{Parent}", this.txtBaseFolder.Text).Replace("{FolderName}", myRow["FolderName"].ToString()); // this.txtBaseFolder.Text + "\\" + myRow["FolderName"].ToString();
                    this.txtInterfaceNamespace.Text = myRow["InterfaceNamespaceFormat"].ToString().Replace("{Parent}", this.txtProjectNamespace.Text).Replace("{FolderName}", myRow["FolderName"].ToString());


                }
                else
                {
                    this.CurrentFolderName = "";
                    this.CurrentFolderId = 0;

                    this.txtGenerateBESaveIn.Text = this.txtBaseFolder.Text;
                    this.txtGenerateBENamespace.Text = this.txtProjectNamespace.Text;

                    this.txtClassName.Text = this.cmbDBTables.Text + ".cs";
                    this.txtInterfaceName.Text = "I" + this.cmbDBTables.Text + ".cs";


                    this.txtInterfaceSaveAs.Text = this.txtBaseFolder.Text + "\\Interface";
                    this.txtInterfaceNamespace.Text = this.txtProjectNamespace.Text + ".Interface";

                }

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region "Business Entity"
        string DateTimeFormat = CommonClasses.CommonVariables.FullDateFormat;
        public void GenerateBE()
        {
            try
            {
                string ClassReferences = "using System; " + Environment.NewLine +
                                     "using System.Collections.Generic; " + Environment.NewLine +
                                     "using System.Linq; " + Environment.NewLine +
                                     "using System.Text; " + Environment.NewLine +
                                     "using System.Threading.Tasks;" + Environment.NewLine +
                                     "using System.ComponentModel.DataAnnotations;" + Environment.NewLine +
                                     "using System.Runtime.Serialization;";

                string HeaderCommand = "/// <summary> " + Environment.NewLine +
                                       "/// Business Entities for Table " + this.cmbDBTables.Text + Environment.NewLine +
                                       "  /// </summary>  " + Environment.NewLine +
                                       "  /// <remarks>  " + Environment.NewLine +
                                       "  /// Tool: Programmer Mate  " + Environment.NewLine +
                                       "  /// Author: Sajjucode  " + Environment.NewLine +
                                       "  /// Created Date: " + DateTime.Now.ToString(DateTimeFormat) + Environment.NewLine +
                                       "  /// Copy Rights: PakSoft Solutions  " + Environment.NewLine +
                                       "/// </remarks> ";

                string Entities = string.Empty;
                string IEntities = string.Empty;
                DataRowView myRows;
                string ClassContent = string.Empty;
                string IClassContent = string.Empty;

                string Namespace = this.txtGenerateBENamespace.Text;// "Pss.DAL.BE";
                string INamespace = this.txtInterfaceNamespace.Text; //this.txtGenerateBENamespace.Text + ".Interface";// "Pss.DAL.BE";

                string ClassName = this.txtClassName.Text.Replace(".cs", ""); //this.cmbDBTables.Text;// +".cs";
                string IClassName = this.txtInterfaceName.Text.Replace(".cs", ""); //"I" + this.cmbDBTables.Text;// +".cs";


                foreach (DataGridViewRow myRow in this.dvgTableColumns.Rows)
                {
                    DataGridViewCheckBoxCell myCell = (DataGridViewCheckBoxCell)myRow.Cells["clmSelect"];

                    if (myCell.Value.ToString() == "1")
                    {
                        myRows = (DataRowView)myRow.DataBoundItem;
                        Entities = Entities + Environment.NewLine + " [Display(Name = \"" + myRows["ColumnName"].ToString() + "\")] " + Environment.NewLine + " [DataMember] " + Environment.NewLine  +
                                  "        public " + SQLDataTypeConversion.getDataType(myRows["DataType"].ToString()) + " " + myRows["ColumnName"].ToString() + " {get;set;} " + Environment.NewLine;
                        IEntities = IEntities + "        " + SQLDataTypeConversion.getDataType(myRows["DataType"].ToString()) + " " + myRows["ColumnName"].ToString() + " {get;set;} " + Environment.NewLine;
                    }


                }

                IClassContent = ClassReferences + Environment.NewLine + Environment.NewLine +
                              "namespace " + INamespace + Environment.NewLine + Environment.NewLine +
                              "{" + Environment.NewLine +
                              "     " + HeaderCommand + " " + Environment.NewLine +
                              "    public interface " + IClassName + Environment.NewLine +
                              "    {" + Environment.NewLine +
                              IEntities +
                              "    }" + Environment.NewLine +
                              "}";

                ClassContent = ClassReferences + Environment.NewLine +
                               "using " + INamespace + ";" + Environment.NewLine + Environment.NewLine +
                               "namespace " + Namespace + Environment.NewLine + Environment.NewLine +
                               "{" + Environment.NewLine +
                               "     " + HeaderCommand + " " + Environment.NewLine +
                               "    public class " + ClassName + " : " + IClassName + Environment.NewLine +
                               "    {" + Environment.NewLine +
                               Entities +
                               "    }" + Environment.NewLine +
                               "}";


                this.txtGeneratedClass.Text = ClassContent;

                //this.ProjectFile_Insert(IClassContent,"interface",INamespace,IClassName + ".cs");

                //this.ProjectFile_Insert(ClassContent, "class", Namespace, ClassName + ".cs");

                this.ProjectFile_Insert(IClassContent, "interface", INamespace, this.txtInterfaceName.Text);

                this.ProjectFile_Insert(ClassContent, "class", Namespace, this.txtClassName.Text);



                this.GetList_ProjectFiles();

                Messages.SuccessMessage("Business Entity Created.", "Business Entity");
                this.cmbDBTables.Focus();


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Project BE");
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

                ProjectFiilesDAL.ProjectId = int.Parse(this.cmbProjects.SelectedValue.ToString());

                ProjectFiilesDAL.ClassType = ClassType;

                if (ClassType.ToLower() == "interface")
                {
                    //ProjectFiilesDAL.FullPath = this.txtGenerateBESaveIn.Text + "\\Interface\\" + SaveAs;
                    ProjectFiilesDAL.FullPath = this.txtInterfaceSaveAs.Text + "\\" + SaveAs;
                }
                else
                {
                    ProjectFiilesDAL.FullPath = this.txtGenerateBESaveIn.Text + "\\" + SaveAs;
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

                    File.WriteAllText(ProjectFiilesDAL.FullPath, ProjectFiilesDAL.FileData);
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

                myDataTable_ProjectFiles = new ProjectFilesDAL().getList_Search(100000, 1, " ProjectId=" + this.cmbProjects.SelectedValue.ToString(), "SaveAs", "asc");




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

        public frmBusinessEntity()
        {
            InitializeComponent();
        }

        private void frmBusinessEntity_Load(object sender, EventArgs e)
        {
            try
            {
                this.dvgProjectFiles.AutoGenerateColumns = false;
                new Appearances.SetFocusBlur_Color().setFocus_Blur_Properties(this);
                Appearances.GridViewStyles.setGridDefaultStyle(this.dvgTableColumns);
                this.dvgTableColumns.AutoGenerateColumns = false;

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
                this.ViewAll_Projects();

                if (this.cmbProjects != null && this.cmbProjects.Text != string.Empty && this.cmbProjects.Text.Length > 1)
                {
                    this.GetList_ProjectFiles();
                }
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


            }
            catch (Exception ex)
            {
                CommonClasses.Messages.GeneralError(ex.Message, " Table Columns");
            }
        }

        private void cmbSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cmbSolutions.Items != null && this.cmbSolutions.Items.Count > 0)
            //{
            //    this.ViewAll_Projects();
            //}
        }

        private void cbkSelectAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbDBTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDBTables_TextChanged(object sender, EventArgs e)
        {

            if (this.cmbDBTables != null && this.cmbDBTables.Text != string.Empty && this.cmbDBTables.Text.Length > 0)
            {

                this.GetSelectDB_TableColumns();

                this.cbkSelectAll.Checked = true;

                this.SelectColumns();
            }
        }

        private void cmdGenerateBE_Click(object sender, EventArgs e)
        {

        }

        private void txtCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtGeneratedClass.Text);
            CommonClasses.Messages.SuccessMessage("Copy successfully.", "Copy");
        }

        private void cmdGenerateBE_Click_1(object sender, EventArgs e)
        {
            this.GenerateBE();
        }

        private void txtProjectNamespace_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {            

                if (this.cmbProjects != null && this.cmbProjects.Text != string.Empty && this.cmbProjects.Text.Length > 1)
                {
                    this.GetList_ProjectFiles();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbProjects != null && this.cmbProjects.Text != string.Empty && this.cmbProjects.Text.Length > 1)
                {
                    this.GetList_ProjectFiles();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdExecuteQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tbBusinessEntity.SelectedTab.Name == tpNewEntity.Name)
                {

                    saveFileDialog1.CheckFileExists = false;
                    saveFileDialog1.AddExtension = true;
                    saveFileDialog1.FileName = this.txtClassName.Text;
                    saveFileDialog1.InitialDirectory = this.txtGenerateBESaveIn.Text;

                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, this.txtGeneratedClass.Text);
                        MessageBox.Show(saveFileDialog1.FileName + " Created Successfully.", "Class Saved.", MessageBoxButtons.OK);
                    }
                }
                else if (this.tbBusinessEntity.SelectedTab.Name == tpProjectEntity.Name)
                {

                    saveFileDialog1.CheckFileExists = false;
                    saveFileDialog1.AddExtension = true;
                    saveFileDialog1.FileName = this.txtSaveAs.Text;
                    saveFileDialog1.InitialDirectory = this.txtFullPath.Text;

                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, this.txtGeneratedClass.Text);
                        MessageBox.Show(saveFileDialog1.FileName + " Created Successfully.", "Class Saved.", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}
