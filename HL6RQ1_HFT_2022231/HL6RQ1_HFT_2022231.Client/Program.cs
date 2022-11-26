using ConsoleTools;
using HL6RQ1_HFT_2022231.Models;
using System;

namespace HL6RQ1_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RestService rest = new RestService("http://localhost:35445/", typeof(Lenting).Name);
                CrudService crud = new CrudService(rest);
                NonCrudService nonCrud = new NonCrudService(rest);

                var bookSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => crud.List<Book>())
                    .Add("Create", () => crud.Create<Book>())
                    .Add("Delete", () => crud.Delete<Book>())
                    .Add("Update", () => crud.Update<Book>())
                    .Add("Exit", ConsoleMenu.Close);

                var AuthorSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => crud.List<Author>())
                    .Add("Create", () => crud.Create<Author>())
                    .Add("Delete", () => crud.Delete<Author>())
                    .Add("Update", () => crud.Update<Author>())
                    .Add("Exit", ConsoleMenu.Close);

                var LentSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => crud.List<Lenting>())
                    .Add("Create", () => crud.Create<Lenting>())
                    .Add("Delete", () => crud.Delete<Lenting>())
                    .Add("Update", () => crud.Update<Lenting>())
                    .Add("Exit", ConsoleMenu.Close);

                var statsSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("Average book lenting price", () => nonCrud.AvgLentprice())
                    .Add("Average yearly income by books", () => nonCrud.GetAvarageIncomePerBookPerYear())
                    .Add("Average price by authors", () => nonCrud.AVGLentingPricesByAuthors())
                    .Add("People who are fine for latency", () => nonCrud.HastoPayFine())
                    .Add("Books out", () => nonCrud.StillOpenLentsByBookId())
                    .Add("Exit", ConsoleMenu.Close);
                var menu = new ConsoleMenu(args, level: 0)
                    .Add("Lentings", () => LentSubMenu.Show())
                    .Add("Books", () => bookSubMenu.Show())
                    .Add("Authors", () => AuthorSubMenu.Show())
                    .Add("Statistics", () => statsSubMenu.Show())
                    .Add("Exit", ConsoleMenu.Close);
                menu.Show();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
