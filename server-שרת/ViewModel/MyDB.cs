using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class MyDB
    {
        public static AdressDB Adress = new AdressDB();
        public static CustomerDetailsDB CustomersDetails = new CustomerDetailsDB();
        public static CustomersDB Customers = new CustomersDB();
        public static HairdoDB Hairdo = new HairdoDB();
        public static OrdersDB Orders = new OrdersDB();
        public static CitiesDB Cities = new CitiesDB();
        public static SaleDB Sale = new SaleDB();
    }
}
