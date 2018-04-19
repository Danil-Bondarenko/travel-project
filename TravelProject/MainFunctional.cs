using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelProject
{
    public partial class MainFunctional : Form
    {
        private Stopwatch _stopWatch = new Stopwatch();
        public MainFunctional()
        {
            InitializeComponent();
            
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Українська")
            {
                label1.Text = "Вибрати готель:";
                label2.Text = "Вибрати ресторан:";
                label3.Text = "Вибрати розваги:";
                label4.Text = "Час подорожі:";
                groupBox2.Text = "Мова";
                groupBox1.Text = "Опції";
                button1.Text = "Зберегти";

            }
            else
            {
                label1.Text = "Select  hostel:";
                label2.Text = "Select  restaurant:";
                label3.Text = "Select entertainment:";
                label4.Text = "Select  time:";
                groupBox2.Text = "Language";
                groupBox1.Text = "Options";
                button1.Text = "Save";
            }
        }

        private string GET(string Url, out string done)
        {
            WebRequest req = WebRequest.Create(Url);
            WebResponse resp = req.GetResponse();
            string l = req.RequestUri.ToString();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            done = sr.ReadToEnd();
            sr.Close();

            return done;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = comboBox5.SelectedItem.ToString();
            time = Regex.Replace(time, " hours", "");
            int minutes = Int32.Parse(time)*60;
            int progres = minutes / 100;
            if(_stopWatch.Elapsed.Minutes % progres == 0 && _stopWatch.Elapsed.Minutes != 0)
            {
                progressBar1.Increment(+1);
                if(progressBar1.Value % 10 == 0)
                {
                    label6.Text = "Прошло " + progressBar1.Value + "процентов";
                }
            }
          
            label5.Text = string.Format("{0:00}:{1:00}:{2:00}", _stopWatch.Elapsed.Hours, _stopWatch.Elapsed.Minutes, _stopWatch.Elapsed.Seconds);     
            if(progressBar1.Value == 100)
            {
                timer1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            _stopWatch.Reset();
            _stopWatch.Start();

            progressBar1.Maximum = 100;
            //for (int i = 0; i < 100; i++)
            //{
            //    progressBar1.Value = i;
            //    System.Threading.Thread.Sleep(100);
            //}
        }
    }
}
