using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ChatButlerProjectB
{
    internal class Login
    {
        public string Code;
        public void MainLogin()
        {
            //Vrag user voor code
            Console.WriteLine("Vul uw membershipcode in");
            string userCode = Console.ReadLine();
            //Check code
            string result = CheckCode(userCode);
            Console.WriteLine(result);
            //User inloggen
            if(result != "wrong")
            {
                var filePath = @"..\..\..\loggedInUser.json";
                var readCurrentText = File.ReadAllText(filePath);
                readCurrentText = JsonConvert.SerializeObject(result, Formatting.Indented);
                File.WriteAllText(filePath, readCurrentText);
                Program.Main();
            }
            else
            {
                Console.WriteLine("Dit is geen geldige code");
                MainLogin();
            }   
        }

        public static string CheckCode(string code)
        {
            //Haal huidige user gegevens op
            var getMemberPath = @"..\..\..\members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);
            //Check of code overeenkomt met een bestaande code
            foreach (var item in currentUsers)
            {
                if (code == item.LoginCode)
                {
                    return item.LoginCode;
                }
            }
            return "wrong";
        }
    }
}