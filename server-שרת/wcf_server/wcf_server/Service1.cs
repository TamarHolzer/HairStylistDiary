using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;
namespace wcf_server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        //sales
        public List<Sale> GetAllSales()
        {
            return MyDB.Sale.GetList();
        }

        public Sale getSaleByCode(int value)//שליפת הנחה לפי קוד
        {
            return MyDB.Sale.GetSaleByCode(value);
        }

        //cities 
        public List<Cities> getAllCities()
        {
            return MyDB.Cities.GetList();
        }
        public Cities GetCodeCityByName(string c)
        {
            return MyDB.Cities.GetCodeCityByName(c);
        }
        public int GetCodeToCities()
        {
            return MyDB.Cities.GetCodeToCities();
        }
        public int AddCity(Cities cities)
        {
            return MyDB.Cities.AddCity(cities);
        }

        //adress
        public List<Adress> GetAllAddresses()
        {
            return MyDB.Adress.GetList();
        }
        public int GetCodeToAdress()
        {
            return MyDB.Adress.GetCodeToAdress();
        }
        public int AddAdress(Adress adress)
        {
            return MyDB.Adress.AddAdress(adress);
        }

        public Adress GetAdresssByName(string name)
        {
            return MyDB.Adress.GetAdresssByName(name);
        }

        public Adress GetAdressByCode(int v)
        {
            return MyDB.Adress.GetAdressByCode(v);
        }

        //hairdo
        public List<Hairdo> GetAllHairdos()
        {
            return MyDB.Hairdo.GetList();
        }

        public int GetCodeToHairdo()
        {
            return MyDB.Hairdo.GetCodeToHairdo();
        }

        public int AddHairdo(Hairdo hairdo)
        {
            return MyDB.Hairdo.AddHairdo(hairdo);
        }
        //customers
        public List<Customers> GetAllCustomers()
        {
            return MyDB.Customers.GetList();
        }
        public int AddCustomers(Customers customers, int codeSale1)
        {
            return MyDB.Customers.AddCustomers(customers, codeSale1);
        }

        public int GetCodeToCustomers()
        {
            return MyDB.Customers.GetCodeToCustomers();
        }


        public int updateOrdersAndCustomer(int code ,Customers c, int codeSale1)
        {
            //delete
            var res = deleteCustomersWithAllDetails(code);
            if (res == 0)
            {
                return 0;
            }
            else
            {
              return  AddCustomers(c, codeSale1);

            }

                    

        }

        public int deleteCustomersWithAllDetails(int code)
        {
            return MyDB.Customers.deleteCustomersWithAllDetails(code);
        }
        public Customers getCustomerDetailsByCode(int code)
        {
            return MyDB.Customers.getCustomerDetailsByCode((int)code);
        }

        public List<Customers> GetAllCustomersByCustName(string n)
        {
            return MyDB.Customers.GetAllCustomersByCustName(n);
        }
        public List<Orders> GetOrderListByCustomer(int cd)
        {
            return MyDB.Orders.GetOrderListByCustomer(cd);
        }
        



        //customerDetails
        public List<CustomerDetails> GetAllCustomerDetails()
        {
            return MyDB.CustomersDetails.GetList();
        }
        public CustomerDetails GetCodeCustomerDetailsByName(string name)
        {
            return MyDB.CustomersDetails.GetCodeCustomerDetailsByName(name);
        }
        public int AddCust(CustomerDetails c)
        {
            return MyDB.CustomersDetails.AddCust(c);
        }
        public int GetCodeToCustomersD()
        {
            return MyDB.CustomersDetails.GetCodeToCustomersD();
        }
        public int IsExist(string n)
        {
            return MyDB.CustomersDetails.IsExist(n);
        }


        //orders
        public List<Orders> GetAllOrders()
        {
            return MyDB.Orders.GetList();
        }
        public List<Orders> GetOrderByCodeCustomer(int c)
        {
            return MyDB.Orders.getOrderByCodeCustomer(c);
        }
        public Orders getOrderByCode(int v)
        {
            return MyDB.Orders.getOrderByCode(v);
        }
        public int UpdateOrder(Customers customers, int codeSale1)
        {
            return MyDB.Customers.UpdateOrder(customers);
        }

        public int AddOrder(Orders order)
        {
            return MyDB.Orders.AddOrder(order);
        }
        public int GetCodeToOrder()
        {
            return MyDB.Orders.GetCodeToOrder();
        }


    }
}

