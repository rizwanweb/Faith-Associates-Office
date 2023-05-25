using Faith_Associates.Models.Accounts;
using Faith_Associates.Models.Bills;
using Faith_Associates.Reports.Bills;
using Faith_Associates.Reports.Jobs;
using Faith_Associates.Screens.Jobs;
using Faith_Associates.Utilities;
using Faith_Associates.Utilities.Lists;
using RSDBFramework;
using RSDBFramework.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

namespace Faith_Associates.Screens.Bill
{
    public partial class BillScreen : TemplateForm
    {
        int BillID { get; set; }
        int JobID { get; set; }
        int JobNo { get; set; }
        int BillNo { get; set; }
        public int BillDetailsID { get; set; }
        public int SalesTaxInvoiceID { get; set; }
        public int TransactionID { get; set; }

        // Form objects
        public int RowIndex { get; set; }

        public BillScreen()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBillJobsForm search = new SearchBillJobsForm();
            search.ShowDialog();
            JobID = search.JobID;
            this.isUpdate = search.isUpdate;

            if (isUpdate)
            {
                EnableButtons();
                btnAdd.Enabled = false;
                LoadJobDataToBillScreen(this.JobID);             

            }
        }

        private void LoadJobDataToBillScreen(int JobID)
        {
            try
            {
                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                DBParameter para = new DBParameter();
                para.Parameter = "@JobID";
                para.Value = JobID;
                DataTable dt = db.GetDataList("usp_BillsGetJobDataByJobNo", para);
                if (dt != null)
                {
                    DataRow row = dt.Rows[0];
                    txtJobNo.Text = row["JobNo"].ToString();
                    dtJob.Value = Convert.ToDateTime(row["JobDate"]);
                    txtBill.Text = row["JobNo"].ToString();
                    txtClient.Text = row["ClientName"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    txtItem.Text = row["ItemName"].ToString();
                    txtLC.Text = row["LC"].ToString();
                    txtBL.Text = row["BL"].ToString();
                    txtContainers.Text = row["Containers"].ToString();
                    txtSize.Text = row["Size"].ToString();
                    txtPackages.Text = row["Packages"].ToString();
                    txtIGM.Text = row["IGM"].ToString();
                    txtIndex.Text = row["IndexNo"].ToString();
                    txtVessel.Text = row["Vessel"].ToString();
                    dtJob.Value = Convert.ToDateTime(row["JobDate"]);
                    dtLC.Value = Convert.ToDateTime(row["LCDate"]);
                    dtBL.Value = Convert.ToDateTime(row["BLDate"]);
                    dtIGM.Value = Convert.ToDateTime(row["IGMDate"]);

                    txtGD.Text = row["GD"].ToString();
                    txtCash.Text = row["Cash"].ToString();
                    dtGD.Value = Convert.ToDateTime(row["GDDate"]);
                    dtCash.Value = Convert.ToDateTime(row["CashDate"]);
                }
                else
                {
                    RSMessageBox.ShowErrorMessage("No Data");
                }
            }
            catch (Exception)
            {
                
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BillScreen_Load(object sender, EventArgs e)
        {
            if (!isUpdate)
            {
                DisableButtons();
                LoadBillingHeadsToDataGrid();
                btnAdd.Focus();
            }
        }

        private void LoadBillingHeadsToDataGrid()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DataTable dt = db.GetDataList("usp_HeadsGetAllHeads");

            foreach (DataRow row in dt.Rows)
            {
                dgvBill.Rows.Add(null,row["BillHead"]);                
            }
        }

        private void DisableButtons()
        {
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
        }

        private void EnableButtons()
        {
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnPrint.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidated())
            {                
                if (isUpdate)
                {
                    // UPdate GD and Cash Number in Job Table
                    UpdateGDAndCash();
                    UpdateBill();
                    UpdateBillDetails();
                    UpdateSalesTaxInvoice();

                    // Get Transaction ID from ledger
                    this.TransactionID = GetTransactionID();

                    // Update Ledger Enter
                    UpdateLedgerEntry();

                    isUpdate = false;
                    RSMessageBox.ShowSuccessMessage("Bill Updated");
                    ListData.ClearFormControls(this);
                    dgvBill.Rows.Clear();
                    dgvBill.Refresh();
                    LoadBillingHeadsToDataGrid();
                    btnPrint.Focus();
                }
                else
                {
                    // UPdate GD and Cash Number in Job Table
                    UpdateGDAndCash();
                    using (TransactionScope ts = new TransactionScope())
                    {
                        // Save Bill
                        SaveBill();
                        // Get Last Bill ID FROM DATABASE
                        this.BillID = GetLatestBillID();
                        // Save Bill Particulars to Database
                        SaveBillDetails();
                        // Save SalesTax Invoice to Database
                        SaveSalesTaxInvoice();
                        // Enter Transaction into Ledger Table
                        SaveLedgerEntry();

                        ts.Complete();
                    }

                    isUpdate = false;                 
                    ListData.ClearFormControls(this);
                    dgvBill.Rows.Clear();
                    dgvBill.Refresh();
                    LoadBillingHeadsToDataGrid();
                    RSMessageBox.ShowSuccessMessage("Bill Added Successfully");
                    btnPrint.Focus();
                }
            }
        }

        private void UpdateLedgerEntry()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            List<DBParameter> parameters = new List<DBParameter>();

            DBParameter paraTotal = new DBParameter();
            paraTotal.Parameter = "@Total";
            paraTotal.Value = Convert.ToInt32(txtTotal.Text);
            parameters.Add(paraTotal);

            DBParameter paraTID = new DBParameter();
            paraTID.Parameter = "@TransactionID";
            paraTID.Value = this.TransactionID;
            parameters.Add(paraTID);
            db.InsertOrUpdateRecord("usp_LedgerUpdateLedgerEntryTotal", parameters.ToArray());
        }

