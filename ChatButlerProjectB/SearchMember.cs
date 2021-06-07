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
            Console.WriteLine("Vul de naam in die u zoekt");
            string searchedName = Console.ReadLine();
            if(!searchedName.Contains(" "))
            {
                //Wanneer gebruiker alleen een voornaam invult achternamen aanvullen
                CheckFirstName(searchedName);
            }
            else
            {
                //Wanneer gebruiker volledige naam invult zoek de naam
                SearchName(searchedName);
            }

            //Laat user nog een member zoeken
            Console.WriteLine("Wilt u nog een member zoeken?");
            string searchNewName = Console.ReadLine();
            if(searchNewName == "ja")
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
            var getMemberPath = @"..\..\..\members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);

            //Bepaal array lengte
            int count = 0;
            foreach(var item in currentUsers)
            {
                if(item.Fname == name)
                {
                    count++;
                }
            }

            if(count == 0)
            {
                Console.WriteLine("Deze voornaam is niet gevonden");
                MainSearch();
            }
            //Sla gevonden achternamen op
            string[] lastNames = new string[count];
            int i = 0;
            foreach (var item in currentUsers)
            {
                if (item.Fname == name)
                {
                    lastNames[i] = item.Lname;
                    i++;
                }
            }           
            //Toon gevonden achternamen
            Console.WriteLine("De gevonden achternaam bij uw voornaam zijn: ");
            for (int id = 0; id < lastNames.Length; id++)
            {
                Console.WriteLine($"{id + 1}: {lastNames[id]}");
            }
            //Laat een achternaam kiezen
            Console.WriteLine("Welke achternaam zoekt u?");
            string chosenLastname = Console.ReadLine();
            SearchName(name + " " + lastNames[Int32.Parse(chosenLastname) - 1]);
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
            var getMemberPath = @"..\..\..\members.json";
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
                if (vnaam == user.Fname)
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
            if(totalcount == lastNameCheck)
            {
                Console.WriteLine("De achternaam is niet gevonden");
                CheckFirstName(vnaam);
            }
        }

        public bool CheckIfStringInMember(string s) 
        {
            //Haal alle users op
            var getMemberPath = @"..\..\..\members.json";
            var readAllUsers = File.ReadAllText(getMemberPath);
            var currentUsers = JsonConvert.DeserializeObject<List<MemberDetails>>(readAllUsers);

            foreach(var user in currentUsers)
            {
                if(user.Fname == s)
                {
                    return true;
                }
            }
            return false;
        }

        public void GetUserInfo(string f, string l, string cont, string mail, bool saf, int trees)
        {
            Console.WriteLine($"Bedoelt u de member {f} {l}?");
            string rightUser = Console.ReadLine();
            if (rightUser == "ja")
            {
                Console.Clear();
                Console.WriteLine("Hier is de info van uw gezochte gebruiker");
                Console.WriteLine($"Naam: {f} {l}\n" +
                  $"Continent: {cont}\n" +
                  $"E-Mail: {mail}\n" +
                  $"Safari: {saf}\n" +
                  $"Trees: {trees}\n\n" +
                  $"Gegeten menu's:\n" +
                  $"");
                MainSearch();
            }
            else
            {
                MainSearch();
            }
        }

        public string[] GetEatenMenus(string code)
        {
            string[] menuArr = new string[code.Length];
            return menuArr;
        }
    }
}