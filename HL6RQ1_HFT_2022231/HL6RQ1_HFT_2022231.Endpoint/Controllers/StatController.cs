using HL6RQ1_HFT_2022231.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HL6RQ1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBookLogic bookLogic;
        ILentingLogic lentingLogic;

        public StatController(IBookLogic bookLogic, ILentingLogic lentingLogic)
        {
            this.bookLogic = bookLogic;
            this.lentingLogic = lentingLogic;
        }

        [HttpGet]
        public double AVGLentingPrice()
        {
            return bookLogic.AVGLentingPrice();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGLentingPricesByAuthors()
        {
            return bookLogic.AVGLentingPricesByAuthors();
        }

        [HttpGet("{year}")]
        public IEnumerable<KeyValuePair<string, double>> GetAverageIncomePerBookPerYear(int year)
        {
            return lentingLogic.GetAverageIncomePerBookPerYear(year);
        }

        [HttpGet]
        public IEnumerable<int> HasToPayFine()
        {
            return lentingLogic.HasToPayFine();
        }

        [HttpGet]
        public IEnumerable<int> StillOpenLentsByBookId()
        {
            return lentingLogic.StillOpenLentsByBookId();
        }
    }
}
