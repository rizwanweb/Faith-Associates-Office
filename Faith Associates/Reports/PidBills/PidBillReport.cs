using CrystalDecisions.CrystalReports.Engine;
using Faith_Associates.Screens;
using Faith_Associates.Utilities;
using RSDBFramework;
using RSDBFramework.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Reports.Bills
{
    public partial class PidBillReport : TemplateForm
    {
        public int BID { get; set; }
        public PidBillReport()
        {
            InitializeComponent();     
        }


        private void BillReport_Load(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            string appPath = Application.StartupPath;
            string reportPath = @"Reports\PidBills\PidBillReport.rpt";
            string reportFullPath = Path.Combine(appPath, reportPath);

            report.Load(reportFullPath);
            crystalReportViewer1.ReportSource = report;

            report.SetDataSource(GetBillReportData());
        }
        private DataTable GetBillReportData()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@BillID";
            para.Value = this.BID;
            DataTable dt = db.GetDataList("usp_ReportsGePidtBillDataByBillID", para);
            return dt;
        }
    }
}
