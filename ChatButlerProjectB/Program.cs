using System;
using ChatButlerProjectB;

namespace ChatButlerProjectB
{

    public 
    class Program
    {
        static void Main(string[] args)
        {
            Butler Winston = new Butler();

            

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
