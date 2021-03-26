using System;
using System.Text.RegularExpressions;

namespace ChatButlerProjectB
{
    internal class Register
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string CreditCard { get; set; }
        public string Continent { get; set; }
        public string Email { get; set; }
        public string LoginCode { get; set; }

        public void MainReg()
        {
            //Haal voornaam op
            string fname = FirstName();
            //Haal achternaam op
            string lname = LastName();
            //Haal creditcard nummer op
            string CardNumber = CreditCardNumber();
            //Haal continent op
            string continent = ChooseContinent();
            //Haal email op
            string email = GetEmail();
            //Laat de user zijn gegevens checken
            Console.WriteLine($"\nNaam: {fname} {lname}");
            Console.WriteLine($"Creditcard: {CardNumber}");
            Console.WriteLine($"Continent: {continent}");
            Console.WriteLine($"E-mail: {email}");

            Console.WriteLine("Kloppen deze gegevens?");
            string check = Console.ReadLine();
            if(check == "ja" || check == "Ja" || check == "j" || check == "J")
            {
                MakeAccount(fname, lname, CardNumber, continent, email);
                Console.WriteLine("Uw account is gemaakt!");
            }
            //Laat gebruiker fouten aanpassen
            else
            {
                bool FouteGegevens = true;
                while (FouteGegevens)
                {
                    Console.WriteLine("Welke klopt niet?");
                    Console.WriteLine("1: Voornaam\n 2: Achternaam\n 3: Creditcard\n 4: Continent\n 5: e-mail");
                    string foutOnderdeel = Console.ReadLine();
                    while (!Regex.IsMatch(foutOnderdeel, @"^[1-5]+$"))
                    {
                        Console.Write("Dit is geen geldig nummer. Kijk na of u een typefout gemaakt heeft\n");
                        fname = Console.ReadLine();
                    }
                    //Check of foute onderdeel nu wel goed is en vraag of er nog andere fouten onderdelen zijn
                    switch (foutOnderdeel)
                    {
                        case "1":
                            fname = FirstName();
                            Console.WriteLine($"\nNaam: {fname} {lname}");
                            Console.WriteLine($"Creditcard: {CardNumber}");
                            Console.WriteLine($"Continent: {continent}");
                            Console.WriteLine($"E-mail: {email}");
                            Console.Write("Kloppen uw gegevens nu?\n 1: ja 2: nee\n");
                            string gegevens = Console.ReadLine();
                            if (gegevens == "1" || gegevens == "ja")
                            {   
                                FouteGegevens = false;
                            }
                            break;
                        case "2":
                            lname = LastName();
                            Console.WriteLine($"\nNaam: {fname} {lname}");
                            Console.WriteLine($"Creditcard: {CardNumber}");
                            Console.WriteLine($"Continent: {continent}");
                            Console.WriteLine($"E-mail: {email}");
                            Console.Write("Kloppen uw gegevens nu?\n 1: ja 2: nee\n");
                            string gegevens2 = Console.ReadLine();
                            if (gegevens2 == "1" || gegevens2 == "ja")
                            {
                                FouteGegevens = false;
                            }
                            break;
                        case "3":
                            CardNumber = CreditCardNumber();
                            Console.WriteLine($"\nNaam: {fname} {lname}");
                            Console.WriteLine($"Creditcard: {CardNumber}");
                            Console.WriteLine($"Continent: {continent}");
                            Console.WriteLine($"E-mail: {email}");
                            Console.Write("Kloppen uw gegevens nu?\n 1: ja 2: nee\n");
                            string gegevens3 = Console.ReadLine();
                            if (gegevens3 == "1" || gegevens3 == "ja")
                            {
                                FouteGegevens = false;
                            }
                            break;
                        case "4":
                            continent = ChooseContinent();
                            Console.WriteLine($"\nNaam: {fname} {lname}");
                            Console.WriteLine($"Creditcard: {CardNumber}");
                            Console.WriteLine($"Continent: {continent}");
                            Console.WriteLine($"E-mail: {email}");
                            Console.Write("Kloppen uw gegevens nu?\n 1: ja 2: nee\n");
                            string gegevens4 = Console.ReadLine();
                            if (gegevens4 == "1" || gegevens4 == "ja")
                            {
                                FouteGegevens = false;
                            }
                            break;
                        case "5":
                            email = GetEmail();
                            Console.WriteLine($"\nNaam: {fname} {lname}");
                            Console.WriteLine($"Creditcard: {CardNumber}");
                            Console.WriteLine($"Continent: {continent}");
                            Console.WriteLine($"E-mail: {email}");
                            Console.Write("Kloppen uw gegevens nu?\n 1: ja 2: nee\n");
                            string gegevens5 = Console.ReadLine();
                            if (gegevens5 == "1" || gegevens5 == "ja")
                            {
                                FouteGegevens = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("Jason gaat zijn ding doen");
            }
        }
        
        public string FirstName()
        {
            Console.WriteLine("Vul uw voornaam in");
            string fname = Console.ReadLine();
            //Check of fname alleen maar bestaat uit letters. Zo niet vraag opnieuw voor naam
            while(!Regex.IsMatch(fname, @"^[A-Za-z]+$"))
            {
                Console.Write("Dit is geen geldige naam. Kijk na of u een typefout gemaakt heeft\n");
                fname = Console.ReadLine();
            }
            //Maak alle leters lowercase
            string LowerCaseName = fname.ToLower();
            return LowerCaseName;
        }
        public string LastName()
        {
            Console.WriteLine("Vul uw achternaam in");
            string lname = Console.ReadLine();
            //Check of fname alleen maar bestaat uit letters. Zo niet vraag opnieuw voor naam
            while (!Regex.IsMatch(lname, @"^[A-Za-z]+$"))
            {
                Console.Write("Dit is geen geldige naam. Kijk na of u een typefout gemaakt heeft\n");
                lname = Console.ReadLine();
            }
            //Maak alle leters lowercase
            string LowerCaseName = lname.ToLower();
            return LowerCaseName;
        }
        public string CreditCardNumber()
        {
            Console.WriteLine("Vul uw creditcard nummer in");
            string creditnumber = Console.ReadLine();
            //Check of creditnumber alleen bestaat uit nummers
            while (!Regex.IsMatch(creditnumber, @"^[0-9]+$"))
            {
                Console.Write("Dit is geen geldig creditcard nummer. Kijk na of u een typefout gemaakt heeft\n");
                creditnumber = Console.ReadLine();
            }

            return creditnumber;
        }
        public string ChooseContinent()
        {
            Console.WriteLine("In welk continent woont u");
            Console.WriteLine("1: Europa\n 2: Afrika\n 3: Amerika\n 4: Zuid-Amerika\n 5: Azie\n 6: Australie");
            string place = Console.ReadLine();
            //check of place alleen bestaat uit geldige nummers
            while (!Regex.IsMatch(place, @"^[1-6]+$"))
            {
                Console.Write("Dit is geen geldig nummer. Kijk na of u een typefout gemaakt heeft\n");
                place = Console.ReadLine();
            }
            //check welk continent gekozen is en stuur de naam ipv het nummer terug
            switch (place)
            {
                case "1":
                    return "Europa";
                case "2":
                    return "Afrika";
                case "3":
                    return "Amerika";
                case "4":
                    return "Zuid-Amerika";
                case "5":
                    return "Azie";
                case "6":
                    return "Australie";
                default:
                    return "Dit kan niet maar anders blijft hij een error geven";
            }
        }
        public string GetEmail()
        {
            Console.WriteLine("Wat is uw e-mail");
            string mail = Console.ReadLine();
            while (!Regex.IsMatch(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                Console.Write("Dit is geen geldig e-mail. Kijk na of u een typefout gemaakt heeft\n");
                mail = Console.ReadLine();
            }
            return mail;
        }

        public static void MakeAccount(string fname, string lname, string cnumber, string cont, string mail)
        {
            Console.WriteLine("yee");

        }
    }
}