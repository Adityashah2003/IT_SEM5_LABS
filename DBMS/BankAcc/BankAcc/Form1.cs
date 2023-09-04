using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAcc
{
    public partial class Form1 : Form
    {
        String userid = "admin";
        String pass;
        int currBal = 50000;
        public Form1(String pass_f3)
        {
            InitializeComponent();
            pass = pass_f3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(pass);
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == userid && textBox2.Text == pass)
            {
                Form2 f2 = new Form2(userid,currBal);
                f2.Show();
            }
            else
            {
                label4.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
