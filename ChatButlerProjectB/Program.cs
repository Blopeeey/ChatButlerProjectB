using System;
using ChatButlerProjectB;

namespace ChatButlerProjectB
{

    public
    class Program
    {
        public static void Main()
        {
            Butler Winston = new Butler();
            Register reg = new Register();

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
                Console.WriteLine("Reservering");
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


            Console.WriteLine(Winston.Greet());
            Console.WriteLine(Winston.ChooseLanguage());
            string language = Console.ReadLine();
            string Chosenlanguage = null;
            if (language != "en" && language != "nl")
            {
                Console.Write("Chosen language in invalid. Please enter 'en' or 'nl' ");
                language = Console.ReadLine();
            }
            if (language == "en")
            {
                Chosenlanguage = "English";
            }
            else if (language == "nl")
            {
                Chosenlanguage = "Dutch";
            }

            Console.WriteLine("Chosen language is " + Chosenlanguage);


        }
    }
}
