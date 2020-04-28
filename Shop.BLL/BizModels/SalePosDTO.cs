using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.BizModels
{
    public class SalePosDTO
    {
        public int SalePosId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int ProductCount { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
