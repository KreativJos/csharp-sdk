namespace PAYNLFormsApp
{
    public partial class MandateDebitForm
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
            this.btnMandateDebitOk = new System.Windows.Forms.Button();
            this.btnMandateDebitCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxMandateId = new System.Windows.Forms.TextBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpProcessDate = new System.Windows.Forms.DateTimePicker();
            this.cbxProcessDateNull = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxIsLastDebit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMandateDebitOk
            // 
            this.btnMandateDebitOk.Location = new System.Drawing.Point(323, 182);
            this.btnMandateDebitOk.Name = "btnMandateDebitOk";
            this.btnMandateDebitOk.Size = new System.Drawing.Size(75, 23);
            this.btnMandateDebitOk.TabIndex = 1;
            this.btnMandateDebitOk.Text = "OK";
            this.btnMandateDebitOk.Click += new System.EventHandler(this.btnMandateDebitOk_Click);
            // 
            // btnMandateDebitCancel
            // 
            this.btnMandateDebitCancel.Location = new System.Drawing.Point(404, 182);
            this.btnMandateDebitCancel.Name = "btnMandateDebitCancel";
            this.btnMandateDebitCancel.Size = new System.Drawing.Size(75, 23);
            this.btnMandateDebitCancel.TabIndex = 0;
            this.btnMandateDebitCancel.Text = "Cancel";
            this.btnMandateDebitCancel.Click += new System.EventHandler(this.btnMandateDebitCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Amount (cents)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mandate Id *";
            // 
            // tbxMandateId
            // 
            this.tbxMandateId.Location = new System.Drawing.Point(190, 12);
            this.tbxMandateId.Name = "tbxMandateId";
            this.tbxMandateId.Size = new System.Drawing.Size(290, 23);
            this.tbxMandateId.TabIndex = 3;
            this.tbxMandateId.TextChanged += new System.EventHandler(this.tbxMandateId_TextChanged);
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(360, 42);
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 23);
            this.nudAmount.TabIndex = 4;
            this.nudAmount.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(190, 71);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(290, 23);
            this.tbxDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // dtpProcessDate
            // 
            this.dtpProcessDate.Location = new System.Drawing.Point(278, 101);
            this.dtpProcessDate.Name = "dtpProcessDate";
            this.dtpProcessDate.Size = new System.Drawing.Size(200, 23);
            this.dtpProcessDate.TabIndex = 5;
            // 
            // cbxProcessDateNull
            // 
            this.cbxProcessDateNull.AutoSize = true;
            this.cbxProcessDateNull.Location = new System.Drawing.Point(212, 104);
            this.cbxProcessDateNull.Name = "cbxProcessDateNull";
            this.cbxProcessDateNull.Size = new System.Drawing.Size(60, 19);
            this.cbxProcessDateNull.TabIndex = 6;
            this.cbxProcessDateNull.Text = "Empty";
            this.cbxProcessDateNull.UseVisualStyleBackColor = true;
            this.cbxProcessDateNull.CheckedChanged += new System.EventHandler(this.cbxProcessDateNull_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Process Date";
            // 
            // cbxIsLastDebit
            // 
            this.cbxIsLastDebit.AutoSize = true;
            this.cbxIsLastDebit.Location = new System.Drawing.Point(123, 130);
            this.cbxIsLastDebit.Name = "cbxIsLastDebit";
            this.cbxIsLastDebit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxIsLastDebit.Size = new System.Drawing.Size(78, 19);
            this.cbxIsLastDebit.TabIndex = 7;
            this.cbxIsLastDebit.Text = "Last Debit";
            this.cbxIsLastDebit.ThreeState = true;
            this.cbxIsLastDebit.UseVisualStyleBackColor = true;
            // 
            // MandateDebitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 217);
            this.Controls.Add(this.cbxIsLastDebit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxProcessDateNull);
            this.Controls.Add(this.dtpProcessDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.tbxMandateId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMandateDebitCancel);
            this.Controls.Add(this.btnMandateDebitOk);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MandateDebitForm";
            this.Text = "Description";
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnMandateDebitOk;
        private System.Windows.Forms.Button btnMandateDebitCancel;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxMandateId;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpProcessDate;
        private System.Windows.Forms.CheckBox cbxProcessDateNull;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxIsLastDebit;
    }
}