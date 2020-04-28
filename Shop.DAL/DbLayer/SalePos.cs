namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalePos
    {
        public int SalePosId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int ProductCount { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
