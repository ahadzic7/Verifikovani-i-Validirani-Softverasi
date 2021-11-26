using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pijaca;
using System.Collections.Generic;

namespace Zadatak3
{
    [TestClass]
    public class UnitTestovi
    {
        private static Štand stand;
        private static Prodavač prodavac;
        private static Proizvod proizvod;
        private static Tržnica pijaca;
        
        [TestInitialize]
        public void InicijalizacijaProdavaca()
        {
            prodavac = new Prodavač("ime", "sifra", DateTime.Now.AddDays(-32), 0);
            proizvod = new Proizvod(Namirnica.Žitarica, "kukuruz", 49, DateTime.Now, 5, true);
            pijaca = new Tržnica();
        }

        #region ŠtandTestovi
        [TestMethod]
        public void TestKrajZakupa() 
        {
            stand = new Štand(prodavac, new DateTime(2021, 5, 1, 8, 30, 52));
            DateTime d1 = new DateTime(2021, 5, 1, 8, 30, 52);
            Assert.IsTrue(stand.KrajZakupa == d1);
        }

        [TestMethod]
        public void TestKupovine() 
        {
            stand = new Štand(prodavac, new DateTime(2021, 5, 1, 8, 30, 52));
            Assert.IsTrue(stand.Kupovine.Count == 0);
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
            Kupovina kupovina = new Kupovina(mesniProizvod, 2);
            stand.RegistrujKupovinu(kupovina);
            Assert.IsFalse(stand.Kupovine == null);
        }

        #endregion

        #region KupovnaTestovi

        [TestMethod]
        public void TestKupovinaProizvod()
        {
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
            Kupovina kupovina = new Kupovina(mesniProizvod, 2);
            Assert.AreEqual(kupovina.Proizvod.Ime, "Salama");
        }

        [TestMethod]
        public void TestKupovinaKolicina()
        {
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
            Kupovina kupovina = new Kupovina(mesniProizvod, 2);
            Assert.AreEqual(kupovina.Količina, 2);
        }

        [TestMethod]
        public void TestKupovinaCijena()
        {
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
            Kupovina kupovina = new Kupovina(mesniProizvod, 2);
            Assert.IsTrue(kupovina.UkupnaCijena == 5);
        }

        [TestMethod]
        public void TestKupovinaPopust()
        {
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
            Kupovina kupovina = new Kupovina(mesniProizvod, 2);
            Assert.IsTrue(kupovina.Popust == 10);
        }

        [TestMethod]
        public void TestKupovinaDatum()
        {
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
            Kupovina kupovina = new Kupovina(mesniProizvod, 2);
            Assert.IsTrue(kupovina.DatumKupovine.CompareTo(DateTime.Now) == 0);
        }

        #endregion

        #region ProdavačTestovi
        [TestMethod]
        public void TestDatumOtvaranja()
        {
            Prodavač prodavac2 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
            Assert.IsTrue(prodavac2.OtvaranjeŠtanda == new DateTime(2021, 5, 1, 8, 30, 52));
        }

        [TestMethod]
        public void TestAktivnosti()
        {
            Assert.IsFalse(prodavac.Aktivnost == false);
            prodavac.Aktivnost = false;
            Assert.IsTrue(prodavac.Aktivnost == false);
        }

        [TestMethod]
        public void TestPromet()
        {
            Assert.AreEqual(prodavac.UkupniPromet, 0);
        }


        #endregion

        #region ProizvodTestovi
        [TestMethod]
        public void TestSifraProizvoda()
        {
            Assert.IsTrue(proizvod.ŠifraProizvoda.StartsWith("387"));
        }

        [TestMethod]
        public void TestKolicina()
        {
            Assert.IsTrue(proizvod.KoličinaNaStanju == 49);
            proizvod.KoličinaNaStanju = 15;
            Assert.AreEqual(proizvod.KoličinaNaStanju, 15);
        }

        [TestMethod]
        public void TestOcekivanaKolicina()
        {
            Assert.IsTrue(proizvod.OčekivanaKoličina == 0);
        }

        [TestMethod]
        public void TestDatumPristizanja()
        {
            Proizvod proizvod1 = new Proizvod(Namirnica.Žitarica, "kukuruz", 49, new DateTime(2021, 5, 4, 12, 30, 0), 5, false);
            Assert.AreEqual(proizvod1.DatumPristizanja, new DateTime(2021, 5, 4, 12, 30, 0));
        }

        [TestMethod]
        public void TestDatumOcekivaneKolicine()
        {
            Proizvod proizvod1 = new Proizvod(Namirnica.Žitarica, "kukuruz", 49, new DateTime(2021, 5, 4, 12, 30, 0), 5, false);
            proizvod1.DatumOčekivaneKoličine = new DateTime(2022, 1, 1, 10, 0, 0);
            Assert.AreEqual(proizvod1.DatumOčekivaneKoličine, new DateTime(2022, 1, 1, 10, 0, 0));
        }

