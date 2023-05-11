using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Client
{
    class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }
        public void AvgLentprice()
        {
            double price = rest.GetSingle<double>("Stat/AVGLentingPrice");
            Console.WriteLine($"Average book price = {price}");
            Console.ReadLine();
        }
        public void AVGLentingPricesByAuthors()
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/AVGLentingPricesByAuthors");
            Console.WriteLine("Author\tAvgPrice");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }
        public void GetAvarageIncomePerBookPerYear()
        {
            Console.WriteLine("Enter a Year:");
            int year = int.Parse(Console.ReadLine());
            var items = rest.Getp<KeyValuePair<string, double>>(year, "Stat/GetAverageIncomePerBookPerYear");
            Console.WriteLine("Book\tAvgIncome");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }
        public void HastoPayFine()
        {
            var items = rest.Get<long>("Stat/HasToPayFine").ToList();
            if (items.Count != 0)
            {
                Console.WriteLine("Renter ID-s who has to pay latency fine:");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
            else if (items.Count == 0)
            {
                Console.WriteLine("There is no data here...");
                Console.ReadLine();
            }
        }
        public void StillOpenLentsByBookId()
        {
            var items = rest.Get<long>("Stat/StillOpenLentsByBookId");
            if (items != null)
            {
                Console.WriteLine("Book ID-s whitch are still out:");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
            else if (items.Count == 0)
            {
                Console.WriteLine("There is no data here...");
                Console.ReadLine();
            }
        }

    }
}
