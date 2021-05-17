using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace ChatButlerProjectB
{
    public class Review_data
    {
        public string Language { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string Rating { get; set; }
    }

    public class UserCode
    {
        public string Code { get; set; }
    }

    internal class Review
    {
        private UserCode currentuser;

        public void Get_reviews()
        {
            Console.CursorVisible = false;
            var filePath = "../../../reviews.json";
            var readCurrentText = File.ReadAllText(filePath);
            var currentMembers = JsonConvert.DeserializeObject<List<Review_data>>(readCurrentText) ?? new List<Review_data>();

            int count = 0;
            foreach (var item in currentMembers)
            {
                count++;
            }

            int current_review = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"-Recensies La Mouette-\nrecensie {current_review + 1} van {count}\n");
                Console.WriteLine("{0}\n{1}\n{2}\n{3}", currentMembers[current_review].Date, currentMembers[current_review].Name, currentMembers[current_review].Text, currentMembers[current_review].Rating);
                Console.WriteLine("\nBlader door de reviews met de pijltjes of druk op escape om terug te keren naar het hoofdmenu.");

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key.Equals(ConsoleKey.RightArrow) && (current_review + 1) < count)
                {
                    current_review++;
                }
                else if (key.Equals(ConsoleKey.LeftArrow) && current_review > 0)
                {
                    current_review--;
                }
                else if (key.Equals(ConsoleKey.Escape))
                {
                    Program.Main();
                    break;
                }
            }
        }

        public bool check_rating(string rating)
        {
            foreach (char i in rating)
            {
                if (i != '*')
                {
                    return false;
                }
            }
            return true;
        }

        public double Make_review()
            {
            Console.Clear();
            //Language--
            string input_language = "Nederlands";

            //Name--
            string input_name = "";
            string code_json = File.ReadAllText(@"..\..\..\loggedInUser.json");
            currentuser = System.Text.Json.JsonSerializer.Deserialize<UserCode>(code_json);
            string userCode = currentuser.Code;

            string members_json = File.ReadAllText(@"..\..\..\members.json");
            var currentMem = JsonConvert.DeserializeObject<List<MemberDetails>>(members_json);

            foreach (var item in currentMem)
            {
                Console.WriteLine($"{item.LoginCode} -- {userCode}");
                if (item.LoginCode == userCode)
                {
                    input_name = $"{item.Fname} {item.Lname}:";
                }
            }
            //Date--
            string input_date = DateTime.Now.ToString("dd/MM/yyyy");

            //Review--
            string input_text = "";
            Console.CursorVisible = false;
            while (input_text.Length < 512)
            {
                Console.Clear();
                Console.WriteLine($"Gebruiker: {input_name.TrimEnd(':')}");
                Console.WriteLine($"Typ '-' om tekst te verwijderen\nTekens over: {512 - input_text.Length}\nSchrijf uw recensie en druk op enter om te bevestigen:");
                Console.WriteLine(input_text);
                char c = Console.ReadKey().KeyChar;
                if (c == 13)
                    //{
                    //    Console.Clear();
                    //    Console.WriteLine("Druk nogmaals op enter om te bevestigen of druk op backspace om terug te gaan.");
                    //    if (Console.ReadKey().KeyChar == 13)
                    //    {}
                    break;
                       
                if (c.Equals('-') && input_text.Length > 0)
                {
                    input_text = input_text.Remove(input_text.Length - 1);
                }
                else
                {
                    if (!c.Equals('-'))
                        input_text += c;
                }
            }
            int letter_count = 0;
            var temp_text = "";
            foreach (char letter in input_text)
            {
                temp_text += letter;
                letter_count++;
                if (letter_count > 70 && letter == ' ')
                {
                    temp_text += "\n";
                    letter_count = 0;
                }
            }
            input_text = temp_text;

            //Rating--
            string rating_dutch = "\nVoer het aantal sterren '*' in dat uw afgelopen bezoek waard was:";
            Console.WriteLine(rating_dutch);
            string input_rating = Console.ReadLine();
            bool valid_rating = check_rating(input_rating);

            while (valid_rating == false || input_rating.Length > 5 || input_rating.Length < 1)
            {
                Console.WriteLine("Ongeldige invoer\n" +
                "Kies [max. *****]");
                input_rating = Console.ReadLine();
                valid_rating = check_rating(input_rating);
            }
            input_rating += $" | {input_rating.Length}/5";

            var filePath = "../../../reviews.json";
            var readCurrentText = File.ReadAllText(filePath);
            var currentMembers = JsonConvert.DeserializeObject<List<Review_data>>(readCurrentText) ?? new List<Review_data>();

            currentMembers.Add(new Review_data()
            {
                Language = input_language,
                Name = input_name,
                Date = input_date,
                Text = input_text,
                Rating = input_rating,
            });

            readCurrentText = JsonConvert.SerializeObject(currentMembers, Formatting.Indented);
            File.WriteAllText(filePath, readCurrentText);
            Console.WriteLine("~Bedanken~");

            //Korting
            input_text = input_text.ToLower();
            double discount = 0.0;
            string[] good_words = new string[] {
                    "fantastisch", "geweldig", "heerlijk", "prachtig"
                };
            foreach (string item in good_words)
            {
                if (input_text.Contains(item))
                {
                    discount = 0.10;
                    break;
                }
            }

            //Toe te passen op volgende rekening
            return discount;
        }

    }
}