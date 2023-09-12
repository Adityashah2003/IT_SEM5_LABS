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
    public partial class Form2 : Form
    {
        String PersonName, Regnum, RadioChoiceSent, checkChoiceSent, combo1Sent, combo2Sent ;
        DateTime date;
        public Form2(String name, String Regno, String radioChoice, String checkChoice, String combo1, String combo2, DateTime datepick)
        {
            InitializeComponent();
            PersonName= name;
            Regnum = Regno;
            RadioChoiceSent= radioChoice ;
            checkChoiceSent = checkChoice;
            combo1Sent = combo1;
            combo2Sent = combo2;
            date = datepick;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Info you entered is \n\n\n" + "Name: " + PersonName + "\n" + "Reg No.: " + Regnum + "\n" + "Branch:  " + combo2Sent + "\n" +  "Gender: " + RadioChoiceSent + "\n" + "Hobbies: " + checkChoiceSent
                + "\n" + "State:  " + combo1Sent + "\n" + "D.O.B: " + date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
