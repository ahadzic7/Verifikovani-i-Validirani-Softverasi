using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;

namespace Zadatak1
{
    [TestClass]
    public class ProdavacTest
    {
        private static Prodavač p;

        [TestInitialize]
        public void InicijalizacijaProdavaca() {
            p = new Prodavač("ime", "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 0);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPogresnaSifra()
        {
            p.RegistrujPromet("nema_teorije_da_je_ovo_sifra",100, DateTime.Now, DateTime.Now);
        }

        [TestMethod]
        public void TestAktivnosti()
        {
            DateTime d1 = new DateTime(2021, 5, 1, 8, 30, 52);
            DateTime d2 = new DateTime(2021, 12, 1, 8, 30, 52);
            p.RegistrujPromet("sifra", 0, d1, d2);
            Assert.IsFalse(p.Aktivnost);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPogresnihPodataka()
        {
            DateTime d1 = new DateTime(2021, 5, 1, 8, 30, 52);
            DateTime d2 = new DateTime(2021, 5, 2, 8, 30, 52);
            p.RegistrujPromet("sifra", 10000, d1, d2);
        }

        [TestMethod]
        public void TestPovecanjaPrometa()
        {
            double prometPrije = p.UkupniPromet;
            double povecanje = 124456.1684;
            DateTime d1 = new DateTime(2021, 5, 1, 8, 30, 52);
            DateTime d2 = new DateTime(2021, 6, 2, 8, 30, 52);
            p.RegistrujPromet("sifra", povecanje, d1, d2);
            Assert.AreNotEqual(prometPrije, p.UkupniPromet);
            Assert.AreEqual(prometPrije + povecanje, p.UkupniPromet);
        }

        [TestMethod]
        public void TestNegativnogPrometa()
        {
            DateTime d1 = new DateTime(2021, 6, 1, 8, 30, 52);
            DateTime d2 = new DateTime(2021, 5, 1, 8, 30, 52);
            try
            {
                p.RegistrujPromet("sifra", 700, d2, d1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
