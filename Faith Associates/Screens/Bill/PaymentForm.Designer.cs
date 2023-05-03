namespace Faith_Associates.Screens.Bill
{
    partial class PaymentForm
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
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.rbPayorder = new System.Windows.Forms.RadioButton();
            this.rbOnline = new System.Windows.Forms.RadioButton();
            this.rbCheck = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 66);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(707, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "RECEIVE PAYMENT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOther);
            this.groupBox1.Controls.Add(this.lblNum);
            this.groupBox1.Controls.Add(this.txtDetail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtPaymentDate);
            this.groupBox1.Controls.Add(this.rbPayorder);
            this.groupBox1.Controls.Add(this.rbOnline);
            this.groupBox1.Controls.Add(this.rbCheck);
            this.groupBox1.Controls.Add(this.rbCash);
            this.groupBox1.Controls.Add(this.txtPayment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbClient);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 142);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(603, 64);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(73, 25);
            this.rbOther.TabIndex = 13;
            this.rbOther.TabStop = true;
            this.rbOther.Text = "Other";
            this.rbOther.UseVisualStyleBackColor = true;
            this.rbOther.CheckedChanged += new System.EventHandler(this.rbOther_CheckedChanged);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(264, 99);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(64, 21);
            this.lblNum.TabIndex = 12;
            this.lblNum.Text = "Detail";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(334, 99);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(342, 26);
            this.txtDetail.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Date";
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.CustomFormat = "dd-MM-yyyy";
            this.dtPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPaymentDate.Location = new System.Drawing.Point(148, 96);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(110, 26);
            this.dtPaymentDate.TabIndex = 8;
            // 
            // rbPayorder
            // 
            this.rbPayorder.AutoSize = true;
            this.rbPayorder.Location = new System.Drawing.Point(500, 63);
            this.rbPayorder.Name = "rbPayorder";
            this.rbPayorder.Size = new System.Drawing.Size(100, 25);
            this.rbPayorder.TabIndex = 7;
            this.rbPayorder.TabStop = true;
            this.rbPayorder.Text = "Payorder";
            this.rbPayorder.UseVisualStyleBackColor = true;
            this.rbPayorder.CheckedChanged += new System.EventHandler(this.rbPayorder_CheckedChanged);
            // 
            // rbOnline
            // 
            this.rbOnline.AutoSize = true;
            this.rbOnline.Location = new System.Drawing.Point(412, 62);
            this.rbOnline.Name = "rbOnline";
            this.rbOnline.Size = new System.Drawing.Size(82, 25);
            this.rbOnline.TabIndex = 6;
            this.rbOnline.TabStop = true;
            this.rbOnline.Text = "Online";
            this.rbOnline.UseVisualStyleBackColor = true;
            this.rbOnline.CheckedChanged += new System.EventHandler(this.rbOnline_CheckedChanged);
            // 
            // rbCheck
            // 
            this.rbCheck.AutoSize = true;
            this.rbCheck.Location = new System.Drawing.Point(333, 62);
            this.rbCheck.Name = "rbCheck";
            this.rbCheck.Size = new System.Drawing.Size(73, 25);
            this.rbCheck.TabIndex = 5;
            this.rbCheck.TabStop = true;
            this.rbCheck.Text = "Check";
            this.rbCheck.UseVisualStyleBackColor = true;
            this.rbCheck.CheckedChanged += new System.EventHandler(this.rbCheck_CheckedChanged);
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(263, 62);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(64, 25);
            this.rbCash.TabIndex = 4;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.CheckedChanged += new System.EventHandler(this.rbCash_CheckedChanged);
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Cascadia Code", 13F);
            this.txtPayment.Location = new System.Drawing.Point(148, 61);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(110, 28);
            this.txtPayment.TabIndex = 3;
            this.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Payment Amount";
            // 
            // cmbClient
            // 
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(148, 26);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(528, 29);
            this.cmbClient.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Received From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 167);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(222, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 21);
            this.label11.TabIndex = 6;
            this.label11.Text = "966454.00";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "8467.00";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "12345.00";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label7.Location = new System.Drawing.Point(6, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "Remaining Balance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Applied Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Amount Due";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(337, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 167);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(252, 116);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 34);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(132, 116);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 34);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 47);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(342, 63);
            this.textBox1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "Memo";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 403);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "PaymentForm";
            this.Text = "Receive Payment";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPaymentDate;
        private System.Windows.Forms.RadioButton rbPayorder;
        private System.Windows.Forms.RadioButton rbOnline;
        private System.Windows.Forms.RadioButton rbCheck;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbOther;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
    }
}