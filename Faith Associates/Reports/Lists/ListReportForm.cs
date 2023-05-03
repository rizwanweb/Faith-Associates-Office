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
    public partial class ListReportForm : TemplateForm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isSalesTaxRegister { get; set; }
        public bool isJobRegister { get; set; }
        public ListReportForm()
        {
            InitializeComponent();
        }


        private void ListReportForm_Load(object sender, EventArgs e)
        {
            if (isSalesTaxRegister)
            {
                ReportDocument report = new ReportDocument();
                string appPath = Application.StartupPath;
                string reportPath = @"Reports\Lists\SalesTaxRegister.rpt";
                string reportFullPath = Path.Combine(appPath, reportPath);
                report.Load(reportFullPath);
                crystalReportViewer1.ReportSource = report;
                report.SetDataSource(GetSalesTaxReportData());
            }

            if (isJobRegister)
            {
                ReportDocument report = new ReportDocument();
                string appPath = Application.StartupPath;
                string reportPath = @"Reports\Lists\JobRegister.rpt";
                string reportFullPath = Path.Combine(appPath, reportPath);
                report.Load(reportFullPath);
                crystalReportViewer1.ReportSource = report;
                report.SetDataSource(GetJobRegisterReportData());
            }
        }

        private object GetSalesTaxReportData()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DataTable dt = db.GetDataList("usp_ReportsSalesTaxRegister", GetDBParameters());
            return dt;
        }
        private object GetJobRegisterReportData()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DataTable dt = db.GetDataList("usp_ReportJobRegister", GetDBParameters());
            return dt;
        }

        private DBParameter[] GetDBParameters(){
        
            List<DBParameter> parameters = new List<DBParameter>();

            DBParameter p1 = new DBParameter();
            p1.Parameter = "@StartDate";
            p1.Value = this.StartDate;
            parameters.Add(p1);

            DBParameter p2 = new DBParameter();
            p2.Parameter = "@EndDate";
            p2.Value = this.EndDate;
            parameters.Add(p2);

            return parameters.ToArray();
        
        }

    }
}
