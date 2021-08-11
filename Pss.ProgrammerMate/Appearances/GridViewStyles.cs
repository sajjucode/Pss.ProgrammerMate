using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms.Design;
using System.Windows.Forms;


namespace Pss.ProgrammerMate.Appearances
{
    public class GridViewStyles
    {
        public static DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        public static DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        public static DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();

        public static Color BackGroundColor_DataGrid()
        {

            //return Color.FromArgb(237, 235, 235);
            return Color.FromArgb(0, 142, 194);
        }

        public static DataGridViewCellStyle AlternativeRowBG_GridView()
        {
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            return dataGridViewCellStyle1;
        }

        public static DataGridViewCellStyle ColumnHeadersDefaultCellStyle_GridView()
        {
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            return dataGridViewCellStyle6;
        }

        public static DataGridViewCellStyle RowDefaultCellStyle_GridView()
        {
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);

            dataGridViewCellStyle7.ForeColor = Color.Coral;// Color.Red;           

            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(238, 232, 170);
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            return dataGridViewCellStyle7;
        }

        public static void setGridDefaultStyle(DataGridView GridViewName)
        {
            try
            {
                GridViewName.AlternatingRowsDefaultCellStyle = AlternativeRowBG_GridView();
                GridViewName.BackgroundColor = BackGroundColor_DataGrid();
                GridViewName.BorderStyle = System.Windows.Forms.BorderStyle.None;
                GridViewName.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;

                GridViewName.ColumnHeadersDefaultCellStyle = ColumnHeadersDefaultCellStyle_GridView();
                GridViewName.ColumnHeadersHeight = 20;
                GridViewName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                GridViewName.Dock = System.Windows.Forms.DockStyle.Fill;
                GridViewName.EnableHeadersVisualStyles = false;

                GridViewName.MultiSelect = false;

                GridViewName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                GridViewName.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                GridViewName.RowHeadersVisible = false;
                GridViewName.RowsDefaultCellStyle = RowDefaultCellStyle_GridView();
                GridViewName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
