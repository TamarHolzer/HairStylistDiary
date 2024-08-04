using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class CitiesDB : BaseDB
    {


        public CitiesDB() : base("Cities")
        {
        }

        public List<Cities> GetList()
        {

            if (list.Count == 0)
            {
                Select();
            }
            var t = list.Cast<Cities>().ToList();
            return t;
        }
        public int AddCity(Cities cities)
        {
            Add(cities);
            var res = SaveChanges();
            return res;
        }
        public int GetCodeToCities()
        {
            if (MyDB.Cities.GetList().Count == 0) return 1;
            return MyDB.Cities.GetList().Max(X => X.CodeCity) + 1;
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
            Cities c = new Cities();
            c.CodeCity = Convert.ToInt32(reader["CodeCity"]);
            c.NameCity = reader["NameCity"].ToString();
            return c;
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        internal Cities getCitiesDById(int v)
        {
            return GetList().FirstOrDefault(item => item.CodeCity == v);
        }

        public Cities GetCodeCityByName(string c)
        {
            return GetList().FirstOrDefault(item => item.NameCity == c);
        }





    }
}
