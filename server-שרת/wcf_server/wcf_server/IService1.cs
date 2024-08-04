using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace wcf_server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int updateOrdersAndCustomer(int code, Customers c, int codeSale1);

        [OperationContract]
        Sale getSaleByCode(int value);

        [OperationContract]
        List<Cities> getAllCities();

        [OperationContract]
        Adress GetAdressByCode(int v);

        [OperationContract]
        int GetCodeToHairdo();

        [OperationContract]
        List<Customers> GetAllCustomers();

        [OperationContract]
        int AddHairdo(Hairdo hairdo);

        [OperationContract]
        List<Hairdo> GetAllHairdos();

        [OperationContract]
        List<CustomerDetails> GetAllCustomerDetails();

        [OperationContract]
        List<Sale> GetAllSales();

        [OperationContract]
        Adress GetAdresssByName(string name);

        [OperationContract]
        Cities GetCodeCityByName(string c);

        [OperationContract]
        int UpdateOrder(Customers customers, int codeSale1);

        [OperationContract]
        int AddAdress(Adress adress);


        [OperationContract]
        int GetCodeToAdress();

        [OperationContract]
        List<Orders> GetAllOrders();

        [OperationContract]
        CustomerDetails GetCodeCustomerDetailsByName(string name);

        [OperationContract]
        int GetCodeToCustomers();

        [OperationContract]
        int AddCustomers(Customers customers, int codeSale1);

        [OperationContract]
        List<Adress> GetAllAddresses();

        [OperationContract]
        List<Orders> GetOrderByCodeCustomer(int c);

        [OperationContract]
        int GetCodeToCities();

        [OperationContract]
        int AddCity(Cities cities);

        [OperationContract]
        int deleteCustomersWithAllDetails(int code);

        [OperationContract]
        Customers getCustomerDetailsByCode(int code);

        [OperationContract]
        Orders getOrderByCode(int v);

        [OperationContract]
        int AddCust(CustomerDetails c);

        [OperationContract]
        int GetCodeToCustomersD();

        [OperationContract]
        int IsExist(string n);

        [OperationContract]
        List<Customers> GetAllCustomersByCustName(string n);

        [OperationContract]
        List<Orders> GetOrderListByCustomer(int cd);

        [OperationContract]
        int AddOrder(Orders order);

        [OperationContract]
        int GetCodeToOrder();

              
    }
}
