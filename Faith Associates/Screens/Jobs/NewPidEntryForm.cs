using Faith_Associates.Models.Jobs;
using Faith_Associates.Reports.Jobs;
using Faith_Associates.Screens.Clients;
using Faith_Associates.Screens.Items;
using Faith_Associates.Screens.Lolos;
using Faith_Associates.Screens.ShippingLines;
using Faith_Associates.Screens.Terminals;
using Faith_Associates.Utilities;
using Faith_Associates.Utilities.Lists;
using RSDBFramework;
using RSDBFramework.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

namespace Faith_Associates.Screens.Jobs
{
    public partial class NewPidEntryForm : TemplateForm
    {
        public int PidID { get; set; }
        public int PayorderID { get; set; }
        public NewPidEntryForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewPidEntryForm_Load(object sender, EventArgs e)
        {
            LoadClientIntoComboBox();
            LoadItemsIntoComboBox();
            LoadLolosIntoComboBox();
            LoadTerminalsIntoComboBox();
            LoadShippingLinesIntoComboBox();
            enableDeleteBtn();
            if (!isUpdate)
            {
                LoadPayorderListtoDataGrid();
            }
        }

        private void LoadPayorderListtoDataGrid()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DataTable dt = db.GetDataList("usp_PayorderHeadersGetAllHeaders");
            foreach (DataRow row in dt.Rows)
            {
                string particular = row[1].ToString();
                string details = row[2].ToString();
                dgvPayorders.Rows.Add("",particular, string.Empty, details);
            }
        }

        private void enableDeleteBtn()
        {
            if (isUpdate) btnDelete.Enabled = true; else btnDelete.Enabled = false;
        }

        private void LoadClientIntoComboBox()
        {

            ListData.LoadDataIntoComboBox(cmbClient, "usp_ClientsGetClientsForComboBox");

            cmbClient.DisplayMember = "ClientName";
            cmbClient.ValueMember = "ClientID";
            cmbClient.SelectedIndex = -1;
        }
        private void LoadItemsIntoComboBox()
        {

            ListData.LoadDataIntoComboBox(cmbItem, "usp_ItemsGetItemsForComboBox");

            cmbItem.DisplayMember = "ItemName";
            cmbItem.ValueMember = "ItemID";
            cmbItem.SelectedIndex = -1;
        }
        private void LoadTerminalsIntoComboBox()
        {

            ListData.LoadDataIntoComboBox(cmbTerminal, "usp_TerminalsGetAllTerminals");

            cmbTerminal.DisplayMember = "TerminalName";
            cmbTerminal.ValueMember = "TerminalID";
            cmbTerminal.SelectedIndex = -1;
        }
        private void LoadShippingLinesIntoComboBox()
        {

            ListData.LoadDataIntoComboBox(cmbShippingLine, "usp_ShippingLinesGetAllShippingLines");

            cmbShippingLine.DisplayMember = "ShippingLineName";
            cmbShippingLine.ValueMember = "ShippingLineID";
            cmbShippingLine.SelectedIndex = -1;
        }
        private void LoadLolosIntoComboBox()
        {

            ListData.LoadDataIntoComboBox(cmbLolo, "usp_LOLOsGetAllLolos");

            cmbLolo.DisplayMember = "LoloName";
            cmbLolo.ValueMember = "LoloID";
            cmbLolo.SelectedIndex = -1;
        }

