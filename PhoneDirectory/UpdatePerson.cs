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
    public partial class UpdatePerson : Form
    {
        DataTable table;
        public UpdatePerson(DataTable mytable)
        {
            
            InitializeComponent();
            table = mytable;
            
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdatePerson_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectdbDataSet8.Group_' table. You can move, or remove it, as needed.
            this.group_TableAdapter.Fill(this.projectdbDataSet8.Group_);
            // TODO: This line of code loads data into the 'projectdbDataSet7.Contact' table. You can move, or remove it, as needed.
            this.contactTableAdapter1.Fill(this.projectdbDataSet7.Contact);
            // TODO: This line of code loads data into the 'projectdbDataSet5.Contact' table. You can move, or remove it, as needed.
            this.contactTableAdapter.Fill(this.projectdbDataSet5.Contact);
            // TODO: This line of code loads data into the 'projectdbDataSet5.Person' table. You can move, or remove it, as needed.
            this.personTableAdapter.Fill(this.projectdbDataSet5.Person);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sql1="update contact set c_name='"+textBox1.Text+"',c_number='"+textBox4.Text+"',c_address='"+textBox6.Text+"',c_email='"+textBox5.Text+"',c_group='"+textBox3.Text+"' where user_name='"+textBox2.Text+"'";
            string sql2 = "update person set name='" + textBox1.Text + "' where username='" + textBox2.Text + "'";
            string sql3 = "update pgroup set Group_='" + textBox3.Text + "' and g_id=(select group_id from group_,contact where contact.c_group=group_.groups and groups='" + textBox3.Text + "' and user_name='"+textBox2.Text+"') where username='"+textBox2.Text+"'";
           
           
            try
            {
                DataAccess.ExecuteSQL(sql1);
                DataAccess.ExecuteSQL(sql2);
                DataAccess.ExecuteSQL(sql3);

                MessageBox.Show("Updated");


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql5 = "delete from person where name='" + textBox1.Text + "' and username='"+textBox2.Text+"'";
            string sql6 = "delete from contact where c_name='" + textBox1.Text + "' and user_name='" + textBox2.Text + "'";
            string sql7 = "delete from Pgroup where group_='" + textBox3.Text + "'";
            try
            {
                DataAccess.ExecuteSQL(sql6);
                DataAccess.ExecuteSQL(sql5);
                DataAccess.ExecuteSQL(sql7);

                MessageBox.Show("Person Removed");


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(table);
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql="select * from person where username='"+textBox2.Text+"' and name='"+textBox1.Text+"'";
            DataTable dt = DataAccess.GetDataTable(sql);
            MyProfile p = new MyProfile(dt,table);
            p.Show();
            this.Hide();
        }
      
    }
}
