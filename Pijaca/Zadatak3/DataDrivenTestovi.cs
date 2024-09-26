using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pijaca;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Xml;
using CsvHelper;
using System.Linq;

namespace Zadatak3
{
    // Ahmed Mahovac
    [TestClass]
    public class DataDrivenTestovi
    {
        static IEnumerable<Object[]> PodaciNeispravniProdavac { 
          get
            {
                return UčitajPodatkeCSVProdavac("PodaciNeispravniProdavac.csv");
            }
        }
        static IEnumerable<Object[]> PodaciIspravniProdavac
        {
            get
            {
                return UčitajPodatkeXMLProdavac("PodaciIspravniProdavac.xml");
            }
        }
        static IEnumerable<Object[]> PodaciNeispravniProizvod
        {
            get
            {
                return UčitajPodatkeXMLProizvod("PodaciNeispravniProizvod.xml");
            }
        }
        static IEnumerable<Object[]> PodaciIspravniProizvod
        {
            get
            {
                return UčitajPodatkeCSVProizvod("PodaciIspravniProizvod.csv");
            }
        }
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
            Assert.AreEqual(prodavac.Ime, ime);
            Assert.AreEqual(prodavac.UkupniPromet, dosadašnjiPromet);
            Assert.AreEqual(prodavac.OtvaranjeŠtanda, otvaranje);
            Assert.AreEqual(prodavac.Aktivnost, true);
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
            Assert.AreEqual(proizvod.Ime, ime);
            Assert.AreEqual(proizvod.KoličinaNaStanju, kolicina);
            Assert.AreEqual(proizvod.VrstaNamirnice, vrsta);
            Assert.AreEqual(proizvod.CijenaProizvoda, cijena);
        }
        #endregion


        #region pomocne metode
        public static IEnumerable<object[]> UčitajPodatkeXMLProdavac(string nazivFajla)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(nazivFajla);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { elements[0], elements[1],
DateTime.Parse(elements[2]), double.Parse(elements[3])};
            }
        }


        public static IEnumerable<object[]> UčitajPodatkeXMLProizvod(string nazivFajla)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(nazivFajla);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { Namirnica.Meso, elements[1],
int.Parse(elements[2]), DateTime.Parse(elements[3]), double.Parse(elements[4]), bool.Parse(elements[5])};
            }
        }



        public static IEnumerable<object[]> UčitajPodatkeCSVProdavac(string nazivFajla)
        {
            using (var reader = new StreamReader(nazivFajla))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1],
DateTime.Parse(elements[2]), double.Parse(elements[3]) };
                }
            }
        }



        public static IEnumerable<object[]> UčitajPodatkeCSVProizvod(string nazivFajla)
        {
            using (var reader = new StreamReader(nazivFajla))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { Namirnica.Meso, elements[1],
int.Parse(elements[2]), DateTime.Parse(elements[3]), double.Parse(elements[4]), bool.Parse(elements[5]) };
                }
            }
        }

        #endregion


    }
}
