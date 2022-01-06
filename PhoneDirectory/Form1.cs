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
    public partial class Form1 : Form
    {
        DataTable mytable;
        DataTable newtable;
        public Form1(DataTable table)
        {
            InitializeComponent();
            mytable = table;
            newtable = table;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addAPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Person a = new Add_Person(mytable);
            a.Show();
            this.Hide();
        }

        private void aboutDMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "Awsaf's personal phone directory management system v1.0";
            MessageBox.Show(s);
        }

        private void searchAPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search(mytable);
            s.Show();
            this.Hide();
        }

        private void updateAPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePerson up = new UpdatePerson(mytable);
            up.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyProfile p = new MyProfile(mytable,newtable);
            p.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Call 01716086202 if any info required");
        }

    }
}
