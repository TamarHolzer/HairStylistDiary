using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject3.ServiceReference1;//server//

namespace MyProject3
{
    public static class General
    {
        public static Service1Client sharat = new Service1Client();
        public static int codeUser { get; } = 1234;
        public static List<string> lsWayOfPay = new List<string> { "מזומן", "צ'ק" };
        public static string city="";
        public static string adress="בקליניקה שלי";
        public static bool formState = false;
        public static DateTime dateTreat ;
        public static int codeTreatmentToUpdate;
        public static int codeOrederToDisplay;
        public static DateTime comebackCalander = DateTime.Today.Date;
        public static bool isFirst = false;



        //status  1= adding
        //status  2= updating
        public static int Status { get; set; }//יכיל את סטטוס הזמנה - הוספה או עדכון
        public static Customers UpdateCustomer { get; set; }//יכיל את פרטי ההזמנה של תסרוקת מסוימת וכך נוכל לגשת למאפיינים להציג לפני העדכון
        public static List<Orders> UpdateOrder { get; set; }
    }
}
