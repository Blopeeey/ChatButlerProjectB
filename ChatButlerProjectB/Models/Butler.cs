
using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatButlerProjectB
{

    internal class Butler
    {
        private UserCode currentuser;

        public Butler()
        {
        }

        public string Greet()
        {
            string toReturn_1 = "Waarde heer, mevrouw. \n\nWelkom bij restaurant La Mouette. \n\nWaar kan ik u mee van dienst zijn?";
            Log(1, toReturn_1);
            return toReturn_1;
        }

        public string ShowComponents()
        {
            var getMemberPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getMemberPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);
            string toReturn_2 = "";
            //Check of iemand ingelogd is
            if (currentUser.Code == "000000")
            {
                toReturn_2 = "---------------------------------------------\n" +
                   "|1: Recensie bekijken\n" +
                   "|2: Registreren\n" +
                   "|3: Inloggen\n" +
                   "|4: Andere gast opzoeken\n" +
                   "|5: Sluiten\n" +
                   "---------------------------------------------";
            }
            else
            {
                toReturn_2 = "---------------------------------------------\n" +
                       "|1: Recensie bekijken\n" +
                       "|2: Recensie schrijven\n" +
                       "|3: Een reservering plaatsen\n" +
                       "|4: Een reservering verwijderen\n" +
                       "|5: Account bekijken\n" +
                       "|6: Andere gast opzoeken\n" +
                       "|7: Uitloggen\n" +
                       "|8: Account verwijderen\n" +
                       "|9: Sluiten\n" +
                       "---------------------------------------------";
            }
            Log(1, toReturn_2);
            return toReturn_2;
        }

        public void Log(int source, string text)
        {
            //60 x '-'
            string strLogText = "------------------------------------------------------------|";

            // Create a writer and open/create the file:
            StreamWriter log;

            if (!File.Exists("Log.txt"))
            {
                log = new StreamWriter("Log.txt");
            }
            else
            {
                log = File.AppendText("Log.txt");
            }

            // 1 = output

            // 2 = input

            // 3 = huidige pagina + gebruiker

            //Write to the file with either input/output:
            string source_str = source == 1 ? "OUPUT" : "INPUT";
            if (source == 3)
            {
                //usercode 
                string code_json = File.ReadAllText("../../../loggedInUser.json");
                currentuser = System.Text.Json.JsonSerializer.Deserialize<UserCode>(code_json);
                string userCode = currentuser.Code;

                string spaces = "";
                // 25 = "[gebruikerscode: {}]" + 1 
                for (int i = 0; i < strLogText.Length - (25 + text.Length); i++)
                {
                    spaces += " ";
                }

                log.WriteLine($"{strLogText}\n{text}{spaces}[gebruikerscode: {userCode}]");
            }
            else
            {
                log.WriteLine($"{strLogText}\n{source_str}: {DateTime.Now}\n\n{text}");
            }

            // Close the stream:
            log.Close();
        }

        public string Review_text()
        {
            return "";
        }
    }
}