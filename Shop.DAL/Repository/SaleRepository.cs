using ObjectRepository;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repository
{
    public class SaleRepository: CommonRepository<Sale, int>
    {
        public SaleRepository(DbContext context):base(context)
        {

        }
    }
}
