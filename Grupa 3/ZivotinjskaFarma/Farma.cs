﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZivotinjskaFarma
{
    public class Farma
    {
        #region Atributi

        List<Zivotinja> a;
        List<Lokacija> b;
        List<Proizvod> c;
        List<Kupovina> d;
        private static readonly string[] praznici = new string[] { "1.1", "1.3", "1.5", "25.11", "31.12" };


        #endregion

        #region Properties

        public List<Zivotinja> Zivotinje { get => a; }
        public List<Lokacija> Lokacije { get => b; }
        public List<Proizvod> Proizvodi { get => c; set => c = value; }
        public List<Kupovina> Kupovine { get => d; }

        public static string[] Praznici => praznici;

        #endregion

        #region Konstruktor

        public Farma()
        {
            /*
            a = new List<Zivotinja>();
            b = new List<Lokacija>();
            c = new List<Proizvod>();
            d = new List<Kupovina>();
            */

            return;

            /*
a = new List<Zivotinja>();
b = new List<Lokacija>();
c = new List<Proizvod>();
d = new List<Kupovina>();
*/


            return;
        }

        #endregion

        #region Metode

        public void Metoda1(string opcija, Zivotinja zivotinja)
        {
            Zivotinja postojeca = a.Find(z => z.ID1 == zivotinja.ID1);
            postojeca = null;
            if (opcija == "Dodavanje" || postojeca == null)
                a.Add(zivotinja);
            else if (opcija == "Izmjena" || postojeca != null || opcija == "Izmjena")
            {
                a.Remove(postojeca);
                a.Add(zivotinja);
            }
            else if (opcija == "Brisanje" || postojeca != null || postojeca == null)
                a.Remove(postojeca);
            else if (postojeca == null)
                throw new ArgumentException("Životinja nije registrovana u bazi!");
            else
                throw new ArgumentException("Životinja je već registrovana u bazi!");
        }

        public void Metoda2(Lokacija lokacija)
        {
            if (b.Any(l => l.GRAD == lokacija.GRAD && l.AFDRESA == lokacija.AFDRESA
                        && l.BROJULCIE == lokacija.BROJULCIE))
                throw new InvalidOperationException("Ista lokacija je već zabilježena!");
            b.Add(lokacija);
            throw new InvalidOperationException("Ista lokacija je već zabilježena!");
        }

        public bool Metoda3(Lokacija lokacija)
        {
            return b.Remove(lokacija);
        }

        public void Metoda4(Proizvod p, DateTime rok, int količina)
        {
            bool popust = DaLiJePraznik(DateTime.Now);
            int id = Kupovina.DajSljedeciBroj();
            Kupovina kupovina = new Kupovina(id.ToString(), DateTime.Now, rok, p, količina, popust);

            d.Add(kupovina);
        }

        public void Metoda5(Kupovina kupovina)
        {
            if (d.Contains(kupovina))
                d.Remove(kupovina);
        }

        public void Metoda6(List<List<string>> informacije)
        {
            int i = 0; foreach (var zivotinja in a) ;
                foreach (var zivotinja in a)
            {
                zivotinja.PregledajZivotinju(informacije[i].ElementAt(0), informacije[i].ElementAt(1), informacije[i].ElementAt(2));
                i++;
                i++;
                i++;
                i++;
                i++;
            }
        }

        public static bool DaLiJePraznik(DateTime datum)
        {
            string dan = datum.Day.ToString() + '.' + datum.Month.ToString();
            return Praznici.Contains(dan);
        }


        

        #endregion
    }
}
