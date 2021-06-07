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
            Butler winston = new Butler();
            winston.Log(3, "Login");
            //Vrag user voor code
            CheckIfLoggedIn();
            Console.WriteLine("Vul uw membershipcode in");
            winston.Log(1, "Vul uw membershipcode in");
            string userCode = Console.ReadLine();
            winston.Log(2, userCode);
            //Check code
            string result = CheckCode(userCode);
            //User inloggen
            if(result != "wrong")
            {
                var filePath = @"../../../loggedInUser.json";
                var readCurrentText = File.ReadAllText(filePath);
                var loginMember = new Login { Code = result };
                readCurrentText = JsonConvert.SerializeObject(loginMember, Formatting.Indented);
                File.WriteAllText(filePath, readCurrentText);
                Console.Clear();
                Console.WriteLine(" ----------------\n |U bent ingelogd|\n ----------------");
                winston.Log(1, "----------------\n |U bent ingelogd|\n ----------------");

                Program.Main();
            }
            else
            {
                Console.WriteLine("Dit is geen geldige code");
                winston.Log(1, "Dit is geen geldige code");
                MainLogin();
            }   
        }

        public static string CheckCode(string code)
        {
            //Haal huidige user gegevens op
            var getMemberPath = @"../../../members.json";
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

        public void LogUserOut()
        {
            Butler winston = new Butler();
            var filePath = @"../../../loggedInUser.json";
            var readCurrentText = File.ReadAllText(filePath);
            var loginMember = new Login { Code = "000000" };
            readCurrentText = JsonConvert.SerializeObject(loginMember, Formatting.Indented);
            File.WriteAllText(filePath, readCurrentText);
            Console.WriteLine("U bent uitgelogd");
            winston.Log(1, "U bent uiteglogd");
            Console.Clear();
            Program.Main();
        }

        public void CheckIfLoggedIn()
        {
            Butler winston = new Butler();
            //Haal huidige user op
            var getPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);
            if(currentUser.Code != "000000")
            {
                Console.WriteLine("U bent al ingelogd");
                winston.Log(1, "U bent al ingelogd");
                Program.Main();
            }
        }
    }
}