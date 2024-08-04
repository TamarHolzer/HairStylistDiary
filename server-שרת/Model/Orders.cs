using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orders : BaseEntity
    {
        public int CodeOrder { get; set; }
        public string Remarks { get; set; }
        public Hairdo CodeHairdo { get; set; }
        public Customers CodeCustomers { get; set; }


        public override string[] GetKeyFields()
        {
            return new string[] { "CodeOrder" };
        }

        public override string GetTableName()
        {
            return "Orders";
        }
        public override bool Equals(object obj)
        {
            if (obj is Orders)
                return (obj as Orders).CodeOrder == this.CodeOrder;
            return false;
        }
     
    }
}
