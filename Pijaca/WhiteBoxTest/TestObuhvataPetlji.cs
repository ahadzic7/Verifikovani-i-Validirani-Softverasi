using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pijaca;
using System.Collections.Generic;

namespace WhiteBoxTest
{
    //Ahmed Mahovac 18735
    [TestClass]
    public class TestObuhvataPetlji
    {
        private static Prodavač prodavac;
        private static Tržnica pijaca;
        [TestInitialize]
        public void InicijalizacijaProdavaca()
        {
            prodavac = new Prodavač("prodos", "ise", new DateTime(2021, 5, 1, 8, 30, 52), 0);
            pijaca = new Tržnica();

        }
        [TestMethod]
        public void Test1() // 1 prolazak kroz petlju 
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            for(int i=0; i<20; i++)
            {
                proizvodi.Add(new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false));
            }
            Štand stand = new Štand(prodavac, DateTime.Now.AddDays(25), proizvodi);
            pijaca.NaručiProizvode(stand, new List<Proizvod> { proizvodi[5]}, new List<int> { 5 }, new List<DateTime> { DateTime.Now.AddDays(30) });
            Assert.IsTrue(proizvodi[5].OčekivanaKoličina.Equals(5));
        }

        [TestMethod]
        public void Test2() // 2 prolaska kroz petlju
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            for (int i = 0; i < 20; i++)
            {
                proizvodi.Add(new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false));
            }
            Štand stand = new Štand(prodavac, DateTime.Now.AddDays(25), proizvodi);
            pijaca.NaručiProizvode(stand, new List<Proizvod> { proizvodi[5], proizvodi[10] }, new List<int> { 10, 5 }, new List<DateTime> { DateTime.Now.AddDays(30) , DateTime.Now.AddDays(30) });
            Assert.IsTrue(proizvodi[5].OčekivanaKoličina.Equals(10));
            Assert.IsTrue(proizvodi[10].OčekivanaKoličina.Equals(5));
        }

        [TestMethod]
        public void Test3() // 5 prolazaka kroz petlju
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            for (int i = 0; i < 20; i++)
            {
                proizvodi.Add(new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false));
            }
            Štand stand = new Štand(prodavac, DateTime.Now.AddDays(25), proizvodi);
            pijaca.NaručiProizvode(stand, new List<Proizvod> { proizvodi[5], proizvodi[10], proizvodi[11], proizvodi[12], proizvodi[13]}, new List<int> { 10, 5, 5, 5, 10 }, new List<DateTime> { DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30) });
            Assert.IsTrue(proizvodi[5].OčekivanaKoličina.Equals(10));
            Assert.IsTrue(proizvodi[10].OčekivanaKoličina.Equals(5));
            Assert.IsTrue(proizvodi[11].OčekivanaKoličina.Equals(5));
            Assert.IsTrue(proizvodi[12].OčekivanaKoličina.Equals(5));
            Assert.IsTrue(proizvodi[13].OčekivanaKoličina.Equals(10));
        }

        [TestMethod] // 8 prolazaka kroz petlju
        public void Test4()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            for (int i = 0; i < 20; i++)
            {
                proizvodi.Add(new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false));
            }
            Štand stand = new Štand(prodavac, DateTime.Now.AddDays(25), proizvodi);
            pijaca.NaručiProizvode(stand, new List<Proizvod> { proizvodi[5], proizvodi[10], proizvodi[11], proizvodi[12], proizvodi[13], proizvodi[14], proizvodi[15], proizvodi[16] }, new List<int> { 10, 5, 5, 5, 10, 10, 5, 10 }, new List<DateTime> { DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), DateTime.Now.AddDays(30) });

            Assert.IsTrue(proizvodi[5].OčekivanaKoličina.Equals(10));
            Assert.IsTrue(proizvodi[10].OčekivanaKoličina.Equals(5));
            Assert.IsTrue(proizvodi[11].OčekivanaKoličina.Equals(5));
            Assert.IsTrue(proizvodi[12].OčekivanaKoličina.Equals(5));
            Assert.IsTrue(proizvodi[13].OčekivanaKoličina.Equals(10));
            Assert.IsTrue(proizvodi[14].OčekivanaKoličina.Equals(10));
            Assert.IsTrue(proizvodi[15].OčekivanaKoličina.Equals(5));
            Assert.IsTrue(proizvodi[16].OčekivanaKoličina.Equals(10));

        }

    }
}

