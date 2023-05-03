using Faith_Associates.Models.ShippingLines;
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

namespace Faith_Associates.Screens.ShippingLines
{
    public partial class ShippingLineDetailsForm : TemplateForm
    {
        public int ShippingLineID { get; set; }
        public ShippingLineDetailsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShippingLineDetailsForm_Load(object sender, EventArgs e)
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
                para.Parameter = "@ShippingLineID";
                para.Value = this.ShippingLineID;

                DataTable dtShippingLine = db.GetDataList("usp_ShippingLinesGetShippingLineDetailByID", para);
                
                DataRow row = dtShippingLine.Rows[0];

                txtShippingLineName.Text = row["ShippingLineName"].ToString();
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
                    txtShippingLineName.Focus();
                }
            }
        }

        private void SaveRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_ShippingLinesAddNewShippingLine", GetObjects());
        }

        private void UpdateRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_ShippingLinesUpdateShippingLine", GetObjects());
        }

        private object GetObjects()
        {
            ShippingLine terminal = new ShippingLine();

            terminal.ShippingLineID = (this.isUpdate) ? this.ShippingLineID : 0;
            terminal.ShippingLineName =  txtShippingLineName.Text.ToUpper();
            terminal.ShortName = txtShortName.Text.ToUpper();
            terminal.Phone = txtPhone.Text;
            terminal.Email = txtEmail.Text.ToLower();

            return terminal;
            }

            private bool ifFormIsValidated()
        {
            if (txtShippingLineName.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Shipping Line Name is Required");
                txtShippingLineName.Clear();
                txtShippingLineName.Focus();
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
            para.Parameter = "@ShippingLineID";
            para.Value = this.ShippingLineID;

            DialogResult result = MessageBox.Show("Do you want to Delete this Shipping Line ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.DeleteRecord("usp_ShippingLinesDeleteShippingLine", para);
                RSMessageBox.ShowSuccessMessage("Record Deleted...");
            }            
        }
    }
}
