using CrystalDecisions.CrystalReports.Engine;
using Faith_Associates.Screens;
using Faith_Associates.Utilities;
using RSDBFramework;
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

namespace Faith_Associates.Reports.Refund
{
    public partial class RefundReportViewer : TemplateForm
    {
        public int FromJob { get; set; }
        public int ToJob { get; set; }
        public int SYear { get; set; }
        public int EYear { get; set; }

        public RefundReportViewer()
        {
            InitializeComponent();
        }

        private void RefundReportViewer_Load(object sender, EventArgs e)
        {
            LoadRefundReport();
        }

        private void LoadRefundReport()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            List<DBParameter> paraList = new List<DBParameter>();

            DBParameter fJobPara = new DBParameter() { Parameter = "@JobStart", Value = this.FromJob};
            DBParameter TJobPara = new DBParameter() { Parameter = "@JobEnd", Value = this.ToJob };
            DBParameter sYearPara = new DBParameter() { Parameter = "@SYEAR", Value = this.SYear };
            DBParameter eYearPara = new DBParameter() { Parameter = "@EYEAR", Value = this.EYear };

            paraList.Add(fJobPara);
            paraList.Add(TJobPara);
            paraList.Add(sYearPara);
            paraList.Add(eYearPara);


            DataTable dt = db.GetDataList("usp_ReportDepositRefundDetailByJob", paraList.ToArray());

            ReportDocument report = new ReportDocument();
            string appPath = Application.StartupPath;
            string reportPath = @"Reports\Refund\DepositRefundReport.rpt";
            string reportFullPath = Path.Combine(appPath, reportPath);
            report.Load(reportFullPath);
            crystalReportViewer1.ReportSource = report;
            report.SetDataSource(dt);
        }
    }
}
