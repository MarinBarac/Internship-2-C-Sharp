using System;

namespace popis_stanovnistva
{
    class Program
    {
        static void Main(string[] args)
        {
            izbornik();
        }
        static int izbornik()
        {
            Console.Clear();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis stanovnistva");
            Console.WriteLine("2 - Ispis stanovnika po OIB-u");
            Console.WriteLine("3 - Ispis OIB-a po unosu imena i prezimena");
            Console.WriteLine("4 - Unos novog stanovnika");
            Console.WriteLine("5 - Brisanje stanovnika po OIB-u");
            Console.WriteLine("6 - Brisanje stanovnika po imenu i prezimenu te datumu rodenja");
            Console.WriteLine("7 - Brisanje svih stanovnika");
            Console.WriteLine("8 - Uredivanje stanovnika");
            Console.WriteLine("9 - Statistika");
            Console.WriteLine("0 - Izlaz iz aplikacije");

            var choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ispisStanovnistva();
                    break;
                case 2:
                    ispisStanovnistvaOIB();
                    break;
                case 3:
                    ispisImePrezimeOIB();
                    break;
                case 4:
                    unosStanovnika();
                    break;
                case 5:
                    brisanjeOIB();
                    break;
                case 6:
                    brisanjeImePrezimeDatum();
                    break;
                case 7:
                    brisanjeSvihStanovnika();
                    break;
                case 8:
                    uredivanjeStanovnika();
                    break;
                case 9:
                    ispisStatistika();
                    break;
                case 0:
                    return 1;
                default:
                    var flag = 0;
                    while (flag is 0)
                        flag = izbornik();
                    break;
            }
            return 1;
        }
        static int ispisStanovnistva()
        {
            Console.Clear();

            Console.WriteLine("1 - Ispis stanovnistva");
            Console.WriteLine("     1 - Onako kako su spremljeni");
            Console.WriteLine("     2 - Po datumu rodenja uzlazno");
            Console.WriteLine("     3 - Po datumu rodenja silazno");
            Console.WriteLine("     4 - Povratak na glavni izbornik");
            Console.WriteLine("Unesite jedan od ponudenih brojeva: ");
            var choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Vas izbor je: " + choice);
            return 1;
        }

        static int ispisStanovnistvaOIB()
        {
            Console.Clear();

            Console.WriteLine("Ispis stanovnistva po oibu");
            return 1;
        }

        static int ispisImePrezimeOIB()
        {
            Console.Clear();

            Console.WriteLine("Ispis ime prezime oib");
            return 1;
        }
        static int unosStanovnika()
        {
            Console.Clear();

            Console.WriteLine("Unos novog stanovnika");
            return 1;
        }
        static int brisanjeOIB()
        {
            Console.Clear();

            Console.WriteLine("Brisanje stanovnika unosom OIB-a");
            return 1;
        }

        static int brisanjeImePrezimeDatum()
        {
            Console.Clear();

            Console.WriteLine("Brisanje stanovnika po imenu i prezimenu te datumu rodenja (ako ih je vise odabrat po oib-u onog kojeg zelis izbrisati");
            return 1;
        }

        static int brisanjeSvihStanovnika()
        {
            Console.Clear();

            Console.WriteLine("Izbrisani su svi stanovnici");
            return 1;
        }

        static int uredivanjeStanovnika()
        {
            Console.Clear();

            Console.WriteLine("8 - Uredivanje stanovnika");
            Console.WriteLine("     1 - Uredi OIB stanovnika");
            Console.WriteLine("     2 - Uredi ime i prezime stanovnika");
            Console.WriteLine("     3 - Uredi datum rodenja");
            Console.WriteLine("     4 - Povratak na glavni izbornik");
            Console.WriteLine("Unesite jedan od ponudenih brojeva: ");
            var choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Vas izbor je: " + choice);
            return 1;
        }

        static int ispisStatistika()
        {
            Console.Clear();

            Console.WriteLine("9 - Statistika");
            Console.WriteLine("     1 - Postotak nezaposlenih i postotak zaposlenih");
            Console.WriteLine("     2 - Ispis najcesceg imena i koliko ga stanovnika ima");
            Console.WriteLine("     3 - Ispis najcesceg prezimena i koliko ga stanovnika ima");
            Console.WriteLine("     4 - Ispis datum na koji je roden najveci broj ljudi i koji je to datum");
            Console.WriteLine("     5 - Ispis broja ljudi rodenih u svakom od godisnjih doba");
            Console.WriteLine("     6 - Ispis najmladeg stanovnika");
            Console.WriteLine("     7 - Ispis najstarijeg stanovnika");
            Console.WriteLine("     8 - Prosjecan broj godina");
            Console.WriteLine("     9 - Medijan godina");
            Console.WriteLine("     0 - izlaz iz aplikacije");
            var choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Vas izbor je: " + choice);
            return 1;
        }
    }
}

