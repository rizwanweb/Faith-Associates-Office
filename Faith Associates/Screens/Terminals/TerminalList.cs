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

namespace Faith_Associates.Screens.Terminals
{
    public partial class TerminalList : TemplateForm
    {
        public TerminalList()
        {
            InitializeComponent();
        }

        private void TerminalList_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView();
           
        }

        private void LoadDataIntoGridView()
        {
            ListData.LoadDataIntoDataGridView(dgvTerminalList, "usp_TerminalsGetAllTerminals");
        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerminalDetailsForm terminal = new TerminalDetailsForm();
            terminal.ShowDialog();
            LoadDataIntoGridView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTerminalList_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dgvTerminalList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int terminalID = Convert.ToInt32(dgvTerminalList.Rows[rowIndex].Cells["TerminalID"].Value);

            ShowTerminalDetailsForm(terminalID, true);
        }

        private void ShowTerminalDetailsForm(int terminalID, bool isUpdated)
        {
            TerminalDetailsForm terminal = new TerminalDetailsForm();
            terminal.TerminalID = terminalID;
            terminal.isUpdate = isUpdated;
            terminal.ShowDialog();
            LoadDataIntoGridView();            
        }
    }
}
