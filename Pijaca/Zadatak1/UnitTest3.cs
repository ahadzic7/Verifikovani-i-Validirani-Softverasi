using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;

namespace Zadatak1
{
    //Ahmed Mahovac
    [TestClass]
    public class ProizvodTest
    {
        private static Proizvod proizvod;
        [TestMethod]
        public void test1GenerisanjaSifreDomaci()
        {
            proizvod = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, true);
            string sifra = proizvod.ŠifraProizvoda;
            Assert.IsNotNull(sifra);
            Assert.AreEqual(sifra.Substring(0, 3), "387");
            int prviDioSifre = int.Parse("3871000");
            int sum = 0;
            while (prviDioSifre != 0)
            {
                sum += prviDioSifre % 10;
                prviDioSifre /= 10;
            }
            sifra.Replace("-", String.Empty);
            Assert.AreEqual(int.Parse(sifra.Substring(sifra.Length-1)),sum%10);
            Assert.AreEqual(sifra.Substring(4, 4), "1000");
        }

        [TestMethod]
        public void test2GenerisanjaSifreStrani()
        {
            proizvod = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, false);
            string sifra = proizvod.ŠifraProizvoda;
            Assert.IsNotNull(sifra);
            Assert.AreEqual(sifra.Substring(0, 3), "111");
            int prviDioSifre = int.Parse("3871001");
            int sum = 0;
            while (prviDioSifre != 0)
            {
                sum += prviDioSifre % 10;
                prviDioSifre /= 10;
            }
            sifra.Replace("-", String.Empty);
            Assert.AreEqual(int.Parse(sifra.Substring(sifra.Length - 1)), sum%10);
            Assert.AreEqual(sifra.Substring(4, 4), "1001");
        }
        [TestMethod]
        public void test3BrojacSePovecava()
        {
            proizvod = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, false);
            string sifra1 = proizvod.ŠifraProizvoda;
            proizvod = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, false);
            string sifra2 = proizvod.ŠifraProizvoda;
            Assert.IsNotNull(sifra1);
            Assert.IsNotNull(sifra2);
            sifra1.Replace("-", String.Empty);
            sifra2.Replace("-", String.Empty);
            Assert.Equals(int.Parse(sifra2.Substring(4, 4)) - int.Parse(sifra1.Substring(4, 4)), 1);
        }

    [TestMethod]
    public void test4VracaSeKaoRezultatFunkcije()
    {
        proizvod = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, false);
        string sifra1 = proizvod.ŠifraProizvoda;
        string sifra2 = proizvod.GenerišiŠifru(false);
        Assert.IsNotNull(sifra1);
        Assert.IsNotNull(sifra2);
        sifra1.Replace("-", String.Empty);
        sifra2.Replace("-", String.Empty);
            Assert.Equals(int.Parse(sifra2.Substring(4, 4)) - int.Parse(sifra1.Substring(4, 4)), 1);
    }
}

}
