using System;
using System.Text;//tijdelijk

namespace ChatButlerProjectB
{
    class Program
    {
        public static void Main()
        {
            Butler Winston = new Butler();


            Console.WriteLine(Winston.Greet());
            Console.WriteLine(Winston.ShowComponents());
            Console.WriteLine("Kies het nummer waar u heen wilt gaan!");
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

            if (i == "1")
            {
                rev.Get_reviews();
            }
            else if (i == "2")
            {
                rev.Make_review();
            }
            else if (i == "3")
            {
                res.Reservation();
            }
            else if (i == "4")
            {
                acc.MainAcc();
            }
            else if (i == "5")
            {
                smember.MainSearch();
            }
            else if (i == "6")
            {
                log.LogUserOut();
            }
            else if (i == "7")
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
