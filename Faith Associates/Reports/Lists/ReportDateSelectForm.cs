using Faith_Associates.Reports.Bills;
using Faith_Associates.Utilities.Lists;
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
    public partial class ReportDateSelectForm : TemplateForm
    {
        public bool isSalesTaxRegister { get; set; }
        public bool isJobRegister { get; set; }
        public ReportDateSelectForm()
        {
            InitializeComponent();

        }


        private void btnView_Click(object sender, EventArgs e)
        {
            ListReportForm rp = new ListReportForm();
            rp.StartDate = dtFrom.Value;
            rp.EndDate = dtTo.Value;
            rp.isJobRegister = isJobRegister;
            rp.isSalesTaxRegister = isSalesTaxRegister;
            rp.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportDateSelectForm_Load(object sender, EventArgs e)
        {
            if (isSalesTaxRegister) lblTitle.Text = "Sales Tax Register";
            if (isJobRegister) lblTitle.Text = "Job Register";
        }
    }
}
