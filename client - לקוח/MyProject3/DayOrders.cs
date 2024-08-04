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
    public partial class DayOrders : Form
    {

        public DayOrders()
        {
            InitializeComponent();
        }

        //List<Customers> c = new List<Customers>();

        List<Customers> cs = new List<Customers>();
        private void DayOrders_Load(object sender, EventArgs e)
        {
            //קבלת תאריך מהזמנות קודמות ולפי זה לשלוף
            int monthD = General.dateTreat.Month;
            int yearD = General.dateTreat.Year;
            int dayD = General.dateTreat.Day;

            DateTime d = new DateTime(yearD, monthD, dayD);

            List<Customers> cs = new List<Customers>();
            cs = General.sharat.GetAllCustomers().ToList();



            //יש לשים לב אם משווים תאריך שהשעה לא מאופסת - יש להשוות "ידנית" את השנה חודש ויום
            //customers
            var customers = cs.Where(p => p.DateT == d).ToList();
            var sale = General.sharat.GetAllSales();
            var addresses = General.sharat.GetAllAddresses();
            var q = from c in customers

                    select new
                    {
                        c.CodeCustomers,
                        c.CodeCustomerDetails.NameC,
                        c.Hour1,
                        c.HowLong,
                        c.FinalPrice,
                        c.WayofPay,
                        c.RemarksC,
                        c.IsMyClinic,
                        c.DateT,
                        c.CodeSale.NameSale,
                        mail = c.CodeCustomerDetails.Mail1,
                        phone1 = c.CodeCustomerDetails.NPhone1,
                        phone2 = c.CodeCustomerDetails.NPhone2,
                        address = c.CodeAdress.Street + " " + c.CodeAdress.CodeCity.NameCity

                    };
            dataGridView1.DataSource = q.ToList();

            dataGridView1.Columns[0].HeaderText = "קוד הזמנה";
            dataGridView1.Columns[1].HeaderText = "שם לקוחה";
            dataGridView1.Columns[2].HeaderText = "שעת הטיפול";
            dataGridView1.Columns[3].HeaderText = "משך הטיפול";
            dataGridView1.Columns[4].HeaderText = "מחיר סופי";
            dataGridView1.Columns[5].HeaderText = "דרך התשלום";
            dataGridView1.Columns[6].HeaderText = "תיאור התסרוקת";
            dataGridView1.Columns[7].HeaderText = "האם הטיפול בקליניקה";
            dataGridView1.Columns[8].HeaderText = "תאריך הטיפול";
            dataGridView1.Columns[9].HeaderText = "הנחה";
            dataGridView1.Columns[10].HeaderText = "מייל";
            dataGridView1.Columns[11].HeaderText = "פלאפון 1";
            dataGridView1.Columns[12].HeaderText = "פלאפון 2";
            dataGridView1.Columns[13].HeaderText = "כתובת";
            label2.Text = d.ToString();

            //התאריך של היום
            DateTime dtoday1 = DateTime.Today;
            label5.Text = dtoday1.ToShortDateString().ToString();
            
        }


        private void button19_Click(object sender, EventArgs e)
        {
            CalendarMonth cm1 = new CalendarMonth();
            cm1.Show();
            this.Hide();
            cm1.FormClosed += (s, args) => this.Close();
            cm1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrder ad = new AddOrder();
            ad.Show();
            this.Hide();
            ad.FormClosed += (s, args) => this.Close();
            ad.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //עדכון ההזמנה הרצויה:
            General.Status = 2;

            int updateOrder;

            //אם יש יותר משורה אחת - צריך להדגיש
            //אם לא - גם אם לא ידגישו זה לא יזרוק שגיאה

            if (dataGridView1.SelectedRows.Count>0)
            {
                updateOrder = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            else if (dataGridView1.SelectedCells.Count==1)
            {
                updateOrder = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value);
            }
            else
            {
                updateOrder =  Convert.ToInt32((dataGridView1.Rows[0]).Cells[0].Value);//שליפת הקוד הזמנה של האובייקט המוצג    
            }

            cs = General.sharat.GetAllCustomers().ToList();
            General.UpdateCustomer =cs.FirstOrDefault(p => p.CodeCustomers == updateOrder);//הצבת המשתנה שמצאנו בגלובל
            General.UpdateOrder = General.sharat.GetOrderByCodeCustomer(updateOrder).ToList();
            General.isFirst = true;
            AddOrder ad = new AddOrder();
            ad.Show();
            this.Hide();
            ad.FormClosed += (s, args) => this.Close();
            ad.Show();
            General.isFirst = false;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            General.dateTreat = DateTime.Today.Date;
            DayOrders doo = new DayOrders();
            doo.Show();
            this.Hide();
            doo.FormClosed += (s, args) => this.Close();
            doo.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //מחיקת ההזמנה הרצויה:

            int deleteOrder;
            //מציאת קוד של הזמנה
            //אם יש יותר משורה אחת - צריך להדגיש
            //אם לא - גם אם לא ידגישו זה לא יזרוק שגיאה

            if (dataGridView1.SelectedRows.Count > 0)
            {
                deleteOrder = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            else if (dataGridView1.SelectedCells.Count == 1)
            {
                deleteOrder = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value);
            }
            else
            {
                deleteOrder = Convert.ToInt32((dataGridView1.Rows[0]).Cells[0].Value);//שליפת הקוד הזמנה של האובייקט המוצג    
            }

            //וידוא האם למחוק
            string str = "האם ברצונך למחוק את ההזמנה של " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            DialogResult answer = MessageBox.Show(str,"מחיקה" , MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if(answer== DialogResult.Yes)
            {
                //פעולת המחיקה
                var res =  General.sharat.deleteCustomersWithAllDetails(deleteOrder);

                if (res == 1)
                {
                    MessageBox.Show("נמחק בהצלחה");                   
                }
                else
                {
                    MessageBox.Show("שגיאה אנא נסה שוב");

                }
                DayOrders ad5 = new DayOrders();
                ad5.Show();
                this.Hide();
                ad5.FormClosed += (s, args) => this.Close();
                ad5.Show();
                General.isFirst = false;
            }
            else
            {

            }

        }
    }
}
