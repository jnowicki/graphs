using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    class zadanie21
    {
        // Array reprezentujacy czy wierzcholek o danym numerze byl odwiedzony czy nie.
        bool[] wierzcholki;

        /// <summary>
        /// aktualna sciezka.
        /// </summary>
        Stack sciezka = new Stack();

        Graf graf;

        /// <summary>
        /// Warunek dlugosci cyklu.
        /// </summary>
        int dlugoscMinimalna;

        /// <summary>
        /// Aktualny wierzcholek startowy.
        /// </summary>
        int wierzcholekStartowy;

        /// <summary>
        /// Oznacza czy juz algorytm znalazl jeden ciag.
        /// </summary>
        bool juzZnalazl = false;

        /// <summary>
        /// zmodyfikowany algorytm przeszukiwania w glab ktory zwroci pierwszy cykl grafu ktory znajdzie ktory spelnia wlasnosc
        /// ze jego dlugosc jest wieksza o 1 od jego stopnia minimalnego.
        /// </summary>
        /// <param name="graf">graf wejsciowy</param>
        public void zwrocCykl(Graf graf)
        {
            this.graf = graf;

            if (graf.StopienMinimalny() < 2)
            {
                Console.WriteLine("Stopien grafu za niski.");
                return;
            }

            for (int i = 0; i < graf.LiczbaWierzcholkow; i++)
            {
                wierzcholekStartowy = i;
                przeszukaj(graf);
            }
        }

        /// <summary>
        /// Wlasciwy algorytm.
        /// </summary>
        /// <param name="graf">Graf do przeszukania.</param>
        /// <param name="wierzcholekZaczynajacy">wierzcholek od ktorego zaczynamy.</param>
        private void przeszukaj(Graf graf)
        {
            wierzcholki = new bool[graf.LiczbaWierzcholkow];
            for (int i = 0; i < wierzcholki.Length; i++)
            {
                wierzcholki[i] = false;
            }
            
            dlugoscMinimalna = graf.StopienMinimalny() + 1;

            sciezka.Clear();

            odwiedz(wierzcholekStartowy);

        }

        /// <summary>
        /// funkcja odwiedzajaca wierzcholek, zaznaczajaca go jako "odwiedzony"
        /// </summary>
        /// <param name="wierzcholek">do odwiedzenia</param>
        private void odwiedz(int wierzcholek)
        {

            sciezka.Push(wierzcholek);
            wierzcholki[wierzcholek] = true; // oznacz wierzcholek jako odwiedzony.
            for (int i = 0; i < wierzcholki.Length; i++)
            {
                if (graf.Macierz[wierzcholek, i] == 1) // warunek: wierzcholek jest na liscie sasiedzctwa
                {
                    if (wierzcholki[i] == false) // jezeli nastepny wierzcholek do odwiedzenia byl nieodwiedzony to go odwiedz
                    {
                        odwiedz(i);
                    }
                    else // w przeciwnym wypadku jezeli nastepny wierzcholek do odwiedzenia jest wierzcholkiem startowym i ta sciezka juz ma dlugosc odpowiednia to znalezlismy nasz cykl
                    {
                        if (i == wierzcholekStartowy && sciezka.Count >= dlugoscMinimalna) 
                        {
                            sciezka.Push(i);
                            if (!juzZnalazl)
                            {
                                Console.WriteLine("Szukany cykl:");
                            }
                            object[] enumSciezka = sciezka.ToArray();
                            for (int j = enumSciezka.Length - 1; j >= 0; j--)
                            {
                                Console.Write(enumSciezka[j] + " ");
                            }
                            Console.WriteLine();
                            if (!juzZnalazl)
                            {
                                Console.WriteLine("Przyklady innych takich cyklów:");
                            }
                            sciezka.Pop();
                            juzZnalazl = true;
                        }
                    }
                    
                }
            }
            sciezka.Pop();
        }
    }
}