        private void cmbClient_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //int id = Convert.ToInt32(((DataRowView)cmbClient.SelectedValue)["ClientID"]);
            int id = Convert.ToInt32(cmbClient.SelectedValue);
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter parameter = new DBParameter();
            parameter.Parameter = "@ClientID";
            parameter.Value = Convert.ToInt32(cmbClient.SelectedValue);
            DataTable dt = db.GetDataList("usp_ClientGetClientDetailByID", parameter);
            DataRow row = dt.Rows[0];
            txtContactPerson.Text = row["ContactPerson"].ToString();
            txtAddress.Text = row["Address"].ToString();
        }

        private void cmbItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadItemDutyStructure();
        }

        private void LoadItemDutyStructure()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@ItemID";
            para.Value = Convert.ToInt32(cmbItem.SelectedValue);
            DataTable dt = db.GetDataList("usp_ItemsGetItemByID", para);
            DataRow row = dt.Rows[0];
            // Duty Types
            txtCDType.Text = ReturnDutyType(row, "CustomDutyType");
            txtACDType.Text = ReturnDutyType(row, "AddCustomDutyType");
            txtSTType.Text = "%";
            txtITType.Text = "%";
            txtCessType.Text = ReturnDutyType(row, "CessType");
            txtRDType.Text = ReturnDutyType(row, "RDType");

            // Duty Rates
            txtCDRate.Text = row["CustomDuty"].ToString();
            txtACDRate.Text = row["AddCustomDuty"].ToString();
            txtSTRate.Text = row["SalesTax"].ToString();
            txtITRate.Text = row["IncomeTax"].ToString();
            txtCessRate.Text = row["Cess"].ToString();
            txtRDRate.Text = row["RD"].ToString();

        }

        private string ReturnDutyType(DataRow r, string col)
        {
            string val = r[col].ToString();
            if (val == "1") return "F";
            if (val == "2") return "%";
            return null;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientDetailsForm clientDetailsForm = new ClientDetailsForm();
            clientDetailsForm.ShowDialog();
            LoadClientIntoComboBox();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            ItemDetailsScreen item = new ItemDetailsScreen();
            item.ShowDialog();
            LoadItemsIntoComboBox();
        }

        private void btnAddTerminal_Click(object sender, EventArgs e)
        {
            TerminalDetailsForm terminal = new TerminalDetailsForm();
            terminal.ShowDialog();
            LoadTerminalsIntoComboBox();
        }

        private void btnAddShippingLine_Click(object sender, EventArgs e)
        {
            ShippingLineDetailsForm sl = new ShippingLineDetailsForm();
            sl.ShowDialog();
            LoadShippingLinesIntoComboBox();
        }

        private void btnAddLolo_Click(object sender, EventArgs e)
        {
            LoloDetailsForm lolo = new LoloDetailsForm();
            lolo.ShowDialog();
            LoadLolosIntoComboBox();
        }

        private int CalculateValueInPKR()
        {
            try
            {
                double valueInPKR;
                double exRate = Convert.ToDouble(txtEXRate.Text);
                double invoiceUSD = Convert.ToDouble(txtInvoiceUSD.Text);
                valueInPKR = exRate * invoiceUSD;
                return Convert.ToInt32(valueInPKR);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private int CalculateLandingCharges()
        {
            double valueInPKR = CalculateValueInPKR();
            double insurance = Convert.ToDouble(txtInsurance.Text);
            double landingCharges = (valueInPKR +insurance) * 0.01;
            return Convert.ToInt32(Math.Round(landingCharges, MidpointRounding.AwayFromZero));
        }

        private int CalculateImportValuePKR()
        {
            int pkr = CalculateValueInPKR();
            int ins = Convert.ToInt32(txtInsurance.Text);
            int landingCharges = CalculateLandingCharges();
            return pkr + ins + landingCharges;
        }

        private void txtInsurance_Validated(object sender, EventArgs e)
        {
            if (txtQuantity.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Quantity");
                txtQuantity.Clear();
                txtQuantity.Focus();
            }
            else if (cmbItem.SelectedIndex == -1)
            {
                RSMessageBox.ShowErrorMessage("Select Item");
                cmbItem.Focus();
            }
            else if (txtEXRate.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Exchange Rate..");
                txtEXRate.Clear();
                txtEXRate.Focus();
            }
            else if (txtInvoiceUSD.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Invoice Value..");
                txtInvoiceUSD.Clear();
                txtInvoiceUSD.Focus();
            }
            else
            {
                try
                {
                    //Import Value Calculation
                    txtLandingCharges.Text = CalculateLandingCharges().ToString();
                    txtValuePKR.Text = CalculateValueInPKR().ToString();
                    txtImportPKR.Text = CalculateImportValuePKR().ToString();

                    // Duty Calculation
                    txtCD.Text = CalculateCustomDuty();
                    txtACD.Text = CalculateAddCD();
                    txtST.Text = CalculateSalesTax();
                    txtIT.Text = CalculateIncomeTax();

                    if (txtCessRate.Text != String.Empty || Convert.ToDouble(txtCessRate.Text) > 0)
                    {
                        txtCess.Text = CalculateCess();
                    }
                    else
                    {
                        txtCess.Text = "";
                    }
                    if (txtRDRate.Text != String.Empty || Convert.ToDouble(txtRDRate.Text) > 0)
                    {
                        txtRD.Text = CalculateRD();
                    }
                    else
                    {
                        txtCess.Text = "";
                    }

                    // Get Total
                    try
                    {
                        int cd, acd, st, it, cess, rd;
                        if (Convert.ToInt32(txtCD.Text) > 0) cd = Convert.ToInt32(txtCD.Text); else cd = 0;
                        if (Convert.ToInt32(txtACD.Text) > 0) acd = Convert.ToInt32(txtACD.Text); else acd = 0;
                        if (Convert.ToInt32(txtST.Text) > 0) st = Convert.ToInt32(txtST.Text); else st = 0;
                        if (Convert.ToInt32(txtIT.Text) > 0) it = Convert.ToInt32(txtIT.Text); else it = 0;
                        if (Convert.ToInt32(txtCess.Text) > 0) cess = Convert.ToInt32(txtCess.Text); else cess = 0;
                        if (Convert.ToInt32(txtRD.Text) > 0) rd = Convert.ToInt32(txtRD.Text); else rd = 0;

                        int Total = cd + acd + st + it + cess + rd;
                        txtTotal.Text = Total.ToString();
                    }
                    catch (Exception t)
                    {
                        RSMessageBox.ShowErrorMessage("There is some problem.. " + t.ToString());
                    }

                }
                catch (Exception ex)
                {
                    RSMessageBox.ShowErrorMessage("There is Error. Check Fields" + ex.Message);
                    txtLandingCharges.Clear();
                    txtValuePKR.Clear();
                    txtImportPKR.Clear();
                    txtInsurance.Focus();
                }
            }
        }

        private string CalculateCess()
        {
            try
            {
                double quantity = Convert.ToDouble(txtQuantity.Text);
                double cessRate = Convert.ToDouble(txtCessRate.Text) / 1000;
                int cess = Convert.ToInt32(quantity * cessRate);
                return cess.ToString();
            }
            catch (Exception e)
            {
                RSMessageBox.ShowErrorMessage(e.ToString());
                return "";
            }
        }
        private string CalculateRD()
        {
            try
            {
                double pkr = CalculateImportValuePKR();
                double rdRate = Convert.ToDouble(txtRDRate.Text) / 100;
                int cess = Convert.ToInt32(pkr * rdRate);
                return cess.ToString();
            }
            catch (Exception e)
            {
                RSMessageBox.ShowErrorMessage(e.ToString());
                return "";
            }
        }
        private string CalculateIncomeTax()
        {
            try
            {
                double importValuePKR = CalculateImportValuePKR();
                double cd = Convert.ToDouble(CalculateCustomDuty());
                double acd = Convert.ToDouble(CalculateAddCD());
                double st = Convert.ToDouble(CalculateSalesTax());
                double amount = importValuePKR + cd + acd + st;
                double itRate = Convert.ToDouble(txtITRate.Text);
                int it = Convert.ToInt32(amount * (itRate / 100));
                return it.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string CalculateSalesTax()
        {
            try
            {
                double importValuePKR = CalculateImportValuePKR();
                double cd = Convert.ToDouble(CalculateCustomDuty());
                double acd = Convert.ToDouble(CalculateAddCD());
                double cess = Convert.ToDouble(CalculateCess());
                double amount = importValuePKR + cd + acd + cess;
                double stRate = Convert.ToDouble(txtSTRate.Text);
                int st = Convert.ToInt32(amount * (stRate / 100));
                return st.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string CalculateAddCD()
        {
            try
            {
                double importValuePKR = CalculateImportValuePKR();
                double acdRate = Convert.ToDouble(txtACDRate.Text);
                int addCustomDuty;
                addCustomDuty = Convert.ToInt32(importValuePKR * (acdRate / 100));
                return addCustomDuty.ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }

        private string CalculateCustomDuty()
        {
            double importValuePKR = CalculateImportValuePKR();
            double cdRate = Convert.ToDouble(txtCDRate.Text);
            double quantity = Convert.ToDouble(txtQuantity.Text);
            string cdType = txtCDType.Text;
            int customDuty;
            try
            {
                if (cdType == "%")
                {
                    customDuty = Convert.ToInt32(importValuePKR * (cdRate / 100));
                    return customDuty.ToString();
                }
                else if (cdType == "F")
                {
                    customDuty = Convert.ToInt32((quantity / 1000) * cdRate);
                    return customDuty.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidated())
            {                    
                if (isUpdate)
                {
                    try
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                            db.InsertOrUpdateRecord("usp_PidsUpdatePid", GetObjects());

                            // update job payorders
                            UpdateJobPayorders();
                            RSMessageBox.ShowSuccessMessage("Pid Updated...");
                            ListData.ClearFormControls(this);
                            dgvPayorders.Rows.Clear();
                            LoadPayorderListtoDataGrid();
                            btnPrint.Focus();
                            isUpdate = false;
                            ts.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        RSMessageBox.ShowErrorMessage("There is problem " + ex.Message.ToString());
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        //Check if job exist already or not
                        if (!CheckIfJobExist())
                        {
                            using (TransactionScope ts = new TransactionScope())
                            {
                                this.isUpdate = false;
                                this.PidID = 0;
                                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                                db.InsertOrUpdateRecord("usp_PidsInsertNewPid", GetObjects());

                                this.PidID = Convert.ToInt32(db.GetScalarValue("usp_PidsGetLastPidID"));

                                // Insert Payorder List to Database
                                SaveJobPayorders();
                                RSMessageBox.ShowSuccessMessage("Pid Added Successfully...");
                                ListData.ClearFormControls(this);
                                dgvPayorders.Rows.Clear();
                                LoadPayorderListtoDataGrid();
                                ts.Complete();
                            }

                            btnPrint.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        RSMessageBox.ShowErrorMessage("There is problem " + ex.Message.ToString());
                        throw;
                    }
                }
            }            
        }

        private void UpdateJobPayorders()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            try
            {
                int pid;
                string particulars;
                int amount;
                string detail;

                foreach (DataGridViewRow row in dgvPayorders.Rows)
                {
                    pid = Convert.ToInt32(row.Cells[0].Value);
                    particulars = row.Cells[1].Value.ToString();
                    //amount = Convert.ToInt32(row.Cells[2].Value.ToString()); //row.Cells[2].Value.ToString() == null ? 0 : Convert.ToInt32(row.Cells[2].Value.ToString());
                    //detail = row.Cells[3].Value.ToString();

                        
                    if (row.Cells[2].Value.ToString() == string.Empty || row.Cells[2].Value.ToString() == null) amount = 0;
                    else amount = Convert.ToInt32(row.Cells[2].Value.ToString());

                    if (row.Cells[3].Value.ToString() == String.Empty)
                        detail = String.Empty; 
                    else 
                        detail = row.Cells[3].Value.ToString();

                    db.InsertOrUpdateRecord("usp_PidPayorderUpdatePayorder", GetPayorderObjects(pid, particulars, amount, detail));





                }
            }
            catch (Exception ex)
            {
                RSMessageBox.ShowErrorMessage(ex.Message);
                throw;
            }
        }

        private void SaveJobPayorders()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            try
            {
                int pid = 0;
                string particulars;
                int amount;
                string detail;

                foreach (DataGridViewRow row in dgvPayorders.Rows)
                {
                    particulars = row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value.ToString() == String.Empty) amount = 0; else amount = Convert.ToInt32(row.Cells[2].Value.ToString());
                    if (row.Cells[3].Value.ToString() == String.Empty) detail = String.Empty; else detail = row.Cells[3].Value.ToString();

                    db.InsertOrUpdateRecord("usp_PidPayorderInsertNewPayorder", GetPayorderObjects(pid, particulars, amount, detail));
                }
            }
            catch (Exception ex)
            {
                RSMessageBox.ShowErrorMessage(ex.Message);
                throw;
            }
        }

        private object GetPayorderObjects(int pid, string particulars, int amount, string detail)
        {
            PidPayorder p = new PidPayorder();
            
            p.PayorderID = this.isUpdate ? pid : 0;
            p.PidID = this.PidID;
            p.Particular = particulars;
            p.Amount = amount;
            p.Detail = detail;
            return p;
        }

        private object GetObjects()
        {
            Pid j = new Pid();

            j.PidID = (this.isUpdate) ? this.PidID : 0;
            j.PidNo = Convert.ToInt32(txtJobNo.Text);
            j.PidDate = dtJob.Value;
            j.Client = Convert.ToInt32(cmbClient.SelectedValue);
            j.LC = txtLC.Text.Trim().ToUpper();
            j.LCDate = dtLC.Value;
            j.Item = Convert.ToInt32(cmbItem.SelectedValue);
            j.ItemDetail = txtItemDetail.Text.Trim().ToUpper();
            if (txtContainer.Text == String.Empty) j.Containers = 0; else j.Containers = Convert.ToInt32(txtContainer.Text);
            if (txtSize.Text == String.Empty) j.Size = 0; else j.Size = Convert.ToInt32(txtSize.Text);
            j.Packages = txtPackages.Text.Trim().ToUpper();
            j.Vessel = txtVessel.Text.Trim().ToUpper();
            j.BL = txtBL.Text.Trim().ToUpper();
            j.BLDate = dtBL.Value;
            j.IGM = Convert.ToInt32(txtIGM.Text);
            j.IGMDate = dtIGM.Value;
            j.IndexNo = Convert.ToInt32(txtIndex.Text);
            j.Quantity = Convert.ToInt32(txtQuantity.Text);
            j.InvoiceValueUSD = Convert.ToDouble(txtInvoiceUSD.Text);
            j.ExchangeRate = Convert.ToDouble(txtEXRate.Text);
            j.ValueInPKR = Convert.ToInt32(txtValuePKR.Text);
            j.Insurance = Convert.ToInt32(txtInsurance.Text);
            j.LandingCharges = Convert.ToInt32(txtLandingCharges.Text);
            j.ImportValuePKR = Convert.ToInt32(txtImportPKR.Text);
            j.CustomDuty = Convert.ToInt32(txtCD.Text);
            j.CustomDutyType = txtCDType.Text;
            j.CustomDutyRate = Convert.ToDouble(txtCDRate.Text);
            j.AddCustomDuty = Convert.ToInt32(txtACD.Text);
            j.AddCustomDutyType = txtACDType.Text;
            j.AddCustomDutyRate = Convert.ToDouble(txtACDRate.Text);
            j.SalesTax = Convert.ToInt32(txtST.Text);
            j.SalesTaxType = txtSTType.Text;
            j.SalesTaxRate = Convert.ToDouble(txtSTRate.Text);
            j.IncomeTax = Convert.ToInt32(txtIT.Text);
            j.IncomeTaxType = txtITType.Text;
            j.IncomeTaxRate = Convert.ToDouble(txtITRate.Text);
            j.Cess = Convert.ToInt32(txtCess.Text);
            j.CessType = txtCessType.Text;
            j.CessRate = Convert.ToDouble(txtCessRate.Text);
            j.RD = Convert.ToInt32(txtRD.Text);
            j.RDType = txtRDType.Text;
            j.RDRate = Convert.ToDouble(txtRDRate.Text);
            j.TotalDuty = Convert.ToInt32(txtTotal.Text);

            j.Terminal = Convert.ToInt32(cmbTerminal.SelectedValue);
            j.ShippingLine = Convert.ToInt32(cmbShippingLine.SelectedValue);
            j.Lolo = Convert.ToInt32(cmbLolo.SelectedValue);

            j.GD = String.Empty;
            j.GDDate = DateTime.Now;
            j.Cash = String.Empty;
            j.CashDate = DateTime.Now;

            return j;
        }


        private bool isValidated()
        {

            if (txtJobNo.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Job No.");
                txtJobNo.Clear();
                txtJobNo.Focus();
                return false;
            }
            if (cmbClient.SelectedIndex == -1)
            {
                RSMessageBox.ShowErrorMessage("Select Client from List.");
                cmbClient.Focus();
                return false;
            }
            if (txtIGM.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("IGM Kidher hai bhai ?");
                txtIGM.Focus();
                return false;
            }
            if (txtIndex.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Index Number.");
                txtIndex.Focus();
                return false;
            }
            if (txtVessel.Text == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Vessel Name.");
                txtVessel.Focus();
                return false;
            }

            return true;
        }


        private bool CheckIfJobExist()
        {
            try
            {
                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                bool ifJobExist = Convert.ToBoolean(db.GetScalarValue("usp_PidsCheckPidDetails", GetParameters()));

                if (ifJobExist)
                {
                    RSMessageBox.ShowErrorMessage("Pid Already Exist");
                    return true;
                }
                else
                {                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                RSMessageBox.ShowErrorMessage(ex.Message);
            }
            return false;
        }

        private DBParameter[] GetParameters()
        {
            List<DBParameter> parameters = new List<DBParameter>();
            DBParameter p1 = new DBParameter();
            p1.Parameter = "@PidNo";
            p1.Value = Convert.ToInt32(txtJobNo.Text);
            parameters.Add(p1);

            DBParameter p2 = new DBParameter();
            p2.Parameter = "@Year";
            p2.Value = Convert.ToInt32(dtJob.Value.Year);
            parameters.Add(p2);

            return parameters.ToArray();
        }

        private void btnJobSearch_Click(object sender, EventArgs e)
        {
            this.PidID = 0;
            isUpdate = false;
            SearchPidsForm search = new SearchPidsForm();
            search.ShowDialog();
            isUpdate = search.isUpdate;
            PidID = search.PidID;

            if (isUpdate)
            {
                LoadDataIntoJobEntryFormIfUpdate();
                dgvPayorders.Rows.Clear();
                //TODO :  Load Payorder to Data grid view
                LoadPayorderToDGV();
                enableDeleteBtn();
            }
        }

        private void LoadPayorderToDGV()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@PidID";
            para.Value = this.PidID;
            DataTable dt = db.GetDataList("usp_PayorderHeaderGetHeaderByPidID", para);

            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr[0]);
                string p = dr["Particular"].ToString();
                string a = dr["Amount"].ToString();
                string d = dr["Detail"].ToString();

                if (a == "0") a = string.Empty;               

                dgvPayorders.Rows.Add(id, p, a, d);
            }

        }

        private void LoadDataIntoJobEntryFormIfUpdate()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter
            {
                Parameter = "@PidID",
                Value = this.PidID
            };
            DataTable dt = db.GetDataList("usp_PidsGetPidByID", para);
            DataRow row = dt.Rows[0];

            txtJobNo.Text = row["PidNo"].ToString();
            dtJob.Value = Convert.ToDateTime(row["PidDate"]);
            cmbClient.SelectedValue = row["Client"];
            txtContactPerson.Text = row["ContactPerson"].ToString();
            txtAddress.Text = row["Address"].ToString();
            cmbItem.SelectedValue = row["Item"];
            txtItemDetail.Text = row["ItemDetail"].ToString();
            if (row["Containers"].ToString() == "0") txtContainer.Text = String.Empty; else txtContainer.Text = row["Containers"].ToString();
            if (row["Size"].ToString() == "0") txtSize.Text = String.Empty; else txtSize.Text = row["Size"].ToString();
            txtPackages.Text = row["Packages"].ToString();
            txtLC.Text = row["LC"].ToString();
            dtLC.Value = Convert.ToDateTime(row["LCDate"]);
            txtBL.Text = row["BL"].ToString();
            dtBL.Value = Convert.ToDateTime(row["BLDate"]);
            txtIGM.Text = row["IGM"].ToString();
            dtIGM.Value = Convert.ToDateTime(row["IGMDate"]);
            txtIndex.Text = row["IndexNo"].ToString();
            txtVessel.Text = row["Vessel"].ToString();

            cmbTerminal.SelectedValue = row["Terminal"];
            cmbShippingLine.SelectedValue = row["ShippingLine"];
            cmbLolo.SelectedValue = row["Lolo"];

            txtQuantity.Text = row["Quantity"].ToString();
            txtEXRate.Text = row["ExchangeRate"].ToString();
            txtInvoiceUSD.Text = row["InvoiceValueUSD"].ToString();
            txtInsurance.Text = row["Insurance"].ToString();
            txtLandingCharges.Text = row["LandingCharges"].ToString();
            txtValuePKR.Text = row["ValueInPKR"].ToString();
            txtImportPKR.Text = row["ImportValuePKR"].ToString();
            txtCDType.Text = row["CustomDutyType"].ToString();
            txtCDRate.Text = row["CustomDutyRate"].ToString();
            txtCD.Text = row["CustomDuty"].ToString();
            txtACDType.Text = row["AddCustomDutyType"].ToString();
            txtACDRate.Text = row["AddCustomDutyRate"].ToString();
            txtACD.Text = row["AddCustomDuty"].ToString();
            txtSTType.Text = row["SalesTaxType"].ToString();
            txtSTRate.Text = row["SalesTaxRate"].ToString();
            txtST.Text = row["SalesTax"].ToString();
            txtITType.Text = row["IncomeTaxType"].ToString();
            txtITRate.Text = row["IncomeTaxRate"].ToString();
            txtIT.Text = row["IncomeTax"].ToString();
            txtCessType.Text = row["CessType"].ToString();
            txtCessRate.Text = row["CessRate"].ToString();
            txtCess.Text = row["Cess"].ToString();
            txtRDType.Text = row["RDType"].ToString();
            txtRDRate.Text = row["RDRate"].ToString();
            txtRD.Text = row["RD"].ToString();
            txtTotal.Text = row["TotalDuty"].ToString();
        }


        // Numeric Value Validation

        private void txtJobNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtContainer_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSize_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtIGM_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtIndex_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtQuantity_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtInvoiceUSD_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtInsurance_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtCDRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtACDRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtSTRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtITRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtCessRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtRDRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtCD_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtACD_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtST_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtIT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtCess_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtRD_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtEXRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.PidID <= 0)
            {
                RSMessageBox.ShowErrorMessage("No Pid Selected");
            }
            else
            {
                CalculationSheet cs = new CalculationSheet();
                cs.isPID = true;
                cs.JobID = this.PidID;
                cs.ShowDialog();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this job ?",
                "Warning", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                try
                {
                    DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                    DBParameter para = new DBParameter();
                    para.Parameter = "@PidID";
                    para.Value = this.PidID;
                    db.DeleteRecord("usp_PidPayordersDeleteByPidID", para);
                    db.DeleteRecord("usp_PidsDeletePid", para);

                    //Delete from Job Payorders

                    RSMessageBox.ShowSuccessMessage("Pid Deleted Successfully..");
                    ListData.ClearFormControls(this);
                    LoadPayorderListtoDataGrid();
                    this.PidID = 0;
                    txtJobNo.Focus();
                }
                catch (Exception ex)
                {
                    RSMessageBox.ShowErrorMessage("Problem Deleting Pid.. " + ex.Message.ToString());                    
                }               
            }
        }

        // Duty Customize functions
        private void txtCDRate_Leave(object sender, EventArgs e)
        {
            txtCD.Clear();
            txtCD.Text = CalculateCustomDuty();
        }

        private void txtACDRate_Leave(object sender, EventArgs e)
        {
            txtACD.Clear();
            txtACD.Text = CalculateAddCD();
        }

        private void txtSTRate_Leave(object sender, EventArgs e)
        {
            txtST.Clear();
            txtST.Text = CalculateSalesTax();
        }

        private void txtITRate_Leave(object sender, EventArgs e)
        {
            txtIT.Clear();
            txtIT.Text = CalculateIncomeTax();
        }

        private void txtCessRate_Leave(object sender, EventArgs e)
        {
            txtCess.Clear();
            txtCess.Text = CalculateCess();
        }


        private void cmbTerminal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@TerminalID";
            para.Value = Convert.ToInt32(cmbTerminal.SelectedValue);
            DataTable dt = db.GetDataList("usp_TerminalsGetTerminalDetailByID", para);

            string searchValue = "WHARFAGE";
            foreach (DataGridViewRow row in dgvPayorders.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(searchValue))
                {
                    DataRow r = dt.Rows[0];
                    row.Cells[1].Value = r["ShortName"] + " WHARFAGE";
                    row.Cells[3].Value = r["TerminalName"];
                }
            }
        }

        private void cmbShippingLine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@ShippingLineID";
            para.Value = Convert.ToInt32(cmbShippingLine.SelectedValue);
            DataTable dt = db.GetDataList("usp_ShippingLinesGetShippingLineDetailByID", para);

            
            foreach (DataGridViewRow row in dgvPayorders.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals("DELIVERY ORDER".Trim()) || 
                    row.Cells[1].Value.ToString().Equals("CONTAINER DEPOSIT".Trim()) || 
                    row.Cells[1].Value.ToString().Equals("CONTAINER RENT".Trim()))
                {
                    DataRow r = dt.Rows[0];
                    row.Cells[3].Value = r["ShippingLineName"];
                }
            }
        }

        private void cmbLolo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@LoloID";
            para.Value = Convert.ToInt32(cmbLolo.SelectedValue);
            DataTable dt = db.GetDataList("usp_LOLOsGetLoloDetailByID", para);


            foreach (DataGridViewRow row in dgvPayorders.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals("LIFT ON LIFT OFF".Trim()))
                {
                    DataRow r = dt.Rows[0];
                    row.Cells[3].Value = r["LoloName"];
                }
            }
        }


    }
}
