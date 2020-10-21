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
    public partial class MandateDebitForm : Form
    {
        public MandateDebitForm()
        {
            InitializeComponent();

            btnMandateDebitOk.Enabled = !string.IsNullOrWhiteSpace(tbxMandateId.Text);
            tbxMandateId.Focus();
        }

        private bool? getIsLastDebit()
            => cbxIsLastDebit.CheckState switch
            {
                CheckState.Checked => true,
                CheckState.Unchecked => false,
                _ => null,
            };

        private DateTime? getProcessDate()
        {
            if (cbxProcessDateNull.Checked) return null;

            return dtpProcessDate.Value;
        }

        private void btnMandateDebitOk_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();

            form.DirectDebit_MandateDebit(
                mandateId: tbxMandateId.Text,
                amount: (int)nudAmount.Value,
                description: tbxDescription.Text,
                processDate: getProcessDate(),
                last: getIsLastDebit());

            form.ShowDialog();
        }

        private void cbxProcessDateNull_CheckedChanged(object sender, EventArgs e)
        {
            dtpProcessDate.Enabled = !cbxProcessDateNull.Checked;
        }

        private void tbxMandateId_TextChanged(object sender, EventArgs e)
        {
            btnMandateDebitOk.Enabled = !string.IsNullOrWhiteSpace(tbxMandateId.Text);
        }

        private void btnMandateDebitCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