        [TestMethod]
        public void TestCertifikat387()
        {
            Proizvod proizvod1 = new Proizvod(Namirnica.Žitarica, "kukuruz", 49, new DateTime(2021, 5, 4, 12, 30, 0), 5, false);
            Assert.IsFalse(proizvod1.Certifikat387);
        }

        [TestMethod]
        public void TestNarucikolicinu()
        {
            Assert.IsTrue(proizvod.OčekivanaKoličina == 0);
            proizvod.NaručiKoličinu(5, new DateTime(2022, 1, 1, 10, 0, 0));
            Assert.AreEqual(proizvod.DatumOčekivaneKoličine, new DateTime(2022, 1, 1, 10, 0, 0));
            Assert.AreEqual(proizvod.OčekivanaKoličina, 5);
        }
        #endregion

        #region TrznicaTestovi
        [TestMethod]
        public void TestProdavaci()
        {
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            Assert.IsTrue(pijaca.Prodavači[0].Ime == "ime");
        }

        [TestMethod]
        public void TestStandovi()
        {
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            Assert.IsTrue(pijaca.Štandovi.Count == 0);
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
            pijaca.OtvoriŠtand(prodavac, new List<Proizvod>() { mesniProizvod }, DateTime.Now.AddDays(60));
            Assert.IsFalse(pijaca.Štandovi.Count == 0);
            Assert.AreEqual(pijaca.Štandovi[0].Prodavač.Ime, "ime");
        }

        [TestMethod]
        public void TestUkupniPromet()
        {
            Assert.IsTrue(pijaca.UkupniPrometPijace == 0);
        }

        [TestMethod]
        public void TestIzmjenaProdavaca()
        {
            pijaca.RadSaProdavačima(prodavac, "Dodavanje");
            Assert.IsTrue(pijaca.Prodavači[0].Aktivnost == true);
            prodavac.Aktivnost = false;
            pijaca.RadSaProdavačima(prodavac, "Izmjena");
            Assert.IsTrue(pijaca.Prodavači[0].Aktivnost == false);
        }

        [TestMethod]
        public void TestIzvrsavanjeKupovina()
        {
            Prodavač prodavac2 = new Prodavač("ime", "sifra", DateTime.Now.AddDays(-35), 0);
            pijaca.RadSaProdavačima(prodavac2, "Dodavanje");
            stand = new Štand(prodavac2, DateTime.Now.AddDays(35));
            Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);

            Kupovina kupovina1 = new Kupovina(mesniProizvod, 2);
            Kupovina kupovina2 = new Kupovina(proizvod, 10);
            List<Kupovina> sveKupovine = new List<Kupovina>();

            sveKupovine.Add(kupovina1);
            sveKupovine.Add(kupovina2);

            pijaca.OtvoriŠtand(prodavac2, new List<Proizvod>() { mesniProizvod, proizvod }, DateTime.Now.AddDays(60));

            pijaca.IzvršavanjeKupovina(stand, sveKupovine, "sifra");
            Assert.IsTrue(pijaca.Štandovi[0].Kupovine.Count == 2);
            Assert.IsTrue(pijaca.Štandovi[0].Kupovine[1].Proizvod.Ime == "kukuruz");
            Assert.IsTrue(pijaca.Prodavači[0].UkupniPromet == 55);
        }

        [TestMethod]
        public void TestDodavanjaTipskogVoca()
        {
            Prodavač p1 = new Prodavač("Prodavač voca", "šifra-voce", DateTime.Parse("01/01/2021"), 100000);
            Tržnica pijaca = new Tržnica();
            pijaca.RadSaProdavačima(p1, "Dodavanje");
            Proizvod vocka = new Proizvod(Namirnica.Voće, "Jabuka", 10, DateTime.Now.AddDays(-7), 2.5, true);

            pijaca.OtvoriŠtand(p1, new List<Proizvod>() { vocka }, DateTime.Now.AddDays(60));

            Assert.AreEqual(pijaca.Prodavači.Count, 1);
            Assert.IsTrue(pijaca.Štandovi.Count == 1);
            Assert.IsTrue(pijaca.Štandovi[0].Proizvodi.Contains(vocka));

            pijaca.DodajTipskeNamirnice(Namirnica.Voće);

            Assert.AreEqual(pijaca.Štandovi.Count, 1);
            Assert.IsTrue(pijaca.Štandovi[0].Proizvodi.Contains(vocka));


            Assert.AreEqual(pijaca.Štandovi[0].Proizvodi.Count, 3);
            Assert.IsTrue(pijaca.Štandovi[0].Proizvodi[1].Ime == "Šljiva");
            Assert.IsTrue(pijaca.Štandovi[0].Proizvodi[2].Ime == "Narandža");
        }
        #endregion
    }
}
