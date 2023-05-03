using Faith_Associates.Models.Terminals;
using Faith_Associates.Utilities;
using Faith_Associates.Utilities.Lists;
using RSDBFramework;
using RSDBFramework.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Screens.Terminals
{
    public partial class TerminalDetailsForm : TemplateForm
    {
        public int TerminalID { get; set; }
        public TerminalDetailsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TerminalDetailForm_Load(object sender, EventArgs e)
        {
            LoadDataAndBindToControlIfUpdate();
            if (isUpdate)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void LoadDataAndBindToControlIfUpdate()
        {
            if (this.isUpdate)
            {
                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                DBParameter para = new DBParameter();
                para.Parameter = "@TerminalID";
                para.Value = this.TerminalID;

                DataTable dtTerminal = db.GetDataList("usp_TerminalsGetTerminalDetailByID", para);
                
                DataRow row = dtTerminal.Rows[0];

                txtTerminalName.Text = row["TerminalName"].ToString();
                txtShortName.Text = row["ShortName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPhone.Text = row["Phone"].ToString();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ifFormIsValidated())
            {
                if (this.isUpdate)
                {
                    UpdateRecord();
                    RSMessageBox.ShowSuccessMessage("Record Updated Successfully");
                    this.isUpdate = false;
                    this.Close();
                }
                else
                {
                    SaveRecord();
                    RSMessageBox.ShowSuccessMessage("Record Added Successfully");
                    ListData.ClearFormControls(this);
                    txtTerminalName.Focus();
                }
            }
        }

        private void SaveRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_TerminalsAddNewTerminal", GetObjects());
        }

        private void UpdateRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_TerminalsUpdateTerminal", GetObjects());
        }

        private object GetObjects()
        {
            Terminal terminal = new Terminal();

            terminal.TerminalID = (this.isUpdate) ? this.TerminalID : 0;
            terminal.TerminalName =  txtTerminalName .Text.ToUpper();
            terminal.ShortName = txtShortName.Text.ToUpper();
            terminal.Phone = txtPhone.Text;
            terminal.Email = txtEmail.Text.ToLower();

            return terminal;
            }

            private bool ifFormIsValidated()
        {
            if (txtTerminalName.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Terminal Name is Required");
                txtTerminalName.Clear();
                txtTerminalName.Focus();
                return false;
            }
            if (txtShortName.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Short Name is Required");
                txtShortName.Clear();
                txtShortName.Focus();
                return false;
            }
            if (txtPhone.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Phone Number is Required");
                txtPhone.Clear();
                txtPhone.Focus();
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            this.Close();
        }

        private void DeleteRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@TerminalID";
            para.Value = this.TerminalID;

            DialogResult result = MessageBox.Show("Do you want to Delete this Terminal Record ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.DeleteRecord("usp_TerminalsDeleteTerminal", para);
                RSMessageBox.ShowSuccessMessage("Record Deleted...");
            }            
        }
    }
}
