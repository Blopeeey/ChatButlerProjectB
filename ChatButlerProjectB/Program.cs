using System;

namespace ChatButlerProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            Butler Winston = new Butler();
            Register Register = new Register();

            bool loggedin = false;
            
            Console.WriteLine(Winston.Greet());
            Console.WriteLine(Winston.ShowComponents());
            Console.WriteLine("Kies het nummer waar je heen wilt gaan!");
            string chosenInput = Console.ReadLine();

            if (chosenInput != "1" && chosenInput != "2" && chosenInput != "3")
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
                    Console.WriteLine("Dat is een ongeldig nummer");
                }
                else
                {
                    Console.WriteLine("Register");
                }
            }
            else if(chosenInput == "ma names cheff")
            {
                Console.WriteLine("Cheff");
            }
        }
    }
}
