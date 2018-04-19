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
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        public void inertNewUser()
        {
            label3.Visible = false;

            string login = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox4.Text;

            if (login != "" && password != "" && email != "")
            {


                string conStr = "server=skr1ptfy.beget.tech;user=skr1ptfy_1;" +
                                      "database=skr1ptfy_1;password=11101110aA";

                using (MySqlConnection con = new MySqlConnection(conStr))
                {
                    try
                    {

                        string sql = "INSERT INTO `User`(Login, Password, Email ) VALUES (@a, @b, @c)";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@a", login);
                        cmd.Parameters.AddWithValue("@b", password);
                        cmd.Parameters.AddWithValue("@c", email);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Created!");
                        this.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Error!");
                    }
                }
            }
            else
            {
                label3.Text = "Input all Field";
                label3.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            inertNewUser();
        }
    }
}
