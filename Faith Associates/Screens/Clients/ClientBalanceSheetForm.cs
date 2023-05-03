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
    public partial class ClientBalanceSheetForm : TemplateForm
    {
        public ClientBalanceSheetForm()
        {
            InitializeComponent();
        }

        private void ClientBalanceSheetForm_Load(object sender, EventArgs e)
        {
            ListData.LoadDataIntoComboBox(cmbClient, "usp_ClientsGetClientsForComboBox");
            cmbClient.DisplayMember = "ClientName";
            cmbClient.ValueMember = "ClientID";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MReport rp = new MReport();
            rp.StartDate = dtFrom.Value;
            rp.EndDate = dtTo.Value;
            rp.ClientID = Convert.ToInt32(cmbClient.SelectedValue);
            rp.ClientName = cmbClient.Text;
            
            rp.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
