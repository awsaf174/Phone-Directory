using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneDirectory
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                string sql = "select * from person where username='" + textBox2.Text + "'and password='" + textBox1.Text + "'";
                try
                {
                    DataTable dt = DataAccess.GetDataTable(sql);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                    else
                    {
                        string utype = dt.Rows[0]["user_type"].ToString();
                        if(radioButton1.Checked && utype.Equals(radioButton1.Text))
                        {
                            MessageBox.Show("Succesfully logged in");
                            Form1 f1 = new Form1(dt);
                            f1.Show();
                            this.Hide();
                   
                        }
                        else if (radioButton2.Checked && utype.Equals(radioButton1.Text))
                        {
                            MessageBox.Show("Choose correct usertype");
                        }
                        else if (radioButton1.Checked && utype.Equals(radioButton2.Text))
                        {
                            MessageBox.Show("Choose correct usertype");
                        }

                        else
                        {
                            MessageBox.Show("Succesfully logged in");
                            Form2 f2 = new Form2(dt);
                            f2.Show();
                            this.Hide();
                        }
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                MessageBox.Show("Choose your user type!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
