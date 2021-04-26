﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChatButlerProjectB
{
    internal class Account
    {
        public void MainAcc()
        {
            CheckIfLoggedIn();
            Console.WriteLine(ShowInfo());
            bool menus = AskForTask("Wilt u uw gekozen menu's bekijken?");
            if (menus)
            {
                Console.WriteLine(ShowChosenMenus());
                bool backToMain = AskForTask("Wilt u terug naar het hoofd menu?");
                if (backToMain)
                {
                    Program.Main();
                }
                else
                {
                    MainAcc();
                }
            }
            else
            {
                Program.Main();
            }
        }

        public static void CheckIfLoggedIn()
        {
            var getPath = @"..\..\..\loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);

            if(currentUser.Code == "000000")
            {
                Console.Clear();
                Console.WriteLine("U bent niet ingelogd. Wilt u een account maken?");
                string accountMaken = Console.ReadLine();
                if(accountMaken == "ja")
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
            //Haal alle users op
            var getMemberPath = @"..\..\..\members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);
            //Haal huidige user op
            var getPath = @"..\..\..\loggedInUser.json";
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
            return info;
        }

        public static bool AskForTask(string text)
        {
            Console.WriteLine("\n" + text);
            var keus = Console.ReadLine();
            if(keus == "ja")
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
                if(x > 5)
                {
                    if(x > 10)
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
            var getMemberPath = @"..\..\..\members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);
            //Haal huidige user op
            var getPath = @"..\..\..\loggedInUser.json";
            var readAllUser = File.ReadAllText(getPath);
            var currentUser = JsonConvert.DeserializeObject<Login>(readAllUser);

            bool info = false;
            foreach (var item in currentUsers)
            {
                if (currentUser.Code == item.LoginCode)
                {
                    if(item.Safari == true)
                    {
                        info = true;
                    }
                }
            }
            return info;
        }

        public static int GetExspensiveMenus()
        {
            return 6;
        }

        public static string ShowChosenMenus()
        {
            return "Geen menus gegeten";
        }
    }
}