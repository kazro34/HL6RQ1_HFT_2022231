using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Repository
{
    public class BookRepository : Repository<Book>, IRepository<Book>
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {

        }
        public override Book Read(int id)
        {
            return context.Books.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Book entity)
        {
            var old = Read(entity.Id);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(entity));
                }
            }
            context.SaveChanges();
        }
    }
}
