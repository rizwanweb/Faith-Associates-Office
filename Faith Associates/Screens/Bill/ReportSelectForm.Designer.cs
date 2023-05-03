namespace Faith_Associates.Screens.Bill
{
    partial class ReportSelectForm
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
            this.rbBill = new System.Windows.Forms.RadioButton();
            this.rbST = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbBill
            // 
            this.rbBill.AutoSize = true;
            this.rbBill.Location = new System.Drawing.Point(90, 26);
            this.rbBill.Name = "rbBill";
            this.rbBill.Size = new System.Drawing.Size(64, 25);
            this.rbBill.TabIndex = 0;
            this.rbBill.TabStop = true;
            this.rbBill.Text = "Bill";
            this.rbBill.UseVisualStyleBackColor = true;
            // 
            // rbST
            // 
            this.rbST.AutoSize = true;
            this.rbST.Location = new System.Drawing.Point(90, 62);
            this.rbST.Name = "rbST";
            this.rbST.Size = new System.Drawing.Size(181, 25);
            this.rbST.TabIndex = 1;
            this.rbST.TabStop = true;
            this.rbST.Text = "Sales Tax Invoice";
            this.rbST.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(90, 93);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 32);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(198, 93);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ReportSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 143);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rbST);
            this.Controls.Add(this.rbBill);
            this.Name = "ReportSelectForm";
            this.Text = "Report Select Form";
            this.Load += new System.EventHandler(this.ReportSelectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBill;
        private System.Windows.Forms.RadioButton rbST;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
    }
}