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
    public class CategoryRepository: CommonRepository<Category, int> 
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
