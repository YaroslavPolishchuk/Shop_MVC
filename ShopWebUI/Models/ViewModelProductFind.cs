using LinqKit;
using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShopWebUI.Models
{
    public class CategoryCheck
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ManufacturerCheck
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public bool IsCheck { get; set; }
    }
    [Serializable]
    public class ViewModelProductFind
    {
        IGenericService<CategoryDTO,int> categoryService;
        IGenericService<ManufacturerDTO, int> manufacturerService;
        public string ProductName { get; set; }
        public List<CategoryCheck> CategorySelect { get; set; }
        public List<ManufacturerCheck> ManufacturerSelect { get; set; }
        public ViewModelProductFind(IGenericService<CategoryDTO, int> categoryService,
                    IGenericService<ManufacturerDTO, int> manufacturerService)
        {
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            ManufacturerSelect = manufacturerService.GetAllData()
                .Select(c => new ManufacturerCheck
                {
                    ManufacturerId = c.ManufacturerId,
                    ManufacturerName = c.ManufacturerName
                }).ToList();
            CategorySelect = categoryService.GetAllData()
                .Select(c => new CategoryCheck
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                }).ToList();
        }
        public ViewModelProductFind() { }
        public Expression<Func<ProductDTO,bool>> Predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<ProductDTO>(true);
                if (!string.IsNullOrEmpty(ProductName))
                    predicate = predicate.And(g => g.ProductName.Contains(ProductName));
                if (CategorySelect.Select(c => c.IsCheck).Count() > 0)
                {
                    var predicateCategory = PredicateBuilder.New<ProductDTO>(true);
                    foreach (var item in CategorySelect)
                    {
                        if (item.IsCheck)
                            predicateCategory = predicateCategory.Or(c => c.CategoryId == item.CategoryId);
                    }
                    predicate = predicate.And(predicateCategory);
                }
                if(ManufacturerSelect.Select(m=>m.IsCheck).Count()>0)
                {
                    ExpressionStarter<ProductDTO> predicateManufacturer = PredicateBuilder.New<ProductDTO>(true);
                    foreach (var item in ManufacturerSelect)
                    {
                        if (item.IsCheck)
                            predicateManufacturer = predicateManufacturer.Or(m => m.ManufacturerId == item.ManufacturerId);
                    }
                    predicate = predicate.And(predicateManufacturer);
                }
                
                return predicate;
            }
        }

    }
}