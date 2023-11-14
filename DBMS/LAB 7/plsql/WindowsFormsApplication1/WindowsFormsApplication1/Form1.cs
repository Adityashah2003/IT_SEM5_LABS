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


namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "@D:/210911310/Lab 6/first.sql";
            command1.CommandType = CommandType.Text;
            command1.Dispose();
            OracleCommand command2 = conn.CreateCommand();
            command2.CommandText = "select accd_fn('2023') from Accident";
            command2.CommandType = CommandType.Text;
            OracleDataReader dr = command2.ExecuteReader();
            dr.Read();
            label1.Text =  dr.GetInt32(0).ToString();
            command2.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand c= new OracleCommand("damage", conn);
            c.CommandType=CommandType.StoredProcedure;
            c.Parameters.Add("did_in", OracleDbType.Int32, 10).Value = 12345;
            c.Parameters.Add("year_in", OracleDbType.Int32, 10).Value = 2003;
            c.Parameters.Add("cout", OracleDbType.Int32, 10).Value = 0;

            try
            {
                c.ExecuteNonQuery();
                string result = c.Parameters["cout"].Value.ToString();
                MessageBox.Show(result);
            }
            catch (Exception E) {
                MessageBox.Show(E.ToString());

            }
            //execute damage('12345','2003');
        }

    }
}