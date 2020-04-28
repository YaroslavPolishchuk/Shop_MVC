using LinqKit;
using Shop.BLL.BizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShopWebAPI.Models
{
    public class ViewModelFilter
    {
        public string ProductName { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public Expression<Func<ProductDTO, bool>> predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<ProductDTO>(true);
                if (!string.IsNullOrEmpty(this.ProductName))
                    predicate = predicate.And(g => g.ProductName.Contains(this.ProductName));

                if(this.PriceFrom!=null)
                    predicate = predicate.And(g => g.Price>=this.PriceFrom);
                if (this.PriceTo != null)
                    predicate = predicate.And(g => g.Price <= this.PriceTo);

                return predicate;
            }
        }
    }
}