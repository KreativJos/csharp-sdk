namespace PAYNLFormsApp
{
    partial class MandateRecurringAddForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxBankaccountHolder = new System.Windows.Forms.TextBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.tbxBankaccountNumber = new System.Windows.Forms.TextBox();
            this.tbxBankaccountBic = new System.Windows.Forms.TextBox();
            this.dtpProcessDate = new System.Windows.Forms.DateTimePicker();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxIpAddress = new System.Windows.Forms.TextBox();
            this.tbxExchangeUrl = new System.Windows.Forms.TextBox();
            this.tbxCurrency = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxProcessDateNull = new System.Windows.Forms.CheckBox();
            this.nudIntervalValue = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cobIntervalPeriod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(327, 376);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxBankaccountHolder
            // 
            this.tbxBankaccountHolder.Location = new System.Drawing.Point(244, 42);
            this.tbxBankaccountHolder.Name = "tbxBankaccountHolder";
            this.tbxBankaccountHolder.Size = new System.Drawing.Size(236, 23);
            this.tbxBankaccountHolder.TabIndex = 2;
            this.tbxBankaccountHolder.TextChanged += new System.EventHandler(this.requiredFields_ValueChanged);
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(360, 13);
            this.nudAmount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudAmount.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 23);
            this.nudAmount.TabIndex = 3;
            this.nudAmount.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // tbxBankaccountNumber
            // 
            this.tbxBankaccountNumber.Location = new System.Drawing.Point(244, 71);
            this.tbxBankaccountNumber.Name = "tbxBankaccountNumber";
            this.tbxBankaccountNumber.Size = new System.Drawing.Size(236, 23);
            this.tbxBankaccountNumber.TabIndex = 2;
            this.tbxBankaccountNumber.TextChanged += new System.EventHandler(this.requiredFields_ValueChanged);
            // 
            // tbxBankaccountBic
            // 
            this.tbxBankaccountBic.Location = new System.Drawing.Point(244, 150);
            this.tbxBankaccountBic.Name = "tbxBankaccountBic";
            this.tbxBankaccountBic.Size = new System.Drawing.Size(236, 23);
            this.tbxBankaccountBic.TabIndex = 2;
            // 
            // dtpProcessDate
            // 
            this.dtpProcessDate.Location = new System.Drawing.Point(279, 180);
            this.dtpProcessDate.Name = "dtpProcessDate";
            this.dtpProcessDate.Size = new System.Drawing.Size(200, 23);
            this.dtpProcessDate.TabIndex = 4;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(244, 325);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(235, 23);
            this.tbxEmail.TabIndex = 2;
            // 
            // tbxIpAddress
            // 
            this.tbxIpAddress.Location = new System.Drawing.Point(244, 296);
            this.tbxIpAddress.Name = "tbxIpAddress";
            this.tbxIpAddress.Size = new System.Drawing.Size(236, 23);
            this.tbxIpAddress.TabIndex = 2;
            // 
            // tbxExchangeUrl
            // 
            this.tbxExchangeUrl.Location = new System.Drawing.Point(244, 267);
            this.tbxExchangeUrl.Name = "tbxExchangeUrl";
            this.tbxExchangeUrl.Size = new System.Drawing.Size(236, 23);
            this.tbxExchangeUrl.TabIndex = 2;
            // 
            // tbxCurrency
            // 
            this.tbxCurrency.Location = new System.Drawing.Point(244, 238);
            this.tbxCurrency.Name = "tbxCurrency";
            this.tbxCurrency.Size = new System.Drawing.Size(236, 23);
            this.tbxCurrency.TabIndex = 2;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(244, 209);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(236, 23);
            this.tbxDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bankaccount Holder *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Amount *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bankaccount Number *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bankaccount BIC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Process Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Currency";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Exchange Url";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(176, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "IP Address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(202, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Email";
            // 
            // cbxProcessDateNull
            // 
            this.cbxProcessDateNull.AutoSize = true;
            this.cbxProcessDateNull.Location = new System.Drawing.Point(23, 185);
            this.cbxProcessDateNull.Name = "cbxProcessDateNull";
            this.cbxProcessDateNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxProcessDateNull.Size = new System.Drawing.Size(48, 19);
            this.cbxProcessDateNull.TabIndex = 6;
            this.cbxProcessDateNull.Text = "Null";
            this.cbxProcessDateNull.UseVisualStyleBackColor = true;
            this.cbxProcessDateNull.CheckedChanged += new System.EventHandler(this.cbxProcessDateNull_CheckedChanged);
            // 
            // nudIntervalValue
            // 
            this.nudIntervalValue.Location = new System.Drawing.Point(360, 100);
            this.nudIntervalValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudIntervalValue.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudIntervalValue.Name = "nudIntervalValue";
            this.nudIntervalValue.Size = new System.Drawing.Size(120, 23);
            this.nudIntervalValue.TabIndex = 3;
            this.nudIntervalValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Interval Value *";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(147, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Interval Period *";
            // 
            // cobIntervalPeriod
            // 
            this.cobIntervalPeriod.FormattingEnabled = true;
            this.cobIntervalPeriod.Location = new System.Drawing.Point(244, 126);
            this.cobIntervalPeriod.Name = "cobIntervalPeriod";
            this.cobIntervalPeriod.Size = new System.Drawing.Size(236, 23);
            this.cobIntervalPeriod.TabIndex = 7;
            // 
            // MandateRecurringAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 410);
            this.Controls.Add(this.cobIntervalPeriod);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudIntervalValue);
            this.Controls.Add(this.cbxProcessDateNull);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxCurrency);
            this.Controls.Add(this.tbxExchangeUrl);
            this.Controls.Add(this.tbxIpAddress);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.dtpProcessDate);
            this.Controls.Add(this.tbxBankaccountBic);
            this.Controls.Add(this.tbxBankaccountNumber);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.tbxBankaccountHolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MandateRecurringAddForm";
            this.Text = "Bankaccount Number";
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        #endregion

        private System.Windows.Forms.TextBox tbxBankaccountHolder;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.TextBox tbxBankaccountNumber;
        private System.Windows.Forms.TextBox tbxBankaccountBic;
        private System.Windows.Forms.DateTimePicker dtpProcessDate;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.TextBox tbxIpAddress;
        private System.Windows.Forms.TextBox tbxExchangeUrl;
        private System.Windows.Forms.TextBox tbxCurrency;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbxProcessDateNull;
        private System.Windows.Forms.NumericUpDown nudIntervalValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cobIntervalPeriod;
    }
}