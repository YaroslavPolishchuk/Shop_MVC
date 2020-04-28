using AutoMapper;
using ObjectRepository;
using Shop.BLL.BizModels;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class CategoryService : GenericService<Category, CategoryDTO, int>
    {
        public CategoryService(ICommonRepository<Category, int> repository) : base(repository)
        {

        }
    }

    //    ICommonRepository<Category, int> repository;
    //    private readonly IMapper _mapper; //Вместо автомапера можно было бы использовать приведение типов, в каждом классе переопределить explicit and implicit 
    //    public CategoryService(ICommonRepository<Category, int> repository)
    //    {
    //        this.repository = repository;
    //        new MapperConfiguration(cfg =>
    //        {
    //            //cfg.AddExpressionMapping();
    //            cfg.CreateMap<Category, CategoryDTO>();
    //            cfg.CreateMap<CategoryDTO, Category>();
    //        }).CreateMapper();
    //    }
    //    public IEnumerable<CategoryDTO> GetAllData()
    //    {
    //        var collection = repository.GetAllData().
    //            Select(e => _mapper.Map<CategoryDTO>(e));
    //        return collection;
    //    }
    //    public CategoryDTO Add(CategoryDTO obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public CategoryDTO Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<CategoryDTO> FindBy(Expression<Func<CategoryDTO, bool>> predicate)
    //    {
    //        try
    //        {
    //            var predicatObj = _mapper.Map<Expression<Func<Category, bool>>>(predicate);
    //            return repository.FindBy(predicatObj)
    //                .Select(obj => _mapper.Map<CategoryDTO>(obj));
    //        }
    //        catch(Exception exc)
    //        {
    //            throw exc;
    //        }
    //    }

        

    //    public CategoryDTO GetObjInstance(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public CategoryDTO Update(CategoryDTO obj)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
