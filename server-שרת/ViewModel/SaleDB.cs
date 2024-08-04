using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace ViewModel
{
    public class SaleDB : BaseDB
    {
        public SaleDB() : base("Sale")
        {
        }
        protected override BaseEntity CreateModel()
        {
            Sale entity = new Sale();
            entity.CodeSale = (int)reader["CodeSale"];
            entity.NameSale = reader["NameSale"].ToString();
            entity.TheSale = (int)reader["TheSale"];

            return entity;
        }

        public Sale GetSaleByCode(int v)
        {
            return GetList().FirstOrDefault(item => item.CodeSale == v);
        }

        public List<Sale> GetList()
        {
            if (list.Count() == 0) { Select(); }
            return list.Cast<Sale>().ToList();
        }
        public Sale getSaleByCode(int v)
        {
            return GetList().FirstOrDefault(item => item.CodeSale == v);
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

