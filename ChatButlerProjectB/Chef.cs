using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
//using System.Text;
//using System.Text.Json;
//using System.Text.RegularExpressions;
//using System.Linq;
//using System.Threading.Tasks;
//using System.IO;
//using System.Collections.Generic;
//using Newtonsoft.Json;
//using System.Net.Mail;
//using System.Net;



//namespace ChatButlerProjectB
//{
//    public class Chef
//    {
//        void Chefmenu()
//        {
//            Console.WriteLine("DD/MM/JJJJ");
//            string datum = ViableCheckdate(Console.ReadLine(), "de gewenste datum");

//        }

//        string Value = text;
//            while (!Regex.IsMatch(Value, @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"))
//            {
//                Console.Write($"Oops! dat kan niet kloppen, voer a.u.b. {waarde} in.\n");
//                Value = Console.ReadLine();
//            }
//    string LowerCaseValue = Value.ToLower();
//            return LowerCaseValue;

//    }


//}


namespace ChatButlerProjectB
{
    class Chef
    {
        public void MainChef()
        {
            Console.Clear();
            Butler Winston = new Butler();
            Winston.Log(3, "Menu/Chefmenu");
            Console.WriteLine("~ChefMenu~\nWelke datum zoekt u? (dd/mm/yy). Druk op enter om uw invoer te bevestigen.");
            Winston.Log(1, "~ChefMenu~\nWelke datum zoekt u? (dd/mm/yy). Druk op enter om uw invoer te bevestigen.");

            string datum = Console.ReadLine();

            Winston.Log(2, $"Invoer: {datum}");
            Console.WriteLine(GetReservation(datum));

            //
            Console.WriteLine("Druk op Backspace om een volgende datum te zoeken of druk \nop Escape om terug te keren naar het hoofdmenu.");
            Winston.Log(1, "Druk op Backspace om een volgende datum te zoeken of druk \nop Escape om terug te keren naar het hoofdmenu.");
            ConsoleKey key = Console.ReadKey(true).Key;

            while (!(key.Equals(ConsoleKey.Escape)) && !key.Equals(ConsoleKey.Backspace))
            {
                key = Console.ReadKey(true).Key;
            }

            if (key.Equals(ConsoleKey.Escape))
            {
                Winston.Log(2, $"Invoer: <Escape>");
                Console.Clear();
                Program.Main();
            }
            else if (key.Equals(ConsoleKey.Backspace))
            {
                Winston.Log(2, $"Invoer: <Backspace>");
                MainChef();
            }
            //
        }

        public string GetReservation(string date)
        {
            Butler Winston = new Butler();
            var getMenuPath = @"../../../Reservations.json";
            var readAllMenus = File.ReadAllText(getMenuPath);
            var currentMenus = JsonConvert.DeserializeObject<List<ReservationDetails>>(readAllMenus);
            Console.Clear();
            string allReservations = "Alle gevonden reservaties:\n\n";
            foreach (var item in currentMenus)
            {
                if (date == item.Date)
                {
                    allReservations += $"Datum: {item.Date}\n" +
                                       $"Gebruikerscode: {item.UserCode}\n" +
                                       $"Reservatiecode: {item.ReservationCode}\n" +
                                       $"Tijd: {item.Time}\n" +
                                       $"Aantal gasten: {item.Guestcount}\n" +
                                       $"Ingrediënten: \n" +
                                       $"- Impala {item.Impala}\n" +
                                       $"- Vis {item.Fish}\n" +
                                       $"- Vegetarisch {item.Vegan}\n\n";
                }
            }
            if(allReservations == "Alle gevonden reservaties:\n\n")
            {
                Winston.Log(1, "Er zijn geen reserveringen gevonden op basis van de ingevoerde gegevens.  \n");
                return "Er zijn geen reserveringen gevonden op basis van de ingevoerde gegevens.  \n";
            }
            Winston.Log(1, allReservations);
            return allReservations;
        }
    }
}
