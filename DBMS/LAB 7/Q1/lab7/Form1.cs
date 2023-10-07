using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.DataAccess;

namespace lab7
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {            
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        } 
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=172.16.54.24:1521/ictorcl;USER ID=IT310;PASSWORD=student");
            try
            {
                conn.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception e1)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "select name,driver_id,address from PERSON";
            command1.CommandType = CommandType.Text;
            OracleDataReader dr = command1.ExecuteReader();
            dr.Read();
            textBox1.Text = dr.GetString(0);
            textBox2.Text = dr.GetString(1);
            textBox3.Text = dr.GetString(2);
            command1.Dispose();
            conn.Close();      
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "insert into PERSON values (" + "'" + textBox2.Text + "'" + "," + "'" + textBox1.Text + "'" + "," + "'" + textBox3.Text + "'" + ")";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            command1.Dispose();
            conn.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "delete from PERSON where driver_id= '" + textBox2.Text + "'";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            command1.Dispose();
            conn.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "update PERSON set address='" +textBox3.Text +"'" + "where driver_id= '" + textBox2.Text + "'";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Updated");
            command1.Dispose();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
