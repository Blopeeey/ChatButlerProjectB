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

    public class tableReservationDetails {
        public string Date { get; set; }
        public Dictionary<string, string> Time { get; set; }

        
        public tableReservationDetails() {/* parameterless constructor is needed to deserialze with text.json */ }

        public tableReservationDetails(string date) {
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

    internal class PlaceReservation {

        public void Reservation()
        {
            Console.Clear();
            string fname = ""; string lname = ""; string datum = ""; string tijd = ""; string table = ""; string gasten = "";  string impala = "";  string fish = ""; string vegan = ""; string email = "";
            int step = 0;

            while (step < 10) {
                if (step == 0){
                    Console.WriteLine("Type \"esc\", \"back\" of \"terug\" om terug te gaan.");
                    Console.WriteLine("Voornaam:");
                    fname = ViableCheckname(Console.ReadLine(), "uw voornaam");
                    if (fname.ToLower() == "esc" || fname.ToLower() == "back" || fname.ToLower() == "terug")
                    {
                        Console.Clear();
                        Program.Main();
                    }
                    step = 1;
                }

                if(step == 1)
                {
                    Console.WriteLine("\nAchternaam:");
                    lname = ViableCheckname(Console.ReadLine(), "uw achternaam");
                    if (lname.ToLower() == "esc" || lname.ToLower() == "back" || lname.ToLower() == "terug")
                    {
                        step = 0;
                    }
                    else {
                        step = 2;
                    }
                }

                if (step == 2) {
                    Console.WriteLine("\nDe gewenste datum: (DD/MM/JJJJ)");
                    datum = ViableCheckdate(Console.ReadLine(), "de gewenste datum");
                    if (datum.ToLower() == "esc" || datum.ToLower() == "back" || datum.ToLower() == "terug")
                    {
                        step = 1;
                    }
                    else
                    {
                        step = 3;
                    }
                }

                if (step == 3) {
                    Console.WriteLine("\nEen reservatie voor twee uur. Tijd wordt omlaag afgerond naar een heel uur. \nTijdstip:");
                    tijd = ViableChecktime(Console.ReadLine(), "het gewenste tijdstip");
                    if (tijd.ToLower() == "esc" || tijd.ToLower() == "back" || tijd.ToLower() == "terug")
                    {
                        step = 2;
                    }
                    else
                    {
                        step = 4;
                    }
                }

                if (step == 4)
                {
                    tableOverview(datum, tijd);

                    Console.WriteLine("\nMaximaal zes gasten kunnen aan een tafel \nSelecteer a.u.b. de gewenste tafel: \n");

                    table = ViableCheckint(Console.ReadLine(), "de gewenste tafel");
                    if (table.ToLower() == "esc" || table.ToLower() == "back" || table.ToLower() == "terug")
                    {
                        step = 3;
                    }
                    else if(tableCheck(datum, tijd, table))
                    {
                        step = 5;
                    }
                }

                if (step == 5)
                {
                    Console.WriteLine("\nGasten:");
                    gasten = ViableCheckint(Console.ReadLine(), "het aantal gasten");
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
                    Console.WriteLine("\nImpala:");
                    impala = ViableCheckint(Console.ReadLine(), "het aantal impala");
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
                    Console.WriteLine("\nVis:");
                    fish = ViableCheckint(Console.ReadLine(), "het aantal vis");
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
                    Console.WriteLine("\nVegetarisch:");
                    vegan = ViableCheckint(Console.ReadLine(), "het aantal vegetarisch");
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
                    Console.WriteLine("\nE-mail:");
                    email = ViableCheckEmail(Console.ReadLine(), "uw E-mail");
                    if (email.ToLower() == "esc" || email.ToLower() == "back" || email.ToLower() == "terug")
                    {
                        step = 8;
                    }
                    else
                    {
                        step = 10;
                    }
                }
            }

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
                if (Int32.Parse(impala) >= 3)
                {
                    Console.WriteLine("Wilt u zelf de impala schieten?");
                    string shootyshoot = Console.ReadLine();
                    while (shootyshoot != "ja" && shootyshoot != "j" && shootyshoot != "yes" && shootyshoot != "y" && shootyshoot != "nee" && shootyshoot != "n" && shootyshoot != "no" && shootyshoot != "n")
                    {
                        Console.WriteLine("Just yes or no pls");
                        shootyshoot = Console.ReadLine().ToLower();
                    }
                }

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
            while (!Regex.IsMatch(Value, @"^[A-Za-z]+$") && !(Value.ToLower() == "esc") && !(Value.ToLower() == "back") && !(Value.ToLower() == "terug"))
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
            while (!Regex.IsMatch(Value, @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$") && !(Value.ToLower() == "esc") && !(Value.ToLower() == "back") && !(Value.ToLower() == "terug"))
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

        public string tableOverview(string datum, string tijdstip) {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            var filePath = appRoot + @$"\TableReservations.json";

            // creates file if it doesnt exist
            if (!File.Exists(filePath)) {
                var Filecreation = File.Create(filePath);
                Filecreation.Close();
            }
            var readTableReservations = File.ReadAllText(filePath);

            // adds an entry to the json file of its empty
            if (readTableReservations == "") {
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

            string timeKey = tijdstip.Substring(0,2);
            bool dateExist = false;
            bool place1 = false;
            bool place2 = false;
            bool place3 = false;
            bool place4 = false;
            bool place5 = false;

            // looks for the desired date. if found, it look to see what tables are taken
            foreach (var date in TempJson){
                if (date.Date == datum){
                    dateExist = true;
                    if (date.Time[timeKey].Contains("1")) {
                        place1 = true;
                    }
                    if (date.Time[timeKey].Contains("2"))
                    {
                        place2 = true;
                    }
                    if (date.Time[timeKey].Contains("3"))
                    {
                        place3 = true;
                    }
                    if (date.Time[timeKey].Contains("4"))
                    {
                        place4 = true;
                    }
                    if (date.Time[timeKey].Contains("5"))
                    {
                        place5 = true;
                    }

                    // check if tables available 
                    if (place1 && place2 && place3 && place4 && place5)
                    {
                        Console.WriteLine("ay m8, no seats left i'm afraid.\nPlease select another time: ");
                        return "";
                    }
                }
            }

            // make new date entry in json file if it doesnt exist already
            if (!dateExist) {
                tableReservationDetails newEntry = new tableReservationDetails(datum);
                TempJson.Add(newEntry);
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

            return "";
        }

        public bool tableCheck(string datum, string tijdstip, string table) {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            var filePath = appRoot + @$"\TableReservations.json";
            var readTableReservations = File.ReadAllText(filePath);
            List<tableReservationDetails> TempJson = JsonSerializer.Deserialize<List<tableReservationDetails>>(readTableReservations);

            string timeKey = tijdstip.Substring(0, 2);
            string timeKey2 = "" + (Convert.ToInt32(timeKey)+1);
            if (Convert.ToInt32(timeKey2) > 23) {
                timeKey2 = "00";
            }

            bool placetaken = false;

            // reservs table if its not taken already
            foreach (var date in TempJson)
            {
                if (date.Date == datum)
                {
                    if (date.Time[timeKey].Contains(table) || Convert.ToInt32(table) > 5)
                    {
                        placetaken = true;
                    }

                    else {
                        date.Time[timeKey] += table; date.Time[timeKey2] += table;
                        string newEntryJson = JsonSerializer.Serialize(TempJson, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filePath, newEntryJson);
                    }

                    if (placetaken)
                    {
                        Console.WriteLine("ay m8, table taken.\nPlease select another table or time: ");
                        return false;
                    }

                }
            }

            return true;
        }

    }

}



