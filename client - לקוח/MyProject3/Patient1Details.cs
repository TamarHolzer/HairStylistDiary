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
    public partial class Patient1Details : Form
    {
        public Patient1Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //בדיקת תקינות פלאפון ראשון
            if (IsValid(textBox4.Text) == false)
                label8.Visible = true;

            //בדיקת תקינות פלאפון שני
            if (IsValid(textBox5.Text) == false)
                label7.Visible = true;
            else if(textBox5.Text== null)
                label7.Visible=false;

            if (IsValidMail(textBox6.Text) == false)
            {
                label6.Visible = true;
            }
            if (General.sharat.IsExist(textBox1.Text) == 1)
                label9.Visible = true;

            if (!(label8.Visible == true || label7.Visible == true || label6.Visible == true || label9.Visible == true))
            {
                CustomerDetails c = new CustomerDetails { NameC = textBox1.Text, NPhone1 = textBox4.Text, NPhone2 = textBox5.Text, Mail1 = textBox6.Text };
                c.CodeCustomerDetails = General.sharat.GetCodeToCustomersD();
                var res = General.sharat.AddCust(c);
                if (res == 0)
                {
                    MessageBox.Show("ארעה שגיאה בהכנסת הלקוח, נסה שוב");
                }
                else
                {
                    MessageBox.Show("לקוח נוסף הצטרף בהצלחה");
                    MessageBox.Show("שימי לב הדף יתאפס לכן דאגי למלא מחדש את כל הנתונים");
                }

                AddOrder ad1 = new AddOrder();
                ad1.Show();
                this.Hide();
                ad1.FormClosed += (s, args) => this.Close();
                ad1.Show();
            }
        }

        //חזרה ליצירת הזמנה חדשה
        private void button2_Click(object sender, EventArgs e)
        {
            AddOrder ad1 = new AddOrder();
            ad1.Show();
            this.Hide();
            ad1.FormClosed += (s, args) => this.Close();
            ad1.Show();
        }

        //פונקציה לבדיקת תקינות למייל
        public static bool IsValidMail(string s1)
        {
            if (null == s1)
                return false;

            var posAt = s1.IndexOf('@');

            if (posAt <= 0)
            {  // @ does not exist      
                return false;
            }
            bool flag = false;
            for (int i = posAt + 1; i < s1.Length; i++)
            {
                if (s1[i] == '.')
                    flag = true;
            }

            return flag;
        }
        //פונקציה לבדיקת תקינות פלאפון
        public static bool IsValid(string s)
        {
            if (null == s)
                return false;

            var validPrefixes = new[] {
                  "02",
                  "03",
                  "04",
                  "08",
                  "09",
                  "072",
                  "073",
                  "074",
                  "076",
                  "077",
                  "079",
                  "050",
                  "052",
                  "053",
                  "054",
                  "055",
                  "058"
                  };
            int prefixLength = 0;
            var foundMatchingPrefix = false;
            foreach (var validPrefix in validPrefixes)
                if (s.StartsWith(validPrefix))
                {
                    prefixLength = validPrefix.Length;
                    foundMatchingPrefix = true;
                    break;
                }

            if (!foundMatchingPrefix)
                return false;

            if (s.Length == prefixLength)
                return false;

            int nextDigitIndex;
            if (s[prefixLength] == ' ' || s[prefixLength] == '-')
                nextDigitIndex = prefixLength + 1;
            else
                nextDigitIndex = prefixLength;

            // remaining length should be between 6 and 7
            var remainingLength = s.Length - nextDigitIndex;
            if (!((6 == remainingLength) || (7 == remainingLength)))
                return false;

            // check the rest of the string to be digits
            for (int i = nextDigitIndex; i < s.Length; i++)
                if (!char.IsDigit(s[i]))
                    return false;

            return true;
        }

        //כיבוי התווית לבדיקה מחדש
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
