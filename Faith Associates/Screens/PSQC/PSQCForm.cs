using Faith_Associates.Screens.Clients;
using Faith_Associates.Screens.Jobs;
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

namespace Faith_Associates.Screens.PSQC
{
    public partial class PSQCForm : TemplateForm
    {
        public int JobID;
        public int ClientID;

        public PSQCForm()
        {
            InitializeComponent();
        }


        private void LoadAuthPersonToComboBox()
        {
            ListData.LoadDataIntoComboBox(cmbAuthPerson, "usp_PSQCAuthPersonGetAllAuthPersons");
            cmbAuthPerson.DisplayMember = "Name";
            cmbAuthPerson.ValueMember = "PersonID";
        }

        private void PSQC_Load(object sender, EventArgs e)
        {
            LoadAuthPersonToComboBox();
        }

        private void btnSearchJob_Click(object sender, EventArgs e)
        {
            SearchJobsForm searchJobsForm = new SearchJobsForm();
            searchJobsForm.ShowDialog();
            this.JobID = searchJobsForm.JobID;
            if (this.JobID < 1) 
            {
                RSMessageBox.ShowErrorMessage("No Job Selected");
            }
            else
            {
                LoadJobDataIntoForm();
            }
        }

        private void LoadJobDataIntoForm()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "JobID";
            para.Value = this.JobID;
            DataTable dt = db.GetDataList("usp_PSQCGetJoDatabByID", para);

            if (dt == null)
            {
                RSMessageBox.ShowErrorMessage("No Job Found");
            }
            else
            {
                DataRow row = dt.Rows[0];
                this.ClientID = Convert.ToInt32(row["Client"]);
                txtJob.Text = row["JobNo"].ToString();
                txtClientName.Text = row["ClientName"].ToString();
                txtContact.Text = row["ContactPerson"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtFax.Text = row["Fax"].ToString();
                txtItem.Text = row["ItemName"].ToString();
                txtBL.Text = row["BL"].ToString();
                txtIGM.Text = row["IGM"].ToString();
                txtIndex.Text = row["IndexNo"].ToString();
                txtQuantity.Text = row["Quantity"].ToString();
                txtValueUSD.Text = row["InvoiceValueUSD"].ToString();
                txtValuePKR.Text = row["ValueInPKR"].ToString();
                txtRate.Text = row["ExchangeRate"].ToString();
                txtHSCode.Text = row["HSCode"].ToString();
                txtStandAddress.Text = row["StandAddress"].ToString();
                txtTerminal.Text = row["TerminalName"].ToString();
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            ClientDetailsForm client = new ClientDetailsForm();
            client.isUpdate = true;
            client.ClientID = this.ClientID;
            client.ShowDialog();
            LoadJobDataIntoForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
