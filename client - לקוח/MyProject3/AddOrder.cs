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
    public partial class AddOrder : Form
    {



        public int Status { get; set; }
        public AddOrder()
        {
            InitializeComponent();

        }

        Orders o1 = new Orders();
        string state;

        List<Hairdo> list1 = new List<Hairdo>();
        List<Hairdo> hairDo1 = new List<Hairdo>();
        List<Hairdo> choose = new List<Hairdo>();


        private void AddOrder_Load(object sender, EventArgs e)
        {
            list1 = General.sharat.GetAllHairdos().ToList();
            if (General.Status == 2)//עדכון
            {
                updateCustomerOrder();
            }
            //הצגה במצב יצירת הזמנה
            else
            {
                button1.Text = "שמור";
                //button1.Visible = true;

                var Temp = list1.Select(u => u.DescriptionHairdo.ToString() + "  " + u.Price.ToString() + " :" + u.CodeHairdo.ToString()).ToList();
                Temp.Insert(0, "בחרי סוג תסרוקת");
                comboBoxHairdoT.DataSource = Temp;

                var listHeads = General.sharat.GetAllSales().Select(p => p.NameSale).ToList();
                //comboBoxHeadN.DataSource = listHeads;

                var listWayToPay = General.sharat.GetAllCustomers().Select(p => p.WayofPay).ToList();
                comboBoxPayW.DataSource = listWayToPay;

                var listNameCustomers = General.sharat.GetAllCustomerDetails().Select(p => p.NameC).ToList();
                comboBoxNames.DataSource = listNameCustomers;

                comboBoxPayW.DataSource = General.lsWayOfPay.ToList();



                DateTime dtoday1 = DateTime.Today;
                labelDateToday.Text = dtoday1.ToShortDateString().ToString();

                label14.Text = General.dateTreat.ToShortDateString();

                labelAdress.Visible = true;
                labelCity.Visible = true;
                labelCity.Text = General.city;
                labelAdress.Text = General.adress;
                checkBoxTreatmentAtHome.Visible = true;
            }

        }



        //הצגה במצב עידכון טופס
        private void updateCustomerOrder()
        {
            //הצגת לקוחה
            comboBoxNames.DataSource = General.sharat.GetAllCustomerDetails().Select(p => p.NameC).ToList();
            comboBoxNames.SelectedItem = General.UpdateCustomer.CodeCustomerDetails.NameC;

            //הצגת כפתור העידכון והסתרת כפתור השמירה 
            //buttonUpdate.Visible = true;
            button1.Text = "עדכון";
            button1.Visible = true;
            //הצגת אופן התשלום
            comboBoxPayW.DataSource = General.lsWayOfPay.ToList();
            comboBoxPayW.SelectedItem = General.UpdateCustomer.WayofPay;
            //הצגת הדקות בשעת הטיפול
            textBoxTimeOfTreatmant.Text = General.UpdateCustomer.Hour1.Substring(General.UpdateCustomer.Hour1.IndexOf(':') + 1);

            //הצגת הדקות בשעת הטיפול
            textBox2.Text = General.UpdateCustomer.Hour1.Substring(0, General.UpdateCustomer.Hour1.IndexOf(':'));
            //הצגת הדקות במשך הטיפול
            textBox4.Text = General.UpdateCustomer.HowLong.Substring(General.UpdateCustomer.HowLong.IndexOf(':') + 1);
            //הצגת שעות משך הטיפול
            textBox3.Text = General.UpdateCustomer.HowLong.Substring(0, General.UpdateCustomer.HowLong.IndexOf(':'));
            //הצגת הערות
            textBox1.Text = General.UpdateCustomer.RemarksC;
            //הצגת תאריך הטיפול
            label4.Text = General.UpdateCustomer.DateT.ToString();
            //סימון מקום הטיפול
            checkBoxTreatmentAtHome.Checked = (General.UpdateCustomer.IsMyClinic);
            //הצגת כתובת
            label4.Text = "הטיפול יערך ב:";
            labelAdress.Visible = true;
            labelAdress.Text = General.UpdateCustomer.CodeAdress.Street;
            labelCity.Visible = true;
            labelCity.Text = General.UpdateCustomer.CodeAdress.CodeCity.NameCity;
            //הצגת כתובת הטיפול באם הוא לא בקליניקה
            if (checkBoxTreatmentAtHome.Checked == false)
            {
                General.city = General.UpdateCustomer.CodeAdress.CodeCity.NameCity;
                General.adress = General.UpdateCustomer.CodeAdress.Street;
                labelAdress.Text = General.adress;
                labelCity.Text = General.city;
            }
            else
            {
                General.city = ".";
                General.adress = "בקליניקה שלי";
                labelAdress.Text = General.adress;
                labelCity.Text = General.city;
            }
            //הצגת התאריך העדכני

            DateTime dtoday1 = DateTime.Today;
            labelDateToday.Text = dtoday1.ToShortDateString().ToString();

            //הצגת תאריך הטיפול
            label14.Text = General.dateTreat.ToShortDateString();

            //הצגת תסרוקות בהזמנה
            foreach (var item in General.UpdateOrder)
            {
                checkedListBox1.Items.Add(item.CodeHairdo.DescriptionHairdo.ToString() + "  " + item.CodeHairdo.Price.ToString() + " :" + item.CodeHairdo.CodeHairdo.ToString(), true);

            }
            //הצגת כלל התסרוקות

            var Temp = list1.Select(u => u.DescriptionHairdo.ToString() + "  " + u.Price.ToString() + " :" + u.CodeHairdo.ToString()).ToList();
            Temp.Insert(0, "בחרי סוג תסרוקת");
            comboBoxHairdoT.DataSource = Temp;

        }

        //חזרה ליומן- דף הבית
        private void button2_Click(object sender, EventArgs e)
        {
            General.adress = "בקליניקה שלי";
            General.city = "";
            CalendarMonth cm1 = new CalendarMonth();
            cm1.Show();
            this.Hide();
            cm1.FormClosed += (s, args) => this.Close();
            cm1.Show();
        }
        //מעבר לדף יצירת לקוחה חדשה
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient1Details p1 = new Patient1Details();
            p1.FormClosed += (s, args) => this.Close();
            p1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<Model.CustomerDetails> lscd = new List<Model.CustomerDetails>();

            //students = MyDB.Student.GetList();
            //dataGridView1.DataSource = students;
            //lscd = ViewModel.MyDB.CustomersDetails.GetList();
            //comboBoxNames.DataSource = lscd;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddHairdo a1 = new AddHairdo();
            a1.FormClosed += (s, args) => this.Close();
            a1.Show();

        }
        int mone = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            mone++;
            //ליצור רשימה של התסרוקות שנבחרו להזמנה שתשמר בפרטי ההזמנה
            choose.Add(list1.ElementAt(comboBoxHairdoT.SelectedIndex));
            checkedListBox1.Items.Add(list1.ElementAt(comboBoxHairdoT.SelectedIndex).DescriptionHairdo);
            checkedListBox1.SetItemChecked(mone - 1, false);
        }

        //פתיחת מסך בחירת מיקום הטיפול 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTreatmentAtHome.Checked == true)
            {
                CustomerAdress cad = new CustomerAdress();
                cad.Show();
            }
        }

        //התראה על שעה לא תקינה
        private void textBoxTimeOfTreatmant_TextChanged(object sender, EventArgs e)
        {
            int copy2;
            bool conv2 = int.TryParse(textBoxTimeOfTreatmant.Text, out copy2);
            if (copy2 > 59 || copy2 < 0)
            {
                label28.Visible = true;
            }
            else
            {
                label28.Visible = false;
            }

        }

        //כשהטיפול בקלניקה/בכתובת אחרת
        private void checkBoxTreatmentAtHome_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTreatmentAtHome.Checked == false)
            {
                if (General.isFirst == false)
                {
                    CustomerAdress ca1 = new CustomerAdress();
                    ca1.ShowDialog();
                    labelCity.Text = General.city;
                    labelAdress.Text = General.adress;
                }

            }
            else
            {
                General.city = "";
                General.adress = "בקליניקה שלי";
                labelCity.Text = General.city;
                labelAdress.Text = General.adress;
                checkBoxTreatmentAtHome.Checked = true;
            }

        }
        //תוית שימי לב
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("שימי לב כשהטיפול נערך בבית הלקוחה עליך לחשב את זמן הטיפול יחד עם זמן ההגעה וזמן החזרה לקליניקה.");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            labelPoint.Visible = true;
        }


        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            labelPoint.Visible = false;
        }

        //הוספת תסרוקת לרשימה
        private void comboBoxHairdoT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHairdoT.SelectedIndex != 0)
            {

                checkedListBox1.Items.Add(comboBoxHairdoT.SelectedItem, true);
            }
            errHair.Visible = false;
        }


        //התראה על אורך שעה לא תקין
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int tEzer2;
            bool ese2 = int.TryParse(textBox4.Text, out tEzer2);
            if (tEzer2 > 59 || tEzer2 < 0)
            {
                label29.Visible = true;
            }
            else
            {
                label29.Visible = false;
            }
        }
        //התראה על אורך שעה לא תקין

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int tEzer1;
            bool ese = int.TryParse(textBox3.Text, out tEzer1);
            if (tEzer1 > 24 || tEzer1 < 0)
            {
                label29.Visible = true;
            }
            else
            {
                label29.Visible = false;
            }
        }

        //התראה על שעה לא תקינה
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int copy1;
            bool conv = int.TryParse(textBox2.Text, out copy1);
            if (copy1 > 24 || copy1 < 0)
            {
                label28.Visible = true;
            }
            else
            {
                label28.Visible = false;
            }
        }




        //הוספת תסרוקת לרשימת הזמנה
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(comboBoxHairdoT.SelectedItem, true);
        }

        //מחיקת תסרוקת מרשימת ההזמנה
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex >= 0)
            {


                checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
            }

        }


        //שמירת הזמנה חדשה
        private void button1_Click(object sender, EventArgs e)
        {
            if (label28.Visible == false && label29.Visible == false)
            {
                string name, payW, note, howLong1 = "", hour2 = "";
                bool clinic;
                DateTime date1;
                int codeSale1, finalPrice = 0;

                //אריזת הנתונים ושליחה להוספה במסד, כולל בדיקות תקינות - פנויה , תאריך יותר מהיום....

                //קיבוץ רשימת תסרוקות
                foreach (var item in checkedListBox1.Items)
                {
                    var t = item.ToString().Substring(item.ToString().IndexOf(':') + 1);//מוצא את הקוד של הסוג תסרוקת
                    var kind = list1.FirstOrDefault(p => p.CodeHairdo == Convert.ToInt32(t));//מוצא מהרשימה את האוביקט עם הקוד הנל
                    hairDo1.Add(kind);
                    finalPrice += kind.Price;
                }
                if (hairDo1.Count == 0)
                    errHair.Visible = true;
                name = comboBoxNames.Text;
                note = textBox1.Text;

                // אריזת אורך הטיפול כולל בדיקת תקינות
                if (textBox3.Text == "" || textBox4.Text == "")
                    label29.Visible = true;
                int tEzer1, tEzer2;
                bool ese = int.TryParse(textBox3.Text, out tEzer1);
                bool ese2 = int.TryParse(textBox4.Text, out tEzer2);
                if (ese && ese2)
                {
                    if (tEzer1 < 24 && tEzer1 > -1 && tEzer2 < 60 && tEzer2 > -1)
                        howLong1 = textBox3.Text + ":" + textBox4.Text;
                    else
                        label29.Visible = true;
                }
                else
                    label29.Visible = true;


                //אריזת שעת הטיפול כולל בדיקת תקינות
                if (textBox2.Text == "" || textBoxTimeOfTreatmant.Text == "")
                    label28.Visible = true;
                
                if ((!(label29.Visible == true || label28.Visible == true)))
                {
                    int copy1, copy2;
                    bool conv = int.TryParse(textBox2.Text, out copy1);
                    bool conv2 = int.TryParse(textBoxTimeOfTreatmant.Text, out copy2);
                    if (conv && conv2)
                    {
                        if (copy1 < 24 && copy1 > -1 && copy2 < 60 && copy2 > -1)
                            hour2 = textBox2.Text + ":" + textBoxTimeOfTreatmant.Text;
                        else
                            label28.Visible = true;
                    }
                    else
                        label28.Visible = true;

                }

                //***************************************************************************************
                //אריזת מספר תסרוקות לפי מבצע
                //בדיקה אם רשום יותר מ4 עדיין נשאר 4.
                codeSale1 = checkedListBox1.Items.Count;
                if (codeSale1 >= 4)
                    codeSale1 = 4;
                //שליפה של כל הסיילים וחישוב של הסייל המתאים - לפי המספר שקיים
                if (codeSale1 == 0)
                {
                    errHair.Visible = true;
                }

                else
                {
                    Sale s1 = General.sharat.getSaleByCode(codeSale1);
                    finalPrice = finalPrice - ((finalPrice * s1.TheSale) / 100);

                }


                //אריזת דרך התשלום
                if (comboBoxPayW.Text == "צק")
                    payW = "צק";
                else
                    payW = "מזומן";

                
                //בדיקת תקינות האם נבחרו תסרוקות 
                if (errHair.Visible == false&& label28.Visible == false&& label29.Visible == false)
                {
                    Adress a = new Adress();
                    //אריזת מקום הטיפול
                    if (checkBoxTreatmentAtHome.Checked == true || labelCity.Text == "" || labelCity.Visible == false)
                    {
                        clinic = true;
                        a = General.sharat.GetAdresssByName("הקליניקה שלי");
                    }
                    else
                    {

                        clinic = false;

                        //שמירת כתובת 
                        //אם אין את העיר הזו היא נוספת כבר בבבחירת הכתובת הנחוצה
                        Cities codeC = General.sharat.GetCodeCityByName(labelCity.Text);
                        //שם הרחוב שרשום
                        string nameA = labelAdress.Text;

                        //ניסיון לשלוף מהרשימה באקסס 
                        var g = General.sharat.GetAdresssByName(nameA);
                        // אם קיים
                        if (g != null)
                        {
                            //הצבה
                            a = g;
                        }
                        // אם לא - הוספת הכתובת לרשימה באקסס
                        else
                        {
                            a.Street = nameA;
                            a.CodeCity = codeC;
                            a.CodeAdress = General.sharat.GetCodeToAdress();

                            var res = General.sharat.AddAdress(a);
                            if (res == 0)
                            {
                                MessageBox.Show("ארעה תקלה בשמירת הכתובת, נסה שוב");
                            }
                            else
                            {
                                MessageBox.Show("הכתובת נשמרה בהצלחה");
                            }
                        }
                        General.city = "";
                        General.adress = "בקליניקה שלי";
                    }

                    //אובייקט הזמנה חדשה ושליחה

                    Customers cust = new Customers { DateT = General.dateTreat, IsMyClinic = clinic, RemarksC = note, WayofPay = payW };
                    cust.CodeCustomerDetails = General.sharat.GetCodeCustomerDetailsByName(comboBoxNames.Text);
                    cust.CodeCustomers = General.sharat.GetCodeToCustomers();
                    cust.FinalPrice = finalPrice;
                    cust.CodeSale = new Sale() { CodeSale = codeSale1 };
                    cust.CodeAdress = a;
                    cust.HowLong = howLong1;
                    cust.Hour1 = hour2;

                    int resu;
                    if (General.Status == 1)
                    {

                        resu = General.sharat.AddCustomers(cust, codeSale1);
                    }
                    else
                    {
                        resu = General.sharat.updateOrdersAndCustomer(General.UpdateCustomer.CodeCustomers, cust, codeSale1);

                    }


                    General.city = "";
                    General.adress = "בקליניקה שלי";
                    if (resu == 0)
                    {
                        MessageBox.Show("ארעה שגיאה בשמירת ההזמנה, נסה שוב");
                    }
                    else
                    {
                        //צירוף תסרוקות להזמנה
                        General.adress = "בקליניקה שלי";
                        int resul, flag = 1;
                        foreach (var item in checkedListBox1.Items)
                        {

                            var t = item.ToString().Substring(item.ToString().IndexOf(':') + 1);//מוצא את הקוד של הסוג תסרוקת
                            Orders o1 = new Orders();
                            o1.CodeHairdo = list1.FirstOrDefault(p => p.CodeHairdo == Convert.ToInt32(t));//מוצא מהרשימה את האוביקט עם הקוד הנל
                            o1.Remarks = textBox1.Text;
                            o1.CodeOrder = General.sharat.GetCodeToOrder();
                            o1.CodeCustomers = cust;
                            resul = General.sharat.AddOrder(o1);
                            if (resul == 0)
                            {
                                flag = 0;
                                break;
                            }

                        }
                        if (flag == 0)
                            MessageBox.Show("ארעה שגיאה בשמירת ההזמנה, נסה שוב");
                        MessageBox.Show("ההזמנה נוספה בהצלחה");
                        CalendarMonth calanderO = new CalendarMonth();
                        calanderO.Show();
                        this.Hide();
                        calanderO.FormClosed += (s, args) => this.Close();
                        calanderO.Show();
                    }
                }
            }
        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        //עידכון
        //private void buttonUpdate_Click_1(object sender, EventArgs e)
        //{
        //    //var res = General.sharat.UpdateOrder(22);
        //    //if (res == 1)
        //    {
        //        MessageBox.Show("עידכון פרטי ההזמנה נערך בהצלחה");
        //    }
        //    //else
        //    {
        //        MessageBox.Show("נסה שוב");
        //    }
        //}

        private void button4_MouseHover(object sender, EventArgs e)
        {
            label25.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            label25.Visible = false;

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            label30.Visible = true;

        }

        private void button5_ClientSizeChanged(object sender, EventArgs e)
        {
            //label25.Visible = false;

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            label30.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalendarMonth cm1 = new CalendarMonth();
            cm1.Show();
            this.Hide();
            cm1.FormClosed += (s, args) => this.Close();
            cm1.Show();
        }


    }
}
