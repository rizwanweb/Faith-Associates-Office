using Faith_Associates.Models.Accounts;
using Faith_Associates.Models.Clients;
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

namespace Faith_Associates.Screens.Clients
{
    public partial class ClientDetailsForm : TemplateForm
    {
        public int ClientID { get; set; }
        public ClientDetailsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientDetailsForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBoxes();
            LoadDataAndBindToControlIfUpdate();
            if (isUpdate)
            {
                btnDelete.Enabled = true;
                txtOpeningBalance.Enabled = false;
                dtOpeningBalance.Enabled = false;
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
                para.Parameter = "@ClientID";
                para.Value = this.ClientID;

                DataTable dtClient = db.GetDataList("usp_ClientGetClientDetailByID", para);
                
                DataRow row = dtClient.Rows[0];

                txtClientName.Text = row["ClientName"].ToString();
                txtContactPerson.Text = row["ContactPerson"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtMobile.Text = row["Mobile"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtNTN.Text = row["NTN"].ToString();
                txtGST.Text = row["GST"].ToString();
                cmbCity.SelectedValue = row["City"];
                cmbClientType.SelectedValue = row["ClientType"];
            }
        }

        private void LoadDataIntoComboBoxes()
        {
            ListData.LoadDataIntoComboBox(cmbCity, "usp_CitiesGetCities");
            cmbCity.DisplayMember = "CityName";
            cmbCity.ValueMember = "CityID";

            ListData.LoadDataIntoComboBox(cmbClientType, "usp_ClientTypeGetClientType");
            cmbClientType.DisplayMember = "Description";
            cmbClientType.ValueMember = "TypeID";
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
                    //Get Last added ClientID
                    int cid = GetClientID();
                    //Enter Opening Balance to Ledger Table
                    EnterClientOpeningBalance(cid);

                    RSMessageBox.ShowSuccessMessage("Record Added Successfully");
                    ListData.ClearFormControls(this);
                    txtClientName.Focus();
                }
            }
        }

        private void EnterClientOpeningBalance(int cid)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_LedgerInsertOpeningBalance", GetLedgerObjects(cid));
        }

        private object GetLedgerObjects(int cid)
        {
            AccountLedger al = new AccountLedger();
            al.TransactionID = 0;
            al.TransactionDate = dtOpeningBalance.Value;
            al.ClientID = cid;
            al.Particular = $"Opening Balance";
            al.Reff = 0;
            if (Convert.ToInt32(txtOpeningBalance.Text) > 0)
            {
                al.Debit = Convert.ToInt32(txtOpeningBalance.Text);
                al.Credit = 0;
                al.drcr = "Dr";
            }
            else
            {
                al.Debit = 0;
                al.Credit = Math.Abs(Convert.ToInt32(txtOpeningBalance.Text));
                al.drcr = "Cr";
            }         
            return al;
        }

        private int GetClientID()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            int cid = Convert.ToInt32(db.GetScalarValue("usp_ClientGetLastClientID"));
            return cid;
        }

        private void SaveRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_ClientsAddNewClient", GetObjects());
        }

        private void UpdateRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_ClientsUpdateClient", GetObjects());
        }

        private object GetObjects()
        {
            Client c = new Client();

            c.ClientID = (this.isUpdate) ? this.ClientID : 0;
            c.ClientName = txtClientName.Text.ToUpper();
            c.ContactPerson = txtContactPerson.Text.ToUpper();
            c.Phone = txtPhone.Text;
            c.Mobile = txtMobile.Text;
            c.Address = txtAddress.Text.ToUpper();
            c.Email = txtEmail.Text.ToLower();
            c.NTN = txtNTN.Text;
            c.GST = txtGST.Text;
            c.City = Convert.ToInt32(cmbCity.SelectedValue);
            c.ClientType = Convert.ToInt32(cmbClientType.SelectedValue);

            return c;
        }

        private bool ifFormIsValidated()
        {
            if (txtClientName.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Client Name is Required");
                txtClientName.Clear();
                txtClientName.Focus();
                return false;
            }
            if (txtContactPerson.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Contact Person Name is Required");
                txtContactPerson.Clear();
                txtContactPerson.Focus();
                return false;
            }
            if (txtPhone.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Phone Number is Required");
                txtPhone.Clear();
                txtPhone.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Address is Required");
                txtAddress.Clear();
                txtAddress.Focus();
                return false;
            }
            if (txtNTN.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("NTN number is Required");
                txtNTN.Clear();
                txtNTN.Focus();
                return false;
            }
            if (txtGST.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("GST number is Required");
                txtGST.Clear();
                txtGST.Focus();
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
            para.Parameter = "@ClientID";
            para.Value = this.ClientID;

            DialogResult result = MessageBox.Show("Do you want to Delete this Client ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.DeleteRecord("usp_ClientsDeleteClient", para);
                RSMessageBox.ShowSuccessMessage("Record Deleted...");
            }            
        }
    }
}
