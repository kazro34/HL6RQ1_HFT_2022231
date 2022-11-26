using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Logic
{
    public interface ILentingLogic
    {
        void Create(Lenting item);
        void Update(Lenting item);
        void Delete(int id);
        Lenting Read(int id);
        IQueryable<Lenting> ReadAll();
        IEnumerable<KeyValuePair<string, double>> GetAverageIncomePerBookPerYear(int year);
        IEnumerable<int> HasToPayFine();
        IEnumerable<int> StillOpenLentsByBookId();
    }
}
