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

namespace q2
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand comm = new OracleCommand(); 
            comm.Connection = conn;
            comm.CommandText = "select count(distinct driver_id) from Participated natural join Accident where extract (year from accd_date) = '2008'"; 
            OracleDataReader read = comm.ExecuteReader();
            while (read.Read())
            {
                MessageBox.Show(read["COUNT(DISTINCTDRIVER_ID)"].ToString());
            } 
            read.Close(); 
            conn.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select count(*) from car natural join Participated where model='FSUK'";
            OracleDataReader read = comm.ExecuteReader();
            while (read.Read())
            {
                MessageBox.Show(read["COUNT(*)"].ToString());
            }
            read.Close();
            conn.Close(); 


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
    
                ConnectDB();
                OracleCommand comm1 = new OracleCommand();
                comm1.Connection = conn;
                comm1.CommandText = "select name as Owner_name, count(reportno) as NoofAcc , sum(damage_amount) as Total_damage from person,participated where person.driver_id=participated.driver_id group by name order by Total_damage desc";
                comm1.CommandType = CommandType.Text;
                OracleDataReader read = comm1.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(comm1.CommandText, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
          
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand comm1 = new OracleCommand();
            comm1.Connection = conn;
            comm1.CommandText = "select name , count(reportno) from person,participated where person.driver_id=participated.driver_id group by name having count(reportno)>1";
            comm1.CommandType = CommandType.Text;
            OracleDataReader read = comm1.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(comm1.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand comm1 = new OracleCommand();
            comm1.Connection = conn;
            comm1.CommandText = "SELECT PERSON.NAME FROM PERSON MINUS (SELECT DISTINCT PERSON.NAME FROM PERSON,PARTICIPATED WHERE PERSON.DRIVER_ID = PARTICIPATED.DRIVER_ID)";
            comm1.CommandType = CommandType.Text;
            OracleDataReader read = comm1.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(comm1.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        
    }
}
