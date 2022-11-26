using HL6RQ1_HFT_2022231.Logic;
using HL6RQ1_HFT_2022231.Models;
using HL6RQ1_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Test
{
    [TestFixture]
    public class BookLogicTester
    {
        BookLogic bookLogic;
        [SetUp]
        public void Init()
        {
            var mockRopository = new Mock<IRepository<Book>>();
            List<Lenting> fakelents = new List<Lenting>();
            Author fakeAuthor = new Author();
            fakeAuthor.authorId = 1;
            fakeAuthor.Name = "Orvell";
            var books = new List<Book>()
            {
                new Book() { Id=  1, AuthorId=1, LentingFee= 1000, Title ="Állatfarm", Author= fakeAuthor, Lentings= fakelents  },
                new Book() { Id = 2, AuthorId = 1, LentingFee = 1000, Title = "1984", Author = fakeAuthor, Lentings = fakelents }
            }.AsQueryable();

            mockRopository.Setup(t => t.ReadAll()).Returns(books);

            bookLogic = new BookLogic(mockRopository.Object);
        }
        [Test]
        public void AvgPriceTest()
        {
            var result = bookLogic.AVGLentingPrice();

            Assert.That(result, Is.EqualTo(1000));
        }
        [Test]
        public void AVGLentingPricesByAuthors()
        {
            List<KeyValuePair<string, double>> expected = new List<KeyValuePair<string, double>>()
                {
                    (new KeyValuePair<string, double>("Orvell",1000)),
                };
            var result = bookLogic.AVGLentingPricesByAuthors();
            CollectionAssert.AreEqual(expected, result);
        }
        [Test]
        public void ValidCreate()
        {
            Book testbook = new Book() { Id = 3, AuthorId = 1, Title = "Légszomj", LentingFee = 600 };
            try
            {
                bookLogic.Create(testbook);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.IsTrue(false);
            }
        }
        [Test]
        public void InValidCreate()
        {
            Book TestInvalidBook = null;
            try
            {
                bookLogic.Create(TestInvalidBook);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message == "Invalid book!");
            }
        }
        [Test]
        public void InValidBookRead()
        {
            int id = 3;
            try
            {
                bookLogic.Read(id);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message == "Book not exist!");
            }
        }
    }
}
