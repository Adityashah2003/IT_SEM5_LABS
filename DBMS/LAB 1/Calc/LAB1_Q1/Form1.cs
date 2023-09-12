using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1_Q1
{
    public partial class Form1 : Form
    {
        double num1 = 0.0;
        double num2 = 0.0;
        String op1;
        String op2;
        String op3;
        double res = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            op1 = textBox1.Text;
            double.TryParse(op1, out num1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            op2 = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            op3 = textBox3.Text;
            double.TryParse(op3, out num2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (op2 == "+")
            {
                res = num1 + num2;
                textBox4.Text = res.ToString();
            }
            else if (op2 == "-")
            {
                res = num1 - num2;
                textBox4.Text = res.ToString();
            }
            else if (op2 == "*")
            {
                res = num1 * num2;
                textBox4.Text = res.ToString();
            }
            else if (op2 == "/")
            {
                res = num1 / num2;
                textBox4.Text = res.ToString();
            }
           /* else if (op2 == "/" && (num1 == 0 || num2 == 0)) {
                textBox4.Text = "Invalid operation";
            }*/
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            op1 = null;
            op2 = null;
            op3 = null;
            num1 = 0.0;
            num2 = 0.0;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
