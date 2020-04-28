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
    public class SalePosRepository: CommonRepository<SalePos, int>
    {
        public SalePosRepository(DbContext context) : base(context)
        {

        }
    }
}
