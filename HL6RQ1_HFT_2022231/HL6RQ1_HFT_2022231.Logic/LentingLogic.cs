using HL6RQ1_HFT_2022231.Models;
using HL6RQ1_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Logic
{
    public class LentingLogic : ILentingLogic
    {
        IRepository<Lenting> repo;

        public LentingLogic(IRepository<Lenting> repo)
        {
            this.repo = repo;
        }

        public void Create(Lenting item)
        {
            if (item.Name == null)
            {
                throw new ArgumentException("Please fill name...");
            }
            if (item.In != null && DateTime.Parse(item.In) <= DateTime.Parse(item.Out))
            {
                throw new ArgumentException("Invalid Lent time...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Lenting Read(int id)
        {
            var lent = this.repo.Read(id);
            if (lent != null)
            {
                return lent;
            }
            throw new ArgumentException("Lent not exist!");
        }
        public void Update(Lenting item)
        {
            this.repo.Update(item);
        }

        public IQueryable<Lenting> ReadAll()
        {
            return this.repo.ReadAll();
        }
        // NON CRUDS
        public IEnumerable<KeyValuePair<string, double>> GetAverageIncomePerBookPerYear(int year)
        {
            return from l in repo.ReadAll().Where(t => DateTime.Parse(t.In).Year.Equals(year)).ToList()
                   group l by l.LentBook.Title into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.In != null ? (t.LentBook.LentingFee * (DateTime.Parse(t.In).Subtract(DateTime.Parse(t.Out)).TotalDays)) : t.LentBook.LentingFee * 0));
        }

        public IEnumerable<int> HasToPayFine()
        {
            return this.repo.ReadAll().Where(t => t.In == null).Select(t => t.BookId).ToList();
        }

        public IEnumerable<int> StillOpenLentsByBookId()
        {
            return repo.ReadAll().Where(t => t.In == null).Select(t => t.BookId).ToList();
        }


    }
}
