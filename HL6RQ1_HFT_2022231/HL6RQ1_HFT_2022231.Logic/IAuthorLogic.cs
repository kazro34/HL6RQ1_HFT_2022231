using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Logic
{
    public interface IAuthorLogic
    {
        void Creat(Author item);
        void Update(Author item);
        void Delete(int id);
        Author Read(int id);
        IQueryable<Author> ReadAll();
    }
}
