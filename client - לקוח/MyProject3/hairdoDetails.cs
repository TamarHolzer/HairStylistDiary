using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Model;
//using ViewModel;
using MyProject3.ServiceReference1;


namespace MyProject3
{
    public partial class hairdoDetails : Form
    {
        public hairdoDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient1Details pd1 = new Patient1Details();
            pd1.Show();
        }

    
    }
}
