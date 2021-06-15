using System;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
//using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace ChatButlerProjectB
{
    public class ReservationDetails
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Guestcount { get; set; }
        public string Impala { get; set; }
        public string Fish { get; set; }
        public string Vegan { get; set; }
        public string Email { get; set; }
        public string ReservationCode { get; set; }
        public string UserCode { get; set; }
        public string Calorieën { get; set; }
        public string Allergieën { get; set; }
        public string Booking { get; set; }
        public string CreationDate { get; set; }

        public ReservationDetails() {/* parameterless constructor is needed to deserialze with text.json */ }

        public ReservationDetails(string ReservationCode, string UserCode, string Name, string LastName, string Date, string Time, string Guestcount, string Impala, string Fish, string Vegan, string Cal, string All, string Email, string Booking)
        {
            this.ReservationCode = ReservationCode;
            this.UserCode = UserCode;
            this.Name = Name;
            this.LastName = LastName;
            this.Date = Date;
            this.Time = Time;
            this.Guestcount = Guestcount;
            this.Impala = Impala;
            this.Fish = Fish;
            this.Vegan = Vegan;
            this.Email = Email;
            this.Calorieën = Cal;
            this.Allergieën = All;
            this.Booking = Booking;
            this.CreationDate = DateTime.Today.ToShortTimeString();
        }
    }

    public class tableReservationDetails
    {
        public string Date { get; set; }
        public Dictionary<string, string> Time { get; set; }


        public tableReservationDetails() {/* parameterless constructor is needed to deserialze with text.json */ }

        public tableReservationDetails(string date)
        {
            this.Date = date;
            this.Time = new Dictionary<string, string>() {
                { "00",""},
                { "01",""},
                { "02",""},
                { "03",""},
                { "04",""},
                { "05",""},
                { "06",""},
                { "07",""},
                { "08",""},
                { "09",""},
                { "10",""},
                { "11",""},
                { "12",""},
                { "13",""},
                { "14",""},
                { "15",""},
                { "16",""},
                { "17",""},
                { "18",""},
                { "19",""},
                { "20",""},
                { "21",""},
                { "22",""},
                { "23",""}
            };
        }

    }
    internal class PlaceReservation
    {

        public void Reservation()
        {
            Butler winston = new Butler();
            Console.Clear();

            if (GetUserCode() == "000000")
            {
                for (int i = 5; i > 0; i--)
                {
                    Console.Clear();
                    Console.WriteLine("Log a.u.b eerst in.");
                    Console.WriteLine($"Terug naar hoofd menu in {i}\n");
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Clear();
                Program.Main();
            }

            string fname = ""; string lname = ""; string datum = ""; string tijd = ""; string table = ""; string gasten = ""; string impala = ""; string fish = ""; string vegan = ""; string allergieën = ""; string calorieën = ""; string email = "";
            int step = 0;

            while (step < 12)
            {
                if (step == 0)
                {
                    Console.WriteLine("Type \"esc\", \"back\" of \"terug\" om terug te gaan.");
                    Console.WriteLine("Voornaam:");
                    winston.Log(1, "Voornaam:");
                    fname = ViableCheckname(Console.ReadLine(), "uw voornaam");
                    winston.Log(2, $"Invoer: {fname}");
                    if (fname.ToLower() == "esc" || fname.ToLower() == "back" || fname.ToLower() == "terug")
                    {
                        Console.Clear();
                        Program.Main();
                    }
                    step = 1;
                }

                if (step == 1)
                {
                    Console.WriteLine("\nAchternaam:");
                    winston.Log(1, "Achternaam:");
                    lname = ViableCheckname(Console.ReadLine(), "uw achternaam");
                    winston.Log(2, $"Invoer: {lname}");
                    if (lname.ToLower() == "esc" || lname.ToLower() == "back" || lname.ToLower() == "terug")
                    {
                        step = 0;
                    }
                    else
                    {
                        step = 2;
                    }
                }

                if (step == 2)
                {
                    Console.WriteLine("\nDe gewenste datum: (DD/MM/JJJJ)");
                    winston.Log(1, "De gewenste datum:");
                    datum = ViableCheckdate(Console.ReadLine(), "de gewenste datum");
                    winston.Log(2, $"Invoer: {datum}");
                    if (datum.ToLower() == "esc" || datum.ToLower() == "back" || datum.ToLower() == "terug")
                    {
                        step = 1;
                    }
                    else
                    {
                        step = 3;
                    }
                }

                if (step == 3)
                {
                    Console.WriteLine("\nEen reservatie is voor twee uur. De tijd wordt omlaag afgerond naar een heel uur. \nVoer de aankomsttijd in: (xx:xx)");
                    winston.Log(1, "Het gewenste tijdstip:");
                    tijd = ViableChecktime(Console.ReadLine(), "het gewenste tijdstip");
                    winston.Log(2, $"Invoer: {tijd}");
                    if (tijd.ToLower() == "esc" || tijd.ToLower() == "back" || tijd.ToLower() == "terug")
                    {
                        step = 2;
                    }
                    else
                    {
                        step = tableOverview(datum, tijd);
                    }
                }

                if (step == 4)
                {
                    Console.WriteLine("\nMaximaal zes gasten kunnen aan een tafel \nSelecteer a.u.b. de gewenste tafel: \n");
                    winston.Log(1, "De gewenste tafel:");
                    table = ViableCheckint(Console.ReadLine(), "de gewenste tafel");
                    winston.Log(2, $"Invoer: {table}");
                    if (table.ToLower() == "esc" || table.ToLower() == "back" || table.ToLower() == "terug")
                    {
                        step = 3;
                    }
                    else if (tableCheck(datum, tijd, table))
                    {
                        step = 5;
                    }
                }

                if (step == 5)
                {
                    Console.WriteLine("\nTotaal aantal gasten: (inclusief u zelf)");
                    winston.Log(1, "Het aantal gasten:");
                    gasten = ViableCheckint(Console.ReadLine(), "het aantal gasten");
                    winston.Log(2, $"Invoer: {gasten}");
                    if (gasten.ToLower() == "esc" || gasten.ToLower() == "back" || gasten.ToLower() == "terug")
                    {
                        step = 4;
                    }
                    else
                    {
                        step = 6;
                    }
                }

                if (step == 6)
                {
                    Console.WriteLine("\nTotaal aantal impala:");
                    winston.Log(1, "Aantal Impala:");
                    impala = ViableCheckint(Console.ReadLine(), "het aantal impala");
                    winston.Log(2, $"Invoer: {impala}");
                    if (impala.ToLower() == "esc" || impala.ToLower() == "back" || impala.ToLower() == "terug")
                    {
                        step = 5;
                    }
                    else
                    {
                        step = 7;
                    }
                }

                if (step == 7)
                {
                    Console.WriteLine("\nTotaal aantal vis:");
                    winston.Log(1, "Aantal vis:");
                    fish = ViableCheckint(Console.ReadLine(), "het aantal vis");
                    winston.Log(2, $"Invoer: {fish}");
                    if (fish.ToLower() == "esc" || fish.ToLower() == "back" || fish.ToLower() == "terug")
                    {
                        step = 6;
                    }
                    else
                    {
                        step = 8;
                    }

                }

                if (step == 8)
                {
                    Console.WriteLine("\nTotaal aantal vegetarisch:");
                    winston.Log(1, "Aantal vegetarisch:");
                    vegan = ViableCheckint(Console.ReadLine(), "het aantal vegetarisch");
                    winston.Log(2, $"Invoer: {vegan}");
                    if (vegan.ToLower() == "esc" || vegan.ToLower() == "back" || vegan.ToLower() == "terug")
                    {
                        step = 7;
                    }
                    else
                    {
                        step = 9;
                    }
                }

                if (step == 9)
                {
                    Console.WriteLine("\nGewenste calorieën per persoon: (Dit veld is niet verplicht)");
                    winston.Log(1, "Gewenste calorieën per persoon: (Dit veld is niet verplicht)");
                    calorieën = Console.ReadLine();
                    winston.Log(2, $"Invoer: {calorieën}");
                    if (calorieën.ToLower() == "esc" || calorieën.ToLower() == "back" || calorieën.ToLower() == "terug")
                    {
                        step = 8;
                    }
                    else
                    {
                        step = 10;
                    }
                }

                if (step == 10)
                {
                    Console.WriteLine("\nAllergieën: (Dit veld is niet verplicht)");
                    winston.Log(1, "Allergieën: (Dit veld is niet verplicht)");
                    allergieën = Console.ReadLine();
                    winston.Log(2, $"Invoer: {allergieën}");
                    if (allergieën.ToLower() == "esc" || allergieën.ToLower() == "back" || allergieën.ToLower() == "terug")
                    {
                        step = 9;
                    }
                    else
                    {
                        step = 11;
                    }
                }

                if (step == 11)
                {
                    Console.WriteLine("\nE-mail address:");
                    winston.Log(1, "E-mail:");
                    email = ViableCheckEmail(Console.ReadLine(), "uw E-mail");
                    winston.Log(2, $"Invoer: {email}");
                    if (email.ToLower() == "esc" || email.ToLower() == "back" || email.ToLower() == "terug")
                    {
                        step = 10;
                    }
                    else
                    {
                        step = 12;
                    }
                }
            }

            Console.Clear();

            Console.WriteLine($"Naam: {fname} {lname}");
            Console.WriteLine($"Datum: {datum}");
            Console.WriteLine($"Tijd: {tijd}");
            Console.WriteLine($"Aantal gasten: {gasten}");
            Console.WriteLine($"E-mail: {email}");
            Console.WriteLine($"Calorieën per persoon: {calorieën}");
            Console.WriteLine($"Allergieën: {allergieën}");
            Console.WriteLine($"{impala}x Impala, {fish}x Vis, {vegan} Vegetarisch");
            Console.WriteLine("\nKloppen deze gegevens? 'ja' of 'nee' alstublieft");
            winston.Log(1, "Kloppen deze gegevens? 'ja' of 'nee' alstublieft");
            string answer = Console.ReadLine().ToLower();
            winston.Log(2, $"Invoer: {answer}");

            while (answer != "ja" && answer != "j" && answer != "yes" && answer != "y" && answer != "nee" && answer != "n" && answer != "no" && answer != "n")
            {
                Console.WriteLine("Alleen 'ja' of 'nee' alstublieft");
                answer = Console.ReadLine().ToLower();
            }

            while (answer == "nee" || answer == "n" || answer == "no" || answer == "n")
            {
                Console.WriteLine($"Wat klopt er niet:\n1:  Voornaam: {fname} \n2:  Achternaam: {lname}\n3:  Datum: {datum} \n4:  Tijdstip: {tijd} \n5:  Aantal gasten: {gasten} \n6:  Impala: {impala}\n7:  Vis: {fish}\n8:  Vegetarisch: {vegan} \n9:  Calorieën: {calorieën}\n10: Allergieën: {allergieën}\n11: E-Mail: {email} \n> Kies het nummer dat u wilt wijzigen.");
                winston.Log(1, "Wat klopt er niet");
                answer = Console.ReadLine();
                while (!Regex.IsMatch(answer, @"([0-9]|1[0-1])$"))
                {
                    Console.Write("dit is geen geldig nummer. kijk na of u een typefout gemaakt heeft\n");
                    answer = Console.ReadLine();
                }

                winston.Log(2, $"Invoer: {answer}");
                if (answer == "1")
                {
                    Console.WriteLine("Voornaam:");
                    winston.Log(1, "Voornaam:");
                    fname = ViableCheckname(Console.ReadLine(), "uw voornaam");
                    winston.Log(2, $"Invoer: {fname}");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Achternaam:");
                    winston.Log(1, "Achternaam:");
                    lname = ViableCheckname(Console.ReadLine(), "uw achternaam");
                    winston.Log(2, $"Invoer: {lname}");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("DD/MM/JJJJ");
                    winston.Log(1, "Datum:");
                    datum = ViableCheckdate(Console.ReadLine(), "de gewenste datum");
                    winston.Log(2, $"Invoer: {datum}");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Tijdstip:");
                    winston.Log(1, "Tijdstip:");
                    tijd = ViableChecktime(Console.ReadLine(), "het gewenste tijdstip");
                    winston.Log(2, $"Invoer: {tijd}");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("Gasten:");
                    winston.Log(1, "Gasten:");
                    gasten = ViableCheckint(Console.ReadLine(), "het aantal gasten");
                    winston.Log(2, $"Invoer: {gasten}");
                }
                else if (answer == "6")
                {
                    Console.WriteLine("Impala:");
                    winston.Log(1, "Impala:");
                    impala = ViableCheckint(Console.ReadLine(), "het aantal impala");
                    winston.Log(2, $"Invoer: {impala}");
                }
                else if (answer == "7")
                {
                    Console.WriteLine("Vis:");
                    winston.Log(1, "Vis:");
                    fish = ViableCheckint(Console.ReadLine(), "het aantal vis");
                    winston.Log(2, $"Invoer: {fish}");
                }
                else if (answer == "8")
                {
                    Console.WriteLine("Vegetarisch:");
                    winston.Log(1, "Vegetarisch:");
                    vegan = ViableCheckint(Console.ReadLine(), "het aantal vegetarisch");
                    winston.Log(2, $"Invoer: {vegan}");
                }
                else if (answer == "9")
                {
                    Console.WriteLine("Calorieën:");
                    winston.Log(1, "Calorieën:");
                    calorieën = Console.ReadLine();
                    winston.Log(2, $"Invoer: {calorieën}");
                }
                else if (answer == "10")
                {
                    Console.WriteLine("Allergieën:");
                    winston.Log(1, "Allergieën:");
                    allergieën = Console.ReadLine();
                    winston.Log(2, $"Invoer: {allergieën}");
                }
                else if (answer == "11")
                {
                    Console.WriteLine("E-mail:");
                    winston.Log(1, "E-mail:");
                    email = ViableCheckEmail(Console.ReadLine(), "uw E-mail");
                    winston.Log(2, $"Invoer: {email}");
                }
                Console.Clear();
                Console.WriteLine($"1:  Voornaam: {fname} \n2:  Achternaam: {lname}\n3:  Datum: {datum} \n4:  Tijdstip: {tijd} \n5:  Aantal gasten: {gasten} \n6:  Impala: {impala}\n7:  Vis: {fish}\n8:  Vegetarisch: {vegan} \n9:  Calorieën: {calorieën}\n10: Allergieën: {allergieën}\n11: E-Mail: {email} \n");
                Console.WriteLine("Klopt alles nu wel?");
                winston.Log(1, "Klopt alles nu wel:");
                answer = Console.ReadLine();
                winston.Log(2, $"Invoer: {answer}");
            }

            if (answer == "ja" || answer == "j" || answer == "yes" || answer == "y")
            {
                if (Int32.Parse(impala) >= 3)
                {
                    Console.WriteLine("Wilt u zelf de impala schieten?");
                    winston.Log(1, "Wilt u zelf de impala schieten:");
                    string shootyshoot = Console.ReadLine();
                    while (shootyshoot != "ja" && shootyshoot != "j" && shootyshoot != "yes" && shootyshoot != "y" && shootyshoot != "nee" && shootyshoot != "n" && shootyshoot != "no" && shootyshoot != "n")
                    {
                        Console.WriteLine("voer alleen 'ja' of 'nee' in alstublieft");
                        shootyshoot = Console.ReadLine().ToLower();
                    }
                    winston.Log(2, $"Invoer: {shootyshoot}");
                }

                Console.WriteLine("Wilt u het restaurant uw hotel en vliegticket laten boeken?");
                winston.Log(1, "Wilt u het restaurant uw hotel en vliegticket laten boeken?");
                string Booking = Console.ReadLine().ToLower();
                while (Booking != "ja" && Booking != "j" && Booking != "yes" && Booking != "y" && Booking != "nee" && Booking != "n" && Booking != "no" && Booking != "n")
                {
                    Console.WriteLine("Voer alleen 'ja' of 'nee' in alstublieft");
                    Booking = Console.ReadLine().ToLower();
                }
                winston.Log(2, $"Invoer: {Booking}");

                string code = SaveReservation(GetUserCode(), fname, lname, datum, tijd, gasten, impala, fish, vegan, calorieën, allergieën, email, Booking);

                winston.Log(1, $"Usercode: {GetUserCode()}");
                winston.Log(1, $"Reservatie code: {code}");
                winston.Log(1, $"Voornaam: {fname}");
                winston.Log(1, $"Achternaam: {lname}");
                winston.Log(1, $"Datum: {datum}");
                winston.Log(1, $"Tijd: {tijd}");
                winston.Log(1, $"Gasten: {gasten}");
                winston.Log(1, $"Impala: {impala}");
                winston.Log(1, $"Vis: {fish}");
                winston.Log(1, $"Veganistisch: {vegan}");
                winston.Log(1, $"Calorieën: {calorieën}");
                winston.Log(1, $"Allergieën: {allergieën}");
                winston.Log(1, $"E-mail: {email}");
                winston.Log(1, $"Restaurant boekt hotel en vlucht: {Booking}");

                SendEmail(code, GetUserCode(), fname, lname, datum, tijd, gasten, table, impala, fish, vegan, email);
                for (int i = 10; i > 0; i--)
                {
                    Console.Clear();
                    Console.WriteLine($"Terug naar hoofd menu in {i}\n");
                    Console.WriteLine("Controleer uw e-mail voor uw reservatie code");
                    System.Threading.Thread.Sleep(1000);
                }
                winston.Log(1, $"Terug naar hoofd menu...");
                Console.Clear();
                Program.Main();
            }

        }

        public string ViableCheckname(string text, string waarde)
        {
            string Value = text;
            while (!Regex.IsMatch(Value, @"^[A-Za-z]+$") && !(Value.ToLower() == "esc") && !(Value.ToLower() == "back") && !(Value.ToLower() == "terug"))
            {
                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in zonder spaties.\n");
                Value = Console.ReadLine();
            }
            string LowerCaseValue = Value.ToLower();
            return LowerCaseValue;
        }

        public string ViableCheckdate(string text, string waarde)
        {
            string Value = text;
            // !Regex.IsMatch(Value, @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$")
            // ^ Original regex for date copy pasted from internet. place back if underlying code doesnt work.
            while (!Regex.IsMatch(Value, @"(((0|1|2)[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$") && !Regex.IsMatch(Value, @"(((0|1|2)[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$") && !(Value.ToLower() == "esc") && !(Value.ToLower() == "back") && !(Value.ToLower() == "terug"))
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
            while (!Regex.IsMatch(Value, @"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$") && !(Value.ToLower() == "esc") && !(Value.ToLower() == "back") && !(Value.ToLower() == "terug"))
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
            while (!Regex.IsMatch(Value, @"^[0-9]+$") && !(Value.ToLower() == "esc") && !(Value.ToLower() == "back") && !(Value.ToLower() == "terug"))
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
            while (!Regex.IsMatch(Value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") && !(Value.ToLower() == "esc") && !(Value.ToLower() == "back") && !(Value.ToLower() == "terug"))
            {
                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in.\n");
                Value = Console.ReadLine();
            }
            string LowerCaseValue = Value.ToLower();
            return LowerCaseValue;
        }

        public string SaveReservation(string UserCode, string Firstname, string Lastname, string Datum, string Tijdstip, string Gasten, string Impala, string Vis, string Vegetarisch, string Calorieën, string Allergieën, string Email, string Booking)
        {
            // Creates a path to current folder (of the exe)
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;

            var filePath = @"../../../Reservations.json";
            var readCurrentText = File.ReadAllText(filePath);
            var currentReservation = JsonSerializer.Deserialize<List<ReservationDetails>>(readCurrentText);

            string ReservationCode = RandomCode();

            bool CodeUsed = true;

            // Checks if Reservation code is in use
            while (CodeUsed)
            {
                CodeUsed = false;
                foreach (var item in currentReservation)
                {
                    if (item.ReservationCode == ReservationCode)
                    {
                        CodeUsed = true;
                        ReservationCode = RandomCode();
                    }
                }
            }

            //bool CodeUsed = File.Exists(appRoot + @$"\{ReservationCode}.json");

            //while (CodeUsed) {
            //    ReservationCode = RandomCode();
            //    CodeUsed = File.Exists(appRoot + @$"\{ReservationCode}.json");
            //}

            //var filePath = appRoot + @$"\{ReservationCode}.json";

            // read json file

            //var filePath = @"..\..\..\Reservations.json";
            //var readCurrentText = File.ReadAllText(filePath);
            //var currentReservation = JsonSerializer.Deserialize<List<ReservationDetails>>(readCurrentText);


            //Adds reservation to Json
            currentReservation.Add(new ReservationDetails(ReservationCode, UserCode, Firstname, Lastname, Datum, Tijdstip, Gasten, Impala, Vis, Vegetarisch, Calorieën, Allergieën, Email, Booking));

            readCurrentText = JsonSerializer.Serialize(currentReservation, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, readCurrentText);
            //Console.WriteLine(filePath);
            // stores it in json file
            //ReservationDetails temp = new ReservationDetails(Voornaam, Achternaam, Datum, Tijdstip, Gasten, Impala, Vis, Vegetarisch, email);

            //currentReservation.Add(temp);


            //string TempJson = JsonSerializer.Serialize(temp, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText(filePath, TempJson);
            return ReservationCode;

        }

        public string RandomCode()
        {
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

        public int tableOverview(string datum, string tijdstip)
        {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            var filePath = appRoot + @$"\TableReservations.json";

            // creates file if it doesnt exist
            if (!File.Exists(filePath))
            {
                var Filecreation = File.Create(filePath);
                Filecreation.Close();
            }
            var readTableReservations = File.ReadAllText(filePath);

            // adds an entry to the json file of its empty
            if (readTableReservations == "")
            {
                // creates list
                tableReservationDetails newEntry = new tableReservationDetails(datum);
                List<tableReservationDetails> newEntryList = new List<tableReservationDetails>();
                newEntryList.Add(newEntry);

                // stores list in json
                string newEntryJson = JsonSerializer.Serialize(newEntryList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, newEntryJson);
            }

            readTableReservations = File.ReadAllText(filePath);
            List<tableReservationDetails> TempJson = JsonSerializer.Deserialize<List<tableReservationDetails>>(readTableReservations);

            string timeKey = "";
            if (tijdstip.Substring(1, 1) == ":")
            {
                timeKey = "0" + tijdstip.Substring(0, 1);
            }
            else
            {
                timeKey = tijdstip.Substring(0, 2);
            }
            string timeKey2 = "" + (Convert.ToInt32(timeKey) + 1);
            if (timeKey2.Length == 1)
            {
                timeKey2 = "0" + timeKey2;
            }
            if (Convert.ToInt32(timeKey2) > 23)
            {
                timeKey2 = "00";
            }

            bool dateExist = false;
            bool place1 = false;
            bool place2 = false;
            bool place3 = false;
            bool place4 = false;
            bool place5 = false;

            // looks for the desired date. if found, it look to see what tables are taken
            foreach (var date in TempJson)
            {
                if (date.Date == datum)
                {
                    dateExist = true;
                    if (date.Time[timeKey].Contains("1") || date.Time[timeKey2].Contains("1"))
                    {
                        place1 = true;
                    }
                    if (date.Time[timeKey].Contains("2") || date.Time[timeKey2].Contains("2"))
                    {
                        place2 = true;
                    }
                    if (date.Time[timeKey].Contains("3") || date.Time[timeKey2].Contains("3"))
                    {
                        place3 = true;
                    }
                    if (date.Time[timeKey].Contains("4") || date.Time[timeKey2].Contains("4"))
                    {
                        place4 = true;
                    }
                    if (date.Time[timeKey].Contains("5") || date.Time[timeKey2].Contains("5"))
                    {
                        place5 = true;
                    }

                    // check if tables available 
                    if (place1 && place2 && place3 && place4 && place5)
                    {
                        Console.WriteLine("\nSorry maar er zijn geen tafels beschikbaar op tid tijdstip.\nKies alstublieft een ander tijdstip: (xx:xx)");
                        return 3;
                    }
                }
            }

            // make new date entry in json file if it doesnt exist already
            if (!dateExist)
            {
                tableReservationDetails newEntry = new tableReservationDetails(datum);
                TempJson.Add(newEntry);
                string newEntryJson = JsonSerializer.Serialize(TempJson, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, newEntryJson);
            }


            // check json file for date and time to see what tables are taken
            // if date doesnt exist in json file. create it
            // return overview of tables depending on whats taken
            string map = "";

            map += "\n        ____         ____     \n";
            map += "  _____/    \\_______/    \\____\n";

            if (!place1) { map += " /        1            "; }
            else { map += " /                     "; }
            if (!place2) { map += "2     |\n"; }
            else { map += "      |\n"; }

            map += "/                            |\n";

            if (!place3) { map += "|               3            |\n"; }
            else { map += "|                            |\n"; }

            if (!place4) { map += "|    4                  "; }
            else { map += "|                       "; }
            if (!place5) { map += "5    |\n"; }
            else { map += "     |\n"; }

            map += "|                            |\n";
            map += "|          ----------------- |\n";
            map += "|_________/__________________|\n";

            Console.WriteLine(map);

            //Console.WriteLine("        ____         ____     ");
            //Console.WriteLine("  _____/    \\_______/    \\____");
            //Console.WriteLine(" /        1            2     |");
            //Console.WriteLine("/                            |");
            //Console.WriteLine("|               3            |");
            //Console.WriteLine("|    4                  5    |");
            //Console.WriteLine("|                            |");
            //Console.WriteLine("|          ----------------- |");
            //Console.WriteLine("|_________/__________________|");

            return 4;
        }

        public bool tableCheck(string datum, string tijdstip, string table)
        {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            var filePath = appRoot + @$"\TableReservations.json";
            var readTableReservations = File.ReadAllText(filePath);
            List<tableReservationDetails> TempJson = JsonSerializer.Deserialize<List<tableReservationDetails>>(readTableReservations);
            string timeKey = "";

            if (tijdstip.Substring(1, 1) == ":")
            {
                timeKey = "0" + tijdstip.Substring(0, 1);
            }
            else
            {
                timeKey = tijdstip.Substring(0, 2);
            }

            string timeKey2 = "" + (Convert.ToInt32(timeKey) + 1);
            if (timeKey2.Length == 1)
            {
                timeKey2 = "0" + timeKey2;
            }
            if (Convert.ToInt32(timeKey2) > 23)
            {
                timeKey2 = "00";
            }

            bool placetaken = false;

            // reserves table if its not taken already
            foreach (var date in TempJson)
            {
                if (date.Date == datum)
                {
                    if (date.Time[timeKey].Contains(table) || Convert.ToInt32(table) > 5 || date.Time[timeKey].Contains(table))
                    {
                        placetaken = true;
                    }

                    else
                    {
                        date.Time[timeKey] += table; date.Time[timeKey2] += table;
                        string newEntryJson = JsonSerializer.Serialize(TempJson, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filePath, newEntryJson);
                    }

                    if (placetaken)
                    {
                        Console.WriteLine("\nSorry maar er zijn geen tafels beschikbaar op tid tijdstip.\nKies alstublieft een ander tijdstip: ");
                        return false;
                    }

                }
            }

            return true;
        }

        public string GetUserCode()
        {
            var getPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonSerializer.Deserialize<Login>(readAllUser);
            return currentUser.Code;
        }

        public static void SendEmail(string reservationcode, string usercode, string fname, string lname, string datum, string tijd, string gasten, string table, string impala, string fish, string vegan, string email)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("lamouette.noreply@gmail.com", "LaMouette123"),
                EnableSsl = true,
            };

            string body = $"Hallo {fname},\n\n" +
                $"Bedankt voor het reserveren bij ons.\n\n" +
                $"De gegevens die u doorgegeven hebt zijn: \n" +
                $"Naam: {fname} {lname}\n" +
                $"Datum: {datum} {tijd}\n" +
                $"Tafel: {table}\n" +
                $"Gasten: {gasten}, Impala: {impala}, Vis {fish}, Vegan: {vegan}\n\n" +
                $"Om uw reservering te annuleren kunt u de volgende code gebruiken: {reservationcode}\n" +
                $"De reservering kan binnen 7 dagen na ontvangst van deze mail worden geannuleerd.";

            smtpClient.Send("lamouette.noreply@gmail.com", email, "Registreer bevestiging", body);
        }

    }

    internal class CancelReservation
    {
        public void DeleteReservation()
        {
            Console.WriteLine("Voer uw reserveringscode in:");
            string reservationCode = Console.ReadLine();
            //var UserCode = GetUserCode();
            var filePath = @"../../../Reservations.json";
            var readCurrentText = File.ReadAllText(filePath);
            var newReservation = new List<ReservationDetails>();
            var currentReservation = JsonSerializer.Deserialize<List<ReservationDetails>>(readCurrentText);
            foreach (var item in currentReservation)
            {
                if (item.ReservationCode == reservationCode)
                {
                    if ((DateTime.Parse(item.CreationDate) - DateTime.Today).TotalDays > 7)
                    {
                        Console.WriteLine("De reservatie is langer dan een week geleden geplaatst. Deze kunt u helaas niet meer annuleren");
                        newReservation.Add(new ReservationDetails(item.ReservationCode, item.UserCode, item.Name, item.LastName, item.Date, item.Time, item.Guestcount, item.Impala, item.Fish, item.Vegan, item.Calorieën, item.Allergieën, item.Email, item.Booking));
                    }
                }
                if (item.ReservationCode != reservationCode)
                {
                    newReservation.Add(new ReservationDetails(item.ReservationCode, item.UserCode, item.Name, item.LastName, item.Date, item.Time, item.Guestcount, item.Impala, item.Fish, item.Vegan, item.Calorieën, item.Allergieën, item.Email, item.Booking));
                    //readCurrentText = JsonSerializer.Serialize(newReservation, new JsonSerializerOptions { WriteIndented = true });
                    //File.WriteAllText(filePath, readCurrentText);
                }
            }
            readCurrentText = JsonSerializer.Serialize(newReservation, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, readCurrentText);
            Console.Clear();
            Program.Main();
        }

    }

}
