using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hairdo : BaseEntity
    {
        public int CodeHairdo { get; set; }
        public string DescriptionHairdo { get; set; }
        public int Price { get; set; }
        public override string[] GetKeyFields()
        {
            return new string[] { "CodeHairdo" };
        }

        public override string GetTableName()
        {
            return "Hairdo";
        }
        public override bool Equals(object obj)
        {
            if (obj is Hairdo)
                return (obj as Hairdo).CodeHairdo == this.CodeHairdo;
            return false;
        }
    }

}
