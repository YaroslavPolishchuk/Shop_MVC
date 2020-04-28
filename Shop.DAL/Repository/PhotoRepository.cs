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
    public class PhotoRepository:CommonRepository<Photo,int>
    {
        public PhotoRepository(DbContext context):base(context)
        {

        }
    }
}
