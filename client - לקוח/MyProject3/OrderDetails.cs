﻿using System;
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
    public partial class OrderDetails : Form
    {
        public OrderDetails()
        {
            InitializeComponent();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = AddOrder.textBox2.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hairdoDetails h = new hairdoDetails();
            h.Show();
        }
    }
}
