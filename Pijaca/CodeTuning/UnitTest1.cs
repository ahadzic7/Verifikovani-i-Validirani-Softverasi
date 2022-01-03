using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;
using System.Collections.Generic;

namespace CodeTuning
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tržnica t = new Tržnica();
            List<Prodavač> pr = new List<Prodavač>();
            Prodavač spasiMe = null;
            var limit = 37_000_000;
            for(int i = 0; i  < limit; i++)
            {
                Prodavač p = new Prodavač("ime" + i.ToString(), "sifra", new DateTime(2021, 5, 1, 8, 30, 52), i);
                if(i == limit-1)
                {
                    spasiMe = p;
                }
                pr.Add(p);
                /*if(i % 10_000_000 == 0)
                {
                    var f = 0;
                }*/
            }

            t.setter(pr);


            var x = (0);
//            Prodavač pro = new Prodavač("ime" + (499_999).ToString(), "sifra", new DateTime(2021, 5, 1, 8, 30, 52), 4_999_999);
            t.RadSaProdavačima(spasiMe, "Izmjena", spasiMe.UkupniPromet);

            var y = 0;
        }
    }
}
