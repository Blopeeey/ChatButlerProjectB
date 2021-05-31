using System;
//using Newtonsoft.Json;
//using ChatButlerProjectB;
//using System.Collections.Generic;
//using System.Globalization;
//using Newtonsoft.Json.Converters;
//using System.IO;
//using System.Threading;
//using System.Text.RegularExpressions;

namespace ChatButlerProjectB
{
    class Program
    {
        public static void Main()
        {
            Console.Clear();

            //bool loggedin = false;

            Butler Winston = new Butler();

            Winston.Log(3, "Menu");
            Console.WriteLine(Winston.Greet());
            Console.WriteLine(Winston.ShowComponents());
            Console.WriteLine("Kies het nummer waar u heen wilt gaan!");
            Winston.Log(1, "Kies het nummer waar u heen wilt gaan!");
            string chosenInput = Console.ReadLine();

            string user = Account.GetUserCode();
            if(user == "000000")
            {
                MenuNotLoggedIn(chosenInput);
            }
            else
            {
                MenuLoggedIn(chosenInput);
            }
        }
       
        public static void MenuNotLoggedIn(string i)
        {
            Butler Winston = new Butler();
            Register reg = new Register();
            Login log = new Login();
            Review rev = new Review();
            SearchMember smember = new SearchMember();
            Chef chef = new Chef();

            if (i == "1")
            {
                Winston.Log(2, "Invoer: <1>");
                rev.Get_reviews();
            }
            else if(i == "2")
            {
                Winston.Log(2, "Invoer: <2>");
                reg.MainReg();
            }
            else if(i == "3")
            {
                Winston.Log(2, "Invoer: <3>");
                log.MainLogin();
            }
            else if(i == "4")
            {
                Winston.Log(2, "Invoer: <4>");
                smember.MainSearch();
            }
            else if(i == "5")
            {
                Winston.Log(2, "Invoer: <5>");
                Console.WriteLine("Bedankt voor uw bezoek");
            }
            else if (i == "sesame")
            {
                Winston.Log(2, "Invoer: <sesame>");
                chef.MainChef();
            }
            else
            {
                Winston.Log(2, $"Invoer: <{i}>");
                Console.WriteLine("Dat is een ongeldig nummer");
                
                Main();
            }
        }

        public static void MenuLoggedIn(string i)
        {
            Butler Winston = new Butler();
            Login log = new Login();
            Account acc = new Account();
            Review rev = new Review();
            SearchMember smember = new SearchMember();
            PlaceReservation res = new PlaceReservation();
            Chef chef = new Chef();
            CancelReservation can = new CancelReservation();

            if (i == "1")
            {
                Winston.Log(2, "Invoer: <1>");
                rev.Get_reviews();
            }
            else if (i == "2")
            {
                Winston.Log(2, "Invoer: <2>");
                rev.Make_review();
                Program.Main();
            }
            else if (i == "3")
            {
                Winston.Log(2, "Invoer: <3>");
                res.Reservation();
            }
            else if (i == "9")
            {
                Winston.Log(2, "Invoer: <9>");
                can.DeleteReservation();
            }
            else if (i == "4")
            {
                Winston.Log(2, "Invoer: <4>");
                acc.MainAcc();
            }
            else if (i == "5")
            {
                Winston.Log(2, "Invoer: <5>");
                smember.MainSearch();
            }
            else if (i == "6")
            {
                Winston.Log(2, "Invoer: <6>");
                log.LogUserOut();
            }
            else if (i == "7")
            {
                Winston.Log(2, "Invoer: <7>");
                acc.RemoveAccount();
            }
            else if (i == "8")
            {
                Winston.Log(2, "Invoer: <8>");
                Console.WriteLine("Bedankt voor uw bezoek");
            }
            else if (i == "sesame")
            {
                Winston.Log(2, "Invoer: <sesame>");
                chef.MainChef();
            }
            else
            {
                Winston.Log(2, $"Invoer: <{i}>");
                Console.WriteLine("Dat is een ongeldig nummer");
                Main();
            }
        }
    }
}
