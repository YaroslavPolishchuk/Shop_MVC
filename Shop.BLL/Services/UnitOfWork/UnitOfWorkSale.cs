using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Shop.BLL.BizModels;

namespace Shop.BLL.Services
{
    public class UnitOfWorkSale : IUnitOfWorkSale
    {        
        public TransactionScope Transaction { get; set; }

        public IGenericService<SaleDTO, int> saleService { get; }

        public IGenericService<SalePosDTO, int> salePosService { get; }

        public IGenericService<ProductDTO, int> productService { get; }
        public UnitOfWorkSale(IGenericService<SaleDTO, int> saleService,
            IGenericService<SalePosDTO, int> salePosService,
            IGenericService<ProductDTO, int> productService)
        {            
            this.saleService = saleService;
            this.salePosService = salePosService;
            this.productService = productService;

        }
        #region  реализация паттерна IDisposable
        bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Transaction.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion  реализация паттерна IDisposable

        public void Save()
        {
            Transaction.Complete();
        }
    }
}
