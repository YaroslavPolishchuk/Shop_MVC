using Shop.BLL.BizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebAPI.Models
{
    public class ViewModelProductWithPhoto 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal ProductCount { get; set; }
        public IEnumerable<PhotoDTO> photos;
    }
}