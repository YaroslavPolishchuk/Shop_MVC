using ObjectRepository;
using Shop.BLL.Services;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.BizModels
{
    public class SalePosService: GenericService<SalePos, SalePosDTO, int>
    {
        public SalePosService(ICommonRepository<SalePos, int> repository) : base(repository)
        {

        }
    }
}
