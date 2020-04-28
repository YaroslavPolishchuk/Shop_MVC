using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ObjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public abstract class GenericService<DbObject, DbObjectDTO, Tkey> : IGenericService<DbObjectDTO, Tkey> where DbObjectDTO : class, new()
                                                        where DbObject : class, new()
    {
        ICommonRepository<DbObject,Tkey> repository;
        private readonly IMapper _mapper;
        public GenericService(ICommonRepository<DbObject, Tkey> repository)
        {
            this.repository = repository;
            _mapper = GetMapper();
        }
        public virtual IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<DbObject, DbObjectDTO>();
                cfg.CreateMap<DbObjectDTO, DbObject>();
            }).CreateMapper();
        }
        public DbObjectDTO GetObjInstance(Tkey id)
        {
            DbObject dbObject = repository.GetObjInstance(id);
            return _mapper.Map<DbObjectDTO>(dbObject);
        }
        public DbObjectDTO Add(DbObjectDTO obj)
        {
            DbObject dbObject = _mapper.Map<DbObject>(obj);
            repository.AddOrUpdate(dbObject);
            repository.Save();
            return _mapper.Map<DbObjectDTO>(dbObject);
        }

        public DbObjectDTO Delete(Tkey id)
        {
            DbObject dbObject = repository.GetObjInstance(id);
            repository.Delete(id);
            repository.Save();
            return _mapper.Map<DbObjectDTO>(dbObject);
        }

        public IEnumerable<DbObjectDTO> FindBy(Expression<Func<DbObjectDTO, bool>> predicate)
        {
            try
            {
                Expression<Func<DbObject, bool>> predicateObj = _mapper.Map<Expression<Func<DbObject, bool>>>(predicate);
                return repository.FindBy(predicateObj)
                    .Select(obj => _mapper.Map<DbObjectDTO>(obj));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public IEnumerable<DbObjectDTO> GetAllData()
        {
            var collection = repository.GetAllData().Select(e => _mapper.Map<DbObjectDTO>(e));
            return collection;
        }        

        public DbObjectDTO Update(DbObjectDTO obj)
        {
            return Add(obj);
        }
    }
}
