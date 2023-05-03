using Faith_Associates.Screens.Jobs;
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
    public partial class ClientList : TemplateForm
    {
        public ClientList()
        {
            InitializeComponent();
        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView();           
        }

        private void LoadDataIntoGridView()
        {
            ListData.LoadDataIntoDataGridView(dgvClientList, "usp_ClientGetAllClients");
        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientDetailsForm client = new ClientDetailsForm();
            client.ShowDialog();
            LoadDataIntoGridView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvClientList_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dgvClientList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int clientID = Convert.ToInt32(dgvClientList.Rows[rowIndex].Cells["ClientID"].Value);

            ShowClientDetailsForm(clientID, true);
        }

        private void ShowClientDetailsForm(int clientID, bool isUpdated)
        {
            ClientDetailsForm client = new ClientDetailsForm();
            client.ClientID = clientID;
            client.isUpdate = isUpdated;
            client.ShowDialog();
            LoadDataIntoGridView();            
        }
    }
}
