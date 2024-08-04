using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class HairdoDB : BaseDB
    {

        public HairdoDB() : base("hairdo")
        {
        }
        protected override BaseEntity CreateModel()
        {
            {
                Hairdo hairdo = new Hairdo();
                hairdo.CodeHairdo = (int)reader["CodeHairdo"];
                hairdo.DescriptionHairdo = reader["DescriptionHairdo"].ToString();
                hairdo.Price = (int)reader["Price"];
                return hairdo;
            }
        }

        public List<Hairdo> GetList()
        {
            if (list.Count() == 0) { Select(); }
            return list.Cast<Hairdo>().ToList();
        }
        public Hairdo getHairdoByCode(int v)
        {
            return GetList().FirstOrDefault(item => item.CodeHairdo == v);
        }

        public Hairdo GetCodeHairdoByName(string name)
        {
                return GetList().FirstOrDefault(item => item.DescriptionHairdo == name);
        }

        public int GetCodeToHairdo()
        {
            if (MyDB.Hairdo.GetList().Count == 0) return 1;
            return MyDB.Hairdo.GetList().Max(X => X.CodeHairdo) + 1;
        }
        public int AddHairdo(Hairdo hairdo)
        {
            MyDB.Hairdo.Add(hairdo);
            var res = MyDB.Hairdo.SaveChanges();
            return res;
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
