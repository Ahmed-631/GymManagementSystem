using GymManagementDAL.Entities.Repositories.Interfaces;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GymManagementDAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ISessionRepository SessionRepository { get; }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity :BaseEntity , new() ;

        public int SaveChanges(); 
    }
}
