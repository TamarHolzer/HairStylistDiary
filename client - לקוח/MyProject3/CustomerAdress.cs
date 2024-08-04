using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyProject3.ServiceReference1;

namespace MyProject3
{
    public partial class CustomerAdress : Form
    {
        public CustomerAdress()
        {
            InitializeComponent();
        }

        private void CustomerAdress_Load(object sender, EventArgs e)
        {
            var listCities = General.sharat.getAllCities().Select(p => p.NameCity).ToList();
            comboBoxCities.DataSource = listCities;
            
            var listStreet = General.sharat.GetAllAddresses().Select(p => p.Street).ToList();
            comboBoxStreet.DataSource = listStreet;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            General.adress = "";

            if (textBoxCity.Text == "")
            {
                General.city = comboBoxCities.Text;
            }
            else
            {
                List<Cities> lcity = General.sharat.getAllCities().ToList();
                Cities pc = lcity.First();
                int check = 0;

                for (int i = 0; i < lcity.Count; i++)
                {
                    if (textBoxCity.Text == pc.NameCity)
                    {
                        General.city = textBoxCity.Text;
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    Cities c = new Cities { NameCity = textBoxCity.Text };
                    c.CodeCity = General.sharat.GetCodeToCities();
                    var r = General.sharat.AddCity(c);

                    if (r == 0)
                    {
                        MessageBox.Show("ארעה שגיאה בהכנסת העיר,בבקשה נסו שוב");
                    }
                    else
                    {
                        MessageBox.Show("שם העיר נוסף בהצלחה");
                        General.city = textBoxCity.Text;
                    }
                }
            }



            if (textBoxAdress.Text == "")
            {
                General.adress = comboBoxStreet.Text;
            }
            else
            {               

                General.adress = textBoxAdress.Text;
            
            }

            this.Close();
        }
        private void textBoxCity_TextChanged(object sender, EventArgs e)
        {
        //int i = 0;

        //    if (textBoxCity.Text[i] < '9' && textBoxCity.Text[i] > '0')
        //        labelErr.Visible = true;
                
        }
    }
}
