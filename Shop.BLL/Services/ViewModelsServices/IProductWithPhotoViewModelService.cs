using ShopWebAPI.Models;
using System.Collections.Generic;

namespace Shop.BLL.Services.ViewModelsServices
{
    public interface IProductWithPhotoViewModelService
    {
        IEnumerable<ViewModelProductWithPhoto> GetAllProducts();
    }
}
