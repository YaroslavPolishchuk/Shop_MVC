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
    public class ManufacturerService : GenericService<Manufacturer,ManufacturerDTO, int>
    {
        public ManufacturerService(ICommonRepository<Manufacturer,int> repository):base(repository)
        {

        }
        //ICommonRepository<Manufacturer, int> repository;
        //private readonly IMapper _mapper;
        //public ManufacturerService(ICommonRepository<Manufacturer, int> repository)
        //{
        //    this.repository = repository;
        //    _mapper = new MapperConfiguration(cfg =>
        //    {
        //        //cfg.AddExpressionMapping();
        //        cfg.CreateMap<Manufacturer, ManufacturerDTO>();
        //        cfg.CreateMap<ManufacturerDTO, Manufacturer>();
        //    }).CreateMapper();
        //}
        //public IEnumerable<ManufacturerDTO> GetAllData()
        //{
        //    throw new NotImplementedException();
        //}
        //public ManufacturerDTO Add(ManufacturerDTO obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public ManufacturerDTO Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<ManufacturerDTO> FindBy(Expression<Func<ManufacturerDTO, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

       

        //public ManufacturerDTO GetObjInstance(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public ManufacturerDTO Update(ManufacturerDTO obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
