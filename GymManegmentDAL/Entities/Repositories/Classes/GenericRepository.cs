using GymManagementDAL.Entities.Repositories.Interfaces;
using GymManegementDAL.Data.Context;
using GymManegementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;    

namespace GymManagementDAL.Entities.Repositories.Classes
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly GymDbcontext _Dbcontext;

        public GenericRepository(GymDbcontext  Dbcontext )
        {
            _Dbcontext = Dbcontext;
        }


        public IEnumerable<TEntity> GetAll()
        {
              return _Dbcontext.Set<TEntity>()
                .AsNoTracking()
                .ToList();
        }


        public TEntity? GetById(int id)
        {

                return _Dbcontext.Set<TEntity>()
                .Find(id); 
             

        }


        public void Add(TEntity entity)
        {

            _Dbcontext.Set<TEntity>().Add(entity); 
           
        }

        public void Delete(TEntity entity)
        {
            _Dbcontext.Set<TEntity>().Remove(entity);
           
        }

       

      

        public void Update(TEntity entity)
        {
            _Dbcontext.Set<TEntity>().Update(entity);
          
        }
    }
}
