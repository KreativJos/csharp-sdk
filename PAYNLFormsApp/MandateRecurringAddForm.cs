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
using PAYNLSDK.Enums;

namespace PAYNLFormsApp
{
    public partial class MandateRecurringAddForm : Form
    {
        public MandateRecurringAddForm()
        {
            InitializeComponent();

            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbxBankaccountHolder.Text)
                && !string.IsNullOrWhiteSpace(tbxBankaccountNumber.Text);

            cobIntervalPeriod.DataSource = Enum.GetValues(typeof(MandateInterval)).Cast<MandateInterval>()
                .Select(i => new KeyValuePair<string, int>(i.ToString(), (int)i))
                .ToList();
            cobIntervalPeriod.DisplayMember = "Key";
            cobIntervalPeriod.ValueMember = "Value";

            nudAmount.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private DateTime? getProcessDate()
        {
            if (cbxProcessDateNull.Checked) return null;

            return dtpProcessDate.Value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();

            form.DirectDebit_MandateRecurringAdd(
                amount: (int)nudAmount.Value,
                bankaccountHolder: tbxBankaccountHolder.Text,
                bankaccountNumber: tbxBankaccountNumber.Text,
                intervalValue: 1,
                intervalPeriod: MandateInterval.Week,
                bankaccountBic: tbxBankaccountBic.Text,
                processDate: getProcessDate(),
                description: tbxDescription.Text,
                currency: tbxCurrency.Text,
                exchangeUrl: tbxExchangeUrl.Text,
                ipAddress: tbxIpAddress.Text,
                email: tbxEmail.Text,
                promotorId: null,
                tool: null,
                info: null,
                objectData: null,
                extra1: null,
                extra2: null,
                extra3: null
            );

            form.ShowDialog();
        }

        private void requiredFields_ValueChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbxBankaccountHolder.Text)
                && !string.IsNullOrWhiteSpace(tbxBankaccountNumber.Text);
        }

        private void cbxProcessDateNull_CheckedChanged(object sender, EventArgs e)
        {
            dtpProcessDate.Enabled = !cbxProcessDateNull.Checked;
        }
    }
}

