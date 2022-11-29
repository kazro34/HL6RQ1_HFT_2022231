using HL6RQ1_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Repository
{
    public class LibraryDbContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Lenting> Lentings { get; set; }


        public LibraryDbContext()
        {
            this.Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("Librarydb");
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(book =>

                book.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Lenting>(entity =>
             entity.HasOne(entity => entity.Book)
                .WithMany(book => book.Lentings)
                .HasForeignKey(entity => entity.BookId)
                .OnDelete(DeleteBehavior.Cascade));



            Author Orwell = new Author() { authorId = 1, Name = "George Orwel" };
            Author Rejtő = new Author() { authorId = 2, Name = "Rejtő Jenő" };
            Author Glukhovsky = new Author() { authorId = 3, Name = "Dmitry Glukhovsky" };

            Book Orwell1 = new Book() { Id = 1, LentingFee = 500, Title = "1984", AuthorId = Orwell.authorId };
            Book Orwell2 = new Book() { Id = 2, LentingFee = 700, Title = "Állatfarm", AuthorId = Orwell.authorId };
            Book Rejtő1 = new Book() { Id = 3, LentingFee = 600, Title = "Az elveszett cirkáló", AuthorId = Rejtő.authorId };
            Book Rejtő2 = new Book() { Id = 4, LentingFee = 560, Title = "A megkerült cirkáló", AuthorId = Rejtő.authorId };
            Book Glukhovsky1 = new Book() { Id = 5, LentingFee = 700, Title = "Metro 2033", AuthorId = Glukhovsky.authorId };
            Book Glukhovsky2 = new Book() { Id = 6, LentingFee = 800, Title = "Metro 2035", AuthorId = Glukhovsky.authorId };

            Lenting Elek = new Lenting() { Id = 1, Name = "Teszt Elek", BookId = Orwell1.Id, Out = "2022.09.14", In = "2022.09.22" };
            Lenting Milán = new Lenting() { Id = 2, Name = "Kiss Milán", BookId = Orwell2.Id, Out = "2022.08.14", In = "2022.08.28" };
            Lenting Emese = new Lenting() { Id = 3, Name = "Bartalos Emese", BookId = Glukhovsky1.Id, Out = "2021.04.14", In = "2021.05.25" };
            Lenting Luca = new Lenting() { Id = 4, Name = "Misurda Luca", BookId = Rejtő2.Id, Out = "2022.10.22", In = "2022.11.20" };
            Lenting Dávid = new Lenting() { Id = 5, Name = "Nagy Dávid", BookId = Glukhovsky2.Id, Out = "2021.01.05", In = null };
            Lenting Ildikó = new Lenting() { Id = 6, Name = "Kober Ildikó", BookId = Rejtő1.Id, Out = "2022.03.03", In = null };

            modelBuilder.Entity<Author>().HasData(Orwell, Rejtő, Glukhovsky);
            modelBuilder.Entity<Book>().HasData(Orwell1, Orwell2, Rejtő1, Rejtő2, Glukhovsky1, Glukhovsky2);
            modelBuilder.Entity<Lenting>().HasData(Elek, Milán, Emese, Luca, Dávid, Ildikó);
        }
    }
}
