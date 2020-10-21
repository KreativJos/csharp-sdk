namespace PAYNLFormsApp
{
    partial class MandateInfoForm
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
            this.tbxMandateInfoMandateId = new System.Windows.Forms.TextBox();
            this.tbxMandateInfoReferenceId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMandateInfoOk = new System.Windows.Forms.Button();
            this.btnMandateInfoCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxMandateInfoMandateId
            // 
            this.tbxMandateInfoMandateId.Location = new System.Drawing.Point(213, 30);
            this.tbxMandateInfoMandateId.Name = "tbxMandateInfoMandateId";
            this.tbxMandateInfoMandateId.Size = new System.Drawing.Size(251, 23);
            this.tbxMandateInfoMandateId.TabIndex = 0;
            this.tbxMandateInfoMandateId.TextChanged += new System.EventHandler(this.tbxMandateInfoMandateId_TextChanged);
            // 
            // tbxMandateInfoReferenceId
            // 
            this.tbxMandateInfoReferenceId.Location = new System.Drawing.Point(213, 71);
            this.tbxMandateInfoReferenceId.Name = "tbxMandateInfoReferenceId";
            this.tbxMandateInfoReferenceId.Size = new System.Drawing.Size(251, 23);
            this.tbxMandateInfoReferenceId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mandate Id *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference Id";
            // 
            // btnMandateInfoOk
            // 
            this.btnMandateInfoOk.Location = new System.Drawing.Point(309, 112);
            this.btnMandateInfoOk.Name = "btnMandateInfoOk";
            this.btnMandateInfoOk.Size = new System.Drawing.Size(75, 23);
            this.btnMandateInfoOk.TabIndex = 2;
            this.btnMandateInfoOk.Text = "OK";
            this.btnMandateInfoOk.UseVisualStyleBackColor = true;
            this.btnMandateInfoOk.Click += new System.EventHandler(this.btnMandateInfoOk_Click);
            // 
            // btnMandateInfoCancel
            // 
            this.btnMandateInfoCancel.Location = new System.Drawing.Point(390, 112);
            this.btnMandateInfoCancel.Name = "btnMandateInfoCancel";
            this.btnMandateInfoCancel.Size = new System.Drawing.Size(75, 23);
            this.btnMandateInfoCancel.TabIndex = 2;
            this.btnMandateInfoCancel.Text = "Cancel";
            this.btnMandateInfoCancel.UseVisualStyleBackColor = true;
            this.btnMandateInfoCancel.Click += new System.EventHandler(this.btnMandateInfoCancel_Click);
            // 
            // MandateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 152);
            this.Controls.Add(this.btnMandateInfoCancel);
            this.Controls.Add(this.btnMandateInfoOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxMandateInfoReferenceId);
            this.Controls.Add(this.tbxMandateInfoMandateId);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MandateInfoForm";
            this.Text = "MandateInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMandateInfoMandateId;
        private System.Windows.Forms.TextBox tbxMandateInfoReferenceId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMandateInfoOk;
        private System.Windows.Forms.Button btnMandateInfoCancel;
    }
}
