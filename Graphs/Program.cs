using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<Tuple<int,int>> krawedzie = new List<Tuple<int,int>>();
            krawedzie.Add(new Tuple<int,int>(0,1));
            krawedzie.Add(new Tuple<int,int>(1,2));
            krawedzie.Add(new Tuple<int,int>(2,0));
            Graf graf = new Graf(3, krawedzie);

            Console.WriteLine(graf);

            graf.Dodaj(2);

            graf.Dodaj(new Tuple<int, int>(3, 2));

            graf.Dodaj(new Tuple<int, int>(3, 1));

            graf.Dodaj(new Tuple<int, int>(4, 3));

            graf.Dodaj(new Tuple<int,int>(4, 0));

            Console.WriteLine(graf);

            Console.WriteLine(graf);

            Console.WriteLine(graf.IleStopniNieparzystych());
            Console.WriteLine(graf.IleStopniParzystych());
            Console.WriteLine(String.Join(",", graf.CiagStopni()));
            Console.ReadKey();
            List<Tuple<int,int>> krawedzie2 = new List<Tuple<int,int>>();
            krawedzie2.Add(new Tuple<int,int>(1, 0));
            krawedzie2.Add(new Tuple<int,int>(2, 0));
            krawedzie2.Add(new Tuple<int, int>(3, 0));
            krawedzie2.Add(new Tuple<int, int>(3, 2));
            krawedzie2.Add(new Tuple<int, int>(3, 1));
            Graf graf2 = new Graf(4, krawedzie2);
            Console.WriteLine(graf2);
            Console.WriteLine(graf2.CzyJestCyklC3());
            List<Tuple<int,int>> krawedzie3 = new List<Tuple<int,int>>();
            krawedzie3.Add(new Tuple<int,int>(1, 0));
            krawedzie3.Add(new Tuple<int,int>(2, 0));
            krawedzie3.Add(new Tuple<int, int>(3, 0));
            Graf graf3 = new Graf(4, krawedzie3);
            Console.WriteLine(graf3);
            Console.WriteLine(graf3.CzyJestCyklC3());
            Console.ReadKey();
             */
            Graf graf = new Graf();
            while(true){
                Console.WriteLine("Stworz graf podajac mu krawedzie - 1\nDodaj krawedz do grafu - 2\nDodaj wierzcholek do grafu - 3\n" +
                    "Usun krawedz z grafu - 4\nUsun wierzcholek z grafu - 5\nWyznacz stopien wierzcholka - 6\nPodaj stopien minimalny - 7\n" +
                    "Podaj stopien maksymalny - 8\nPodaj ile wierzcholkow jest stopnia parzystego - 9\nPodaj ile wierzcholkow jest stopnia nieparzystego - 10\n" +
                    "Wypisz ciag stopni - 11\nNarysuj graf na konsoli - 12\nCzy jest cykl C3? - 13\nZadanie 2.1 - 14");
                string read = Console.ReadLine();
                int conv = Convert.ToInt32(read);
                switch (conv)
                {
                    case 1:
                        Console.WriteLine("Podaj ile wierzcholkow ma miec graf: ");
                        string read1 = Console.ReadLine();
                        int conv1 = Convert.ToInt32(read1);
                        Console.WriteLine("Podaj krawedzie oddzielone znakiem ',' w formie '[nr wierzcholka] [nr wierzcholka]'");
                        read1 = Console.ReadLine();
                        string[] split1 = read1.Split(',');
                        List<Tuple<int, int>> krawedzie1 = new List<Tuple<int, int>>();
                        foreach (string str in split1)
                        {
                            string[] splitTemp = str.Split(' ');
                            krawedzie1.Add(new Tuple<int, int>(Convert.ToInt32(splitTemp[0]), Convert.ToInt32(splitTemp[1])));
                        }
                        graf = new Graf(conv1, krawedzie1);
                        Console.WriteLine(graf);
                        break;
                    case 2:
                        Console.WriteLine("Podaj krawedz do przeczytania w formie '[nr wierzcholka] [nr wierzcholka]'");
                        string read2 = Console.ReadLine();
                        string[] split2 = read2.Split(' ');
                        graf.Dodaj(new Tuple<int,int>(Convert.ToInt32(split2[0]), Convert.ToInt32(split2[1])));
                        Console.WriteLine(graf);
                        break;
                    case 3:
                        Console.WriteLine("Podaj ile wierzcholkow chcesz dodac: ");
                        string read3 = Console.ReadLine();
                        int conv3 = Convert.ToInt32(read3);
                        graf.Dodaj(conv3);
                        Console.WriteLine(graf);
                        break;
                    case 4:
                        Console.WriteLine("Podaj ktora krawedz chcesz usunac: ");
                        string read4 = Console.ReadLine();
                        string[] split4 = read4.Split(' ');
                        graf.Usun(new Tuple<int, int>(Convert.ToInt32(split4[0]), Convert.ToInt32(split4[1])));
                        Console.WriteLine(graf);
                        break;
                    case 5:
                        Console.WriteLine("Podaj ktory wierzcholek chcesz usunac: ");
                        string read5 = Console.ReadLine();
                        int conv5 = Convert.ToInt32(read5);
                        graf.Usun(conv5);
                        Console.WriteLine(graf);
                        break;
                    case 6:
                        Console.WriteLine("Podaj stopien ktorego wierzcholka wyswietlic: ");
                        string read6 = Console.ReadLine();
                        int conv6 = Convert.ToInt32(read6);
                        Console.WriteLine(graf.Stopien(conv6));
                        break;
                    case 7:
                        Console.WriteLine(graf.StopienMinimalny());
                        break;
                    case 8:
                        Console.WriteLine(graf.StopienMaksymalny());
                        break;
                    case 9:
                        Console.WriteLine(graf.IleStopniParzystych());
                        break;
                    case 10:
                        Console.WriteLine(graf.IleStopniNieparzystych());
                        break;
                    case 11:
                        int[] ciag = graf.CiagStopni();
                        StringBuilder sb = new StringBuilder();
                        foreach(int i in ciag){
                            sb.Append(i + " ");
                        }
                        Console.WriteLine(sb.ToString());
                        break;
                    case 12:
                        Console.WriteLine(graf);
                        break;
                    case 13:
                        Console.WriteLine(graf.CzyJestCyklC3());
                        break;
                    case 14:
                        zadanie21 zadanie = new zadanie21();
                        zadanie.zwrocCykl(graf);
                        break;
                }
            }

        }
    }
}
