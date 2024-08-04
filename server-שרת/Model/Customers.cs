using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customers : BaseEntity
    {
        public int CodeCustomers { get; set; }
        public CustomerDetails CodeCustomerDetails { get; set; }
        public string Hour1 { get; set; }
        public int FinalPrice { get; set; }
        public string HowLong { get; set; }
        public string WayofPay { get; set; }
        public string RemarksC { get; set; }
        public DateTime DateT { get; set; }
        public bool IsMyClinic { get; set; }
        public Sale CodeSale { get; set; }
        public Adress CodeAdress { get; set; }




        public override string[] GetKeyFields()
        {
            return new string[] { "CodeCustomers" };
        }

        public override string GetTableName()
        {
            return "Customers";
        }

        public override bool Equals(object obj)
        {
            if (obj is Customers)
                return (obj as Customers).CodeCustomers == this.CodeCustomers;
            return false;
        }
       
    }
}