        private int GetTransactionID()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@Reff";
            para.Value = this.BillID;
            int tid = Convert.ToInt32(db.GetScalarValue("usp_LedgerGetTransactionID", para));
            return tid;
        }

        private void SaveLedgerEntry()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter paraJobID = new DBParameter();
            paraJobID.Parameter = "@JobID";
            paraJobID.Value = this.JobID;
            int cid = Convert.ToInt32(db.GetScalarValue("usp_JobsGetClientID", paraJobID));
            db.InsertOrUpdateRecord("usp_LedgerInsertNewEntry", GetLedgerObjects(cid));
        }

        private object GetLedgerObjects(int cid)
        {
            AccountLedger al = new AccountLedger();
            al.TransactionID = this.isUpdate ? this.TransactionID : 0;
            al.TransactionDate = dtBill.Value;
            al.ClientID = cid;
            al.Particular = $"Job # : {txtBill.Text}/{dtBill.Value.Year}, STN # {txtSTInvoice.Text} L/C# : {txtLC.Text}";
            al.Debit = Convert.ToInt32(txtTotal.Text);
            al.Credit = 0;
            al.Reff = this.BillID;
            al.drcr = "Dr";
            return al;
        }

        private void UpdateGDAndCash()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_JobsUpdateGDAndCash", GetGDAndCashObject());
        }

        private DBParameter[] GetGDAndCashObject()
        {
            List<DBParameter> paras = new List<DBParameter>();
            DBParameter GDPara = new DBParameter();
            DBParameter GDDate = new DBParameter();
            DBParameter CashPara = new DBParameter();
            DBParameter CashDate = new DBParameter();
            DBParameter JobPara = new DBParameter();

            GDPara.Parameter = "@GD";
            GDPara.Value = txtGD.Text.ToUpper().Trim();
            GDDate.Parameter = "@GDDate";
            GDDate.Value = dtGD.Value;

            CashPara.Parameter = "@Cash";
            CashPara.Value = txtCash.Text.ToUpper().Trim();
            CashDate.Parameter = "@CashDate";
            CashDate.Value = dtCash.Value;

            JobPara.Parameter = "@JobID";
            JobPara.Value = this.JobID;

            paras.Add(GDPara);
            paras.Add(GDDate);
            paras.Add(CashPara);
            paras.Add(CashDate);
            paras.Add(JobPara);

            return paras.ToArray();
        }

        private void UpdateSalesTaxInvoice()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            // If Updating Bill
             db.InsertOrUpdateRecord("usp_SalesTaxInvoiceUpdateSTInvoice", GetSTInvoiceObjects());

        }
        private void UpdateBillDetails()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            int bid;
            string particulars;
            string receiptNo;
            int you;
            int us;
            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.Cells[1].Value != DBNull.Value)
                {
                bid = Convert.ToInt32(row.Cells[0].Value);
                particulars = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value == null) receiptNo = ""; else receiptNo = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value == null) you = 0; else you = Convert.ToInt32(row.Cells[3].Value);
                if (row.Cells[4].Value == null) us = 0; else us = Convert.ToInt32(row.Cells[4].Value);
                db.InsertOrUpdateRecord("usp_BillDetailsUpdateBillDetail", GetBillDetailsObject(bid, particulars, receiptNo, you, us));
                }

            }
        }

        private void UpdateBill()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_BillsUpdateBill", GetBillObjects());
        }

        private void SaveSalesTaxInvoice()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            // If Saving New Bill
            if (!isUpdate)
            {
                db.InsertOrUpdateRecord("usp_SalesTaxInvoiceInsertNewSalesTaxInvoice", GetSTInvoiceObjects());
            }
        }

        private object GetSTInvoiceObjects()
        {
            SalesTaxInvoice st = new SalesTaxInvoice();
            st.STID = this.isUpdate ? this.SalesTaxInvoiceID : 0;
            st.SalesTaxNo = Convert.ToInt32(txtSTInvoice.Text);
            st.STDate = Convert.ToDateTime(dtBill.Value);
            st.BillID = this.BillID;
            st.Rate = Convert.ToDouble(txtSalesTaxRate.Text);
            st.SalesTax = Convert.ToInt32(txtSalesTax.Text);
            return st;
        }

        private void SaveBillDetails()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            try
            {
                int bid = 0;
                string particulars;
                string receiptNo;
                int you;
                int us;
                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    if (row.Cells[1].Value.ToString() != string.Empty)
                    {
                        particulars = row.Cells[1].Value.ToString();
                        if (row.Cells[2].Value == null) receiptNo = ""; else receiptNo = row.Cells[2].Value.ToString();
                        if (row.Cells[3].Value == null) you = 0; else you = Convert.ToInt32(row.Cells[3].Value);
                        if (row.Cells[4].Value == null) us = 0; else us = Convert.ToInt32(row.Cells[4].Value);
                        db.InsertOrUpdateRecord("usp_BillDetailsInsertNewBillDetail", GetBillDetailsObject(bid, particulars, receiptNo, you, us));
                    }                    
                }
            }
            catch (Exception ex)
            {
                RSMessageBox.ShowErrorMessage(ex.Message);
            }                       
        }

        private object GetBillDetailsObject(int id, string p, string r, int you, int us)
        {
            BillDetail bd = new BillDetail();
            bd.BillDetailsID = this.isUpdate ? id : 0;
            bd.BillID = this.BillID;
            bd.Particulars = p;
            bd.ReceiptNo = r;
            bd.ByYou = you;
            bd.ByUs = us;
            return bd;
        }

        private int GetLatestBillID()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            int Bid = Convert.ToInt32(db.GetScalarValue("usp_BillsGetLastBillID"));
            return Bid;
        }

        private void SaveBill()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            try
            {
                db.InsertOrUpdateRecord("usp_BillsInsertNewBill", GetBillObjects());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private object GetBillObjects()
        {
            Billl b =  new Billl();
            b.BillID = (this.isUpdate) ? this.BillID : 0;
            b.BillNo = Convert.ToInt32(txtBill.Text);
            b.BillDate = Convert.ToDateTime(dtBill.Value);
            b.JobID = this.JobID;
            b.SubTotal = Convert.ToInt32(txtSubTotal.Text);
            b.ServiceCharges = Convert.ToInt32(txtServiceCharges.Text);
            b.SalesTaxRate = Convert.ToDouble(txtSalesTaxRate.Text);
            b.SalesTax = Convert.ToInt32(txtSalesTax.Text);
            b.Total = Convert.ToInt32(txtTotal.Text);
            b.Refund = txtRefund.Text == string.Empty ? 0 : Convert.ToInt32(txtRefund.Text);
            b.Balance = txtBalance.Text == string.Empty ? 0 : Convert.ToInt32(txtBalance.Text);

			b.Note = txtNote.Text.ToUpper();
            return b;
        }

        private bool IsValidated()
        {
            if (txtBill.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Bill Number Required");
                txtBill.Clear();
                txtBill.Focus();
                return false;
            }
            if (txtSubTotal.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Sub Total Required");
                txtSubTotal.Clear();
                txtSubTotal.Focus();
                return false;
            }
            if (txtServiceCharges.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Service Charges");
                txtServiceCharges.Clear();
                txtServiceCharges.Focus();
                return false;
            }
            if (txtSalesTaxRate.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Sales Tax Kitna % hai ?");
                txtSalesTaxRate.Clear();
                txtSalesTaxRate.Focus();
                return false;
            }
            if (txtSalesTax.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Sales Tax Required");
                txtSalesTax.Clear();
                txtSalesTax.Focus();
                return false;
            }
            if (txtTotal.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Total Required");
                txtTotal.Clear();
                txtTotal.Focus();
                return false;
            }
            return true;
        }

        private void dgvBill_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            txtSubTotal.Text =  SumTotalByUs().ToString();
        }

        private int SumTotalByUs()
        {
            int sum = 0;

            for (int i = 0; i < dgvBill.Rows.Count; i++)
            {
                try
                {
                  sum += Convert.ToInt32(dgvBill.Rows[i].Cells[4].Value);                 
                }
                catch (Exception)
                {
                    
                }                
            }
            return sum;
        }

        private void txtServiceCharges_TextChanged(object sender, EventArgs e)
        {
            if(txtSubTotal.Text == String.Empty)
            {
                txtSubTotal.Text = "0";
            }
            if (txtServiceCharges.Text == String.Empty)
            {
                txtServiceCharges.Text = "0";
            }
            CalculateBillAmount();
        }

        private void CalculateBillAmount()
        {
            try
            {
                int subTotal = Convert.ToInt32(txtSubTotal.Text);
                double serviceCharges = Convert.ToDouble(txtServiceCharges.Text);
                double stRate = Convert.ToDouble(txtSalesTaxRate.Text);
                int st = Convert.ToInt32(serviceCharges * (stRate / 100));
                txtSalesTax.Text = st.ToString();
                txtTotal.Text = Convert.ToString(subTotal + serviceCharges + st);
            }
            catch (Exception)
            {                
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isUpdate = false;

            SearchBillJobsForm search = new SearchBillJobsForm();
            search.ShowDialog();
            this.JobID = search.JobID;

            // Add Function to Check if Bill Already Created for this Job or not

            if (!BillExist())
            {
                EnableButtons();
                ListData.ClearFormControls(this);
                dgvBill.Rows.Clear();
                LoadBillingHeadsToDataGrid();
                LoadJobDataToBillScreen(this.JobID);
                dtBill.Focus();
                // Add Sales Tax Invoice Number to Control
                txtSTInvoice.Text = Convert.ToString(AddSTInvoiceNumber());
            }
            else
            {
                RSMessageBox.ShowErrorMessage("Bill Already Exist for this Job..");
                isUpdate = false;
            }
        }

        private bool BillExist()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@JobID";
            para.Value = this.JobID;
            bool b = Convert.ToBoolean(db.GetScalarValue("usp_BillsCheckBillExist", para));
            return b;
        }

        private int AddSTInvoiceNumber()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            int stNumber;
            try
            {
                stNumber = Convert.ToInt32(db.GetScalarValue("usp_SalesTaxInvoiceGetMaxNumber")) + 1;
            }
            catch (Exception)
            {
                stNumber = 0;   
            }           
          
            return stNumber;
        }

        private void btnSearchBill_Click(object sender, EventArgs e)
        {
            SearchBillForm b = new SearchBillForm();
            b.ShowDialog();

            // Get Bill information
            BillNo = b.BillNo;
            JobID = b.JobID;
            BillID = b.BillID;
            this.isUpdate = true;
            // Load Bill Data to Form
            LoadJobDataToBillScreen(this.JobID);
            LoadBIllDetailstoDataGrid(this.BillID);
            SalesTaxInvoiceID = Convert.ToInt32(GetSTID(this.BillID));
            LoadBillDataToControls(this.BillID);
            EnableButtons();
            dtBill.Focus();

        }

        private int GetSTID(int billID)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@BillID";
            para.Value = billID;
            int st = Convert.ToInt32(db.GetScalarValue("usp_STInvoiceGetSTInvoiceByBillID", para));
            return st;
        }

        private void LoadBillDataToControls(int billID)
        {
            try
            {
                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                DBParameter para = new DBParameter();
                para.Parameter = "@BillID";
                para.Value = billID;
                DataTable dt = db.GetDataList("usp_BillsGetBillDataByID", para);
                if (dt != null)
                {
                    DataRow row = dt.Rows[0];
                    dtBill.Value = Convert.ToDateTime(row["BillDate"]);
                    txtSTInvoice.Text = row["SalesTaxNo"].ToString();
                    txtSubTotal.Text = row["SubTotal"].ToString();
                    txtServiceCharges.Text = row["ServiceCharges"].ToString();
                    txtSalesTaxRate.Text = row["SalesTaxRate"].ToString();
                    txtSalesTax.Text = row["SalesTax"].ToString();
                    txtTotal.Text = row["Total"].ToString();
                    if (Convert.ToInt32(row["Refund"]) == 0) txtRefund.Text = string.Empty;
                    else txtRefund.Text = row["Refund"].ToString();
					if (Convert.ToInt32(row["Balance"]) == 0) txtBalance.Text = string.Empty;
					else txtBalance.Text = row["Balance"].ToString();
					txtNote.Text = row["Note"].ToString();
                }
            }
            catch (Exception)
            {
                //RSMessageBox.ShowErrorMessage(ex.ToString());
            }

        }

        private void LoadBIllDetailstoDataGrid(int billID)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@BillID";
            para.Value = this.BillID;
            DataTable dt = db.GetDataList("usp_BillDetailsGetBillDetailsByBillID", para);

            dgvBill.Rows.Clear();
            dgvBill.Refresh();

            foreach (DataRow row in dt.Rows)
            {
                string BillDetailID = row["BillDetailsID"].ToString();
                string particulars = row["Particulars"].ToString();
                string rno=  row["ReceiptNo"].ToString();
                string you = row["ByYou"].ToString();
                string us = row["ByUs"].ToString();

                if (you == "0")
                {
                    you = null;
                }
                if (us == "0")
                {
                    us = null;
                }
                dgvBill.Rows.Add(BillDetailID, particulars, rno, you, us);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //RSMessageBox.ShowSuccessMessage(this.BillID.ToString());
            if (this.BillID <= 0)
            {
                RSMessageBox.ShowErrorMessage("No Bill Selected");
            }
            else
            {
                ReportSelectForm rs = new ReportSelectForm();
                rs.BillID = this.BillID;
                if (txtNote.Text != string.Empty)
                {
                    rs.note = txtNote.Text;
                    rs.ShowDialog();
                }
                else
                {
                    rs.note = string.Empty;
                    rs.ShowDialog();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                DialogResult dr = MessageBox.Show("You Sure you want to delete this bill ?", "Delete Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    DeleteLedgerEntry();
                    DeleteBillAndSTInvoice();
                    RSMessageBox.ShowSuccessMessage("Bill Deleted Successfully");
                    ListData.ClearFormControls(this);
                    dgvBill.Rows.Clear();
                    LoadBillingHeadsToDataGrid();
                }
            }
            catch (Exception ex)
            {
                RSMessageBox.ShowErrorMessage(ex.Message);                
            }
        }

        private void DeleteLedgerEntry()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter paraReff = new DBParameter();
            paraReff.Parameter = "@REFF";
            paraReff.Value = this.BillID;
            db.DeleteRecord("usp_LedgerDeleteEntry", paraReff);
        }

        private void DeleteBillAndSTInvoice()
        {
            DBParameter para = new DBParameter();
            para.Parameter = "@BillID";
            para.Value = this.BillID;
            DeleteSTInvoice(para);
            DeleteBillDetails(para);
            DeleteBill(para);
        }

        private void DeleteBill(DBParameter para)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.DeleteRecord("usp_BillsDeleteByBillID", para);
        }

        private void DeleteBillDetails(DBParameter para)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.DeleteRecord("usp_BillDetailsDeleteByBillID", para);
        }

        private void DeleteSTInvoice(DBParameter para)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.DeleteRecord("usp_SalesTaxInvoiceDeleteByBillID", para);
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                try
                {
                    CalculateBillAmount();
                }
                catch (Exception)
                {
                                        
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvBill.Rows.Add();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            int ri = dgvBill.CurrentCell.RowIndex;
            

            int BillDetailsID = Convert.ToInt32(dgvBill.Rows[this.RowIndex].Cells["bdi"].Value);
            
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter bdi = new DBParameter();
            bdi.Parameter = "@BillDetailsID";
            bdi.Value = BillDetailsID;
            db.DeleteRecord("usp_BillDetailsDeleteItemByID", bdi);
            dgvBill.Rows.RemoveAt(ri);
            txtSubTotal.Text = SumTotalByUs().ToString();
            CalculateBillAmount();
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.RowIndex = dgvBill.CurrentCell.RowIndex;         
        }

        private void btnGoUp_Click(object sender, EventArgs e)
        {
            int RowIndex = dgvBill.CurrentCell.RowIndex;
            if (RowIndex > 0)
            {
                DataGridViewRow clonedRow = (DataGridViewRow)dgvBill.Rows[RowIndex].Clone();
                DataGridViewRow oldRow = dgvBill.Rows[RowIndex];
                clonedRow.Cells[0].Value = oldRow.Cells[0].Value;
                clonedRow.Cells[1].Value = oldRow.Cells[1].Value;
                clonedRow.Cells[2].Value = oldRow.Cells[2].Value;
                clonedRow.Cells[3].Value = oldRow.Cells[3].Value;
                clonedRow.Cells[4].Value = oldRow.Cells[4].Value;
                dgvBill.Rows.RemoveAt(RowIndex);
                dgvBill.Rows.Insert(RowIndex - 1, clonedRow);
                txtSubTotal.Text = SumTotalByUs().ToString();
                CalculateBillAmount();                
            }
        }

        private void btnGoDown_Click(object sender, EventArgs e)
        {
            RowIndex = dgvBill.CurrentCell.RowIndex;
            if (RowIndex < dgvBill.Rows.Count)
            {
                DataGridViewRow clonedRow = (DataGridViewRow)dgvBill.Rows[RowIndex].Clone();
                DataGridViewRow oldRow = dgvBill.Rows[RowIndex];
                clonedRow.Cells[0].Value = oldRow.Cells[0].Value;
                clonedRow.Cells[1].Value = oldRow.Cells[1].Value;
                clonedRow.Cells[2].Value = oldRow.Cells[2].Value;
                clonedRow.Cells[3].Value = oldRow.Cells[3].Value;
                clonedRow.Cells[4].Value = oldRow.Cells[4].Value;
                dgvBill.Rows.RemoveAt(RowIndex);
                dgvBill.Rows.Insert(RowIndex + 1, clonedRow);
                txtSubTotal.Text = SumTotalByUs().ToString();
                CalculateBillAmount();
            }
        }

		private void txtRefund_TextChanged(object sender, EventArgs e)
		{
            if (txtRefund.Text == string.Empty)
            {
                txtBalance.Text = string.Empty;
            }
            else
            {
				int refund = Convert.ToInt32(txtRefund.Text);
				int total = Convert.ToInt32(txtTotal.Text);
				int balance =  total - refund;
				txtBalance.Text = balance.ToString();
			}
		}

	}
}
