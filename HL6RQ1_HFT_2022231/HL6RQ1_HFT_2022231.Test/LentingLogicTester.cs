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
    public class LentingLogicTester
    {
        Mock<IRepository<Lenting>> mockRepository;
        LentingLogic lentingLogic;
        [SetUp]
        public void Init()
        {
            mockRepository = new Mock<IRepository<Lenting>>();

            Book fakeBook = new Book();
            fakeBook.Id = 1;
            fakeBook.Title = "1984";
            fakeBook.LentingFee = 1000;
            Book fakeBook2 = new Book();
            fakeBook2.Id = 2;
            fakeBook2.Title = "Állatfarm";
            fakeBook2.LentingFee = 2000;
            Book fakeBook3 = new Book();
            fakeBook3.Id = 3;
            fakeBook3.Title = "Az elveszett cirkáló";
            fakeBook3.LentingFee = 3000;
            Book fakeBook4 = new Book();
            fakeBook4.Id = 4;
            fakeBook4.Title = "A megkerült cirkáló";
            fakeBook4.LentingFee = 4000;
            Book fakeBook5 = new Book();
            fakeBook5.Id = 5;
            fakeBook5.Title = "Metro 2033";
            fakeBook5.LentingFee = 5000;
            Book fakeBook6 = new Book();
            fakeBook6.Id = 6;
            fakeBook6.Title = "Metro 2035";
            fakeBook6.LentingFee = 6000;
            var lentings = new List<Lenting>()
            {
            new Lenting() { Id = 1, Name="Teszt Elek", BookId= fakeBook.Id, Out= "2022.04.13", In="2021.04.20", Book =fakeBook},
            new Lenting() { Id = 2, Name = "Kiss Milán", BookId = fakeBook.Id,Out = "2022.05.13", In = "2021.05.23", Book =fakeBook },
            new Lenting() { Id = 3, Name = "Bartalos Emese", BookId = fakeBook3.Id, Out = "2022.04.15", In = "2022.05.26", Book =fakeBook3},
            new Lenting() { Id = 4, Name = "Misurda Luca", BookId = fakeBook4.Id, Out = "2022.04.12", In = "2022.04.20",Book =fakeBook3 },
            new Lenting() { Id = 5, Name = "Nagy Dávid", BookId = fakeBook5.Id, Out = "2021.04.13", In = "2021.04.22",Book =fakeBook4 },
            new Lenting() { Id = 6, Name = "Kober Ildikó", BookId = fakeBook6.Id, Out = "2021.01.01", In =null,Book =fakeBook5 },
            }.AsQueryable();

            mockRepository.Setup(t => t.ReadAll()).Returns(lentings);

            lentingLogic = new LentingLogic(mockRepository.Object);
        }
        [Test]
        public void HasToPayFine()
        {
            var result = lentingLogic.HasToPayFine().Single();
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void StillOpenLentsByBookId()
        {
            var result = lentingLogic.StillOpenLentsByBookId().Single();
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void GetAverageIncomePerBookPerYear()
        {
            List<KeyValuePair<string, double>> expected = new List<KeyValuePair<string, double>>()
            {
                (new KeyValuePair<string, double>("A megkerült cirkáló", 36000)),
                (new KeyValuePair<string, double>("Metro 2033", 0.0))
            };
            var result = lentingLogic.GetAverageIncomePerBookPerYear(2021);
            CollectionAssert.AreEqual(expected, result);
        }
        [Test]
        public void ValidCreate()
        {
            Lenting testlent = new Lenting() { Id = 7, BookId = 1, Name = "Teszt Elek", Out = "2022.09.14", In = "2022.09.22" };
            try
            {
                lentingLogic.Create(testlent);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.IsTrue(false);
            }
        }
        [Test]
        public void InValidCreateDateBigger()
        {
            Lenting testlent = new Lenting() { Id = 7, BookId = 1, Name = "Teszt Elek", Out = "2022.09.14", In = "2021.09.22" };
            try
            {
                lentingLogic.Create(testlent);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Invalid Lent time...");
            }
        }
        [Test]
        public void InValidNameCreate()
        {
            Lenting testlent = new Lenting() { Id = 8, BookId = 1, Name = null, Out = "2022.09.14", In = "2022.09.22" };
            try
            {
                lentingLogic.Create(testlent);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Please fill name...");
            }
        }
        [Test]
        public void InValidLentRead()
        {
            int id = 7;
            try
            {
                lentingLogic.Read(id);
                Assert.IsFalse(false);
            }
            catch (Exception ex)
            {

                Assert.IsFalse(ex.Message == "Lenting not exist!");
            }
        }
    }
}
