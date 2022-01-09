/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pijaca;
using System.Collections.Generic;

namespace WhiteBoxTest
{
    //Muris Sladić 18613
    [TestClass]
    public class TestObuhvataOdluka
    {
        private static Prodavač prodavac;
        private static Proizvod proizvod;
        private static Tržnica pijaca;

        [TestInitialize]
        public void InicijalizacijaProdavaca()
        {
            prodavac = new Prodavač("prodos", "ise", new DateTime(2021, 5, 1, 8, 30, 52), 0);
            proizvod = new Proizvod(Namirnica.Žitarica, "psenica", 32, DateTime.Now, 5, true);
            pijaca = new Tržnica();
        }
        [TestMethod]
        public void Test1()
        {

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                Proizvod nesto = new Proizvod(Namirnica.Žitarica, "psenica", 32, DateTime.Now, 5, true);
                pijaca.NaručiProizvode(stand, new List<Proizvod> { nesto }, new List<int> { 10, 5 }, new List<DateTime> { });
            },
                "Pogrešan unos parametara!");
        }

        [TestMethod]
        public void Test2()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Proizvod nemame = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
                Štand stand = new Štand(prodavac, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { nemame }, new List<int> { 100 }, new List<DateTime> { DateTime.Now.AddDays(5) });
            },
                "Nemoguće naručiti proizvod - nije registrovan na štandu!");
        }

        [TestMethod]
        public void Test3()
        {
           
            Proizvod imame = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
            Štand stand = new Štand(prodavac, DateTime.Now.AddDays(25), new List<Proizvod> { imame });
            pijaca.NaručiProizvode(stand, new List<Proizvod> { imame }, new List<int> { 5 }, new List<DateTime> { DateTime.Now.AddDays(5) });

            Assert.IsTrue(imame.OčekivanaKoličina == 5);

        }

        [TestMethod]
        public void Test4()
        {

            Proizvod imame = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
            Štand stand = new Štand(prodavac, DateTime.Now.AddDays(25), new List<Proizvod> { imame });
            pijaca.NaručiProizvode(stand, new List<Proizvod> { imame }, new List<int> { 5 }, new List<DateTime> { DateTime.Now.AddDays(5) }, true);


            Assert.IsTrue(imame.OčekivanaKoličina == 0);
        }

    }
}
*/
