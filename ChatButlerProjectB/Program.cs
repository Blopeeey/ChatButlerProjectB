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

    public
    class Program
    {
        public static void Main()
        {

            Console.Title = "Restuarant La Mouette";

            Butler Winston = new Butler();
            Register reg = new Register();
            Login log = new Login();
            Account acc = new Account();
            Review rev = new Review();
            SearchMember smember = new SearchMember();
            PlaceReservation res = new PlaceReservation();

            Console.WriteLine(Winston.Greet());
            Console.WriteLine(Winston.ShowComponents());
            Console.WriteLine("Kies het nummer waar u heen wilt gaan!");
            string chosenInput = Console.ReadLine();

            if (chosenInput != "1" && chosenInput != "2" && chosenInput != "3" && chosenInput != "4" && chosenInput != "5" && chosenInput != "6" && chosenInput != "7" && chosenInput != "sesame")
            {
                Console.WriteLine("Dat is een ongeldig nummer");
                Main();
            }
            else if (chosenInput == "5")
            {
                Console.WriteLine("Bedankt voor uw bezoek");
            }
            else if (chosenInput == "1")
            {
                rev.Make_review();
                rev.Get_reviews();
            }
            else if (chosenInput == "2")
            {
                res.Reservation();
            }
            else if (chosenInput == "3")
            {
                reg.MainReg();
            }
            else if (chosenInput == "4")
            {
                log.MainLogin();
            }
            else if (chosenInput == "6")
            {
                acc.MainAcc();
            }
            else if (chosenInput == "7")
            {
                log.LogUserOut();
            }
            else if (chosenInput == "8")
            {
                smember.MainSearch();
            }
            else if (chosenInput == "sesame")
            {
                Console.WriteLine("Chef");
            }
            else
            {
                Console.WriteLine("Dat is een ongeldig nummer");
                Main();
            }
            Review Rev = new Review();

            //tests
            double discount_pc = Rev.Make_review();
            //Console.WriteLine(discount_pc);
            Rev.Get_reviews();
        }
    }
}
