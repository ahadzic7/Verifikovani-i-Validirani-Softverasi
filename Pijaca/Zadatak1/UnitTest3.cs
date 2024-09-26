﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;

namespace Zadatak1
{
    //Ahmed Mahovac
    [TestClass]
    public class ProizvodTest
    {
        private static Proizvod pd = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, true);
        private static Proizvod ps = new Proizvod(Namirnica.Meso, "piletina", 2, DateTime.Now, 10.0, false);


   


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
            int prviDioSifre = int.Parse("1111001");
            int sum = 0;
            while (prviDioSifre != 0)
            {
                sum += prviDioSifre % 10;
                prviDioSifre /= 10;
            }
            Assert.AreEqual(int.Parse(sifra.Substring(sifra.Length - 1)), sum%10);
            Assert.AreEqual("1001", sifra.Substring(4, 4));
        }
        [TestMethod]
        public void test3BrojacSePovecava()
        {
            Proizvod proizvod = pd;
            string sifra1 = proizvod.ŠifraProizvoda;
            proizvod = ps;
            string sifra2 = proizvod.ŠifraProizvoda;
            Assert.IsNotNull(sifra1);
            Assert.IsNotNull(sifra2);
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
    }


        [TestMethod]
        public void test5SvegaPomalo()
        {
            string sifraDomaca = pd.ŠifraProizvoda;
            string sifraStrana = ps.ŠifraProizvoda;
            StringAssert.StartsWith(sifraDomaca, "387");
            StringAssert.StartsWith(sifraStrana, "111");
            Assert.AreEqual(sifraDomaca[3], '-');
            Assert.AreEqual(sifraStrana[3], '-');
            Assert.AreEqual(sifraDomaca[8], '-');
            Assert.AreEqual(sifraStrana[8], '-');
        } 

}

}
