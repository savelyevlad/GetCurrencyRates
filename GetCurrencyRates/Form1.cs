using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections;

namespace GetCurrencyRates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            txtResponse.Text = "eur: " + CurrencyRatesInformation.getCurrencyRate("eur") + System.Environment.NewLine +
                               "usd: " + CurrencyRatesInformation.getCurrencyRate("usd") + System.Environment.NewLine +
                               "uah: " + CurrencyRatesInformation.getCurrencyRate("uah");
        }
    }
}
