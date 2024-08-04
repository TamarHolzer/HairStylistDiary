using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerDetails : BaseEntity
    {
        public int CodeCustomerDetails { get; set; }
        public string NPhone1 { get; set; }
        public string NPhone2 { get; set; }
        public string NameC { get; set; }
        public string Mail1 { get; set; }
        public override string[] GetKeyFields()
        {
            return new string[] { "CodeCustomerDetails" };
        }

        public override string GetTableName()
        {
            return "CustomerDetails";
        }
        public override bool Equals(object obj)
        {
            if (obj is CustomerDetails)
                return (obj as CustomerDetails).CodeCustomerDetails == this.CodeCustomerDetails;
            return false;
        }
    }
}
