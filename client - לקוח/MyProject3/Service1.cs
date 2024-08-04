
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace Sharat
{
    public class Service1 : IService1
    {
        public bool CheckUser(int code)
        {
            if (code == 0)
                return true;
            return false;
        }
      public List<Cities> GetAllCities()
        {
            return MyDB.Cities.GetList();
        }

      public  List<CustomerD> GetAllCustomerD()
        {
            return MyDB.CustomersD.GetList();
        }

        public List<Hairdo> GetAllHairdo()
        {
            return MyDB.Hairdo.GetList();
        }  
    
       public List<Sale> GetAllSale()
        {
            return MyDB.Sale.GetList();
        }

        public Customers GetCustomers(int code)
        {
            return MyDB.Customers.getCustomerDByCode(code);
        }

        public Customers GetCustomersByName(string name)
        {
            return MyDB.Customers.getCustomerDByName(name);
        }
        public int GetCodeCustomerDsByName(string name)
        {
            CustomerD customerD = new CustomerD();
            customerD = MyDB.CustomersD.GetCodeCustomerDByName(name);
            return customerD.CodeCustomerD;
        }

       
        //public int GetCodeHairdoByName(string name)
        //{
        //    Hairdo hairdo = new Hairdo();
        //    hairdo = MyDB.Hairdo.GetCodeAddsByName(name);
        //    return hairdo.CodeHairdo;
        //}


        //קבלת רשימות
        public List<Customers> GetCustomersbyDate(DateTime date)//קבלת רשימת לקוחות ע"פ תאריך
        {
            return MyDB.Customers.GetCustomerByDate(date);
        }
        public List<Customers> GetAllCustomers()
        {
            return MyDB.Customers.GetList();
        }
        public List<Adress> GetAllAdresses()     
        {
            return MyDB.Adress.GetList();
        }

        public List<Orders> GetAllOrders()
        {
            return MyDB.Orders.GetList();
        }


        // הוספות
        public string AddOrder(Orders newOrders)
        {
            MyDB.Orders.Add(newOrders);
            MyDB.Orders.SaveChanges();
            return "הפגישה הוכנסה למערכת בהצלחה";
        }
        public void AddHairdo(Hairdo hairdo)
        {
            MyDB.Hairdo.Add(hairdo);
            MyDB.Hairdo.SaveChanges();
        }
        public void AddAdress(Adress adress)
        {
            MyDB.Adress.Add(adress);
            MyDB.Adress.SaveChanges();
        }

        public void AddCustomers( Customers customers)
        {
            MyDB.Customers.Add(customers);
            MyDB.Customers.SaveChanges();
        }
       public void AddCustomerD(CustomerD customerD)
        {

            MyDB.CustomersD.Add(customerD);
            MyDB.CustomersD.SaveChanges();
        }
     
        public void AddSale(Sale sale)
        {
            MyDB.Sale.Add(sale);
            MyDB.Sale.SaveChanges();
        }
        public void AddCity(Cities cities)
        {
            MyDB.Cities.Add(cities);
            MyDB.Cities.SaveChanges();
        }
     
        public void AddListOrders(List<Orders> list)
        {
            foreach (Orders item in list)
            {
                MyDB.Orders.Add(item);
            }
          MyDB.Orders.SaveChanges();
        }

        //עדכון
        public void UpdateCustomers(Customers customers)
        {
            MyDB.Customers.Update(customers);
            MyDB.Customers.SaveChanges();
        }
        public void UpdateCustomersD(CustomerD customerD)
        {
            MyDB.CustomersD.Update(customerD);
            MyDB.CustomersD.SaveChanges();
        }
        public void UpdateListOrders(List<Orders> list)
        {
            int i = 0;
            foreach (Orders item in list)
            {
                if(MyDB.Orders.getOrderByCode(item.CodeOrder)!=null)
                {
                    MyDB.Orders.Update(item);
                    MyDB.Orders.SaveChanges();
                }
                else
                {
                    item.CodeOrder = GetCodeToOrder() + i;
                    MyDB.Orders.Add(item);
                    MyDB.Orders.SaveChanges();
                }
            }
            
        }
        public void DeleteCustomers(Customers customers)
        {
            MyDB.Customers.Deleted(customers);
            MyDB.Customers.SaveChanges();
        }

        public int GetCodeToHairdo()
        {
            if (MyDB.Hairdo.GetList().Count == 0) return 1;
            return MyDB.Hairdo.GetList().Max(X => X.CodeHairdo) + 1;
        }
        public  int GetCodeToOrder()
        {
            if (MyDB.Orders.GetList().Count == 0) return 1;
            return MyDB.Orders.GetList().Max(X => X.CodeOrder) + 1;
        }  public  int GetCodeToAdress()
        {
            if (MyDB.Adress.GetList().Count == 0) return 1;
            return MyDB.Adress.GetList().Max(X => X.CodeAdress) + 1;
        }
        
        public int GetCodeToCustomers()
        {
            if (MyDB.Customers.GetList().Count == 0) return 1;
            return MyDB.Customers.GetList().Max(X => X.CodeCustomers) + 1;
        }

        public int GetCodeToCustomersD()
        {
            if (MyDB.CustomersD.GetList().Count == 0) return 1;
            return MyDB.CustomersD.GetList().Max(X => X.CodeCustomerD) + 1;
        }

        public int GetCodeToCities()
        {
            if (MyDB.Cities.GetList().Count == 0) return 1;
            return MyDB.Cities.GetList().Max(X => X.CodeCity) + 1;
        }
       
         public int GetCodeToSale()
        {
            if (MyDB.Sale.GetList().Count == 0) return 1;
            return MyDB.Sale.GetList().Max(X => X.CodeSale) + 1;
        }

    }
}


