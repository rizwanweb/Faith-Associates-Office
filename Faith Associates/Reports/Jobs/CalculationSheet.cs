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

namespace Faith_Associates.Reports.Jobs
{
    public partial class CalculationSheet : TemplateForm
    {
        public bool isPID = false;
        public int JobID { get; set; }
        public CalculationSheet()
        {
            InitializeComponent();
        }

        private void CalculationSheet_Load(object sender, EventArgs e)
        {           
            if (isPID)
            {
                ReportDocument report = new ReportDocument();
                string appPath = Application.StartupPath;
                string reportPath = @"Reports\Jobs\NewPIDCalculationSheetReport.rpt";
                string reportFullPath = Path.Combine(appPath, reportPath);

                report.Load(reportFullPath);
                crystalReportViewer1.ReportSource = report;
                report.SetDataSource(GetPIDReportData());
            }
            else
            {
                ReportDocument report = new ReportDocument();
                string appPath = Application.StartupPath;
                string reportPath = @"Reports\Jobs\CalculationSheetReport.rpt";
                string reportFullPath = Path.Combine(appPath, reportPath);

                report.Load(reportFullPath);
                crystalReportViewer1.ReportSource = report;
                report.SetDataSource(GetJobReportData());                
            }            
        }

        private object GetPIDReportData()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@PidID";
            para.Value = this.JobID;

            DataTable dt = db.GetDataList("usp_ReportsGetNewPidDataByID", para);
            return dt;
        }

        private DataTable GetJobReportData()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@JobID";
            para.Value = this.JobID;
            
            DataTable dt = db.GetDataList("usp_ReportsGetJobDataByID", para);
            return dt;
        }
    }
}
