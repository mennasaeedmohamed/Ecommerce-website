using Commerce.Context.Context;
using Commerce.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Repositories.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        CommerceDbContext commerceDbContext;
        DbSet<T> dbset;
        public GenericRepository(CommerceDbContext _commerceDbContext)
        {
            commerceDbContext = _commerceDbContext;
            dbset = commerceDbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return dbset;
        }
        public IQueryable<T> GetOne(int id)
        {
            return dbset;
        }
        public void Create(T Entity)
        {
            dbset.Add(Entity);
            commerceDbContext.SaveChanges();

        }
        public void Update(T Entity)
        {
            dbset.Update(Entity);
            commerceDbContext.SaveChanges();

        }
        public void Delete(T Entity)
        {
            dbset.Remove(Entity);
            commerceDbContext.SaveChanges();

        }

    }

}
