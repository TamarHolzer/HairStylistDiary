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
    public partial class CalendarMonth : Form
    {
        List<Customers> lc = new List<Customers>();
        List<Customers> temp;

        public CalendarMonth()
        {
            InitializeComponent();
            //ordersInThisDay();


        }

        public void PageAddOrder()
        {
            AddOrder ad1 = new AddOrder();
            ad1.Show();
            this.Hide();
            ad1.FormClosed += (s, args) => this.Close();
            ad1.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //עדכון סטטוס בגלובל =הוספה
            General.Status = 1;
            PageAddOrder();
        }
        bool flagL;
        private void CalendarMonth_Load(object sender, EventArgs e)
        {
            General.dateTreat = DateTime.Today.Date;
            DateRangeEventArgs dt = new DateRangeEventArgs(DateTime.Today.Date, DateTime.Today.Date);
            flagL = false;
            ordersInThisDay(sender, dt);
            if (flagL == true)
                noOrders.Visible = true;
            labeDate.Text = DateTime.Today.ToShortDateString().ToString();
            labelToday.Text = DateTime.Today.ToShortDateString().ToString();
            if (General.comebackCalander != DateTime.Today.Date)
            {
                monthCalendar1.SetDate((DateTime)General.comebackCalander);
                General.comebackCalander = DateTime.Today.Date;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            General.Status = 1;

            AddOrder ad1 = new AddOrder();
            ad1.Show();
            this.Hide();
            ad1.FormClosed += (s, args) => this.Close();
            ad1.Show();
        }
        //הזמנות ליום מבוקש
        public void ordersInThisDay(object sender, DateRangeEventArgs e)
        {
            labeDate.Text = e.End.ToShortDateString().ToString();

            General.dateTreat = e.Start.Date;
            lc = General.sharat.GetAllCustomers().ToList();
            //יש לשים לב אם משווים תאריך שהשעה לא מאופסת - יש להשוות "ידנית" את השנה חודש ויום
            var temp = lc.Where(p => p.DateT == General.dateTreat).ToList();
            int moneTreat;
            moneTreat = lc.Count;
            Customers m = lc.First();


            if (temp.Count() > 0)
            {
                flagL = false;
                //הצגת ה-panels
                List<Panel> lp = new List<Panel>
                {
                    panel1,
                    panel2,
                    panel3,
                    panel4,
                    panel5,
                    panel6,
                    panel7,
                    panel8,
                    panel9,
                    panel10,
                    panel11,
                    panel12
                };

                List<Customers> t2 = new List<Customers>();
                t2 = temp;
                foreach (var i in temp)
                {
                    lp.First().Visible = true;
                    lp.RemoveAt(0);
                }

                //הצגת עיקרי ההזמנה ב-labels

                //list of labels to show the name customer
                List<Label> listName = new List<Label>
                {
                    l1,
                    l2,
                    l3,
                    l4,
                    l5,
                    l6,
                    l7,
                    l8,
                    l9,
                    l10,
                    l11,
                    l12
                };

                //list of labels to show the price treatment
                List<Label> listPrice = new List<Label>
                {
                   labelA,
                   labelB,
                   labelC,
                   labelD,
                   labelE,
                   labelF,
                   labelG,
                   labelH,
                   labelI,
                   labelG,
                   labelK,
                   labelL
                };

                //list of labels to show the price treatment
                List<Label> listAdress = new List<Label>
                {
                    lla,
                    llb,
                    llc,
                    lld,
                    lle,
                    llf,
                    llg,
                    llh,
                    lli,
                    llj,
                    llk,
                    lll
                };

                //list of labels to show the price treatment
                List<Label> listCode = new List<Label>
                {
                    label1,
                    label3,
                    label4,
                    label5,
                    label6,
                    label7,
                    label8,
                    label9,
                    label10,
                    label11,
                    label12,
                    label13
                };
                foreach (var i in temp)
                {
                    listName.First().Visible = true;
                    listName.First().Text = i.CodeCustomerDetails.NameC;
                    listName.RemoveAt(0);

                    listPrice.First().Visible = true;
                    listPrice.First().Text = i.FinalPrice.ToString();
                    listPrice.RemoveAt(0);

                    listCode.First().Visible = true;
                    listCode.First().Text = i.CodeCustomers.ToString();
                    listCode.RemoveAt(0);

                    if (i.IsMyClinic != true)
                    {
                        listAdress.First().Visible = true;
                        listAdress.First().Text = i.CodeAdress.Street + "," + i.CodeAdress.CodeCity.NameCity;
                    }
                    else
                    {
                        listAdress.First().Visible = true;
                        listAdress.First().Text = "הטיפול נערך בקליניקה";
                    }
                    listAdress.RemoveAt(0);
                }

                for (int i = 0; i < lp.Count(); i++)
                {
                    lp.First().Visible = false;
                    lp.RemoveAt(0);
                }

            }
            else if (e.End.Date == DateTime.Today.Date)
            {
                flagL = true;
            }
            else
            {
                flagL = true;

                List<Panel> lpt = new List<Panel>
                {
                    panel1,
                    panel2,
                    panel3,
                    panel4,
                    panel5,
                    panel6,
                    panel7,
                    panel8,
                    panel9,
                    panel10,
                    panel11,
                    panel12,
                    panel13
                };


                for (int i = 0; i < lpt.Count(); i++)
                {
                    lpt.First().Visible = false;
                    lpt.RemoveAt(0);
                }
                panel8.Visible = false;


                // MessageBox.Show("אין עדיין הזמנות ליום זה");
            }
            if (flagL == true)
                noOrders.Visible = true;
            else
                noOrders.Visible = false;

        }


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            ordersInThisDay(sender, e);
        }




        private void button15_Click(object sender, EventArgs e)
        {
            Orders o = new Orders();
            o = General.sharat.GetAllOrders().ElementAt(1);
            //  General.UpdateOrder = o;
            AddOrder order = new AddOrder();
        }

        /*private void button38_Click(object sender, EventArgs e)
               {
                   ShowDayOrder();
               }*/







        //הצגת פרטים נוספים על ההזמנה
        public void ShowDayOrder()
        {
            DayOrders do1 = new DayOrders();
            do1.Show();
            this.Hide();
            do1.FormClosed += (s, args) => this.Close();
            do1.Show();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label1.Text);
            ShowDayOrder();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label3.Text);
            ShowDayOrder();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label4.Text);

            ShowDayOrder();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label5.Text);

            ShowDayOrder();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label6.Text);

            ShowDayOrder();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label7.Text);

            ShowDayOrder();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label8.Text);

            ShowDayOrder();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label9.Text);

            ShowDayOrder();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label10.Text);

            ShowDayOrder();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label11.Text);

            ShowDayOrder();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label12.Text);

            ShowDayOrder();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            General.codeOrederToDisplay = int.Parse(label13.Text);

            ShowDayOrder();
        }



        //פעולות עריכת הזמנה
        public void UpdateOrder(string idCust)
        {
            General.Status = 2;
            int n = int.Parse(idCust);
            Customers c = new Customers();
            c = General.sharat.getCustomerDetailsByCode(n);
            General.UpdateCustomer = c;
            List<Orders> orderList = General.sharat.GetOrderListByCustomer(n).ToList();
            General.UpdateOrder = orderList;


            //אחרי שמירת השינויים של עדכון הזמנה כולל כל הפרטים
            //שליחה לפונקציה שמקבלת גם את ההזמה וגם את הפרטים בהזמנה 
            //ooo = General.sharat.getOrderByCode(222);
            //ooo = General.sharat.GetOrderByCodeCustomer(c.CodeCustomers);
            ///General.UpdateOrder = ooo;
            General.isFirst = true;
            AddOrder ad5 = new AddOrder();
            ad5.Show();
            this.Hide();
            ad5.FormClosed += (s, args) => this.Close();
            ad5.Show();
            General.isFirst = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            General.Status = 2;
            UpdateOrder(label1.Text);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            General.Status = 2;

            UpdateOrder(label3.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateOrder(label4.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateOrder(label5.Text);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            UpdateOrder(label6.Text);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            UpdateOrder(label7.Text);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            UpdateOrder(label8.Text);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            UpdateOrder(label9.Text);

        }

        private void button20_Click(object sender, EventArgs e)
        {
            UpdateOrder(label10.Text);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            UpdateOrder(label11.Text);

        }

        private void button24_Click(object sender, EventArgs e)
        {
            UpdateOrder(label12.Text);

        }

        private void button26_Click(object sender, EventArgs e)
        {
            UpdateOrder(label13.Text);

        }




        //פעולות מחיקת הזמנה
        private void deleteOrder(string code)
        {
            int c = int.Parse(code);
            //הצגה של הפרטים הנוספים ,
            //וכן כפתורים של עריכה ומחיקה
            var res = General.sharat.deleteCustomersWithAllDetails(c);
            if (res == 1)
            {
                MessageBox.Show("נמחק");
                CalendarMonth cc=new CalendarMonth();
                cc.Show();
                this.Hide();
                cc.FormClosed += (s, args) => this.Close();
                cc.Show();
            }
            else
            {
                MessageBox.Show("נסה שוב");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            deleteOrder(label1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            deleteOrder(label3.Text);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            deleteOrder(label4.Text);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            deleteOrder(label5.Text);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            deleteOrder(label6.Text);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            deleteOrder(label7.Text);

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            deleteOrder(label8.Text);

        }

        private void button17_Click(object sender, EventArgs e)
        {
            deleteOrder(label9.Text);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            deleteOrder(label10.Text);

        }

        private void button21_Click(object sender, EventArgs e)
        {
            deleteOrder(label11.Text);

        }

        private void button23_Click(object sender, EventArgs e)
        {
            deleteOrder(label12.Text);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            deleteOrder(label13.Text);

        }

      

       

        private void button27_Click(object sender, EventArgs e)
        {
            var lc = General.sharat.GetAllCustomersByCustName(textBox1.Text).OrderBy(c => c.DateT);
            List<string> ldt = new List<string> { "תאריכי ההזמנות" };
            foreach (var item in lc)
            {
                ldt.Add("  " + item.DateT.ToShortDateString());
            }
            comboBoxSearch.DataSource = ldt;

        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lc = General.sharat.GetAllCustomersByCustName(textBox1.Text).OrderBy(c => c.DateT);
            var ind = comboBoxSearch.SelectedIndex;
            var ind2 = comboBoxSearch.SelectedItem;
            try
            {
                ind2 = Convert.ToDateTime(ind2);
                monthCalendar1.SetDate((DateTime)ind2);
            }
            catch { }


        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            monthCalendar1_DateSelected(sender, e);
        }
    }
}

