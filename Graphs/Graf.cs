using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    class Graf
    {
        private int[,] macierz;

        public int[,] Macierz
        {
            get { return macierz; }
        }

        public int LiczbaWierzcholkow
        {
            get { return macierz.GetLength(0); }
        }

        public bool CzyJestCyklC3()
        {
            int[,] pomnozona = new int[macierz.GetLength(0), macierz.GetLength(1)];
            for (int row = 0; row < pomnozona.GetLength(0); row++)
            {
                for (int col = 0; col < pomnozona.GetLength(1); col++)
                {
                    int suma = 0;
                    for(int x = 0; x < pomnozona.GetLength(0); x++)
                    {
                        suma += macierz[row, x] * macierz[x, col];
                    }
                    pomnozona[row, col] = suma;
                }
            }
            bool czyJest = false;
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    if (pomnozona[row, col] >= 1 && macierz[row, col] >= 1) czyJest = true;
                }
            }
            return czyJest;
        }

        public Graf()
        {

        }

        public Graf(int liczbaWierzcholkow, List<Tuple<int, int>> krawedzie)
        {
            macierz = new int[liczbaWierzcholkow, liczbaWierzcholkow];
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    macierz[row, col] = 0;
                }
            }

            foreach(Tuple<int,int> krawedz in krawedzie){
                macierz[krawedz.Item1, krawedz.Item2] = 1;
                macierz[krawedz.Item2, krawedz.Item1] = 1;
            }
        }
        
        public void Dodaj(int liczbaWierzcholkow){
            int[,] nowa = new int[macierz.GetLength(0) + liczbaWierzcholkow, macierz.GetLength(1) + liczbaWierzcholkow];
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    nowa[row, col] = macierz[row, col];
                }
            }
            for (int i = 0; i < liczbaWierzcholkow; i++)
            {
                nowa[macierz.GetLength(0) + i, macierz.GetLength(1) + i] = 0;
            }
            macierz = nowa;
        }

        public void Dodaj(Tuple<int, int> krawedz)
        {
            macierz[krawedz.Item1, krawedz.Item2] = 1;
            macierz[krawedz.Item2, krawedz.Item1] = 1;
        }

        public void Usun(int wierzcholek)
        {
            int[,] nowa = new int[macierz.GetLength(0)-1, macierz.GetLength(1)-1];
            for (int row1 = 0, row2 = 0; row1 < macierz.GetLength(0); row1++)
            {
                if (row1 == wierzcholek) continue;
                for (int col1 = 0, col2 = 0; col1 < macierz.GetLength(1); col1++)
                {
                    if (col1 == wierzcholek) continue;
                    nowa[row2, col2] = macierz[row1, col1];
                    col2++;
                    
                }
                row2++;
            }
            macierz = nowa;
        }

        public void Usun(Tuple<int, int> krawedz)
        {
            macierz[krawedz.Item1, krawedz.Item2] = 0;
            macierz[krawedz.Item2, krawedz.Item1] = 0;
        }

        public int Stopien(int wierzcholek)
        {
            int stopien = 0;
            for(int col = 0; col < macierz.GetLength(1); col++){
                stopien += macierz[wierzcholek, col];
            }
            return stopien;
        }

        public int StopienMinimalny()
        {
            int stopienMin = Int32.MaxValue;
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                int stopien = 0;
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    stopien += macierz[row, col];
                }
                if (stopien < stopienMin) stopienMin = stopien;

            }
            return stopienMin;
        }

        public int StopienMaksymalny()
        {
            int stopienMax = 0;
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                int stopien = 0;
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    stopien += macierz[row, col];
                }
                if (stopien > stopienMax) stopienMax = stopien;

            }
            return stopienMax;
        }

        public int IleStopniParzystych()
        {
            int[] stopnie = new int[macierz.GetLength(0)];
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                int stopien = 0;
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    stopien += macierz[row, col];
                }
                stopnie[row] = stopien;

            }
            int stopnieParzyste = 0;
            foreach (int stopien in stopnie)
            {
                if (stopien % 2 == 0) stopnieParzyste++;
            }
            return stopnieParzyste;
        }

        public int IleStopniNieparzystych()
        {
            int[] stopnie = new int[macierz.GetLength(0)];
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                int stopien = 0;
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    stopien += macierz[row, col];
                }
                stopnie[row] = stopien;

            }
            int stopnieNieparzyste = 0;
            foreach (int stopien in stopnie)
            {
                if (stopien % 2 == 1) stopnieNieparzyste++;
            }
            return stopnieNieparzyste;
        }

        public int[] CiagStopni()
        {
            int[] stopnie = new int[macierz.GetLength(0)];
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                int stopien = 0;
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    stopien += macierz[row, col];
                }
                stopnie[row] = stopien;

            }
            return stopnie.OrderBy(x => x).ToArray();
        }

        public int this[int row, int col]
        {
            get { return macierz[row, col]; }
            set { macierz[row, col] = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < macierz.GetLength(0); row++)
            {
                sb.Append("|");
                for (int col = 0; col < macierz.GetLength(1); col++)
                {
                    sb.Append(macierz[row, col] + ", ");
                }
                sb.Append("|\n");
                
            }
            return sb.ToString();
        }
    }
}
