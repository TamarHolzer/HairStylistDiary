
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model
{

    public class Cities : BaseEntity
    {
        public int CodeCity { get; set; }
        public string NameCity { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "CodeCity" };
        }

        public override string GetTableName()
        {
            return "Cities";
        }
        public override bool Equals(object obj)
        {
            if (obj is Cities)
                return (obj as Cities).CodeCity == this.CodeCity;
            return false;
        }
    }
}

