using System;

namespace FirmaInzynieryjna
{
    public enum Skutecznosc
    {
        SLABY = 1,
        DOBRY = 2,
        WYBITNY = 3
    }

    public class Inzynier
    {
        public string imie;
        public string nazwisko;
        public Skutecznosc skutecznosc;
        public int liczbaProjektow;

        public static int wszystkieProjektyFirmy = 0;
        public static int liczbaInzynierow = 0;
        public static int rekordProjektow = 0;

        public Inzynier(string imie, string nazwisko, Skutecznosc skutecznosc, int liczbaProjektow)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.skutecznosc = skutecznosc;

            if (liczbaProjektow < 0)
            {
                this.liczbaProjektow = 0;
            }
            else
            {
                this.liczbaProjektow = liczbaProjektow;
            }

            wszystkieProjektyFirmy += this.liczbaProjektow;
            liczbaInzynierow++;

            if (this.liczbaProjektow > rekordProjektow)
            {
                rekordProjektow = this.liczbaProjektow;
            }
        }

        public void Buduj()
        {
            Console.WriteLine("Inzynier " + imie + " " + nazwisko + " buduje projekty. Aktualna liczba projektow przed praca: " + liczbaProjektow);

            int wartoscPracy = (int)this.skutecznosc;

            this.liczbaProjektow += wartoscPracy;
            wszystkieProjektyFirmy += wartoscPracy;

            if (this.liczbaProjektow > rekordProjektow)
            {
                rekordProjektow = this.liczbaProjektow;
                Console.WriteLine("[REKORD] Nowy rekord pojedynczego inzyniera wynosi teraz: " + rekordProjektow + " (" + imie + " " + nazwisko + ")");
            }

            this.Awansuj();
        }

        public void Awansuj()
        {
            if (this.liczbaProjektow >= 10 && this.skutecznosc == Skutecznosc.SLABY)
            {
                this.skutecznosc = Skutecznosc.DOBRY;
                Console.WriteLine("[AWANS] " + imie + " " + nazwisko + " awansowal na status DOBRY! (Projekty: " + liczbaProjektow + ")");
            }
            else if (this.liczbaProjektow > 20 && this.skutecznosc == Skutecznosc.DOBRY)
            {
                this.skutecznosc = Skutecznosc.WYBITNY;
                Console.WriteLine("[AWANS] " + imie + " " + nazwisko + " awansowal na status MEGA (Projekty: " + liczbaProjektow + ")");
            }
        }

        public void porownajZ(Inzynier innyInzynier)
        {
            if (this.liczbaProjektow > innyInzynier.liczbaProjektow)
            {
                int roznica = this.liczbaProjektow - innyInzynier.liczbaProjektow;
                Console.WriteLine(this.imie + " " + this.nazwisko + " zrealizowal wiecej zadan niz " + innyInzynier.imie + " " + innyInzynier.nazwisko + " o " + roznica);
            }
            else if (this.liczbaProjektow < innyInzynier.liczbaProjektow)
            {
                int roznica = innyInzynier.liczbaProjektow - this.liczbaProjektow;
                Console.WriteLine(innyInzynier.imie + " " + innyInzynier.nazwisko + " zrealizowal wiecej zadan niz " + this.imie + " " + this.nazwisko + " o " + roznica);
            }
            else
            {
                Console.WriteLine(this.imie + " " + this.nazwisko + " oraz " + innyInzynier.imie + " " + innyInzynier.nazwisko + " zrealizowali tyle samo zadan (" + this.liczbaProjektow + ")");
            }
        }

        public static double sredniaProjektowNaInzyniera()
        {
            if (liczbaInzynierow == 0)
            {
                return 0;
            }
            return (double)wszystkieProjektyFirmy / liczbaInzynierow;
        }

        public void Pokaz()
        {
            Console.WriteLine("Imie: " + imie + " Nazwisko: " + nazwisko + " Zrealizowane projekty: " + liczbaProjektow + " Status: " + skutecznosc);
        }

        public static void PokazGlobalneProjekty()
        {
            Console.WriteLine("Sumaryczna liczba projektow wykonanych przez cala firme: " + wszystkieProjektyFirmy);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inzynier[] zespol = new Inzynier[3];

            zespol[0] = new Inzynier("Maks", "Nowacki", Skutecznosc.SLABY, -3);
            zespol[1] = new Inzynier("Antek", "Nakladek", Skutecznosc.DOBRY, 19);
            zespol[2] = new Inzynier("Piotrek", "Zielony", Skutecznosc.WYBITNY, 0);

            for (int runda = 1; runda <= 3; runda++)
            {
                Console.WriteLine("runda budowania " + runda);

                foreach (Inzynier inz in zespol)
                {
                    inz.Buduj();
                }
                Console.WriteLine();
            }

            Console.WriteLine("stan koncowy");
            foreach (Inzynier inz in zespol)
            {
                inz.Pokaz();
            }
            Console.WriteLine();

            Inzynier.PokazGlobalneProjekty();

            Console.WriteLine("Laczna liczba zatrudnionych inzynierow: " + Inzynier.liczbaInzynierow);
            Console.WriteLine("Srednia liczba projektow na inzyniera: " + Inzynier.sredniaProjektowNaInzyniera());
            Console.WriteLine("Najwyzszy rekord pojedynczego pracownika: " + Inzynier.rekordProjektow);
            Console.WriteLine();

            Console.WriteLine("Rywalizacja i porownanie pracownikow:");
            zespol[0].porownajZ(zespol[1]);
            zespol[1].porownajZ(zespol[2]);

            Console.WriteLine("\nNacisnij Enter zeby wyłaczyc program");
            Console.ReadLine();
        }
    }
}
