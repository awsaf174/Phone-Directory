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
    public partial class MyProfile : Form
    {
        DataTable newtable;
        DataTable newtablee;
        public MyProfile(DataTable table,DataTable ntable)
        {
            InitializeComponent();
            newtable = table;
            newtablee = ntable;
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
            
        }

        private void MyProfile_Load_1(object sender, EventArgs e)
        {
            label4.Text =newtable.Rows[0]["user_type"].ToString()+" "+"User" ;
            textBox1.Text = newtable.Rows[0]["name"].ToString();
            textBox2.Text=newtable.Rows[0]["dob"].ToString();
            string sql="select username,c_address,c_number,c_email from contact,person where person.name='"+newtable.Rows[0]["name"].ToString()+"' and person.name=contact.c_name";
            DataTable dt = DataAccess.GetDataTable(sql);
            textBox3.Text = dt.Rows[0]["c_address"].ToString();
            textBox4.Text = dt.Rows[0]["c_email"].ToString();
            textBox5.Text = dt.Rows[0]["c_number"].ToString();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string utype = newtable.Rows[0]["user_type"].ToString();
            string usertype = newtablee.Rows[0]["user_type"].ToString();
            if (utype.Equals("Guest", StringComparison.OrdinalIgnoreCase))
            {
                if (usertype.Equals("Guest", StringComparison.OrdinalIgnoreCase))
                {
                    Form2 f2 = new Form2(newtable);
                    f2.Show();
                    this.Hide();
                }
            }
            if (utype.Equals("Guest", StringComparison.OrdinalIgnoreCase))
            {
                if (usertype.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
                {
                    Form1 f1 = new Form1(newtablee);
                    f1.Show();
                    this.Hide();
                }
            }
            if (utype.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
            {
                if (usertype.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
                {
                    Form1 f1 = new Form1(newtable);
                    f1.Show();
                    this.Hide();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    

    }
}
