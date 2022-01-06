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
    public partial class Add_Person : Form
    {
        DataTable mytable;
        public Add_Person(DataTable table)
        {
            InitializeComponent();
            mytable = table;
        }

        private void Add_Person_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectdbDataSet3.Group_' table. You can move, or remove it, as needed.
            this.group_TableAdapter1.Fill(this.projectdbDataSet3.Group_);
            // TODO: This line of code loads data into the 'projectdbDataSet2.User' table. You can move, or remove it, as needed.
            this.userTableAdapter1.Fill(this.projectdbDataSet2.User);
            // TODO: This line of code loads data into the 'projectdbDataSet1.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.projectdbDataSet1.User);
            // TODO: This line of code loads data into the 'projectdbDataSet.Group_' table. You can move, or remove it, as needed.
            this.group_TableAdapter.Fill(this.projectdbDataSet.Group_);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            Form1 f = new Form1(mytable);
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = true;
            string name = textBox1.Text;
            string number = textBox2.Text.ToString();
            string email = textBox3.Text.ToString();
            string Uname = textBox4.Text.ToString();
            string add = textBox5.Text.ToString();
            string pw = textBox6.Text.ToString();
            string group = comboBox1.Text;
            string utype = comboBox2.Text;
            DateTime bday = Convert.ToDateTime(dateTimePicker1.Text);
            string gender = "";
            string G_ID = comboBox1.SelectedValue.ToString();
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            
            if (textBox1.Text == "")
            {
                success = false;
                MessageBox.Show("Please provide your name");

            }
            if (textBox2.Text == "")
            {
                success = false;
                MessageBox.Show("Please provide your number");
            }
            if (textBox3.Text == "")
            {
                success = false;
                MessageBox.Show("Please provide your email");
            }
            if (textBox4.Text == "")
            {
                success = false;
                MessageBox.Show("Please choose your username");
            }
            if (textBox6.Text == "")
            {
                success = false;
                MessageBox.Show("Please choose a password");
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                success = false;
                MessageBox.Show("Please choose your gender");
            }
            if (success == true)
            {
                string sql1 = "insert into person(name,password,dob,gender,User_type,Username) values('" + name + "','" + pw + "','" + bday + "','" + gender + "','" + utype + "','" + Uname + "')";
                string sql2 = "insert into contact(c_name,c_address,c_number,c_email,user_name,c_group)values('" + name + "','" + add + "','" + number + "','" + email + "','" + Uname + "','" + group + "')";
                string sql3 = "insert into pgroup(username,G_id,pw,group_) values('"+Uname+"','" + G_ID + "','" + pw + "','" + group + "')";

                try
                {
                    DataAccess.ExecuteSQL(sql1);
                    DataAccess.ExecuteSQL(sql2);
                    DataAccess.ExecuteSQL(sql3);
                    MessageBox.Show("Person successfully added");
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
