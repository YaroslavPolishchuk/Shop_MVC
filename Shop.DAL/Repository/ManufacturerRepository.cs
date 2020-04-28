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
    public class ManufacturerRepository : CommonRepository<Manufacturer, int>
    {
        public ManufacturerRepository(DbContext context) : base(context)
        {
        }
    }
}
