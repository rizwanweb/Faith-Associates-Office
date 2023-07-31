namespace Faith_Associates.Reports.Refund
{
    partial class DepositRefund
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.cmbEYear = new System.Windows.Forms.ComboBox();
            this.txtToJob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSYear = new System.Windows.Forms.ComboBox();
            this.txtFromJob = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 59);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refund Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnShowReport);
            this.groupBox1.Controls.Add(this.cmbEYear);
            this.groupBox1.Controls.Add(this.txtToJob);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbSYear);
            this.groupBox1.Controls.Add(this.txtFromJob);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 162);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(185, 117);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 35);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(39, 117);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(140, 35);
            this.btnShowReport.TabIndex = 6;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // cmbEYear
            // 
            this.cmbEYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEYear.FormattingEnabled = true;
            this.cmbEYear.Items.AddRange(new object[] {
            "2023",
            "2022"});
            this.cmbEYear.Location = new System.Drawing.Point(210, 68);
            this.cmbEYear.Name = "cmbEYear";
            this.cmbEYear.Size = new System.Drawing.Size(148, 34);
            this.cmbEYear.TabIndex = 5;
            // 
            // txtToJob
            // 
            this.txtToJob.Location = new System.Drawing.Point(114, 69);
            this.txtToJob.Name = "txtToJob";
            this.txtToJob.Size = new System.Drawing.Size(89, 32);
            this.txtToJob.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "To Job #";
            // 
            // cmbSYear
            // 
            this.cmbSYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSYear.FormattingEnabled = true;
            this.cmbSYear.Items.AddRange(new object[] {
            "2023",
            "2022"});
            this.cmbSYear.Location = new System.Drawing.Point(210, 30);
            this.cmbSYear.Name = "cmbSYear";
            this.cmbSYear.Size = new System.Drawing.Size(148, 34);
            this.cmbSYear.TabIndex = 2;
            // 
            // txtFromJob
            // 
            this.txtFromJob.Location = new System.Drawing.Point(114, 31);
            this.txtFromJob.Name = "txtFromJob";
            this.txtFromJob.Size = new System.Drawing.Size(89, 32);
            this.txtFromJob.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "From Job #";
            // 
            // DepositRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 233);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "DepositRefund";
            this.Text = "Deposit Refund Screen";
            this.Load += new System.EventHandler(this.DepositRefund_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEYear;
        private System.Windows.Forms.TextBox txtToJob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSYear;
        private System.Windows.Forms.TextBox txtFromJob;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnShowReport;
    }
}