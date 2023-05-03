using CrystalDecisions.CrystalReports.Engine;
using Faith_Associates.Models;
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
    public partial class MReport : TemplateForm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public MReport()
        {
            InitializeComponent();     
        }


        private void MReport_Load(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            string appPath = Application.StartupPath;
            string reportPath = @"Reports\Clients\BalanceSheet.rpt";
            string reportFullPath = Path.Combine(appPath, reportPath);

            report.Load(reportFullPath);
            crystalReportViewer1.ReportSource = report;

            report.SetDataSource(GetBillReportData());
            report.SetParameterValue("ClientName", ClientName);
        }
        private DataTable GetBillReportData()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DataTable dt = db.GetDataList("usp_ReportBalanceSheet", GetObjects());
            return dt;
        }

        private object GetObjects()
        {
            BalanceSheet bl = new BalanceSheet();
            bl.StartDate = this.StartDate;
            bl.EndDate = this.EndDate;
            bl.ClientID = this.ClientID;
            return bl;
        }
    }
}
