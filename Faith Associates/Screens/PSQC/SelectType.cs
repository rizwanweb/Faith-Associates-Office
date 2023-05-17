using Faith_Associates.Screens.Jobs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Screens.PSQC
{
    public partial class SelectType : TemplateForm
    {
        public bool isPID { get; set; }
        public bool isJob { get; set; }

        public SelectType()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbJob.Checked == true )
            {
                SearchJobsForm s = new SearchJobsForm();
                s.ShowDialog();
                this.isJob = true;                
            }
            if (rbPid.Checked == true)
            {
                SearchPidsForm s = new SearchPidsForm();
                s.ShowDialog();
                this.isPID = true;
            }
        }
    }
}
