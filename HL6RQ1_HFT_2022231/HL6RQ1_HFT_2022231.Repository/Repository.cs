using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Repository
{//GENERIC REPOSITORY
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected LibraryDbContext context;

        protected Repository(LibraryDbContext context)
        {
            this.context = context;
        }

        public void Create(T Item)
        {
            context.Set<T>().Add(Item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Read(id));
            context.SaveChanges();
        }

        abstract public T Read(int id);


        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        abstract public void Update(T entity);

    }
}