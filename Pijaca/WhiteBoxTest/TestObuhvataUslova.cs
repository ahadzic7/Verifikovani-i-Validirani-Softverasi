using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pijaca;
using System.Collections.Generic;

namespace WhiteBoxTest
{
    [TestClass]
    public class UnitTest1
    {
        private static Prodavač prodavac;
        private static Proizvod proizvod;
        private static Tržnica pijaca;

        [TestInitialize]
        public void InicijalizacijaProdavaca()
        {
            prodavac = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
            proizvod = new Proizvod(Namirnica.Žitarica, "kukuruz", 49, DateTime.Now, 5, true);
            pijaca = new Tržnica();
        }
        /// <summary>
        /// Potpuni obuhvat linija koda slucaj 1.a
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { }, new List<int> { 100, 5 }, new List<DateTime> { });
            },
                "Pogrešan unos parametara!");
        }

        /// <summary>
        /// Potpuni obuhvat linija koda slucaj 1.b
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { }, new List<int> { }, new List<DateTime> { DateTime.Now.AddDays(5) });
            },
                "Pogrešan unos parametara!");
        }

        /// <summary>
        /// Potpuni obuhvat linija koda slucaj 2
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Proizvod p = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { p }, new List<int> { 100 }, new List<DateTime> { DateTime.Now.AddDays(5) });
            },
                "Nemoguće naručiti proizvod - nije registrovan na štandu!");
        }

        /// <summary>
        /// Potpuni obuhvat linija koda slucaj 3
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            try
            {
                Proizvod paa = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
                Proizvod pbb = new Proizvod(Namirnica.Voće, "banana", 45, DateTime.Now, 6, false);

                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25), new List<Proizvod> { paa });
                pijaca.NaručiProizvode(stand, new List<Proizvod> {pbb }, new List<int> { 30 }, new List<DateTime> { DateTime.Now.AddDays(7) }, true);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Nije trebalo uci u petlju");
            }
        }

        /// <summary>
        /// Potpuni obuhvat linija koda slucaj 4
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            try
            {
                Proizvod p = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { p }, new List<int> { 5 }, new List<DateTime> { DateTime.Now.AddDays(5) }, false);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Nije trebalo uci u petlju");
            }
        }


        /// <summary>
        /// Potpuni obuhvat linija koda slucaj 5
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            try
            {
                Proizvod p = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25), new List<Proizvod> { p });
                pijaca.NaručiProizvode(stand, new List<Proizvod> { p }, new List<int> { 5 }, new List<DateTime> { DateTime.Now.AddDays(5) }, false);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Ne bi trebalo ovo da se desi");
            }
        }
    }
}
