using Shop.BLL.BizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Shop.BLL.Services
{
    public interface IUnitOfWorkSale : IUnitOfWork
    {
        TransactionScope Transaction { get; set; }
        IGenericService<SaleDTO,int> saleService { get; }
        IGenericService<SalePosDTO,int> salePosService { get; }
        IGenericService<ProductDTO,int> productService { get; }

    }
}
