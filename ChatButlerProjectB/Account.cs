using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChatButlerProjectB
{
    internal class Account
    {
        public void MainAcc()
        {
            Console.Clear();
            Butler winston = new Butler();
            winston.Log(3, "Account");
            CheckIfLoggedIn();
            Console.WriteLine(ShowInfo());
            bool menus = AskForTask("Wilt u uw gekozen menu's bekijken? (ja/nee)");
            if (menus)
            {
                Console.WriteLine(ShowChosenMenus());
                bool backToMain = AskForTask("Wilt u terug naar het hoofd menu? (ja/nee)");
                if (backToMain)
                {
                    Console.Clear();
                    Program.Main();
                }
                else
                {
                    MainAcc();
                }
            }
            else
            {
                Console.Clear();
                Program.Main();
            }
        }

        public static void CheckIfLoggedIn()
        {
            Butler winston = new Butler();
            var getPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);

            if (currentUser.Code == "000000")
            {
                Console.Clear();
                Console.WriteLine("U bent niet ingelogd. Wilt u een account maken? (ja/nee)");
                winston.Log(1, "U bent niet ingelogd. Wilt u een account maken?");
                string accountMaken = Console.ReadLine();
                winston.Log(2, accountMaken);
                if (accountMaken == "ja")
                {
                    Register newReg = new Register();
                    newReg.MainReg();
                }
                else
                {
                    Program.Main();
                }
            }
        }

        public static string ShowInfo()
        {
            Butler winston = new Butler();
            //Haal alle users op
            var getMemberPath = @"../../../members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);
            //Haal huidige user op
            var getPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);

            string status = GetStatus();

            string info = $"Status: {status}";
            foreach (var item in currentUsers)
            {
                if (currentUser.Code == item.LoginCode)
                {
                    info += $"\nFirstname: {item.Fname}\n" +
                            $"Lastname: {item.Lname}\n" +
                            $"Creditcard: {item.CreditCard[..5]}******\n" +
                            $"Continent: {item.Continent}\n" +
                            $"E-mail: {item.Email}\n" +
                            $"Safari: {item.Safari}\n" +
                            $"Trees to compensate: {item.Trees}";
                }
            }
            winston.Log(2, info);
            return info;
        }

        public static bool AskForTask(string text)
        {
            Butler winston = new Butler();
            Console.WriteLine("\n" + text);
            winston.Log(1, "\n" + text);
            var keus = Console.ReadLine();
            winston.Log(2, keus);
            if (keus == "ja")
            {
                return true;
            }
            return false;
        }

        public static string GetStatus()
        {
            int x = GetExspensiveMenus();
            string pleb = "Bronze";
            string med = "Silver";
            string high = "Gold";
            string extreme = "Platinum";

            if (GetSafari())
            {
                if (x > 7)
                {
                    if (x > 15)
                    {
                        return extreme;
                    }
                    else
                    {
                        return high;
                    }
                }
                else
                {
                    return med;
                }
            }
            else
            {
                if (x > 5)
                {
                    if (x > 10)
                    {
                        return high;
                    }
                    else
                    {
                        return med;
                    }
                }
                else
                {
                    return pleb;
                }
            }
        }

        public static bool GetSafari()
        {
            //Haal alle users op
            var getMemberPath = @"../../../members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);
            //Haal huidige user op
            var getPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);

            bool info = false;
            foreach (var item in currentUsers)
            {
                if (currentUser.Code == item.LoginCode)
                {
                    if (item.Safari == true)
                    {
                        info = true;
                    }
                }
            }
            return info;
        }

        public static int GetExspensiveMenus()
        {
            var getMenuPath = @"../../../Reservations.json";
            var readAllMenus = File.ReadAllText(getMenuPath);
            var currentMenus = JsonConvert.DeserializeObject<List<ReservationDetails>>(readAllMenus);
            int impala = 0;
            foreach (var item in currentMenus)
            {
                if (item.UserCode == GetUserCode())
                {
                    impala += Int32.Parse(item.Impala);
                }
            }
            return impala; 
        }

        public static string GetUserCode()
        {
            var getPath = @"../../../loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);
            return currentUser.Code;
        }

        public static string ShowChosenMenus()
        {
            var getMenuPath = @"../../../Reservations.json";
            var readAllMenus = File.ReadAllText(getMenuPath);
            var currentMenus = JsonConvert.DeserializeObject<List<ReservationDetails>>(readAllMenus);
            int impala = 0;
            int fish = 0;
            int vegan = 0;
            //Haal gekozen menu naam op
            foreach (var item in currentMenus)
            {
                if (item.UserCode == GetUserCode())
                {
                    impala += Int32.Parse(item.Impala);
                    fish += Int32.Parse(item.Fish);
                    vegan += Int32.Parse(item.Vegan);
                }
            }
            return $"Impala: {impala}\n" +
                   $"Fish: {fish}\n" +
                   $"Vegan: {vegan}";
        }

        public void RemoveAccount()
        {
            string code = GetUserCode();
            Login log = new Login();
            var getMemberPath = @"../../../members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var newUser = new List<MemberDetails>();
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);

            foreach(var item in currentUsers)
            {
                if (item.LoginCode != code)
                {
                    newUser.Add(new MemberDetails()
                    {
                        Fname = item.Fname,
                        Lname = item.Lname,
                        CreditCard = item.CreditCard,
                        Continent = item.Continent,
                        Email = item.Email,
                        Safari = item.Safari,
                        Trees = 0,
                        LoginCode = item.LoginCode
                    });
                }
            }
            readAllUsers = JsonConvert.SerializeObject(newUser, Formatting.Indented);
            File.WriteAllText(getMemberPath, readAllUsers);
            log.LogUserOut();
        }
    }
}