using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PAYNLSDK.API.Validate;

namespace PAYNLFormsApp
{
    public partial class MandateInfoForm : Form
    {
        public MandateInfoForm()
        {
            InitializeComponent();

            btnMandateInfoOk.Enabled = !string.IsNullOrWhiteSpace(tbxMandateInfoMandateId.Text);
            tbxMandateInfoMandateId.Focus();
        }

        private void btnMandateInfoCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnMandateInfoOk_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();
            form.DirectDebit_MandateInfo(tbxMandateInfoMandateId.Text, tbxMandateInfoReferenceId.Text);
            form.ShowDialog();
        }

        private void tbxMandateInfoMandateId_TextChanged(object sender, EventArgs e)
        {
            btnMandateInfoOk.Enabled = !string.IsNullOrWhiteSpace(tbxMandateInfoMandateId.Text);
        }
    }
}
