using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ChatButlerProjectB
{
    internal class Butler
    {
        public Butler()
        {

        }

        public string Greet()
        {
            return "Waarde heer, mevrouw. \n\nWelkom bij restuarant La Mouette. \n\nWaar kan ik u mee van dienst zijn?\n";
        }

        public string ShowComponents()
        {
            var getMemberPath = @"..\..\..\loggedInUser.json";
            var readAllUser = File.ReadAllText(getMemberPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);
            //Check of iemand ingelogd is
            if(currentUser.Code == "000000")
            {
                return "---------------------------------------------\n" +
                   "|1: Reviews bekijken\n" +
                   "|2: Registreren\n" +
                   "|3: Inloggen\n" +
                   "|4: Andere gast opzoeken\n" +
                   "|5: Sluiten\n" + 
                   "---------------------------------------------";
            }
            return "---------------------------------------------\n" +
                   "|1: Reviews bekijken\n" +
                   "|2: Review schrijven\n" +
                   "|3: Een reservering plaatsen\n" +    
                   "|4: Account bekijken\n" +
                   "|5: Andere gast opzoeken\n" +
                   "|6: Uitloggen\n" +
                   "|7: Sluiten\n" + 
                   "---------------------------------------------";
        }

        public string Review_text()
        {
            return "";
        }


    }
}
