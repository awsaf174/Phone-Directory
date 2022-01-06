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
    public partial class Form2 : Form
    {
        DataTable mytable;
        DataTable newtable;
        public Form2(DataTable table)
        {
            InitializeComponent();
            mytable = table;
            newtable = table;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = mytable.Rows[0]["name"].ToString();

        }

        private void goToYourProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyProfile p = new MyProfile(mytable,newtable);
            p.Show();
            this.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Awsaf's personal phone directory management system v1.0");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search(mytable);
            s.Show();
            this.Hide();
        }
    }
}
