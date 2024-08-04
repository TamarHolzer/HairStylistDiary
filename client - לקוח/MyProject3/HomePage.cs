using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject3
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (maskedTextBoxCodeUser.Text == General.codeUser.ToString())
            //{
            //    CalendarMonth cm = new CalendarMonth();
            //    cm.Show();
            //    this.Hide();
            //    cm.FormClosed += (s, args) => this.Close();

            //}
            //else
            //{
            //    labelNode1.Visible = true;
            //}
            //למחוק
            CalendarMonth cmm = new CalendarMonth();
            cmm.Show();
            this.Hide();
            cmm.FormClosed += (s, args) => this.Close();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            maskedTextBoxCodeUser.PasswordChar = '*';
        }


       
    }
}
