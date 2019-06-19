using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClientWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonTest_Click(object sender, EventArgs e)
        {
            string inputData = textBoxInputData.Text;
            string webApiBaseUrl = ConfigurationManager.AppSettings["SerkoWebApiUrl"];
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(inputData);
                    var response = await client.PostAsync(string.Format("{0}{1}", webApiBaseUrl, "Expense/ProcessEmailText"), stringContent);
                    var result = await response.Content.ReadAsStringAsync();
                    textBoxResult.Text = result;
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
