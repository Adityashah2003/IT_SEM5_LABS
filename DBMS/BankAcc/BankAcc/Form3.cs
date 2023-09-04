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
    public partial class Form3 : Form
    {
        String pass;
        public Form3(String old_pass)
        {
            InitializeComponent();
            pass = old_pass;
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pass == textBox1.Text)
            {
                String new_pass = textBox2.Text;
                Form1 f1 = new Form1(new_pass);
                f1.Show();
            }
            else {
                this.Close();
            }
        }
    }
}
