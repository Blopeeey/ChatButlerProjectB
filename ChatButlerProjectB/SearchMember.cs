
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChatButlerProjectB
{
    internal class SearchMember
    {
        public void MainSearch()
        {
            //Console.Clear();   
            Console.WriteLine("Voer de naam in die u zoekt of druk op enter om terug te keren naar \nhet hoofdmenu.");
            string searchedName = Console.ReadLine();
            if (!searchedName.Contains(" ") && searchedName.Length > 1)
            {
                //Wanneer gebruiker alleen een voornaam invult achternamen aanvullen
                CheckFirstName(searchedName);
            }
            else if (searchedName.Contains(" "))
            {
                //Wanneer gebruiker volledige naam invult zoek de naam
                SearchName(searchedName);
            } else
            {
                Console.Clear();
                Program.Main();
            }

            //Laat user nog een member zoeken
            Console.Clear();
            Console.WriteLine($"Geen gebruiker gevonden met de naam '{searchedName}', wilt u nog een member \nzoeken? Voer 'ja' in of druk op enter om terug te keren naar het hoofdmenu.");
            string searchNewName = Console.ReadLine();
            if (searchNewName == "ja")
            {
                Console.Clear();
                MainSearch();
            }
            else
            {
                Console.Clear();
                Program.Main();
            }
        }

        public void CheckFirstName(string name)
        {
            name = name.ToLower();
            //Haal alle users op
            var getMemberPath = @"../../../members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);

            //Bepaal array lengte
            int count = 0;
            foreach (var item in currentUsers)
            {
                if (item.Fname == name && item.Verified == true)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Console.Clear();
                Console.WriteLine($"Geen gebruiker gevonden met de naam '{name}'.");
                MainSearch();
            }
            //Sla gevonden achternamen op
            string[] lastNames = new string[count];
            int i = 0;
            string[] listnumbers = new string[count];//-----------------
            foreach (var item in currentUsers)
            {
                if (item.Fname == name && item.Verified == true)
                {
                    lastNames[i] = item.Lname;
                    listnumbers[i] = (i + 1).ToString();//----------------
                    i++;
                }
            }
            //Toon gevonden achternamen
            Console.Clear();
            Console.WriteLine($"De gevonden achternaam bij de naam '{name}' zijn: ");
            for (int id = 0; id < lastNames.Length; id++)
            {
                Console.WriteLine($"{id + 1}: {lastNames[id]}");
            }
            //Laat een achternaam kiezen
            Console.WriteLine("Welke achternaam zoekt u? Kies het nummer van de achternaam of druk \nop enter om terug te keren naar het hoofdmenu.");


            //-----------------------------------------
            string Toreturn = "";
            while (true)
            {
                string chosenLastname = Console.ReadLine();
                if (chosenLastname == "")
                {
                    Console.Clear();
                    Program.Main();
                }
                foreach (string item in listnumbers)
                {
                    if (chosenLastname == item)
                    {
                        Toreturn = chosenLastname;
                    }
                }
                if (Toreturn != "")
                {
                    break;
                }
                //Toon gevonden achternamen
                Console.Clear();
                Console.WriteLine($"De gevonden achternaam bij de naam '{name}' zijn: ");
                for (int id = 0; id < lastNames.Length; id++)
                {
                    Console.WriteLine($"{id + 1}: {lastNames[id]}");
                }
                //Laat een achternaam kiezen
                Console.WriteLine("Welke achternaam zoekt u? Kies het nummer van de achternaam of druk \nop enter om terug te keren naar het hoofdmenu.");
            }
            //-----------------------------------------


            SearchName(name + " " + lastNames[Int32.Parse(Toreturn) - 1]);
        }

        public void SearchName(string enteredName)
        {
            //Haal voornaam en achternaam uit volle naam
            string[] naam = enteredName.Split(" ");
            string vnaam = naam[0].ToLower();
            string anaam = naam[1].ToLower();

            GetRightFirstName(vnaam, anaam);
        }

        public void GetRightFirstName(string vnaam, string anaam)
        {
            //Haal alle users op
            var getMemberPath = @"../../../members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);
            int totalcount = 0;
            int lastNameCheck = 0;
            string foundName = "";
            bool NameIsFound = false;
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            //Loop door alle gebruikers
            foreach (var user in currentUsers)
            {
                totalcount++;
                if (vnaam == user.Fname && user.Verified == true)
                {
                    if (anaam == user.Lname)
                    {
                        //Als ingevulde achternaam en voornaam gevonden zijn toon gegevens
                        GetUserInfo(user.Fname, user.Lname, user.Continent, user.Email, user.Safari, user.Trees);
                    }
                    else
                    {
                        //Als achternaam niet gevonden is tel op zodat hij later gecheckt kan worden
                        lastNameCheck++;
                    }
                }
                else
                {
                    //Maak van de voornaam eerst een char array zodat elke letter doorheen gelopen kan worden
                    for (int i = 0; i < vnaam.Length; i++)
                    {
                        char[] currentName = vnaam.ToCharArray();
                        for (int j = 0; j < alpha.Length; j++)
                        {
                            //Verander steeds de letters in volgorde totdat het word gevonden is
                            currentName[i] = alpha[j];
                            string vnaamString = new string(currentName);
                            if (CheckIfStringInMember(vnaamString))
                            {
                                NameIsFound = true;
                                foundName = vnaamString;
                            }
                        }
                    }

                }

            }
            //Als voornaam gevonden kon worden na wijzigingen 
            if (NameIsFound)
            {
                GetRightFirstName(foundName, anaam);
            }

            //Als er geen gevonden achternaam is. Laat alle achternamen zien die dezelfde voornaam hebben
            if (totalcount == lastNameCheck)
            {
                Console.WriteLine("De achternaam is niet gevonden");
                CheckFirstName(vnaam);
            }
        }

        public bool CheckIfStringInMember(string s)
        {
            //Haal alle users op
            var getMemberPath = @"../../../members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);

            foreach (var user in currentUsers)
            {
                if (user.Fname == s && user.Verified == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void GetUserInfo(string f, string l, string cont, string mail, bool saf, int trees)
        {
            Console.Clear();
            Console.WriteLine($"Bedoelt u het lid '{f} {l}'?");
            Console.WriteLine("Voer 'ja' in om te bevestigen of voer 'nee' in om opnieuw te zoeken.\nDruk op enter om terug te keren naar het hoofdmenu.");
            string rightUser = Console.ReadLine();
            if (rightUser == "ja")
            {
                Console.Clear();
                Console.WriteLine("De gegevens van de gezochte gebruiker:");
                //
                string saf101 = saf ? "Bezocht" : "Niet bezocht";
                string newemail = "";
                bool check = false;
                for (int i=0; i<mail.Length; i++)
                {
                    if (mail[i] == '@' || check == true)
                    {
                        check = true;
                        newemail += mail[i];
                    } else
                    {
                        newemail += "*";
                    }
                }
                //
                Console.WriteLine($"Naam: {f} {l}\n" +
                  $"Continent: {cont}\n" +
                  $"E-Mail: {newemail}\n" +
                  $"Safari: {saf101}\n" +
                  $"Bomen: {trees}\n\n" +
                  $"Gegeten menu's:\n" +
                  $"");
                MainSearch();
            }
            else if (rightUser == "nee")
            {
                Console.Clear();
                MainSearch();
            }
            else if (rightUser == "") 
            {
                Console.Clear();
                Program.Main();
            }
            else
            {
                GetUserInfo(f, l, cont, mail, saf, trees);
            }
        }

        public string[] GetEatenMenus(string code)
        {
            string[] menuArr = new string[code.Length];
            return menuArr;
        }
    }
}
