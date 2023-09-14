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
    public partial class Form2 : Form
    {
        String user_name;
        int curr_bal;
        public Form2(String name,int bal,String lastaccess,String transactions)
        {
            InitializeComponent();
            user_name = name;
            curr_bal = bal;
            label4.Text = lastaccess;
            label8.Text = transactions; 
            label6.Text = user_name;
            label5.Text = curr_bal.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Proceed to banking";
            Form4 f4 = new Form4(curr_bal);
            f4.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }
    }
}
