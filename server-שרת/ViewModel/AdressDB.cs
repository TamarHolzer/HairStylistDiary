using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AdressDB : BaseDB
    {
        public AdressDB() : base("Adress") { }

        protected override BaseEntity CreateModel()
        {
            Adress entity = new Adress();
            entity.CodeAdress = Convert.ToInt32(reader["CodeAdress"]);
            entity.Street = reader["Street"].ToString();
            entity.CodeCity = MyDB.Cities.getCitiesDById((int)reader["CodeCity"]);
            return entity;
        }

        //internal Adress GetAdressByCodereader(int v)
        //{
        //    return GetList().FirstOrDefault(item => item.CodeCustomers == v);
        //}

        public List<Adress> GetList()
        {
            if (list.Count() == 0) { Select(); }
            var l = list.Cast<Adress>().ToList();
            return l;
        }
        public Adress GetAdressByCode(int v)
        {
            return GetList().FirstOrDefault(item => item.CodeAdress == v);
        }

        public Adress GetAdresssByName(string name)
        {
            return GetList().FirstOrDefault(item => item.Street == name);
        }

        public int GetCodeToAdress()
        {
            if (MyDB.Adress.GetList().Count == 0) return 1;
            return MyDB.Adress.GetList().Max(X => X.CodeAdress) + 1;
        }
        public int AddAdress(Adress adress)
        {
            Add(adress);
            int r = SaveChanges();
            return r;
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

