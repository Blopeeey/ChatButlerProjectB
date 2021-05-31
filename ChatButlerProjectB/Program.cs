using System;
using Newtonsoft.Json;
using ChatButlerProjectB;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace ChatButlerProjectB
{
    class Program
    {
        public static void Main()
        {
            Butler Winston = new Butler();

            //bool loggedin = false;

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
            Register reg = new Register();
            Login log = new Login();
            Review rev = new Review();
            SearchMember smember = new SearchMember();
            Chef chef = new Chef();

            if (i == "1")
            {
                rev.Get_reviews();
            }
            else if(i == "2")
            {
                reg.MainReg();
            }
            else if(i == "3")
            {
                log.MainLogin();
            }
            else if(i == "4")
            {
                smember.MainSearch();
            }
            else if(i == "5")
            {
                Console.WriteLine("Bedankt voor uw bezoek");
            }
            else if (i == "sesame")
            {
                chef.MainChef();
            }
            else
            {
                Console.WriteLine("Dat is een ongeldig nummer");
                Main();
            }
        }

        public static void MenuLoggedIn(string i)
        {
            Login log = new Login();
            Account acc = new Account();
            Review rev = new Review();
            SearchMember smember = new SearchMember();
            PlaceReservation res = new PlaceReservation();
            Chef chef = new Chef();
            CancelReservation can = new CancelReservation();

            if (i == "1")
            {
                rev.Get_reviews();
            }
            else if (i == "2")
            {
                rev.Make_review();
                Program.Main();
            }
            else if (i == "3")
            {
                res.Reservation();
            }
            else if (i == "4")
            {
                can.DeleteReservation();
            }
            else if (i == "5")
            {
                acc.MainAcc();
            }
            else if (i == "6")
            {
                smember.MainSearch();
            }
            else if (i == "7")
            {
                log.LogUserOut();
            }
            else if (i == "8")
            {
                acc.RemoveAccount();
            }
            else if (i == "9")
            {
                Console.WriteLine("Bedankt voor uw bezoek");
            }
            else if (i == "sesame")
            {
                chef.MainChef();
            }
            else
            {
                Console.WriteLine("Dat is een ongeldig nummer");
                Main();
            }
        }
    }
}
