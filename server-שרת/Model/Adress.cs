using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class Adress : BaseEntity
    {
        public int CodeAdress { get; set; }
        public string Street { get; set; }
        public Cities CodeCity { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "CodeAdress" };
        }

        public override string GetTableName()
        {
            return "Adress";
        }
        public override bool Equals(object obj)
        {
            if (obj is Adress)
                return (obj as Adress).CodeAdress == this.CodeAdress;
            return false;
        }
    }
}
