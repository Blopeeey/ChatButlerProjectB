using System;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace ChatButlerProjectB 
{
    public class ReservationDetails {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Guestcount { get; set; }
        public string Impala { get; set; }
        public string Fish { get; set; }
        public string Vegan { get; set; }
        public string Email { get; set; }

        public ReservationDetails(string Name, string LastName, string Date, string Time, string Guestcount, string Impala, string Fish, string Vegan, string Email) {
            this.Name = Name;
            this.LastName = LastName;
            this.Date = Date;
            this.Time = Time;
            this.Guestcount = Guestcount;
            this.Impala = Impala;
            this.Fish = Fish;
            this.Vegan = Vegan;
            this.Email = Email;
        }
    }

    internal class PlaceReservation {

        public void Reservation()
        {
            Console.WriteLine("Voornaam:");
            string fname = ViableCheckname(Console.ReadLine(),"uw voornaam");

            Console.WriteLine("Achternaam:");
            string lname = ViableCheckname(Console.ReadLine(), "uw achternaam");

            Console.WriteLine("DD/MM/JJJJ");
            string datum = ViableCheckdate(Console.ReadLine(), "de gewenste datum");

            Console.WriteLine("Tijdstip:");
            string tijd = ViableChecktime(Console.ReadLine(), "het gewenste tijdstip");

            Console.WriteLine("Gasten:");
            string gasten = ViableCheckint(Console.ReadLine(), "het aantal gasten");

            Console.WriteLine("Impala:");
            string impala = ViableCheckint(Console.ReadLine(), "het aantal impala");

            Console.WriteLine("Vis:");
            string fish = ViableCheckint(Console.ReadLine(), "het aantal vis");

            Console.WriteLine("Vegetarisch:");
            string vegan = ViableCheckint(Console.ReadLine(), "het aantal vegetarisch");

            Console.WriteLine("E-mail:");
            string email = ViableCheckEmail(Console.ReadLine(), "uw E-mail");

            Console.Clear();

            Console.WriteLine($"Naam: {fname} {lname}");
            Console.WriteLine($"Datum: {datum}");
            Console.WriteLine($"Tijd: {tijd}");
            Console.WriteLine($"Aantal gasten: {gasten}");
            Console.WriteLine($"E-mail: {email}");
            Console.WriteLine($"{impala}x Impala, {fish}x Vis, {vegan} Vegetarisch");
            Console.WriteLine("\nKloppen deze gegevens?");
            string answer = Console.ReadLine().ToLower();

            while (answer != "ja" && answer != "j" && answer != "yes" && answer != "y" && answer != "nee" && answer != "n" && answer != "no" && answer != "n")
            {
                Console.WriteLine("Just yes or no pls");
                answer = Console.ReadLine().ToLower();
            }

            while (answer == "nee" || answer == "n" || answer == "no" || answer == "n")
            {
                Console.WriteLine("Wat klopt er niet? \n 1: Voornaam \n 2: Achternaam \n 3: Datum \n 4: Tijdstip \n 5: Aantal gasten \n 6: Imapala \n 7: Vis \n 8: Vegetarisch \n 9: E-Mail \n");
                answer = Console.ReadLine();
                while (!Regex.IsMatch(answer, @"^[1-9]+$"))
                {
                    Console.Write("dit is geen geldig nummer. kijk na of u een typefout gemaakt heeft\n");
                    answer = Console.ReadLine();
                }

                if (answer == "1") {
                    Console.WriteLine("Voornaam:");
                    fname = ViableCheckname(Console.ReadLine(), "uw voornaam");
                }
                else if (answer == "2") {
                    Console.WriteLine("Achternaam:");
                    lname = ViableCheckname(Console.ReadLine(), "uw achternaam");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("DD/MM/JJJJ");
                    datum = ViableCheckdate(Console.ReadLine(), "de gewenste datum");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Tijdstip:");
                    tijd = ViableChecktime(Console.ReadLine(), "het gewenste tijdstip");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("Gasten:");
                    gasten = ViableCheckint(Console.ReadLine(), "het aantal gasten");
                }
                else if (answer == "6")
                {
                    Console.WriteLine("Impala:");
                    impala = ViableCheckint(Console.ReadLine(), "het aantal impala");
                }
                else if (answer == "7")
                {
                    Console.WriteLine("Vis:");
                    fish = ViableCheckint(Console.ReadLine(), "het aantal vis");
                }
                else if (answer == "8")
                {
                    Console.WriteLine("Vegetarisch:");
                    vegan = ViableCheckint(Console.ReadLine(), "het aantal vegetarisch");
                }
                else if (answer == "9")
                {
                    Console.WriteLine("E-mail:");
                    email = ViableCheckEmail(Console.ReadLine(), "uw E-mail");
                }
                Console.Clear();
                Console.WriteLine("Wat klopt er niet? \n 1: Voornaam \n 2: Achternaam \n 3: Datum \n 4: Tijdstip \n 5: Aantal gasten \n 6: E-mail \n 7: Impala \n 8: Vis \n 9: Vegetarisch \n");
                Console.WriteLine("Klopt alles nu wel?");
                answer = Console.ReadLine();
            }

            if (answer == "ja" || answer == "j" || answer == "yes" || answer == "y")
            {
                SaveReservation(fname, lname, datum, tijd, gasten, impala, fish, vegan, email);
                for (int i = 10; i > 0; i--) {
                    Console.Clear();
                    Console.WriteLine($"Terug naar hoofd menu in {i}\n");
                    Console.WriteLine("Check uw e-mail voor uw reservatie code");
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Clear();
                Program.Main();
            }

        }

        public string ViableCheckname(string text, string waarde)
        {
            string Value = text;
            while (!Regex.IsMatch(Value, @"^[A-Za-z]+$"))
            {
                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in.\n");
                Value = Console.ReadLine();
            }
            string LowerCaseValue = Value.ToLower();
            return LowerCaseValue;
        }

        public string ViableCheckdate(string text, string waarde)
        {
            string Value = text;
            while (!Regex.IsMatch(Value, @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"))
            {
                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in.\n");
                Value = Console.ReadLine();
            }
            string LowerCaseValue = Value.ToLower();
            return LowerCaseValue;
        }

        public string ViableChecktime(string aantal, string waarde)
        {
            string Value = aantal;
            while (!Regex.IsMatch(Value, @"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"))
            {
                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in.\n");
                Value = Console.ReadLine();
            }
            string LowerCaseValue = Value.ToLower();
            return LowerCaseValue;
        }

        public string ViableCheckint(string aantal, string waarde)
        {
            string Value = aantal;
            while (!Regex.IsMatch(Value, @"^[0-9]+$"))
            {
                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in.\n");
                Value = Console.ReadLine();
            }
            string LowerCaseValue = Value.ToLower();
            return LowerCaseValue;
        }

        public string ViableCheckEmail(string Email, string waarde)
        {
            string Value = Email;
            while (!Regex.IsMatch(Value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in.\n");
                Value = Console.ReadLine();
            }
            string LowerCaseValue = Value.ToLower();
            return LowerCaseValue;
        }

        public void SaveReservation(string Voornaam, string Achternaam, string Datum, string Tijdstip, string Gasten, string Impala, string Vis, string Vegetarisch, string email) 
        {
            // Creates a path to current folder (of the exe)
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;

            // Checks if Reservation code is in use
            string ReservationCode = RandomCode();
            bool CodeUsed = File.Exists(appRoot + @$"\{ReservationCode}.json");

            while (CodeUsed) {
                ReservationCode = RandomCode();
                CodeUsed = File.Exists(appRoot + @$"\{ReservationCode}.json");
            }
            
            var filePath = appRoot + @$"\{ReservationCode}.json";

            // stores it in json file
            ReservationDetails temp = new ReservationDetails(Voornaam, Achternaam, Datum, Tijdstip, Gasten, Impala, Vis, Vegetarisch, email);
            string TempJson = JsonSerializer.Serialize(temp, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, TempJson);

            Console.WriteLine(filePath);
        }

        public string RandomCode() {
            Random rnd = new Random();
            string temp = "";
            temp += rnd.Next(0, 9).ToString();
            temp += rnd.Next(0, 9).ToString();
            temp += rnd.Next(0, 9).ToString();
            temp += rnd.Next(0, 9).ToString();
            temp += rnd.Next(0, 9).ToString();
            temp += rnd.Next(0, 9).ToString();

            return temp;
        }
    }

}



