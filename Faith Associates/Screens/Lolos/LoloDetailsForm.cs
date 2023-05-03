using Faith_Associates.Models.LOLOs;
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

namespace Faith_Associates.Screens.Lolos
{
    public partial class LoloDetailsForm : TemplateForm
    {
        public int LoloID { get; set; }
        public LoloDetailsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoloDetailsForm_Load(object sender, EventArgs e)
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
                para.Parameter = "@LoloID";
                para.Value = this.LoloID;

                DataTable dtLolo = db.GetDataList("usp_LolosGetLoloDetailByID", para);
                
                DataRow row = dtLolo.Rows[0];

                txtLoloName.Text = row["LoloName"].ToString();
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
                    txtLoloName.Focus();
                }
            }
        }

        private void SaveRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_LolosAddNewLolo", GetObjects());
        }

        private void UpdateRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_LolosUpdateLolo", GetObjects());
        }

        private object GetObjects()
        {
            Lolo lolo = new Lolo();

            lolo.LoloID = (this.isUpdate) ? this.LoloID : 0;
            lolo.LoloName =  txtLoloName.Text.ToUpper();
            lolo.ShortName = txtShortName.Text.ToUpper();
            lolo.Phone = txtPhone.Text;
            lolo.Email = txtEmail.Text.ToLower();

            return lolo;
            }

            private bool ifFormIsValidated()
        {
            if (txtLoloName.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Shipping Line Name is Required");
                txtLoloName.Clear();
                txtLoloName.Focus();
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
            para.Parameter = "@LoloID";
            para.Value = this.LoloID;

            DialogResult result = MessageBox.Show("Do you want to Delete this Record ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.DeleteRecord("usp_LOLODeletelolo", para);
                RSMessageBox.ShowSuccessMessage("Record Deleted...");
            }            
        }
    }
}
