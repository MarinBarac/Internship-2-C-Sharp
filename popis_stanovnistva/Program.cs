using System;
using System.Collections.Generic;
using System.Linq;

namespace popis_stanovnistva
{
    class Program
    {
        static void Main(string[] args)
        {
            var popisStanovnika = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            int flag = 0;
            while(flag is 0)
            {
                flag = izbornik(popisStanovnika);
            }
        }
        static int izbornik(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
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
                    return ispisStanovnistva(popisStanovnika);
                case 2:
                    ispisStanovnistvaOIB();
                    break;
                case 3:
                    ispisImePrezimeOIB();
                    break;
                case 4:
                    return unosStanovnika(popisStanovnika);
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
                    break;
            }
            return 0;
        }
        static int ispisStanovnistva(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var flag = 0;
            while(flag is 0)
            {

                Console.WriteLine("1 - Ispis stanovnistva");
                Console.WriteLine("     1 - Onako kako su spremljeni");
                Console.WriteLine("     2 - Po datumu rodenja uzlazno");
                Console.WriteLine("     3 - Po datumu rodenja silazno");
                Console.WriteLine("     4 - Povratak na glavni izbornik");
                Console.WriteLine("Unesite jedan od ponudenih brojeva: ");
                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        flag = obicniIspis(popisStanovnika);
                        break;
                    case 2:
                        flag = uzlazniIspis(popisStanovnika);
                        break;
                    case 3:
                        flag = silazniIspis(popisStanovnika);
                        break;
                    case 4:
                        return 0;
                }
            }
            
            return 0;
        }
        static int obicniIspis(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var index = 1;
            foreach (var person in popisStanovnika)
            {
                Console.WriteLine($"Osoba broj {index}: ");
                Console.WriteLine($"    OIB osobe: {person.Key}");
                Console.WriteLine($"    Ime i prezime osobe: {person.Value.nameAndSurname}");
                Console.WriteLine($"    Datum rodenja: {person.Value.dateOfBirth.ToShortDateString()}");
                Console.WriteLine();
                index++;
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            return 0;
        }

        static int uzlazniIspis(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var index = 1;
            foreach (var person in popisStanovnika.OrderBy(key => key.Value.dateOfBirth))
            {
                Console.WriteLine($"Osoba broj {index}: ");
                Console.WriteLine($"    OIB osobe: {person.Key}");
                Console.WriteLine($"    Ime i prezime osobe: {person.Value.nameAndSurname}");
                Console.WriteLine($"    Datum rodenja: {person.Value.dateOfBirth.ToShortDateString()}");
                Console.WriteLine();
                index++;
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            return 0;
        }
        static int silazniIspis(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var sortiraniIspis = from entry in popisStanovnika orderby entry.Value.dateOfBirth descending select entry;
            var index = 1;
            foreach (var person in sortiraniIspis)
            {
                Console.WriteLine($"Osoba broj {index}: ");
                Console.WriteLine($"    OIB osobe: {person.Key}");
                Console.WriteLine($"    Ime i prezime osobe: {person.Value.nameAndSurname}");
                Console.WriteLine($"    Datum rodenja: {person.Value.dateOfBirth.ToShortDateString()}");
                Console.WriteLine();
                index++;
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            return 0;
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
        static int unosStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            Console.WriteLine("Unesite OIB: ");
            var oib = Console.ReadLine();
            if (oib.Length != 11)
            {
                while (oib.Length != 11)
                {
                    Console.Clear();
                    Console.WriteLine("OIB mora imati 11 znamenki!");
                    Console.WriteLine("Unesite OIB:");
                    oib = Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine("Unesite ime stanovnika: ");
            var name = Console.ReadLine();
            Console.WriteLine("Unesite prezime stanovnika:");
            if (name.Length is 0)
            {
                while (name.Length is 0)
                {
                    Console.Clear();
                    Console.WriteLine("Ime osobe ne smije biti duzine 0!");
                    Console.WriteLine("Unesite ime:");
                    name = Console.ReadLine();
                }
            }
            var surName = Console.ReadLine();
            if (surName.Length is 0)
            {
                while (surName.Length is 0)
                {
                    Console.WriteLine("Prezime osobe ne smije biti duzine 0!");
                    Console.WriteLine("Unesite prezime:");
                    surName = Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine("Unesite godinu rodenja osobe:");
            var year = int.Parse(Console.ReadLine());
            if(year > DateTime.Now.Year)
            {
                while(year > DateTime.Now.Year)
                {
                    Console.Clear();
                    Console.WriteLine("Godina rodenja ne moze biti iza ove godine!");
                    Console.WriteLine("Unesite godinu rodenja osobe:");
                    year = int.Parse(Console.ReadLine());
                }
            }
            Console.Clear();
            Console.WriteLine("Unesite broj mjeseca u kojem se osoba rodila: ");
            var month = int.Parse(Console.ReadLine());
            if (month < 1 || month > 12)
            {
                while (month < 1 || month > 12)
                {
                    Console.Clear();
                    Console.WriteLine("Broj mjeseca mora biti u rasponu od 1 do 12!");
                    Console.WriteLine("Unesite mjesec u kojem se osoba rodila:");
                    month = int.Parse(Console.ReadLine());
                }
            }
            Console.Clear();
            Console.WriteLine("Unesite dan u mjesecu kada se osoba rodila:");
            var day = int.Parse(Console.ReadLine());
            if (month == 2)
            {
                if (year % 4 == 0)
                {
                    if (day < 1 || day > 28)
                    {
                        while (day < 1 || day > 28)
                        {
                            Console.Clear();
                            Console.WriteLine("Dan mora biti u intervalu od 1 do 28!");
                            Console.WriteLine("Unesite dan u mjesecu kada se osoba rodila:");
                            day = int.Parse(Console.ReadLine());
                        }
                    }
                }
                else
                {
                    if (day < 1 || day > 29)
                    {
                        while (day < 1 || day > 29)
                        {
                            Console.Clear();
                            Console.WriteLine("Dan mora biti u intervalu od 1 do 29!");
                            Console.WriteLine("Unesite dan u mjesecu kada se osoba rodila:");
                            day = int.Parse(Console.ReadLine());
                        }
                    }
                }
            }
            if (month % 2 == 0 || month == 9 || month == 11)
            {
                if (day < 1 || day > 30)
                {
                    while (day < 1 || day > 30)
                    {
                        Console.Clear();
                        Console.WriteLine("Dan mora biti u intervalu od 1 do 30!");
                        Console.WriteLine("Unesite dan u mjesecu kada se osoba rodila:");
                        day = int.Parse(Console.ReadLine());
                    }
                }
            }
            if (month % 2 == 1 || month == 10 || month == 12)
            {
                if (day < 1 || day > 31)
                {
                    while (day < 1 || day > 31)
                    {
                        Console.Clear();
                        Console.WriteLine("Dan mora biti u intervalu od 1 do 31!");
                        Console.WriteLine("Unesite dan u mjesecu kada se osoba rodila:");
                        day = int.Parse(Console.ReadLine());
                    }
                }
            }
            var day_string = day.ToString();
            if (day < 10)
                day_string = '0' + day_string;
            
            var date = DateTime.ParseExact(month.ToString() + '/' + day_string + '/' + year.ToString(), "M/dd/yyyy", null);
            popisStanovnika.Add(oib, (name + " " + surName, date));
            return 0;
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

