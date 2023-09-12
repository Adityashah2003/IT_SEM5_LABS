using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            checkBox2.Checked = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String radioChoice , checkChoice = null;
            if (radioButton1.Checked == true)
            {
                radioChoice = radioButton1.Text;
            }
            else
            {
                radioChoice = radioButton2.Text;
            }

            if (checkBox2.Checked) {
                checkChoice = checkBox2.Text;
            }
            if (checkBox3.Checked)
            {
                checkChoice = checkChoice + ", " + checkBox3.Text;
            }
            if (checkBox4.Checked)
            {
                checkChoice = checkChoice + ", " + checkBox4.Text;
            }
            if (checkBox5.Checked)
            {
                checkChoice = checkChoice + ", " + checkBox5.Text;
            }




            Form2 f2 = new Form2(textBox1.Text, textBox2.Text, radioChoice, checkChoice, comboBox1.Text, comboBox2.Text, dateTimePicker1.Value);
            f2.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
