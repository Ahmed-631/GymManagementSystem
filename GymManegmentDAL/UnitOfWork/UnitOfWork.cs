using GymManagementDAL.Entities.Repositories.Classes;
using GymManagementDAL.Entities.Repositories.Interfaces;
using GymManegementDAL.Data.Context;
using GymManegementDAL.Entities;

namespace GymManagementDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _Repository = new Dictionary<Type, object>();

        private readonly GymDbcontext _DbContext;
        public UnitOfWork(GymDbcontext DbContext, ISessionRepository sessionRepository)
        {
            _DbContext = DbContext;
            SessionRepository = sessionRepository;


        }



        public ISessionRepository SessionRepository { get; }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {

            var EntityType = typeof(TEntity);
            if (_Repository.TryGetValue(EntityType, out var Repo))
                return (IGenericRepository<TEntity>)Repo;

            var NewRepo = new GenericRepository<TEntity>(_DbContext);
            _Repository.Add(EntityType, NewRepo);
            return NewRepo;



        }

        public int SaveChanges()
        {
            return _DbContext.SaveChanges();



        }


      
    }
}
//public ISessionRepository SessionRepository => throw new NotImplementedException();

//private readonly Dictionary<Type, object> _Repositories;
//private readonly GymDbcontext _dbcontext;

//public UnitOfWork(GymDbcontext dbcontext )
//{
//    _dbcontext = dbcontext;
//}
//public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
//{
//    var EntityType = typeof(TEntity);
//    if (_Repositories.TryGetValue(EntityType, out var Repo))
//        return (IGenericRepository<TEntity>)Repo;

//    var NewRepo = new GenericRepository<TEntity>(_dbcontext);
//   _Repositories.Add(EntityType, NewRepo);

//    return NewRepo; 


//}

//public int SaveChanges()
//{
//    throw new NotImplementedException();
//}