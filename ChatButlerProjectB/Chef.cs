using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

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
            Console.WriteLine("Welke datum zoekt u? (dd/mm/yy)");
            string datum = Console.ReadLine();
            Console.WriteLine(GetReservation(datum));
            Console.WriteLine("Wilt u nog een datum zoeken?");
            string nieuweDatum = Console.ReadLine();
            if(nieuweDatum == "ja")
            {
                MainChef();
            }
            else
            {
                Console.Clear();
                Program.Main();
            }
        }

        public string GetReservation(string date)
        {
            var getMenuPath = @"..\..\..\Reservations.json";
            var readAllMenus = File.ReadAllText(getMenuPath);
            var currentMenus = JsonConvert.DeserializeObject<List<ReservationDetails>>(readAllMenus);
            Console.Clear();
            string allReservations = "Alle gevonden reservaties:\n\n";
            foreach (var item in currentMenus)
            {
                if (date == item.Date)
                {
                    allReservations += $"Usercode: {item.UserCode}\n" +
                                       $"ReservationCode: {item.ReservationCode}\n" +
                                       $"Tijd: {item.Time}\n" +
                                       $"Hoeveelheid gasten: {item.Guestcount}\n" +
                                       $"Ingredienten: \n" +
                                       $"- Impala {item.Impala}\n" +
                                       $"- Fish {item.Fish}\n" +
                                       $"- Vegan {item.Vegan}\n\n";
                }
            }
            if(allReservations == "Alle gevonden reservaties:\n\n")
            {
                return "Er zijn geen reserveringen gevonden op deze datum\n";
            }
            return allReservations;
        }

    }
}
