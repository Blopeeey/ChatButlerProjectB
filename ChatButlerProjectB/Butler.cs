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
                return "1: Een review bekijken van eerdere gasten\n" +
                        "2: Een reservering plaatsen\n" +
                        "3: Registreren\n" +
                        "4: Inloggen\n" +
                        "5: Sluiten";
            }
            return "1: Een review bekijken van eerdere gasten\n" +
                   "2: Een reservering plaatsen\n" +
                   "3: Membership bekijken\n" +
                   "4: Log into other account\n" +    
                   "5: Sluiten";
        }
    }
}