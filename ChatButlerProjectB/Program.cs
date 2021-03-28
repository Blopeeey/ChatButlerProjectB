using System;

namespace ChatButlerProjectB
{
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

            if (chosenInput != "1" && chosenInput != "2" && chosenInput != "3" && chosenInput != "4" && chosenInput != "chef input")
            {
                Console.WriteLine("Dat is een ongeldig nummer");
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
                if (loggedin)
                {
                    Console.WriteLine("Hier komt account bekijken");
                }
                else
                {
                    reg.MainReg();
                }
            }
            else if(chosenInput == "ma names cheff")
            {
                Console.WriteLine("Cheff");
            }
        }
    }
}
