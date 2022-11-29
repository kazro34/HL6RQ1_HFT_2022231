using ConsoleTools;
using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace HL6RQ1_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;
        
        static void List(string entity)
        {
            if (entity == "Author")
            {
                List<Author> authors = rest.Get<Author>("author");
                foreach (var item in authors)
                {
                    Console.WriteLine(item.authorId + ": " + item.Name);
                }
                Console.ReadLine();
            }
            
            if (entity == "Book")
            {
                List<Book> books = rest.Get<Book>("book");
                foreach (var item in books)
                {
                    Console.WriteLine(item.Id + ": " + item.Title);
                }
                Console.ReadLine();
            }
            if (entity == "Lenting")
            {
                List<Lenting> lentings = rest.Get<Lenting>("lenting");
                foreach (var item in lentings)
                {
                    Console.WriteLine(item.Id + ": " + item.Name +": "+ item.Out + ": " + item.In + ": " + item.Book.Title);
                }
                Console.ReadLine();
            }
            
        }
        static void Main(string[] args)
        {
            try
            {
                rest = new RestService("http://localhost:54941/","lenting");
                CrudService crud = new CrudService(rest);
                NonCrudService nonCrud = new NonCrudService(rest);

                var bookSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Book"))
                    .Add("Create", () => crud.Create<Book>())
                    .Add("Delete", () => crud.Delete<Book>())
                    .Add("Update", () => crud.Update<Book>())
                    .Add("Exit", ConsoleMenu.Close);

                var AuthorSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Author"))
                    .Add("Create", () => crud.Create<Author>())
                    .Add("Delete", () => crud.Delete<Author>())
                    .Add("Update", () => crud.Update<Author>())
                    .Add("Exit", ConsoleMenu.Close);

                var LentSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Lenting"))
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
