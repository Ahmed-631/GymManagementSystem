using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    { 
        public IEnumerable<TEntity> GetAll();

        public TEntity? GetById (int id);


        public void Delete(TEntity entity);


        public void Update(TEntity entity);

        public void Add(TEntity entity); 









    }
}
