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
    public partial class AddHairdo : Form
    {
        public AddHairdo()
        {
            InitializeComponent();
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    AddOrder ad1 = new AddOrder(monthCalendar1.SelectionStart);
        //    ad1.Show();
        //    this.Hide();
        //    ad1.FormClosed += (s, args) => this.Close();
        //    ad1.Show();
        //}



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(textBoxPrice.Text);
                
                string de = textBoxDescription.Text;

                Hairdo h = new Hairdo { DescriptionHairdo = de, Price = p };
                h.CodeHairdo = General.sharat.GetCodeToHairdo();
                var res = General.sharat.AddHairdo(h);
                if (res == 0)
                {
                    MessageBox.Show("ארעה שגיאה בהכנסת פרטי התסרוקת, נסה שוב");
                }
                else
                {
                    MessageBox.Show("תסרוקת חדשה נוספה בהצלחה");
                    MessageBox.Show("שימי לב הדף יתאפס לכן דאגי למלא מחדש את כל הנתונים");
                }
                AddOrder ad1 = new AddOrder();
                ad1.Show();
                this.Hide();
                ad1.FormClosed += (s, args) => this.Close();
                ad1.Show();
            }
            catch
            {
                MessageBox.Show("אופס ארעה שגיאה,ודא כי המחיר המוקלד הינו תקין ");

            }
            finally
            {

            }







        }

        private void button4_Click(object sender, EventArgs e)
        {

            MessageBox.Show("שימי לב הדף יתאפס לכן דאגי למלא מחדש את כל הנתונים");
            AddOrder ad1 = new AddOrder();
            ad1.Show();
            this.Hide();
            ad1.FormClosed += (s, args) => this.Close();
            ad1.Show();

        }

        private void AddHairdo_Load(object sender, EventArgs e)
        {

        }
    }
}
