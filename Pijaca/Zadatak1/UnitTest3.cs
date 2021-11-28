using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;

namespace Zadatak1
{
    //Ahmed Mahovac
    [TestClass]
    public class ProizvodTest
    {
        private static Proizvod pd, ps;
        
        [TestInitialize]
        public void InicijalizacijaProizvoda()
        {
            pd = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, true);
            ps = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, false);
        }


        [TestMethod]
        public void test1GenerisanjaSifreDomaci()
        {
            Proizvod proizvod = pd;
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
            Assert.AreEqual(int.Parse(sifra.Substring(sifra.Length-1)),sum%10);
            Assert.AreEqual(sifra.Substring(4, 4), "1000");
        }

        [TestMethod]
        public void test2GenerisanjaSifreStrani()
        {
            Proizvod proizvod = ps;
            string sifra = proizvod.ŠifraProizvoda;
            Assert.IsNotNull(sifra);
            Assert.AreEqual(sifra.Substring(0, 3), "111");
            int prviDioSifre = int.Parse("1111000");
            int sum = 0;
            while (prviDioSifre != 0)
            {
                sum += prviDioSifre % 10;
                prviDioSifre /= 10;
            }
            sifra.Replace("-", String.Empty);
            Console.WriteLine(sifra.Substring(sifra.Length - 1));
            Assert.AreEqual(int.Parse(sifra.Substring(sifra.Length - 1)), sum%10);
            Assert.AreEqual("1000", sifra.Substring(4, 4));
        }
        [TestMethod]
        public void test3BrojacSePovecava()
        {
            Proizvod proizvod = ps;
            string sifra1 = proizvod.ŠifraProizvoda;
            proizvod = ps;
            string sifra2 = proizvod.ŠifraProizvoda;
            Assert.IsNotNull(sifra1);
            Assert.IsNotNull(sifra2);
            sifra1.Replace("-", String.Empty);
            sifra2.Replace("-", String.Empty);
            Assert.AreEqual(int.Parse(sifra2.Substring(4, 4)) - int.Parse(sifra1.Substring(4, 4)), 1);
        }

    [TestMethod]
    public void test4VracaSeKaoRezultatFunkcije()
    {
        Proizvod proizvod = ps;
        string sifra1 = proizvod.ŠifraProizvoda;
        string sifra2 = proizvod.GenerišiŠifru(false);
        Assert.IsNotNull(sifra1);
        Assert.IsNotNull(sifra2);
        sifra1.Replace("-", String.Empty);
        sifra2.Replace("-", String.Empty);
        Assert.AreEqual(int.Parse(sifra2.Substring(4, 4)) - int.Parse(sifra1.Substring(4, 4)), 1);
    }
}

}
