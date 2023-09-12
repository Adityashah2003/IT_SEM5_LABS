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
    public partial class Form4 : Form
    {
        int net_bal;
        public Form4(int amount)
        {
            net_bal = amount;
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int bal;
            int.TryParse(textBox1.Text, out bal);
            net_bal = net_bal - bal;
            label1.Text = net_bal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Click();
        }
    }
}
