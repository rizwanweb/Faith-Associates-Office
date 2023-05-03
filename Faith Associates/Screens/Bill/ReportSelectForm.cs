using Faith_Associates.Reports.Bills;
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
    public partial class ReportSelectForm : TemplateForm
    {
        public int BillID { get; set; }
        public ReportSelectForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportSelectForm_Load(object sender, EventArgs e)
        {
            rbBill.Checked = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rbBill.Checked)
            {
                BillReport bp = new BillReport();
                bp.BID = this.BillID;
                
                bp.Show();
            }
            else if (rbST.Checked)
            {
                STReport stp = new STReport();
                stp.BID = this.BillID;
                stp.Show();
            }
            else
            {
                RSMessageBox.ShowErrorMessage("Select Report");
            }
        }
    }
}
