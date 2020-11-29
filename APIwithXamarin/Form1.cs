using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIwithXamarin
{
    public partial class Form1 : Form
    {
        CovidAPI CAPI;

        public Form1()
        {
            InitializeComponent();

            CAPI = new CovidAPI();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid-19-coronavirus-statistics.p.rapidapi.com/v1/total?country=" + textBox1.Text),
                Headers =
            {
                { "x-rapidapi-key", "7ab2f6eae9msh7c5a0dc76fd6e4dp120a5fjsn68768a5398bd" },
                { "x-rapidapi-host", "covid-19-coronavirus-statistics.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                richTextBox1.Text = body;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int output = await CAPI.ReturnDeaths(textBox1.Text);

            textBox2.Text = output.ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int output = await CAPI.ReturnRecovered(textBox1.Text);

            textBox3.Text = output.ToString();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            int output = await CAPI.ReturnConfirmed(textBox1.Text);

            textBox4.Text = output.ToString();
        }
    }
}
