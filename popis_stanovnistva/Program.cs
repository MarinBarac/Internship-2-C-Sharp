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
                    return brisanjeOIB(popisStanovnika);
                case 6:
                    return brisanjeImePrezimeDatum(popisStanovnika);
                case 7:
                    return brisanjeSvihStanovnika(popisStanovnika);
                 case 8:
                    return uredivanjeStanovnika(popisStanovnika);
                 case 9:
                    return ispisStatistika(popisStanovnika);
                case 0:
                    return 1;
                default:
                    break;
            }
            return 0;
        }


        static string stvoriOIB()
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
        static string stvoriGodinu()
        {
            Console.Clear();
            Console.WriteLine("Unesite godinu rodenja osobe:");
            var year = Console.ReadLine();
            if (int.Parse(year) < (DateTime.Now.Year - 110) || int.Parse(year) > DateTime.Now.Year)
            {
                while (int.Parse(year) < (DateTime.Now.Year - 110) || int.Parse(year) > DateTime.Now.Year )
                {
                    Console.Clear();
                    Console.WriteLine($"Godina rodenja mora biti u intervalu od {DateTime.Now.Year - 110} do {DateTime.Now.Year}!");
                    Console.WriteLine("Unesite godinu rodenja osobe:");
                    year = Console.ReadLine();
                }
            }
            return year;
        }

        static string stvoriMjesec()
        {
            Console.Clear();
            Console.WriteLine("Unesite broj mjeseca u kojem se osoba rodila: ");
            var month = Console.ReadLine();
            if (int.Parse(month) < 1 || int.Parse(month) > 12)
            {
                while (int.Parse(month) < 1 || int.Parse(month) > 12)
                {
                    Console.Clear();
                    Console.WriteLine("Broj mjeseca mora biti u rasponu od 1 do 12!");
                    Console.WriteLine("Unesite mjesec u kojem se osoba rodila:");
                    month = Console.ReadLine();
                }
            }
            return month;
        }

        static string stvoriDan(string year, string month)
        {
            Console.Clear();
            Console.WriteLine("Unesite dan u mjesecu kada se osoba rodila:");
            var day = int.Parse(Console.ReadLine());
            if (int.Parse(month) == 2)
            {
                if (int.Parse(year) % 4 == 0)
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
            if (int.Parse(month) % 2 == 0 || int.Parse(month) == 9 || int.Parse(month) == 11)
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
            if (int.Parse(month) % 2 == 1 || int.Parse(month) == 10 || int.Parse(month) == 12)
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

            return day_string;
        }

        static DateTime stvoriDatum(string year, string month, string day)
        {
            var date = DateTime.ParseExact(month + '/' + day + '/' + year, "M/dd/yyyy", null);
            return date;
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
                    default:
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
            oib = stvoriOIB();
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
            var date = stvoriDatum(year, month, day);

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
            var oib = stvoriOIB();
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
            
            var date = stvoriDatum(year, month, day);
            popisStanovnika.Add(oib, (name + " " + surname, date));
            return 0;
        }
        static int brisanjeOIB(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var oib = stvoriOIB();
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
            
            var nameAndSurname = name + " " + surname;
            var date = stvoriDatum(year, month, day);
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

        static int uredivanjeStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();

            Console.WriteLine("8 - Uredivanje stanovnika");
            Console.WriteLine("     1 - Uredi OIB stanovnika");
            Console.WriteLine("     2 - Uredi ime i prezime stanovnika");
            Console.WriteLine("     3 - Uredi datum rodenja");
            Console.WriteLine("     4 - Povratak na glavni izbornik");
            Console.WriteLine("Unesite jedan od ponudenih brojeva: ");
            var choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    return urediOibStanovnika(popisStanovnika);
                case 2:
                    return urediImePrezimeStanovnika(popisStanovnika);
                case 3:
                    return urediDatumStanovnika(popisStanovnika);
                case 4:
                    return 0;
                default:
                    Console.WriteLine("Niste unjeli tocan broj!");
                    Console.WriteLine("Pritisnite 'enter' za nastavak!");
                    Console.ReadLine();
                    return uredivanjeStanovnika(popisStanovnika);
            }

            
            return 0;
        }

        static int urediOibStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var oib = stvoriOIB();
            while (popisStanovnika.ContainsKey(oib) is false)
            {
                Console.WriteLine("Uneseni OIB se ne nalazi u bazi podataka. Molimo vas pokusajte ponovno.");
                Console.WriteLine("Za nastavak pritisnite tipku 'enter'.");
                Console.ReadLine();
                oib = stvoriOIB();
            }
            var person = pronadiOIB(popisStanovnika, oib);
            Console.WriteLine("Sada trebate unjeti novi OIB stanovnika!");
            Console.WriteLine("Za nastavak pritisnite tipku 'enter'.");
            Console.ReadLine();
            oib = stvoriOIB();

            while (popisStanovnika.ContainsKey(oib) is true)
            {
                Console.WriteLine("Uneseni OIB se vec nalazi u bazi podataka. Molimo vas pokusajte ponovno.");
                Console.WriteLine("Za nastavak pritisnite tipku 'enter'.");
                Console.ReadLine();
                oib = stvoriOIB();
            }
            popisStanovnika.Remove(person.Key);
            popisStanovnika.Add(oib, (person.Value.nameAndSurname, person.Value.dateOfBirth));


            Console.Clear();
            Console.WriteLine($"Novi OIB je: {oib}.");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'.");
            Console.ReadLine();
            return 0;

        }
        
        static int urediImePrezimeStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var oib = stvoriOIB();
            while (popisStanovnika.ContainsKey(oib) is false)
            {
                Console.WriteLine("Uneseni OIB se ne nalazi u bazi podataka. Molimo vas pokusajte ponovno.");
                Console.WriteLine("Za nastavak pritisnite tipku 'enter'.");
                Console.ReadLine();
                oib = stvoriOIB();
            }
            var person = pronadiOIB(popisStanovnika, oib);
            Console.WriteLine("U sljedecem koraku cete trebati unjeti novo ime i prezime osobe.");
            Console.WriteLine("Za nastavak pritisnite tipku 'enter'.");
            Console.ReadLine();

            var name = stvoriIme();
            var surname = stvoriPrezime();
            popisStanovnika.Remove(person.Key);
            popisStanovnika.Add(person.Key, (name + " " + surname, person.Value.dateOfBirth));

            Console.Clear();
            Console.WriteLine($"Novo ime i prezime je: {name + " " + surname}.");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'.");
            Console.ReadLine();
            return 0;

        }
        static int urediDatumStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            Console.Clear();
            var oib = stvoriOIB();
            while (popisStanovnika.ContainsKey(oib) is false)
            {
                Console.WriteLine("Uneseni OIB se ne nalazi u bazi podataka. Molimo vas pokusajte ponovno.");
                Console.WriteLine("Za nastavak pritisnite tipku 'enter'.");
                Console.ReadLine();
                oib = stvoriOIB();
            }
            var person = pronadiOIB(popisStanovnika, oib);
            Console.WriteLine("U sljedecem koraku cete trebati unjeti novi datum rodenja osobe.");
            Console.WriteLine("Za nastavak pritisnite tipku 'enter'.");
            Console.ReadLine();

            var year = stvoriGodinu();
            var month = stvoriMjesec();
            var day = stvoriDan(year, month);
            var date = stvoriDatum(year, month, day);

            popisStanovnika.Remove(person.Key);
            popisStanovnika.Add(person.Key, (person.Value.nameAndSurname, date));
            Console.Clear();
            Console.WriteLine($"Novi datum rodenja je: {date.ToShortDateString()}.");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'.");
            Console.ReadLine();
            return 0;

        }

        static int ispisStatistika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
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

            switch (choice)
            {
                case 1:
                    return ispisZaposleniNezaposleni(popisStanovnika);
                case 2:
                    return ispisNajcesceIme(popisStanovnika);
                case 3:
                    return ispisNajcescePrezime(popisStanovnika);
                 case 4:
                    return ispisNajcesciDatum(popisStanovnika);
                case 5:
                    return ispisGodisnjaDoba(popisStanovnika);
                case 6:
                    return ispisNajmladegStanovnika(popisStanovnika);
                case 7:
                    return ispisNajstarijegStanovnika(popisStanovnika);
                case 8:
                    return ispisProsjecanBrojGodina(popisStanovnika);
                case 9:
                    return ispisMedijanGodina(popisStanovnika);
                case 0:
                    return 1;
                default:
                    Console.WriteLine("Niste unjeli tocan broj.");
                    Console.WriteLine("Za povratak u glavni izbornik pritisnite 'enter'!");
                    Console.ReadLine();
                    return 0;
            }


            return 0;
        }

        static int ispisZaposleniNezaposleni(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var zaposleni = 0;
            var nezaposleni = 0;
            var svi = 0;

            foreach (var person in popisStanovnika)
            {
                if ((DateTime.Now.Year - person.Value.dateOfBirth.Year) < 24 || (DateTime.Now.Year - person.Value.dateOfBirth.Year) > 64)
                    nezaposleni++;
                else
                    zaposleni++;
                svi++;
            }
            Console.Clear();
            Console.WriteLine($"Zaposleni: {zaposleni}");
            Console.WriteLine($"U bazi podataka je ukupno {svi} osoba.");
            Console.WriteLine($"Udio zaposlenih je: {Math.Round(((double)zaposleni / svi) * 100)}%");
            Console.WriteLine($"Udio nezaposlenih je: {Math.Round(((double)nezaposleni / svi) * 100)}%");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();
            return 0;
        }

        static int ispisNajcesceIme(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var popisImena = new Dictionary<string , int>();
            foreach (var person in popisStanovnika)
            {
                var name = person.Value.nameAndSurname.Substring(0, person.Value.nameAndSurname.IndexOf(' '));
                if (popisImena.ContainsKey(name))
                {
                    for (var i = 0; i < popisImena.Count(); i++)
                    {
                        if (popisImena.ElementAt(i).Key == name)
                        {
                            var count = popisImena.ElementAt(i).Value + 1;
                            popisImena.Remove(popisImena.ElementAt(i).Key);
                            popisImena.Add(name, count);
                        }
                    }
                }
                else
                {
                    popisImena.Add(name, 1);
                }
            }
            var maxCount = 0;
            var maxName = " ";
            foreach (var name in popisImena)
            {
                if (name.Value > maxCount)
                {
                    maxCount = name.Value;
                    maxName = name.Key;
                }
            }
          

            Console.Clear();
            Console.WriteLine($"Najcesce ime je {maxName} i ima ga {maxCount} ljudi.");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();
            return 0;
        }

        static int ispisNajcescePrezime(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var popisPrezimena = new Dictionary<string, int>();
            foreach (var person in popisStanovnika)
            {
                var surname = person.Value.nameAndSurname.Substring(person.Value.nameAndSurname.IndexOf(' ') + 1);
                if (popisPrezimena.ContainsKey(surname))
                {
                    for (var i = 0; i < popisPrezimena.Count(); i++)
                    {
                        if (popisPrezimena.ElementAt(i).Key == surname)
                        {
                            var count = popisPrezimena.ElementAt(i).Value + 1;
                            popisPrezimena.Remove(popisPrezimena.ElementAt(i).Key);
                            popisPrezimena.Add(surname, count);
                        }
                    }
                }
                else
                {
                    popisPrezimena.Add(surname, 1);
                }
            }
            var maxCount = 0;
            var maxSurname = " ";
            foreach (var surname in popisPrezimena)
            {
                if (surname.Value > maxCount)
                {
                    maxCount = surname.Value;
                    maxSurname = surname.Key;
                }
            }

            Console.Clear();
            Console.WriteLine($"Najcesce prezime je {maxSurname} i ima ga {maxCount} ljudi.");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();
            return 0;
        }

        static int ispisNajcesciDatum(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var popisDatuma = new Dictionary<DateTime, int>();
            foreach (var person in popisStanovnika)
            {
                var date = person.Value.dateOfBirth;
                if (popisDatuma.ContainsKey(date))
                {
                    for (var i = 0; i < popisDatuma.Count(); i++)
                    {
                        if (popisDatuma.ElementAt(i).Key == date)
                        {
                            var count = popisDatuma.ElementAt(i).Value + 1;
                            popisDatuma.Remove(date);
                            popisDatuma.Add(date, count);
                        }
                    }
                }

                else
                    popisDatuma.Add(date, 1);
            }

            var maxCount = 0;
            var maxDate = popisDatuma.First().Key;
            foreach (var item in popisDatuma)
            {
                if(item.Value > maxCount)
                {
                    maxCount = item.Value;
                    maxDate = item.Key;
                }
            }
            Console.Clear();
            Console.WriteLine($"Na dan {maxDate.ToShortDateString()} se rodilo {maxCount} ljudi.");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();
            return 0;
        }

        static int ispisGodisnjaDoba(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var godisnjaDoba = new Dictionary<string, int>()
            {
                {"proljece", 0},
                {"ljeto", 0},
                {"jesen", 0},
                {"zima", 0},
            };

            foreach(var person in popisStanovnika)
            {
                var count = 0;
                if(person.Value.dateOfBirth.Month > 3 && person.Value.dateOfBirth.Month < 7)
                {
                    godisnjaDoba.TryGetValue("proljece", out count);
                    count++;
                    godisnjaDoba.Remove("proljece");
                    godisnjaDoba.Add("proljece", count);
                }
                else if (person.Value.dateOfBirth.Month > 6 && person.Value.dateOfBirth.Month < 9)
                {
                    godisnjaDoba.TryGetValue("ljeto", out count);
                    count++;
                    godisnjaDoba.Remove("ljeto");
                    godisnjaDoba.Add("ljeto", count);
                }
                else if (person.Value.dateOfBirth.Month > 8 && person.Value.dateOfBirth.Month < 12)
                {
                    godisnjaDoba.TryGetValue("jesen", out count);
                    count++;
                    godisnjaDoba.Remove("jesen");
                    godisnjaDoba.Add("jesen", count);
                }
                else 
                {
                    godisnjaDoba.TryGetValue("zima", out count);
                    count++;
                    godisnjaDoba.Remove("zima");
                    godisnjaDoba.Add("zima", count);
                }

            }
            var sorted = from entry in godisnjaDoba orderby entry.Value descending select entry;
            Console.Clear();
            foreach (var item in sorted)
            {
                Console.WriteLine($"Broj rodenih na {item.Key}: {item.Value}");
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();
            return 0;
        }

        static int ispisNajmladegStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var najmladi = popisStanovnika.First();
            var datum = popisStanovnika.First().Value.dateOfBirth;
            foreach (var person in popisStanovnika)
            {
                if (person.Value.dateOfBirth > datum)
                {
                    najmladi = person;
                    datum = person.Value.dateOfBirth;
                }
            }

            Console.Clear();
            Console.WriteLine("Najmladi stanovnik je:");
            Console.WriteLine($"OIB: {najmladi.Key}");
            Console.WriteLine($"Ime i prezime: {najmladi.Value.nameAndSurname}");
            Console.WriteLine($"Datum rodenja: {najmladi.Value.dateOfBirth.ToShortDateString()}");

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();

            return 0;
        }
        static int ispisNajstarijegStanovnika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var najstariji = popisStanovnika.First();
            var datum = popisStanovnika.First().Value.dateOfBirth;
            foreach (var person in popisStanovnika)
            {
                if (person.Value.dateOfBirth < datum)
                {
                    najstariji = person;
                    datum = person.Value.dateOfBirth;
                }
            }

            Console.Clear();
            Console.WriteLine("Nastariji stanovnik je:");
            Console.WriteLine($"OIB: {najstariji.Key}");
            Console.WriteLine($"Ime i prezime: {najstariji.Value.nameAndSurname}");
            Console.WriteLine($"Datum rodenja: {najstariji.Value.dateOfBirth.ToShortDateString()}");

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();

            return 0;
        }

        static int ispisProsjecanBrojGodina(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            var sumaGodina = 0;
            var brojOsoba = 0;
            foreach(var person in popisStanovnika)
            {
                sumaGodina += (DateTime.Now.Year - person.Value.dateOfBirth.Year);
                brojOsoba++;
            }

            Console.Clear();
            Console.WriteLine($"Prosjecan broj godina je: {((float)sumaGodina / brojOsoba).ToString("0.00")}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();
            return 0;
        }

        static int ispisMedijanGodina(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> popisStanovnika)
        {
            if(popisStanovnika.Count % 2 != 0)
            {
                var medianPosition = Convert.ToInt32(Math.Round((double)popisStanovnika.Count() / 2));
                var medianValue = DateTime.Now.Year - popisStanovnika.ElementAt(medianPosition).Value.dateOfBirth.Year;
                Console.Clear();
                Console.WriteLine($"Median godina je: {medianValue}");
            }

            else
            {
                int medianPosition = (popisStanovnika.Count() / 2) - 1;
                double medianValue = ((DateTime.Now.Year - popisStanovnika.ElementAt(medianPosition).Value.dateOfBirth.Year) + (DateTime.Now.Year - popisStanovnika.ElementAt(medianPosition + 1).Value.dateOfBirth.Year)) / 2.0f;
                medianValue = Math.Ceiling(medianValue);
                Console.Clear();
                Console.WriteLine($"Median godina je: {medianValue}");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Za povratak u glavni izbornik pritisnite tipku 'enter'!");
            Console.ReadLine();
            return 0;
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

