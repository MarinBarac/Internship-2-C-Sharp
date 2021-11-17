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
            while (flag is 0)
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
                    return ispisStanovnistvaOIB(popisStanovnika);
                case 3:
                    ispisImePrezimeOIB(popisStanovnika);
                    break;
                case 4:
                    return unosStanovnika(popisStanovnika);
                case 5:
                    brisanjeOIB(popisStanovnika);
                    break;
                case 6:
                    brisanjeImePrezimeDatum(popisStanovnika);
                    break;
                case 7:
                    brisanjeSvihStanovnika(popisStanovnika);
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


        static string stvoriOIB(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
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

            return oib;
        }
        static string stvoriIme()
        {
            Console.Clear();
            Console.WriteLine("Unesite ime stanovnika: ");
            var name = Console.ReadLine();
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
            return name;
        }
        static string stvoriPrezime()
        {
            Console.Clear();
            Console.WriteLine("Unesite prezime stanovnika:");
            var surname = Console.ReadLine();
            if (surname.Length is 0)
            {
                while (surname.Length is 0)
                {
                    Console.WriteLine("Prezime osobe ne smije biti duzine 0!");
                    Console.WriteLine("Unesite prezime:");
                    surname = Console.ReadLine();
                }
            }
            return surname;
        }
        static int stvoriGodinu()
        {
            Console.Clear();
            Console.WriteLine("Unesite godinu rodenja osobe:");
            var year = int.Parse(Console.ReadLine());
            if (year < (DateTime.Now.Year - 110) || year > DateTime.Now.Year)
            {
                while (year < (DateTime.Now.Year - 110) || year > DateTime.Now.Year )
                {
                    Console.Clear();
                    Console.WriteLine($"Godina rodenja mora biti u intervalu od {DateTime.Now.Year - 110} do {DateTime.Now.Year}!");
                    Console.WriteLine("Unesite godinu rodenja osobe:");
                    year = int.Parse(Console.ReadLine());
                }
            }
            return year;
        }

        static int stvoriMjesec()
        {
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
            return month;
        }

        static int stvoriDan(int year, int month)
        {
            Console.Clear();
            Console.WriteLine("Unesite dan u mjesecu kada se osoba rodila:");
            var day = int.Parse(Console.ReadLine());
            if (month == 2)
            {
                if (year % 4 == 0)
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
                else
                {
                    if (day < 1 || day > 29)
                    {
                        while (day < 1 || day > 29)
                        {
                            Console.Clear();
                            Console.WriteLine("Dan mora biti u intervalu od 1 do 28!");
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
            return day;
        }
        static void ispisOsobe(KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> person)
        {
            Console.WriteLine();
            Console.WriteLine($"OIB osobe: {person.Key}");
            Console.WriteLine($"Ime i prezime osobe: {person.Value.nameAndSurname}");
            Console.WriteLine($"Datum rodenja: {person.Value.dateOfBirth.ToShortDateString()}");
            Console.WriteLine();
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
            if (popisStanovnika.Count() is 0)
            {
                Console.WriteLine("Baza podataka trenutno ne sadrzi niti jednu osobu!");
                goto End;
            }
            foreach (var person in popisStanovnika)
            {
                ispisOsobe(person);
            }
            End:
            Console.WriteLine("-------------------------------------------------------------------------");
            return 0;
        }

        static int uzlazniIspis(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            if (popisStanovnika.Count() is 0)
            {
                Console.WriteLine("Baza podataka trenutno ne sadrzi niti jednu osobu!");
                goto End;
            }
            foreach (var person in popisStanovnika.OrderBy(key => key.Value.dateOfBirth))
            {
                ispisOsobe(person);
            }
            End:
            Console.WriteLine("-------------------------------------------------------------------------");
            return 0;
        }
        static int silazniIspis(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            if (popisStanovnika.Count() is 0)
            {
                Console.WriteLine("Baza podataka trenutno ne sadrzi niti jednu osobu!");
                goto End;
            }
            var sortiraniIspis = from entry in popisStanovnika orderby entry.Value.dateOfBirth descending select entry;
            foreach (var person in sortiraniIspis)
            {
                ispisOsobe(person);
            }
            End:
            Console.WriteLine("-------------------------------------------------------------------------");
            return 0;
        }

        static int ispisStanovnistvaOIB(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika, string oib = null)
        {   
            if(oib is not null)
            {
                goto Start;
            }
            Console.Clear();
            oib = stvoriOIB(popisStanovnika);
            Console.WriteLine(oib);
            if (!popisStanovnika.ContainsKey(oib))
            {
                Console.WriteLine("Osoba s tim OIB-om ne postoji!");
                goto Flag;
            }
            Start:
            var person = pronadiOIB(popisStanovnika, oib);
            Console.Clear();
            ispisOsobe(person);
            Console.WriteLine("--------------------------------------------------------------------------");
            Flag:
            Console.WriteLine("Za povratak u glavni izbornik unesite 1, a za izlaz iz aplikacije unesite 0:");
            var choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    return 0;
                case 0:
                    return 1;
                default:
                    Console.WriteLine("Niste unjeli tocan broj!");
                    goto Flag;
            }
            return 0;
        }

        static int ispisImePrezimeOIB(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {

            var name = stvoriIme();
            var surName = stvoriPrezime();
            
            var year = stvoriGodinu();
            
            
            var month = stvoriMjesec();
            
            var day = stvoriDan(year, month);
            var day_string = day.ToString();
            if (day < 10)
                day_string = '0' + day_string;
            var date = DateTime.ParseExact(month.ToString() + '/' + day_string + '/' + year.ToString(), "M/dd/yyyy", null);

            var count = 0;
            foreach (var person in popisStanovnika)
            {
                if(person.Value.nameAndSurname == (name + " " + surName) && person.Value.dateOfBirth == date)
                {
                    Console.WriteLine($"OIB: {person.Key}");
                    count++;
                }
            }
            if(count is 0)
                Console.WriteLine("Ne postoji osoba s odgovarajucim imenom, prezimenom i datumom rodenja!");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite bilo koju tipku.");
            Console.ReadLine();
            return 0;
        }
        static int unosStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var oib = stvoriOIB(popisStanovnika);
            if (popisStanovnika.ContainsKey(oib))
            {
                Console.WriteLine("Osoba s takvim OIB-om vec postoji!");
                Console.WriteLine("Pritisnite 'enter' za nastavak");
                Console.ReadLine();
                return ispisStanovnistvaOIB(popisStanovnika, oib);
            }
            if(long.Parse(oib) is 0)
            {
                return 0;
            }

            var name = stvoriIme();
            var surname = stvoriPrezime();
            var year = stvoriGodinu();
            var month = stvoriMjesec();

            var day = stvoriDan(year, month);
            var day_string = day.ToString();
            if (day < 10)
                day_string = '0' + day_string;
            
            var date = DateTime.ParseExact(month.ToString() + '/' + day_string + '/' + year.ToString(), "M/dd/yyyy", null);
            popisStanovnika.Add(oib, (name + " " + surname, date));
            return 0;
        }
        static int brisanjeOIB(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var oib = stvoriOIB(popisStanovnika);
            if (popisStanovnika.ContainsKey(oib))
            {
                popisStanovnika.Remove(oib);
                Console.WriteLine("Osoba je izbrisana iz baze podataka!");
            }
            else
                Console.WriteLine("U bazi podataka ne postoji osoba s takvim OIB-om!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite 'enter'!");
            Console.ReadLine();
            return 0;
        }

        static int brisanjeImePrezimeDatum(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var name = stvoriIme();
            var surname = stvoriPrezime();
            var year = stvoriGodinu();
            var month = stvoriMjesec();
            var day = stvoriDan(year, month);
            var day_string = day.ToString();
            if (day < 10)
                day_string = '0' + day_string;

            var nameAndSurname = name + " " + surname;
            var date = DateTime.ParseExact(month.ToString() + '/' + day_string + '/' + year.ToString(), "M/dd/yyyy", null);
            var count = 0;
            foreach (var person in popisStanovnika)
            {
                if (person.Value.nameAndSurname == nameAndSurname && person.Value.dateOfBirth == date)
                    count++;
            }
            if(count > 1)
            {
                Console.WriteLine("Postoji vise osoba s takvim podatcima.");
                Console.WriteLine("Pritisni 'enter' za nastavak!");
                Console.ReadLine();
                return brisanjeOIB(popisStanovnika);
            }
            else
            {
                foreach (var person in popisStanovnika)
                {
                    if (person.Value.nameAndSurname == nameAndSurname && person.Value.dateOfBirth == date)
                    {
                        popisStanovnika.Remove(person.Key);
                        Console.WriteLine("Osoba je uklonjena!");
                        Console.WriteLine("Pritisni 'enter' za nastavak!");
                        Console.ReadLine();
                        return 0;
                    }
                }
            }
            return 0;
        }

        static int brisanjeSvihStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            foreach (var person in popisStanovnika)
            {
                popisStanovnika.Remove(person.Key);
            }
            Console.WriteLine("Svi stanovnici su izbrisani iz baze!");
            return 0;
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

        static KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> pronadiOIB(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika, string oib)
        {
            var result = popisStanovnika.First();
            foreach (var person in popisStanovnika)
            {
                if (person.Key == oib)
                    result = person;
            }
            return result;
        }
    }
}

