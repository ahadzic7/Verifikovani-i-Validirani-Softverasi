using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pijaca;
using System.Collections.Generic;

namespace Zadatak3
{
    /// <summary>
    /// implementirao Armin Hadzic 18667
    /// </summary>
    [TestClass]
    public class TestoviIzuzetaka
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

        #region ProdavacTestovi
        [TestMethod]
        public void TestProdavacIme()
        {
            Assert.ThrowsException<InvalidOperationException>(() => prodavac.Ime = "\t\t", "Neispravno uneseno ime prodavača!");
            Assert.ThrowsException<InvalidOperationException>(() => prodavac.Ime = "", "Neispravno uneseno ime prodavača!");
        }

        [TestMethod]
        public void TestOtvaranjeStanda()
        {
            Assert.ThrowsException<InvalidOperationException>(() => prodavac.OtvaranjeŠtanda = DateTime.Now.AddDays(5),
                "Štand nije moguće registrovati dok ne prođe barem mjesec dana!");
            Assert.ThrowsException<InvalidOperationException>(() => prodavac.OtvaranjeŠtanda = new DateTime(1992, 1, 3, 0, 0, 0),
                "Štand nije moguće registrovati - protekao period dozvoljene registracije!");
        }

        [TestMethod]
        public void TestKonstruktoraProdavaca()
        {
            Assert.ThrowsException<InvalidOperationException>(
                () => { Prodavač p = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), -55); },
                "Promet ne može biti negativan!");
        }

        [TestMethod]
        public void TestRegistrujPromet()
        {
            Assert.ThrowsException<InvalidOperationException>(() => prodavac.RegistrujPromet("nema_teorije_da_je_ovo_sifra", 100, DateTime.Now, DateTime.Now),
                "Šifra i sigurnosni kod se ne poklapaju!");
            Assert.ThrowsException<InvalidOperationException>(
                () =>
                {
                    DateTime d1 = new DateTime(2021, 5, 1, 8, 30, 52);
                    DateTime d2 = new DateTime(2021, 5, 2, 8, 30, 52);
                    prodavac.RegistrujPromet("sifra", 10000, d1, d2);
                },
                "Neispravno uneseni podaci!");
        }
        #endregion


        #region ProizvodTestovi
        [TestMethod]
        public void TestProizvodIme()
        {
            Assert.ThrowsException<FormatException>(() => proizvod.Ime = "\n\t",
                "Ime proizvoda ne može biti prazno!");
            Assert.ThrowsException<FormatException>(() => proizvod.Ime = "",
                "Ime proizvoda ne može biti prazno!");
            Assert.ThrowsException<FormatException>(() => proizvod.Ime = "01234567890123456789+1",
                "Ime proizvoda ne smije biti duže od 10 karaktera!");
        }

        [TestMethod]
        public void TestKolicinaNaStanju()
        {
            Assert.ThrowsException<FormatException>(() => proizvod.KoličinaNaStanju = -4,
                "Dostupna količina ne može biti manja od 0!");
            Assert.ThrowsException<FormatException>(() => proizvod.KoličinaNaStanju = 400,
                "Štand ne dopušta više od 50 proizvoda!");
        }

        [TestMethod]
        public void TestOcekivanaKolicina()
        {
            Assert.ThrowsException<FormatException>(() => proizvod.OčekivanaKoličina = -4,
                "Neispravno unesena očekivana količina!");
            Assert.ThrowsException<FormatException>(() => proizvod.OčekivanaKoličina = 400,
                "Štand ne dopušta više od 10 novih proizvoda!");
        }

        [TestMethod]
        public void TestDatumPristizanja()
        {
            Assert.ThrowsException<FormatException>(() => proizvod.DatumPristizanja = DateTime.Now.AddDays(5),
                "Datum pristizanja robe ne može biti u budućnosti!");
        }

        [TestMethod]
        public void TestDatumOcekivaneKolicine()
        {
            Assert.ThrowsException<FormatException>(() => proizvod.DatumOčekivaneKoličine = DateTime.Now.AddDays(-5),
                "Datum pristizanja robe ne može biti u prošlosti!");
        }

        [TestMethod]
        public void TestCijenaProizvoda()
        {
            Assert.ThrowsException<FormatException>(() => proizvod.CijenaProizvoda = -100,
                "Proizvod ne može biti besplatan!");
            Assert.ThrowsException<FormatException>(() => proizvod.CijenaProizvoda = 0.001,
                "Proizvod ne može biti besplatan!");
            Assert.ThrowsException<FormatException>(() => proizvod.CijenaProizvoda = 100_000_000,
                "Pijaca nije namijenjena za skupe proizvode!");
        }

        [TestMethod]
        public void TestCertifikat387()
        {
            Assert.ThrowsException<FormatException>(() => proizvod.Certifikat387 = false,
                "Domaći proizvod se mora označiti kao takav!");
            Assert.ThrowsException<FormatException>(() => 
            {
                Proizvod straniProizvod = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false); 
                straniProizvod.Certifikat387 = true;
            },
                "Strani proizvod se ne smije označiti kao domaći!!");
        }
        #endregion

        #region Trznica
        [TestMethod]
        public void TestRadSaProdavačima()
        {
            Assert.ThrowsException<ArgumentNullException>(() => pijaca.RadSaProdavačima(null, "Dodavanje"),
                "Morate unijeti informacije o prodavaču!");

            Assert.ThrowsException<InvalidOperationException>(() => 
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);

                pijaca.RadSaProdavačima(p1, "Dodavanje");
                pijaca.RadSaProdavačima(p1, "Dodavanje");
            },
                "Nemoguće dodati prodavača kad već postoji registrovan!");

            Assert.ThrowsException<FormatException>(() => 
            {
                Prodavač p2 = new Prodavač("drugo ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                pijaca.RadSaProdavačima(p2, "Izmjena");
            },
                "Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");

            Assert.ThrowsException<FormatException>(() =>
            {
                Prodavač p3 = new Prodavač("trece ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                pijaca.RadSaProdavačima(p3, "Brisanje");
            },
                "Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");

            Assert.ThrowsException<InvalidOperationException>(() => pijaca.RadSaProdavačima(prodavac, "macka presla preko tastature"),
                "Morate unijeti informacije o prodavaču!");

        }

        [TestMethod]
        public void TestOtvoriŠtand()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                pijaca.OtvoriŠtand(p1, null, DateTime.Now);
            },
                "Prodavač nije registrovan!");

            Assert.ThrowsException<FormatException>(() =>
            {
                Prodavač p1 = new Prodavač("ime_prezime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                pijaca.RadSaProdavačima(p1, "Dodavanje");
                pijaca.OtvoriŠtand(p1, null, DateTime.Now);
                pijaca.OtvoriŠtand(p1, null, DateTime.Now);
            },
                "Prodavač može imati samo jedan štand!");
        }

        [TestMethod]
        public void TestIzvršavanjeKupovina()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.IzvršavanjeKupovina(stand, null, null);
            },
                "Unijeli ste štand koji nije registrovan!");
        }

        [TestMethod]
        public void TestDodavanjeTipskeNamirnice()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                Prodavač p1 = new Prodavač("Prodavač mesa", "šifra-meso", DateTime.Parse("01/01/2021"), 100000);
                Tržnica pijaca = new Tržnica();
                pijaca.RadSaProdavačima(p1, "Dodavanje");
                Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
                pijaca.OtvoriŠtand(p1, new List<Proizvod>() { mesniProizvod }, DateTime.Now.AddDays(60));

                pijaca.DodajTipskeNamirnice(Namirnica.Poluproizvod);
            },
                "");

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                Prodavač p1 = new Prodavač("Prodavač mesa", "šifra-meso", DateTime.Parse("01/01/2021"), 100000);
                Tržnica pijaca = new Tržnica();
                pijaca.RadSaProdavačima(p1, "Dodavanje");
                Proizvod mesniProizvod = new Proizvod(Namirnica.Meso, "Salama", 10, DateTime.Now.AddDays(-7), 2.5, true);
                pijaca.OtvoriŠtand(p1, new List<Proizvod>() { mesniProizvod }, DateTime.Now.AddDays(60));

                pijaca.DodajTipskeNamirnice(Namirnica.Meso, true);
            },
                "");



        }

        [TestMethod]
        public void TestNaručiProizvode()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { }, new List<int> { 100, 5 }, new List<DateTime> { });
            },
                "Pogrešan unos parametara!");

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { }, new List<int> { }, new List<DateTime> { DateTime.Now.AddDays(5) });
            },
                "Pogrešan unos parametara!");

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Prodavač p1 = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
                Proizvod p = new Proizvod(Namirnica.Voće, "ananas", 49, DateTime.Now, 5, false);
                Štand stand = new Štand(p1, DateTime.Now.AddDays(25));
                pijaca.NaručiProizvode(stand, new List<Proizvod> { p }, new List<int> { 100, 5 }, new List<DateTime> { DateTime.Now.AddDays(5) });
            },
                "Nemoguće naručiti proizvod - nije registrovan na štandu!");
        }

            #endregion
        }
}
