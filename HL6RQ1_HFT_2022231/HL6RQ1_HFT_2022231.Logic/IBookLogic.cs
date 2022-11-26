using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Logic
{
    public interface IBookLogic
    {
        void Update(Book item);
        void Delete(int id);
        Book Read(int id);
        void Create(Book item);
        IQueryable<Book> ReadAll();
        double AVGLentingPrice();
        IEnumerable<KeyValuePair<string, double>> AVGLentingPricesByAuthors();
    }
}
