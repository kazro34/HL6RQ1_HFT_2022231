using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Repository
{
    public class AuthorRepository : Repository<Author>, IRepository<Author>
    {
        public AuthorRepository(LibraryDbContext context) : base(context)
        {

        }
        public override Author Read(int id)
        {
            return context.Authors.FirstOrDefault(t => t.authorId == id);
        }


        public override void Update(Author entity)
        {
            var old = Read(entity.authorId);
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
