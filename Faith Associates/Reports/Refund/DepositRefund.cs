using Faith_Associates.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Reports.Refund
{
    public partial class DepositRefund : TemplateForm
    {
        public DepositRefund()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            int fjob = Convert.ToInt32(txtFromJob.Text);
            int tjob = Convert.ToInt32(txtToJob.Text);
            int syear = Convert.ToInt32(cmbSYear.Text);
            int eyear = Convert.ToInt32(cmbEYear.Text);

            RefundReportViewer r = new RefundReportViewer();
            r.FromJob = fjob;
            r.ToJob = tjob;
            r.SYear = syear;
            r.EYear = eyear;
            r.ShowDialog();
        }

        private void DepositRefund_Load(object sender, EventArgs e)
        {
            cmbEYear.SelectedIndex = 0;
            cmbSYear.SelectedIndex = 0;
        }
    }
}
