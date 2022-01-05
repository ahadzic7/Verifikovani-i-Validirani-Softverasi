using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pijaca
{
    public class Tržnica
    {
        #region Atributi

        List<Prodavač> prodavači;
        
        List<Štand> štandovi;
        double ukupniPrometPijace;

        public void setter(List<Prodavač> lista)
        {
            prodavači = lista;
        }

        #endregion

        #region Properties

        public List<Prodavač> Prodavači { get => prodavači; }
        public List<Štand> Štandovi { get => štandovi; }
        public double UkupniPrometPijace { get => ukupniPrometPijace; }

        #endregion

        #region Konstruktor

        public Tržnica()
        {
            prodavači = new List<Prodavač>();
            štandovi = new List<Štand>();
            ukupniPrometPijace = 0.0;
        }

        #endregion

        #region Metode
        public void RadSaProdavačima(Prodavač p, string opcija, double najmanjiPromet)
        {
            if (p == null)
                throw new ArgumentNullException("Morate unijeti informacije o prodavaču!");

            Prodavač postojeći = null;
            foreach (var prodavač in prodavači)
            {
                if (prodavač.Ime == p.Ime)
                {
                    if (p.UkupniPromet < najmanjiPromet)
                        continue;
                    else if (prodavač.UkupniPromet < najmanjiPromet)
                        continue;
                    else if (prodavač.UkupniPromet == p.UkupniPromet)
                        postojeći = prodavač;
                }
            }
            if (opcija == "Dodavanje")
            {
                if (postojeći == null || prodavači.FindAll(prod => prod.Ime == p.Ime).Count == 0)
                    throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");
                else
                    prodavači.Add(p);
            }
            else if (opcija == "Izmjena" || opcija == "Brisanje")
            {
                if (postojeći == null || prodavači.FindAll(prod => prod.Ime == p.Ime).Count == 0)
                    throw new FormatException("Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");
                else
                {
                    prodavači.Remove(postojeći);
                    if (opcija == "Izmjena")
                        prodavači.Add(p);
                }
            }
            else
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        /// <summary>
        /// CodeTuning Armin Hadzic 18667
        /// </summary>

        public void RadSaProdavačimaTuning1(Prodavač p, string opcija, double najmanjiPromet)
        {
            if (p == null)
                throw new ArgumentNullException("Morate unijeti informacije o prodavaču!");

            Prodavač postojeći = null;
            var pIme = p.Ime;
            var pUkupniPromet = p.UkupniPromet;
            foreach (var prodavač in prodavači)
            {
                if (prodavač.Ime == pIme && prodavač.UkupniPromet == pUkupniPromet)
                {
                    postojeći = prodavač;
                }
            }
            if (opcija == "Dodavanje")
            {
                if (postojeći == null || prodavači.FindAll(prod => prod.Ime == p.Ime).Count == 0)
                    throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");
                else
                    prodavači.Add(p);
            }
            else if (opcija == "Izmjena" || opcija == "Brisanje")
            {
                if (postojeći == null || prodavači.FindAll(prod => prod.Ime == p.Ime).Count == 0)
                    throw new FormatException("Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");
                else
                {
                    prodavači.Remove(postojeći);
                    if (opcija == "Izmjena")
                        prodavači.Add(p);
                }
            }
            else
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        /// <summary>
        /// CodeTuning Muris Sladic 18613
        /// </summary>

        public void RadSaProdavačimaTuning2(Prodavač p, string opcija, double najmanjiPromet)
        {
            if (p == null)
                throw new ArgumentNullException("Morate unijeti informacije o prodavaču!");

            Prodavač postojeći = null;
            var pIme = p.Ime;
            var pUkupniPromet = p.UkupniPromet;
            var velicina = prodavači.Count;
            var index = 0;

            for (int i = 0; i < velicina; i++)
            {
                var prodavac = prodavači[i];
                var prodavacIme = prodavac.Ime;
                var prodavacUkupniPromet = prodavac.UkupniPromet;

                if (prodavacIme == pIme && prodavacUkupniPromet == pUkupniPromet)
                {
                    postojeći = prodavac;
                    index = i;
                }
                
            }
            if (opcija == "Dodavanje")
            {
                if (postojeći == null)
                    throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");
                else
                    prodavači.Add(p);
            }
            else if (opcija == "Izmjena" || opcija == "Brisanje")
            {
                if (postojeći == null)
                    throw new FormatException("Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");
                else
                {
                    prodavači.RemoveAt(index);
                    if (opcija == "Izmjena")
                        prodavači.Add(p);
                }
            }
            else
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        /// <summary>
        /// CodeTuning Ahmed Mahovac
        /// </summary>

        public void RadSaProdavačimaTuning3(Prodavač p, string opcija, double najmanjiPromet)
        {
            if (p == null)
                throw new ArgumentNullException("Morate unijeti informacije o prodavaču!");

            Prodavač postojeći = null;
            var pIme = p.Ime;
            var pUkupniPromet = p.UkupniPromet;
            var velicina = prodavači.Count;
            var index = 0;

            for (int i = 0; i < velicina; i += 4)
            {
                var prodavac = prodavači[i];
                var prodavacIme = prodavac.Ime;
                var prodavacUkupniPromet = prodavac.UkupniPromet;

                var prodavac1 = prodavači[i + 1];
                var prodavacIme1 = prodavac1.Ime;
                var prodavacUkupniPromet1 = prodavac1.UkupniPromet;

                var prodavac2 = prodavači[i + 2];
                var prodavacIme2 = prodavac2.Ime;
                var prodavacUkupniPromet2 = prodavac2.UkupniPromet;

                var prodavac3 = prodavači[i + 3];
                var prodavacIme3 = prodavac3.Ime;
                var prodavacUkupniPromet3 = prodavac3.UkupniPromet;

                if (prodavacIme == pIme && prodavacUkupniPromet == pUkupniPromet)
                {
                    postojeći = prodavac;
                    index = i;
                }
                else if (prodavacIme1 == pIme && prodavacUkupniPromet1 == pUkupniPromet)
                {
                    postojeći = prodavac1;
                    index = i + 1;

                }
                else if (prodavacIme2 == pIme && prodavacUkupniPromet2 == pUkupniPromet)
                {
                    postojeći = prodavac2;
                    index = i + 2;

                }
                else if (prodavacIme3 == pIme && prodavacUkupniPromet3 == pUkupniPromet)
                {
                    postojeći = prodavac3;
                    index = i + 3;
                }
            }
            if (opcija == "Dodavanje")
            {
                if (postojeći != null)
                    throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");
                else
                    prodavači.Add(p);
            }
            else if (opcija == "Izmjena" || opcija == "Brisanje")
            {
                if (postojeći == null)
                    throw new FormatException("Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");
                else
                {
                    prodavači.RemoveAt(index);
                    if (opcija == "Izmjena")
                        prodavači.Add(p);
                }
            }
            else
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        /// <summary>
        /// Refaktoring Armin Hadzic 18667
        /// </summary>

        private Prodavač pretragaProdavacaRefaktor(Prodavač p, double najmanjiPromet)
        {
            if (p == null)
                throw new ArgumentNullException("Morate unijeti informacije o prodavaču!");

            return prodavači.Find(prod => prod.Ime == p.Ime && prod.UkupniPromet == p.UkupniPromet);
        }

        public void DodavanjeProdavacaRefaktor(Prodavač p, double najmanjiPromet)
        {
            var postojeci = pretragaProdavacaRefaktor(p, najmanjiPromet);
            if (postojeci != null)
                throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");
            prodavači.Add(p);
        }

        public void BrisanjeProdavacaRefaktor(Prodavač p, double najmanjiPromet)
        {
            var postojeci = pretragaProdavacaRefaktor(p, najmanjiPromet);
            if (postojeci == null)
                throw new InvalidOperationException("Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");
            prodavači.Remove(p);
        }

        public void IzmjenaProdavacaRefaktor(Prodavač p, double najmanjiPromet)
        {
            var postojeci = pretragaProdavacaRefaktor(p, najmanjiPromet);
            if (postojeci == null)
                throw new InvalidOperationException("Nemoguće izmijeniti tj. obrisati prodavača koji nije registrovan!");
            prodavači.Remove(postojeci);
            prodavači.Add(p);
        }



        public void OtvoriŠtand(Prodavač p, List<Proizvod> pr, DateTime rok)
        {
            if (!prodavači.Contains(p))
                throw new ArgumentException("Prodavač nije registrovan!");
            if (štandovi.Find(š => š.Prodavač == p) != null)
                throw new FormatException("Prodavač može imati samo jedan štand!");
            Štand štand = new Štand(p, rok, pr);
            štandovi.Add(štand);
        }

        public void IzvršavanjeKupovina(Štand š, List<Kupovina> kupovine, string sigurnosniKod)
        {
            Štand štand = štandovi.Find(št => št.Prodavač == š.Prodavač);
            if (štand == null)
                throw new ArgumentException("Unijeli ste štand koji nije registrovan!");

            DateTime najranijaKupovina = kupovine[0].DatumKupovine, najkasnijaKupovina = kupovine[0].DatumKupovine;
            double ukupanPromet = 0;

            foreach (var kupovina in kupovine)
            {
                if (kupovina.DatumKupovine < najranijaKupovina)
                    najranijaKupovina = kupovina.DatumKupovine;
                if (kupovina.DatumKupovine > najkasnijaKupovina)
                    najkasnijaKupovina = kupovina.DatumKupovine;
                ukupanPromet += kupovina.UkupnaCijena;

                štand.RegistrujKupovinu(kupovina);
            }

            Prodavač prodavač = štand.Prodavač;
            prodavač.RegistrujPromet(sigurnosniKod, ukupanPromet, najranijaKupovina, najkasnijaKupovina);
        }

        /// <summary>
        /// Refaktoring Muris Sladić 18613
        /// </summary>

        public void IzvršavanjeKupovinaRefaktor(Štand š, List<Kupovina> kupovine, string sigurnosniKod)
        {
            Štand štand = štandovi.Find(št => št.Prodavač == š.Prodavač);
            if (štand == null)
                throw new ArgumentException("Unijeli ste štand koji nije registrovan!");

            DateTime najranijaKupovina = kupovine[0].DatumKupovine, najkasnijaKupovina = kupovine[0].DatumKupovine;
            double ukupanPromet = 0;

            najkasnijaKupovina = kupovine.OrderByDescending(x => x.DatumKupovine).First().DatumKupovine;
            najranijaKupovina = kupovine.OrderByDescending(x => x.DatumKupovine).Last().DatumKupovine;
            ukupanPromet = kupovine.Sum(x => x.UkupnaCijena);
            kupovine.ForEach(kupovina => štand.RegistrujKupovinu(kupovina));

           štand.Prodavač.RegistrujPromet(sigurnosniKod, ukupanPromet, najranijaKupovina, najkasnijaKupovina);
        }


        public void NaručiProizvode(Štand štand, List<Proizvod> proizvodi, List<int> količine, List<DateTime> rokovi, bool svi = false)
        {
            if (proizvodi.Count != količine.Count || proizvodi.Count != rokovi.Count)
                throw new ArgumentException("Pogrešan unos parametara!");

            for (int i = 0; i < proizvodi.Count; i++)
            {
                if (!svi)
                {
                    Proizvod pr = štand.Proizvodi.Find(p => p.ŠifraProizvoda == proizvodi[i].ŠifraProizvoda);
                    if (pr == null)
                        throw new ArgumentException("Nemoguće naručiti proizvod - nije registrovan na štandu!");

                    pr.NaručiKoličinu(količine[i], rokovi[i]);
                }
                else
                    continue;
            }
        }

        #endregion
    }
}
