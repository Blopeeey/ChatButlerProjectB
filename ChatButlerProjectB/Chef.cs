using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            if(allReservations == "")
            {
                return "Er zijn geen reserveringen gevonden op deze datum";
            }
            return allReservations;
        }
        
    }
}
