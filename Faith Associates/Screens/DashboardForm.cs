using Faith_Associates.Models.Users;
using Faith_Associates.Reports.Bills;
using Faith_Associates.Screens.Bill;
using Faith_Associates.Screens.Clients;
using Faith_Associates.Screens.Items;
using Faith_Associates.Screens.Jobs;
using Faith_Associates.Screens.Lolos;
using Faith_Associates.Screens.PSQC;
using Faith_Associates.Screens.ShippingLines;
using Faith_Associates.Screens.Terminals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Screens
{
    public partial class DashboardForm : TemplateForm
    {
        public DashboardForm()
        {
            InitializeComponent();
            this.Text += " " + Application.ProductVersion.ToString();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = LoggedInUser.Username;
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ClientDetailsForm client = new ClientDetailsForm();
            client.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientList clients = new ClientList();
            clients.ShowDialog();
        }

        private void terminalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerminalList terminals = new TerminalList();
            terminals.ShowDialog();
        }

        private void shippingLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShippingLineList shippingLineList = new ShippingLineList();
            shippingLineList.ShowDialog();
        }

        private void lOLOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoloList lolo = new LoloList();
            lolo.ShowDialog();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemListScreen itemListScreen = new ItemListScreen();
            itemListScreen.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ItemDetailsScreen itemDetailsScreen = new ItemDetailsScreen();
            itemDetailsScreen.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            JobEntryForm job = new JobEntryForm();
            job.ShowDialog();
        }


        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            BillScreen bill = new BillScreen();
            bill.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            NewPidEntryForm pid = new NewPidEntryForm();
            pid.ShowDialog();
        }

        private void billHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillHeadersForm headersForm = new BillHeadersForm();
            headersForm.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            PidBillScreen pidBill = new PidBillScreen();
            pidBill.ShowDialog();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientBalanceSheetForm clientBalanceSheetForm = new ClientBalanceSheetForm();
            clientBalanceSheetForm.ShowDialog();

        }

        private void jobRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDateSelectForm reportDateSelectForm = new ReportDateSelectForm();
            reportDateSelectForm.isJobRegister = true;
            reportDateSelectForm.ShowDialog();

        }

        private void salesTaxRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDateSelectForm reportDateSelectForm = new ReportDateSelectForm();
            reportDateSelectForm.isSalesTaxRegister = true;
            reportDateSelectForm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ShippingLineDetailsForm shippingLineDetailsForm = new ShippingLineDetailsForm();
            shippingLineDetailsForm.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            TerminalDetailsForm terminalDetailsForm = new TerminalDetailsForm();
            terminalDetailsForm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            LoloDetailsForm loloDetailsForm = new LoloDetailsForm();
            loloDetailsForm.ShowDialog();
        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientPortal cp = new ClientPortal();
            cp.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.ShowDialog();
        }

        private void pSQCAJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSQCForm psqc = new PSQCForm();
            psqc.ShowDialog();
        }
    }
}
