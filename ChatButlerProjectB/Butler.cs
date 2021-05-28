
using System;
using System.IO;
using System.Text.Json;
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatButlerProjectB
{
    internal class Butler
    {
        private Reviews _reviews;

        public class Reviews
        {
        }

        public Butler()
        {

        }

        public string Greet()
        {
            string toReturn = "Waarde heer, mevrouw. \n\nWelkom bij restuarant La Mouette. \n\nWaar kan ik u mee van dienst zijn?";
            Log(1, toReturn);
            return toReturn;
        }

        public string ShowComponents()
        {
            var getMemberPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getMemberPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);
            //Check of iemand ingelogd is
            /*if(currentUser.Code == "000000")
            {
                return "1: Een review bekijken van eerdere gasten\n" +
                        "2: Een reservering plaatsen\n" +
                        "3: Registreren\n" +
                        "4: Inloggen\n" +
                        "5: Sluiten";
            }*/
            return "\n---------------------------------------------\n" +
                   "|1: Een review bekijken van eerdere gasten\n" +
                   "|2: Een reservering plaatsen\n" +
                   "|3: Registreren\n" +
                   "|4: Login\n" +
                   "|6: Account bekijken\n" +
                   "|7: Uitloggen\n" +
                   "|8: Zoek een member\n" +
                   "|5: Sluiten\n" +
                   "---------------------------------------------";
        }

        public void Log(int source, string text)
        {
            string strLogText = "-------------------------------------------------------";

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


            //string source_ = source == 1 ? "OUPUT" : "INPUT";

            //Write to the file with either input/output:
            if (source == 1)
            {
                log.WriteLine($"{strLogText}\nOutput: {DateTime.Now}\n\n{text}\n");
            } else
            {
                log.WriteLine($"{strLogText}\nInput: {DateTime.Now}\n\n{text}");
            }

            // Close the stream:
            log.Close();
        }

        public string Review_text()
        {
            return "";
        }

        public void Log()
        {
            ////
        }
    }
}
