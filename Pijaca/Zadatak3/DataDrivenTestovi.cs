using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pijaca;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace Zadatak3
{
    // Ahmed Mahovac
    [TestClass]
    public class DataDrivenTestovi
    {
        static IEnumerable<Object[]> PodaciNeispravniProdavac;
        static IEnumerable<Object[]> PodaciIspravniProdavac;
        static IEnumerable<Object[]> PodaciNeispravniProizvod;
        static IEnumerable<Object[]> PodaciIspravniProizvod;
        #region Prodavac
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [DynamicData("PodaciNeispravniProdavac")]
        public void test1NeispravniPodaci(string ime, string sigurnosnaŠifra, DateTime otvaranje, double dosadašnjiPromet)
        {
            Prodavač prodavac = new Prodavač(ime, sigurnosnaŠifra, otvaranje, dosadašnjiPromet);
        }


        [TestMethod]
        [DynamicData("PodaciIspravniProdavac")]
        public void test1IspravniPodaci(string ime, string sigurnosnaŠifra, DateTime otvaranje, double dosadašnjiPromet)
        {
            Prodavač prodavac = new Prodavač(ime, sigurnosnaŠifra, otvaranje, dosadašnjiPromet);
        }

        #endregion

        #region Proizvod
         [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [DynamicData("PodaciNeispravniProizvod")]
        public void test2NeispravniPodaci(Namirnica vrsta, string ime, int kolicina, DateTime datum, double cijena, bool domaci)
        {
            Proizvod proizvod = new Proizvod(vrsta, ime, kolicina, datum, cijena, domaci);
        }


        [TestMethod]
        [DynamicData("PodaciIspravniProizvod")]
        public void test2IspravniPodaci(Namirnica vrsta, string ime, int kolicina, DateTime datum, double cijena, bool domaci)
        {
            Proizvod proizvod = new Proizvod(vrsta, ime, kolicina, datum, cijena, domaci);
        }
        #endregion

    }
}
