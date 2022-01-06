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
    public partial class Search : Form
    {
        DataTable mytable;
        public Search(DataTable table)
        {
            InitializeComponent();
            mytable = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter a detail of the person you want to search for");
            }
            else
            {
                try
                {

                    if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
                    {
                        if (radioButton1.Checked)
                        {
                            string sql = "select name, dob,gender, user_type,c_number,c_address,c_email,c_id,c_group from person,contact where name like '%" + textBox1.Text + "%' and person.name=contact.c_name";
                            DataTable dt = DataAccess.GetDataTable(sql);
                            dataGridView1.DataSource = dt;

                        }
                        if (radioButton2.Checked)
                        {
                            string sql = "select name,dob,gender,user_type,c_number,c_address,c_email,c_id,c_group,g_id from person,contact,Pgroup where c_number=" + textBox1.Text + " and person.name=contact.c_name and contact.c_group=pgroup.group_";
                            DataTable dt = DataAccess.GetDataTable(sql);
                            dataGridView1.DataSource = dt;
                        }
                        if (radioButton3.Checked)
                        {
                            string sql = "select name,dob,gender,user_type,c_number,c_address,c_email,c_id,c_group,g_id from person,contact,Pgroup where c_email like '%" + textBox1.Text + "%' and person.name=contact.c_name and contact.c_group=pgroup.group_";
                            DataTable dt = DataAccess.GetDataTable(sql);
                            dataGridView1.DataSource = dt;
                        }
                        if (radioButton4.Checked)
                        {
                            string sql = "select name,dob,gender,user_type,c_number,c_address,c_email,c_id,c_group,g_id from person,contact,Pgroup where c_group like '%" + textBox1.Text + "%' and person.name=contact.c_name and contact.c_group=pgroup.group_";
                            DataTable dt = DataAccess.GetDataTable(sql);
                            dataGridView1.DataSource = dt;
                        }
                        if (radioButton5.Checked)
                        {
                            string sql = "select name,dob,gender,user_type,c_number,c_address,c_email,c_id,c_group,g_id from person,contact,Pgroup where person.name=contact.c_name and contact.c_group=pgroup.group_ and person.gender='" + textBox1.Text + "'";
                            DataTable dt = DataAccess.GetDataTable(sql);
                            dataGridView1.DataSource = dt;

                        }

                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string utype = mytable.Rows[0]["user_type"].ToString();
            if (utype.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
            {
                Form1 f = new Form1(mytable);
                f.Show();
                this.Hide();
            }
            else
            {
                Form2 f = new Form2(mytable);
                f.Show();
                this.Hide();
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void Search_Layout(object sender, LayoutEventArgs e)
        {

        }

        
    }
}
