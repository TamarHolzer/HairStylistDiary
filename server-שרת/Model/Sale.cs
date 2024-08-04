using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sale : BaseEntity
    {
        public int CodeSale { get; set; }
        public string NameSale { get; set; }
        public int TheSale { get; set; }
        public override string[] GetKeyFields()
        {
            return new string[] { "CodeSale" };
        }

        public override string GetTableName()
        {
            return "Sale";
        }
        public override bool Equals(object obj)
        {
            if (obj is Sale)
                return (obj as Sale).CodeSale == this.CodeSale;
            return false;
        }
    }
}
