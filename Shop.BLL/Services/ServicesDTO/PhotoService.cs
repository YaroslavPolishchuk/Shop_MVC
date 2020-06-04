using ObjectRepository;
using Shop.BLL.BizModels;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class PhotoService: GenericService<Photo, PhotoDTO, int>
    {
        public PhotoService(ICommonRepository<Photo, int> repository) : base(repository)
        {

        }
    }
}
