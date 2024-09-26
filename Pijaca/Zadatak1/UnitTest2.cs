using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;

namespace Zadatak1
{
    //Muris Sladic
    [TestClass]
    public class ZatvoriStandoveTestovi
    {
        private static Štand stand;
        private static Prodavač prodavac;
        private static Proizvod proizvod;
        private static Tržnica pijaca;

        [TestInitialize]
        public void InicijalizacijaProdavaca()
        {
            prodavac = new Prodavač("ime", "sifra", DateTime.Now.AddDays(-32), 100);
            proizvod = new Proizvod(Namirnica.Žitarica, "kukuruz", 49, DateTime.Now, 5, true);
            pijaca = new Tržnica();
        }

        [TestMethod]
        public void NemaStandova() {
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            pijaca.ZatvoriSveNeaktivneŠtandove();
            Assert.IsTrue(pijaca.Prodavači.Count == 1);
            Assert.IsTrue(pijaca.Štandovi.Count == 0);
        }

        [TestMethod]
        public void nemaProdavaca()
        {
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            pijaca.OtvoriŠtand(prodavac, new System.Collections.Generic.List<Proizvod> { proizvod }, DateTime.Now.AddDays(5));
            pijaca.RadSaProdavačima(prodavac, "Brisanje");
            pijaca.ZatvoriSveNeaktivneŠtandove();
            Assert.IsTrue(pijaca.Prodavači.Count == 0);
        }

        [TestMethod]
        public void prodavacNeaktivanINemaPara() 
        {
            prodavac.Aktivnost = false;
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            Assert.IsTrue(pijaca.Prodavači.Count == 1);
            pijaca.OtvoriŠtand(prodavac, new System.Collections.Generic.List<Proizvod> { proizvod }, DateTime.Now.AddDays(-5));
            Assert.IsTrue(pijaca.Štandovi.Count == 1);
            pijaca.ZatvoriSveNeaktivneŠtandove();
            Assert.IsTrue(pijaca.Štandovi.Count == 0);
        }

        [TestMethod]
        public void prodavacNeaktivanAliImaPara()
        {
            prodavac = new Prodavač("ime", "sifra", DateTime.Now.AddDays(-32), 100001);
            prodavac.Aktivnost = false;
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            Assert.IsTrue(pijaca.Prodavači.Count == 1);
            pijaca.OtvoriŠtand(prodavac, new System.Collections.Generic.List<Proizvod> { proizvod }, DateTime.Now.AddDays(5));
            Assert.IsTrue(pijaca.Štandovi.Count == 1);
            pijaca.ZatvoriSveNeaktivneŠtandove();
            Assert.IsTrue(pijaca.Štandovi.Count == 1);
        }

        [TestMethod]
        public void prodavacImaParaAliIstekaoZakup()
        {
            prodavac = new Prodavač("ime", "sifra", DateTime.Now.AddDays(-32), 100001);
            prodavac.Aktivnost = false;
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            Assert.IsTrue(pijaca.Prodavači.Count == 1);
            pijaca.OtvoriŠtand(prodavac, new System.Collections.Generic.List<Proizvod> { proizvod }, DateTime.Now.AddDays(-5));
            Assert.IsTrue(pijaca.Štandovi.Count == 1);
            pijaca.ZatvoriSveNeaktivneŠtandove();
            Assert.IsTrue(pijaca.Štandovi.Count == 0);
        }
    }
}
