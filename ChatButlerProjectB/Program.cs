using System;

namespace ChatButlerProjectB
{
    class Program
    {
        public static void Main()
        {
            Butler Winston = new Butler();
            Register reg = new Register();
            PlaceReservation res = new PlaceReservation();

            bool loggedin = false;
            
            Console.WriteLine(Winston.Greet());
            Console.WriteLine(Winston.ShowComponents());
            Console.WriteLine("Kies het nummer waar u heen wilt gaan!");
            string chosenInput = Console.ReadLine();

            if (chosenInput != "1" && chosenInput != "2" && chosenInput != "3" && chosenInput != "4" && chosenInput != "5" && chosenInput != "chef input")
            {
                Console.WriteLine("Dat is een ongeldig nummer");
                Main();
            }
            else if(chosenInput == "5")
            {
                Console.WriteLine("Bedankt voor uw bezoek");
            }
            else if (chosenInput == "1")
            {
                Console.WriteLine("Review");
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
                Console.WriteLine("Inloggen");
            }
            else if(chosenInput == "ma names cheff")
            {
                Console.WriteLine("Cheff");
            }
        }
    }
}
