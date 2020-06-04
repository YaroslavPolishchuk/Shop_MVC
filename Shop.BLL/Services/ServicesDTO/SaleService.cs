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
    public class SaleService: GenericService<Sale, SaleDTO, int>
    {
        public SaleService(ICommonRepository<Sale, int> repository) : base(repository)
        {

        }
    }
}
