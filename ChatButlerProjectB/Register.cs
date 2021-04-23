using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace ChatButlerProjectB
{

    internal class Register
    {
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
            //Haal random inlogcode op
            string loginCode = GenMemCode();
            //Laat de user zijn gegevens checken
            Console.WriteLine($"\nNaam: {fname} {lname}");
            Console.WriteLine($"Creditcard: {CardNumber}");
            Console.WriteLine($"Continent: {continent}");
            Console.WriteLine($"E-mail: {email}");

            Console.WriteLine("Kloppen deze gegevens?");
            string check = Console.ReadLine();
            if (check == "ja" || check == "Ja" || check == "j" || check == "J")
            {
                MakeAccount(fname, lname, CardNumber, continent, email, loginCode);
                SendEmail(fname, lname, CardNumber, continent, email, loginCode);
                Console.WriteLine("Check uw e-mail voor verificatie en inlog code");
                Program.Main();
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
                            Console.Write("Kloppen uw gegevens nu?\n");
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
                            Console.Write("Kloppen uw gegevens nu?\n");
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
                            Console.Write("Kloppen uw gegevens nu?\n");
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
                            Console.Write("Kloppen uw gegevens nu?\n");
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
                            Console.Write("Kloppen uw gegevens nu?\n");
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
                //Maak account als er geen fouten meer in zitten
                MakeAccount(fname, lname, CardNumber, continent, email, loginCode);
                //Verstuur mail
                SendEmail(fname, lname, CardNumber, continent, email, loginCode);
                Console.WriteLine("Check uw e-mail voor verificatie en inlog code");
                Program.Main();
            }
        }

        public string FirstName()
        {
            Console.WriteLine("Vul uw voornaam in");
            string fname = Console.ReadLine();
            //Check of fname alleen maar bestaat uit letters. Zo niet vraag opnieuw voor naam
            while (!Regex.IsMatch(fname, @"^[A-Za-z]+$"))
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
            while (!Regex.IsMatch(place, @"^[1-6]+$") || place.Length > 1)
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
            //Check of email geldig is
            Console.WriteLine("Wat is uw e-mail");
            string mail = Console.ReadLine();
            while (!Regex.IsMatch(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                Console.Write("Dit is geen geldig e-mail. Kijk na of u een typefout gemaakt heeft\n");
                mail = Console.ReadLine();
            }
            //Haal huidige emails op die in members.json staan
            var getAllMails = @"..\..\..\members.json";
            var readCurrentMails = File.ReadAllText(getAllMails);
            var currentMails = JsonConvert.DeserializeObject<List<MemberDetails>>(readCurrentMails);
            //Check of members.json niet leeg is
            if (currentMails == null)
            {
                return mail;
            }
            //Check of ingevulde email niet al in gebruik is
            foreach (var item in currentMails)
            {
                if(mail == item.Email)
                {
                    Console.Write("Dit e-mail is al in gebruik. Kies een ander\n\n");
                    mail = GetEmail();
                }
            }

            return mail;
        }

        public static void MakeAccount(string fname, string lname, string cnumber, string cont, string mail, string logincode)
        {
            //Lees door members.json heen
            var filePath = @"..\..\..\members.json";
            var readCurrentText = File.ReadAllText(filePath);
            var currentMembers = JsonConvert.DeserializeObject<List<MemberDetails>>(readCurrentText) ?? new List<MemberDetails>();
            //Haal oude gebruikers op en voeg nieuwe gebruiker daar aan
            currentMembers.Add(new MemberDetails()
            {
                Fname = fname,
                Lname = lname,
                CreditCard = cnumber,
                Continent = cont,
                Email = mail,
                Safari = false,
                Trees = 0,
                LoginCode = logincode
            });

            readCurrentText = JsonConvert.SerializeObject(currentMembers, Formatting.Indented);
            File.WriteAllText(filePath, readCurrentText);
        }
        public static void SendEmail(string fname, string lname, string cnumber, string continent, string userMail, string logincode)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("lamouette.noreply@gmail.com", "LaMouette123"),
                EnableSsl = true,
            };

            string body = $"Hallo {fname},\n\n" +
                $"Bedankt voor het maken van uw account.\n" +
                $"De gegevens die u doorgegeven hebt zijn: \n" +
                $"Naam: {fname} {lname}\n" +
                $"Continent: {continent}\n" +
                $"Creditcard: {cnumber[..5]}*****\n\n" +
                $"Om in te loggen kunt u de volgende code gebruiken: {logincode}";

            smtpClient.Send("lamouette.noreply@gmail.com", userMail, "Registreer bevestiging", body);
        }
        private static string GenMemCode()
        {
            string resCode = "", chars = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            int countChar = 0, countNum = 0;
            for (int i = 0; i < 6; i++)
            {
                if ((random.Next(2) == 0 || countNum == 3) && countChar != 3) { resCode += chars[random.Next(26)]; countChar++; }
                else { resCode += random.Next(10); countNum++; }
            }
            return resCode;
        }
    }
}
