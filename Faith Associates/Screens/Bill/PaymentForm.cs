using Faith_Associates.Models.Accounts;
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

namespace Faith_Associates.Screens.Bill
{
    public partial class PaymentForm : TemplateForm
    {
        public int TransactionID { get; set; }
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            ListData.LoadDataIntoComboBox(cmbClient, "usp_ClientsGetClientsForComboBox");
            cmbClient.DisplayMember = "ClientName";
            cmbClient.ValueMember = "ClientID";
            cmbClient.SelectedIndex = -1;
            rbCash.Checked = true;
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            txtDetail.Clear();
            txtDetail.Text = "Cash ";
        }

        private void rbCheck_CheckedChanged(object sender, EventArgs e)
        {
            txtDetail.Clear();
            txtDetail.Text = "Check # ";
        }

        private void rbOnline_CheckedChanged(object sender, EventArgs e)
        {
            txtDetail.Clear();
            txtDetail.Text = "Bank Online Transaction # ";
        }

        private void rbPayorder_CheckedChanged(object sender, EventArgs e)
        {
            txtDetail.Clear();
            txtDetail.Text = "P/O # ";
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            txtDetail.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isUpdate)
            {
                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                db.InsertOrUpdateRecord("usp_LedgerInsertNewEntry", GetPaymentObjects());
                ListData.ClearFormControls(this);
                isUpdate = false;
                RSMessageBox.ShowSuccessMessage("Payment Added Successfully");
            }
        }

        private object GetPaymentObjects()
        {
            AccountLedger ac = new AccountLedger();
            ac.TransactionID = this.isUpdate ? this.TransactionID : 0;
            ac.TransactionDate = dtPaymentDate.Value;
            ac.ClientID = Convert.ToInt32(cmbClient.SelectedValue);
            ac.Particular = txtDetail.Text;
            ac.Debit = 0;
            ac.Credit = Convert.ToInt32(txtPayment.Text);
            ac.Reff = 0;
            ac.drcr = "Cr";
            return ac;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
