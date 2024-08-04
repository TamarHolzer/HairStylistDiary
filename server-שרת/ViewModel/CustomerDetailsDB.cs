using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class CustomerDetailsDB : BaseDB
    {
        public CustomerDetailsDB() : base("CustomerDetails")
        {
        }

        public List<CustomerDetails> GetList()
        {
            if (list.Count() == 0) { Select(); }
            var r = list.Cast<CustomerDetails>().ToList();
            return r;
        }

        protected override string CreateDeletedCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override string CreateInsertCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity CreateModel()
        {
            CustomerDetails cst = new CustomerDetails();
            cst.CodeCustomerDetails = Convert.ToInt32(reader["CodeCustomerDetails"]);
            cst.NPhone1 = reader["NPhone1"].ToString();
            cst.NPhone2 = reader["NPhone2"].ToString();
            cst.NameC = reader["NameC"].ToString();
            cst.Mail1 = reader["Mail1"].ToString();
            return cst;
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }


        internal CustomerDetails getCustomerDetailsById(int v)
        {
            return GetList().FirstOrDefault(item => item.CodeCustomerDetails == v);
        }

        //הוספה - יוצרות אוביקט חדש בפורם, את הקוד נציב ממה שחוזר מהפונקציה כאן שמחזירה את הקוד הבא
        //יצירת פונקצית הוספה ששולחת לADD  וגם עושה את שמירה

        //שליחה לmyDB .CLASS NAME TO ADD.addFunction
        public int AddCust(CustomerDetails c)
        {
            Add(c);
            var res=SaveChanges();
            return res;
        }
        public CustomerDetails GetCodeCustomerDetailsByName(string name)
        {
            return GetList().FirstOrDefault(item => item.NameC == name);
        
        }
        public int IsExist(string n)
        {
           var l= GetList();
            foreach (var item in l)
            {
                if (item.NameC == n)
                    return 1;
            } 
            return 0;
        }

        //שולף את הקוד האחרון ומחזיר אחד יותר - הוספת אוביקט חדש
        public int GetCodeToCustomersD()
        {
            if (GetList().Count == 0) return 1;
            return GetList().Max(X => X.CodeCustomerDetails) + 1;
        }
    }
}



