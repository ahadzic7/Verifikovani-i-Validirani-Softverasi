using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;
using System.Collections.Generic;

namespace CodeTuning
{
    [TestClass]
    public class UnitTest1
    {
        public static Tržnica trznica;
        public static Prodavač trazeniProdavac;
        public static int limit;

        [ClassInitialize]
        public static void priprema(TestContext tc)
        {
            trznica = new Tržnica();
            List<Prodavač> pr = new List<Prodavač>();
            limit = 5;
            for (int i = 0; i < limit; i++)
            {
                pr.Add(new Prodavač("ime" + i.ToString(), "sifra", new DateTime(2021, 5, 1, 8, 30, 52), i));
            }
            trazeniProdavac = pr[limit - 1];

            trznica.setter(pr);
        }

        [TestMethod]
        public void TestMethod1()
        {
            string x = "Brakepoint1";

            trznica.RadSaProdavačimaTuning1(trazeniProdavac, "Izmjena", trazeniProdavac.UkupniPromet);

            string y = "Brakepoint2";
        }

        [TestMethod]
        public void TestMethod2()
        {
            string x = "Brakepoint1";

            trznica.RadSaProdavačimaTuning2(trazeniProdavac, "Izmjena", trazeniProdavac.UkupniPromet);

            string y = "Brakepoint2";
        }

        [TestMethod]
        public void TestMethod3()
        {
            string x = "Brakepoint1";

            trznica.RadSaProdavačimaTuning3(trazeniProdavac, "Izmjena", trazeniProdavac.UkupniPromet);

            string y = "Brakepoint2";
        }
    }
}
