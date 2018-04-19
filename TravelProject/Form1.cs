using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void func_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            label4.Visible = false;

            string login = textBox1.Text;
            string password = textBox2.Text;
            List<String> res = new List<string>();

            res = checkInfo(login, password);

            if(res.Count == 1)
            {
                label4.Text = res[0].ToString();
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            if (res.Count > 1)
            {
              if(res[1].ToString() == password)
                {
                    this.Hide();
                    MainFunctional func = new MainFunctional();
                    func.Show();
                    func.FormClosed += new FormClosedEventHandler(func_FormClosed);

                }
                else
                {
                    label4.Text = "Incorrect Password";
                    label4.Visible = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
           
       


        }

        public List<String> checkInfo(string login, string password)
        {
            List<String> array = new List<String>();
            string conStr = "server=skr1ptfy.beget.tech;user=skr1ptfy_1;" +
                                 "database=skr1ptfy_1;password=11101110aA";

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {

                    string sql = "Select Login,Password From User WHERE Login = @a";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@a", login);
                    con.Open();
                    cmd.ExecuteNonQuery();
                   string znachenie = cmd.ExecuteScalar().ToString();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            login = reader["Login"].ToString();
                            password = reader["Password"].ToString();
                            
                        }
                    }
                    array.Add(login);
                    array.Add(password);

                    return array;
                }
                catch (Exception ex)
                {
                    List<String> error = new List<String>();
                    if (ex.Message == "Ссылка на объект не указывает на экземпляр объекта.")
                    {                      
                        error.Add("Can't find User");
                        return error;
                    }
                    return error;

                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reg registration = new Reg();
            registration.Show();
        }
    }
}
