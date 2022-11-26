using HL6RQ1_HFT_2022231.Models;
using HL6RQ1_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Logic
{
    public class BookLogic : IBookLogic
    {
        IRepository<Book> repo;

        public BookLogic(IRepository<Book> repo)
        {
            this.repo = repo;
        }
        // NON CRUDS
        public double AVGLentingPrice()
        {
            return this.repo.ReadAll().Average(c => c.LentingFee);
        }

        public IEnumerable<KeyValuePair<string, double>> AVGLentingPricesByAuthors()
        {
            return from x in repo.ReadAll()
                   group x by x.Author.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.LentingFee));
        }
        //CRUDS
        public void Create(Book item)
        {
            if (item == null)
            {
                throw new ArgumentException("Invalid book!");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Book Read(int id)
        {
            var book = this.repo.Read(id);
            if (book != null)
            {
                return book;
            }
            else
            {
                throw new ArgumentException("Book not exist!");
            }
        }

        public IQueryable<Book> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Book item)
        {
            this.repo.Update(item);
        }
    }
}
