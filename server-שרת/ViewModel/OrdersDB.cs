using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrdersDB : BaseDB
    {
        public OrdersDB() : base("Orders")
        {
        }
        public List<Orders> GetList()
        {
            if (list.Count() == 0) { Select(); }
            var r = list.Cast<Orders>().ToList();
            return r;
        }

        protected override BaseEntity CreateModel()
        {
            {
                Orders orders = new Orders();
                orders.CodeOrder = (int)reader["CodeOrder"];
                orders.CodeCustomers = MyDB.Customers.getCustomerDetailsByCode((int)reader["CodeCustomers"]);
                orders.Remarks = reader["Remarks"].ToString();
                orders.CodeHairdo = MyDB.Hairdo.getHairdoByCode((int)reader["CodeHairdo"]);

                return orders;
            }
        }
        public Orders getOrderByCode(int v)
        {
            return GetList().FirstOrDefault(item => item.CodeOrder == v);
        }
        public List<Orders> getOrderByCodeCustomer(int c)
        {
            var l = GetList().FindAll(item => item.CodeCustomers.CodeCustomers == c);
            return l;
        }
        public List<Orders> GetOrderListByCustomer(int cd)
        {
            List<Orders> or = GetList().Where(p=>p.CodeCustomers.CodeCustomers==cd).ToList();
            try
            {
                //foreach (var item in or)
                //{
                //    if (item.CodeCustomers.CodeCustomers != cd)
                //        or.Remove(item);

                //}
                return or;
            }
            catch
            {
                return or;
            }

        }
        public int GetCodeToOrder()
        {
            if (MyDB.Orders.GetList().Count == 0) return 1;
            return MyDB.Orders.GetList().Max(X => X.CodeOrder) + 1;
        }

        public int AddOrder(Orders order)
        {

            Add(order);
            int r = SaveChanges();
            return r;

        }
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

    }
}
