using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class CustomersDB : BaseDB
    {
        public CustomersDB() : base("Customers")
        {
        }

        public List<Customers> GetList()
        {
            if (list.Count() == 0) { Select(); }
            return list.Cast<Customers>().ToList();
        }

        protected override BaseEntity CreateModel()
        {
            Customers customers = new Customers();
            customers.CodeCustomers = Convert.ToInt32(reader["CodeCustomers"]);
            customers.CodeCustomerDetails = MyDB.CustomersDetails.getCustomerDetailsById((int)reader["CodeCustomerDetails"]);
            customers.HowLong = reader["HowLong"].ToString();
            customers.WayofPay = reader["WayofPay"].ToString();
            customers.RemarksC = reader["RemarksC"].ToString();
            customers.DateT = Convert.ToDateTime(reader["DateT"]);
            customers.Hour1 = reader["Hour1"].ToString();
            customers.IsMyClinic = Convert.ToBoolean(reader["IsMyClinic"]);
            customers.CodeSale = MyDB.Sale.getSaleByCode((int)reader["CodeSale"]);
            customers.CodeAdress = MyDB.Adress.GetAdressByCode((int)reader["CodeSale"]);
            customers.FinalPrice = (int)reader["FinalPrice"];


            return customers;
        }

        public List<Customers> GetCustomerByDate(DateTime date)
        {
            List<Customers> lstDate = new List<Customers>();
            foreach (var item in GetList())
            {
                if (item.DateT == date)
                {
                    lstDate.Add(item);
                }
            }
            return lstDate;
        }

        public Customers getCustomerDetailsByCode(int code)
        {
            return GetList().FirstOrDefault(item => item.CodeCustomers == code);
        }

        public Customers getCustomerDetailsByName(string name)
        {
            return GetList().FirstOrDefault(item => item.CodeCustomerDetails.NameC == name);
        }
        public List<Customers> GetAllCustomersByCustName(string n)
        {
            var lc = GetList();
            List<Customers> lst = new List<Customers>();
            foreach (var item in lc)
            {
                if (item.CodeCustomerDetails.NameC == n)
                    lst.Add(item);
            }
            return lst;
        }
        public int GetCodeCustomerByNameCust(string n,DateTime dt)
        {
            var lc = GetList();
            foreach (var item in lc)
            {
                if(item.CodeCustomerDetails.NameC==n&&item.DateT == dt)
                {
                    return item.CodeCustomers;
                }
                
            }
            return 0;
        }

        /*public List<DateTime> GetOrdersByCustName(string name)
        {
            var lc = GetList();
            List<DateTime> ld = new List<DateTime>();
            foreach (var item in lc)
            {
                ld.Add(item.DateT);
            }
            return ld;
        }*/

        protected override string CreateInsertCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override string CreateDeletedCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        public int GetCodeToCustomers()
        {
            if (MyDB.Customers.GetList().Count == 0) return 1;
            return MyDB.Customers.GetList().Max(X => X.CodeCustomers) + 1;
        }

        public Customers GetCustomers(int code)
        {
            return MyDB.Customers.getCustomerDetailsByCode(code);
        }

        public int AddCustomers(Customers customers, int codeSale1)
        {
            //customers.CodeSale= MyDB.Sale.getSaleByCode(codeSale1);
            //customers.CodeAdress = null;
            Add(customers);
            int r = SaveChanges();
            return r;
        }
        //מחיקה של הזמנה עם כל הפרטים
        public int deleteCustomersWithAllDetails(int code)
        {
            //חיפוש הלקוחה הזו
            //מחיקה של כל השורות בטבלת הזמנות שמקושרות אליה,
            //אם יש כתובת
            //ורק אז למחוק את הלקוחה
            var cust = GetList().FirstOrDefault(u => u.CodeCustomers == code);
            var details = MyDB.Orders.GetList().Where(o => o.CodeCustomers.CodeCustomers == cust.CodeCustomers).ToList();
            //רק אם זה לא בקליניקה
            //Adress address = MyDB.Adress.GetList().FirstOrDefault(predicate: u => cust.CodeAdress == u);
            //MyDB.Adress.Deleted(address);

            foreach (var item in details)
            {
                MyDB.Orders.Deleted(item);
            }

            var r = MyDB.Orders.SaveChanges();
            if (r != 0)
            {
                Deleted(cust);
                var res = SaveChanges();

                return res;
            }
            else
            {
                return r;
            }

        }
        public int UpdateOrder(Customers code)
        {
            //חיפוש הלקוחה הזו
            //עידכון השורות בטבלת הזמנות שמקושרות אליה,

            var custo = GetList().FirstOrDefault(u => u.CodeCustomers == code.CodeCustomers);
            var details = MyDB.Orders.GetList().Where(o => o.CodeCustomers == custo).ToList();

            Adress address = MyDB.Adress.GetList().FirstOrDefault(predicate: u => custo.CodeAdress == u);
            MyDB.Adress.Update(address);

            foreach (var item in details)
            {
                MyDB.Orders.Update(item);
            }
            var r = MyDB.Orders.SaveChanges();
            if (r != 0)
            {
                Update(custo);
                var res = SaveChanges();

                return res;
            }
            else
            {
                return r;
            }


        }



    }


}

