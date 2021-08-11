using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pss.ProgrammerMate.Appearances
{
    public class SetFocusBlur_Color
    {
        ErrorProvider epMain = new ErrorProvider();
        public static int TextBox_FontSize = 10;

        public SetFocusBlur_Color()
        {
            try
            {
                epMain.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                epMain.BlinkRate = 500;


            }
            catch (Exception ex)
            {
            }
        }

        public void ClearAllControl(Form myForm)
        {
            try
            {
                List<Control> ControlsList = new List<Control>();

                GetAllControl(myForm, ControlsList);

                foreach (Control myControl in ControlsList)
                {
                    if (myControl is TextBox)
                    {
                        myControl.Text = string.Empty;
                    }
                    else if (myControl is ComboBox)
                    {
                        ComboBox myComboBox = (ComboBox)myControl;

                        if (myComboBox.Items.Count > 0)
                        {
                            myComboBox.SelectedIndex = 0;
                        }

                    }
                    else if (myControl is CheckBox)
                    {
                        CheckBox myCheckBox = (CheckBox)myControl;

                        if (myControl.Name.ToLower().Contains("isactive") == true)
                        {
                            myCheckBox.Checked = true;
                        }
                        else
                        {
                            myCheckBox.Checked = false;
                        }


                    }

                }

            }
            catch (Exception ex)
            {
            }
        }

        public void ClearAllControl_GroupBox(GroupBox myGroupBox)
        {
            try
            {
                List<Control> ControlsList = new List<Control>();

                GetAllControl(myGroupBox, ControlsList);

                foreach (Control myControl in ControlsList)
                {
                    if (myControl is TextBox)
                    {
                        myControl.Text = string.Empty;
                    }
                    else if (myControl is ComboBox)
                    {
                        ComboBox myComboBox = (ComboBox)myControl;

                        if (myComboBox.Items.Count > 0)
                        {
                            myComboBox.SelectedIndex = 0;
                        }

                    }
                    else if (myControl is CheckBox)
                    {
                        CheckBox myCheckBox = (CheckBox)myControl;

                        if (myControl.Name.ToLower().Contains("isactive") == true)
                        {
                            myCheckBox.Checked = true;
                        }
                        else
                        {
                            myCheckBox.Checked = false;
                        }


                    }

                }

            }
            catch (Exception ex)
            {
            }
        }

        public void setFocus_Blur_Properties(Form myForm)
        {
            try
            {


                List<Control> ControlsList = new List<Control>();

                this.epMain.ContainerControl = myForm;

                GetAllControl(myForm, ControlsList);

                foreach (Control myControl in ControlsList)
                {
                    if (myControl is TextBox)
                    {

                        TextBox myTextBox = (TextBox)myControl;

                        if (myTextBox.ReadOnly == true)
                        {
                            myControl.Enter += new System.EventHandler(setFocus_ForReadOnly_Enter);
                            myControl.Leave += new System.EventHandler(setLostFocus_ForReadOnly_Leave);
                        }
                        else
                        {

                            myControl.Enter += new System.EventHandler(setFocus_Enter);
                            myControl.Leave += new System.EventHandler(setLostFocus_Leave);
                            myControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(myControls_KeyPress);
                        }
                    }
                    else if (myControl is ComboBox)
                    {


                        myControl.Enter += new System.EventHandler(setFocus_Enter);
                        myControl.Leave += new System.EventHandler(setLostFocus_Leave);
                        myControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(myControls_KeyPress);
                        //myControl.KeyDown += new System.Windows.Forms.KeyEventHandler(new SetFocusBlur_Color().myControl_KeyDown);

                    }
                    else if (myControl is CheckBox)
                    {


                        myControl.Enter += new System.EventHandler(setFocus_Enter);
                        myControl.Leave += new System.EventHandler(setLostFocus_Leave);
                        myControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(myControls_KeyPress);
                        //myControl.KeyDown += new System.Windows.Forms.KeyEventHandler(new SetFocusBlur_Color().myControl_KeyDown);

                    }
                    else if (myControl is DateTimePicker)
                    {


                        myControl.Enter += new System.EventHandler(setFocus_Enter);
                        myControl.Leave += new System.EventHandler(setLostFocus_Leave);
                        myControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(myControls_KeyPress);
                        //myControl.KeyDown += new System.Windows.Forms.KeyEventHandler(new SetFocusBlur_Color().myControl_KeyDown);

                    }
                    if (myControl is MaskedTextBox)
                    {

                        MaskedTextBox myTextBox = (MaskedTextBox)myControl;

                        if (myTextBox.ReadOnly == true)
                        {
                            myControl.Enter += new System.EventHandler(setFocus_ForReadOnly_Enter);
                            myControl.Leave += new System.EventHandler(setLostFocus_ForReadOnly_Leave);
                        }
                        else
                        {

                            myControl.Enter += new System.EventHandler(setFocus_Enter);
                            myControl.Leave += new System.EventHandler(setLostFocus_Leave);
                            myControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(myControls_KeyPress);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
            }
        }


        public static void GetAllControl(Control c, List<Control> list)
        {

            foreach (Control control in c.Controls)
            {
                list.Add(control);

                if (control.Controls.Count > 0)
                    GetAllControl(control, list);
            }
        }


        public void setFocus_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox myTextBox = (TextBox)sender;
                myTextBox.BackColor = System.Drawing.Color.DarkKhaki;
                myTextBox.Font = new System.Drawing.Font("Segoe UI", TextBox_FontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myTextBox.ForeColor = System.Drawing.Color.Black;
            }
            else if (sender is ComboBox)
            {
                ComboBox myComboBox = (ComboBox)sender;
                myComboBox.BackColor = System.Drawing.Color.DarkKhaki;
                myComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myComboBox.ForeColor = System.Drawing.Color.Black;
                myComboBox.DroppedDown = true;

            }
            else if (sender is CheckBox)
            {
                CheckBox myCheckBox = (CheckBox)sender;
                myCheckBox.BackColor = System.Drawing.Color.DarkKhaki;
                myCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myCheckBox.ForeColor = System.Drawing.Color.Black;

            }
            else
            {
                Control mySender = (Control)sender;
                mySender.BackColor = System.Drawing.Color.DarkKhaki;
                mySender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                mySender.ForeColor = System.Drawing.Color.Black;
            }
        }


        private void myControls_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (e.KeyChar == (char)Keys.Enter)
            {

                e.Handled = true;
                SendKeys.Send("{Tab}");
            }

            if (sender is TextBox)
            {
                TextBox myTextBox = (TextBox)sender;

                if (myTextBox != null && myTextBox.Tag != null && myTextBox.Tag != string.Empty && myTextBox.Tag.ToString().ToLower().Contains("readonly") == true)
                {
                    e.Handled = true;
                    this.epMain.SetError(myTextBox, CommonClasses.Validations.ReadOnly);
                }
                else if (myTextBox != null && myTextBox.Tag != null && myTextBox.Tag != string.Empty && myTextBox.Tag.ToString().ToLower().Contains("number") == true)
                {

                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                    {
                        e.Handled = true;
                        this.epMain.SetError(myTextBox, CommonClasses.Validations.Numeric);
                        this.epMain.ContainerControl.Focus();
                    }
                    else
                    {
                        this.epMain.Clear();
                    }
                }
                else if (myTextBox != null && myTextBox.Tag != null && myTextBox.Tag != string.Empty && myTextBox.Tag.ToString().ToLower().Contains("nospace") == true)
                {

                    if (char.IsWhiteSpace(e.KeyChar) == true || char.IsPunctuation(e.KeyChar) == true)
                    {
                        e.Handled = true;
                        this.epMain.SetError(myTextBox, "Space is not allowed");
                        this.epMain.ContainerControl.Focus();
                    }
                    else
                    {
                        this.epMain.Clear();
                    }
                }
            }




        }

        private void myControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.setLostFocus_Leave(sender, null);
            }
        }

        public void setLostFocus_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox myTextBox = (TextBox)sender;
                myTextBox.BackColor = System.Drawing.Color.White;
                myTextBox.Font = new System.Drawing.Font("Segoe UI", TextBox_FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myTextBox.ForeColor = System.Drawing.Color.Black;

                this.epMain.Clear();
            }
            else if (sender is ComboBox)
            {
                ComboBox myComboBox = (ComboBox)sender;
                myComboBox.BackColor = System.Drawing.Color.White;
                myComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myComboBox.ForeColor = System.Drawing.Color.Black;
            }
            else if (sender is CheckBox)
            {
                CheckBox myCheckBox = (CheckBox)sender;
                myCheckBox.BackColor = System.Drawing.Color.White;
                myCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myCheckBox.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Control mySender = (Control)sender;
                mySender.BackColor = System.Drawing.Color.White;
                mySender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                mySender.ForeColor = System.Drawing.Color.Black;
            }
        }


        public void setFocus_ForReadOnly_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox myTextBox = (TextBox)sender;
                myTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                myTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myTextBox.ForeColor = System.Drawing.Color.Black;
            }
            else if (sender is ComboBox)
            {
                ComboBox myComboBox = (ComboBox)sender;
                myComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                myComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myComboBox.ForeColor = System.Drawing.Color.Black;
                myComboBox.DroppedDown = true;

            }
        }

        private void setLostFocus_ForReadOnly_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox myTextBox = (TextBox)sender;
                myTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                myTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myTextBox.ForeColor = System.Drawing.Color.Black;
            }
            else if (sender is ComboBox)
            {
                ComboBox myComboBox = (ComboBox)sender;
                myComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                myComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myComboBox.ForeColor = System.Drawing.Color.Black;
                myComboBox.DroppedDown = true;

            }
        }
    }
}
