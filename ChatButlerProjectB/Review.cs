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
            Butler Winston = new Butler();
            Winston.Log(3, "Menu/Reviews lezen");
            Console.CursorVisible = false;
            var currentMembers = JsonConvert.DeserializeObject<List<Review_data>>(File.ReadAllText("../../../reviews.json")) ?? new List<Review_data>();

            int count = 0;
            foreach (var item in currentMembers)
            {
                count++;
            }

            int current_review = 0;
            string aantal_bekeken = "";
            while (true)
            {
                Console.Clear();
                if (!aantal_bekeken.Contains(current_review.ToString()))
                    aantal_bekeken += current_review.ToString();

                string output_1 = $"-Recensies La Mouette-\nrecensie {current_review + 1} van {count}\n";
                Console.WriteLine(output_1);
                Winston.Log(1, output_1);

                string output_2 = String.Format("{0}\n{1}\n{2}\n{3}", currentMembers[current_review].Date, currentMembers[current_review].Name, currentMembers[current_review].Text, currentMembers[current_review].Rating);
                Console.WriteLine(output_2);
                Winston.Log(1, output_2);

                string output_3 = "\nBlader door de reviews met de pijltjes of druk op Escape om terug te keren naar het hoofdmenu.";
                Console.WriteLine(output_3);
                Winston.Log(1, output_3);

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key.Equals(ConsoleKey.RightArrow))
                {
                    current_review++;
                    current_review = current_review % count;
                    Winston.Log(2, "invoer: <RightArrow>");
                    Console.Clear();
                }
                else if (key.Equals(ConsoleKey.LeftArrow) && current_review > 0)
                {
                    current_review--;
                    Winston.Log(2, "invoer: <LeftArrow>");
                    Console.Clear();
                }
                else if (key.Equals(ConsoleKey.Escape))
                {
                    Winston.Log(2, "invoer: <Escape>");
                    Winston.Log(1, $"Gebruiker heeft {aantal_bekeken.Length} van {count} reviews gelezen");
                    Console.Clear();
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
            Butler Winston = new Butler();
            Winston.Log(3, "Menu/Review scrhrijven");

            //Language--
            string input_language = "Nederlands";
            Winston.Log(2, $"invoertaal: {input_language}");

            //Name--
            string input_name = "";
            string code_json = File.ReadAllText(@"../../../loggedInUser.json");
            currentuser = System.Text.Json.JsonSerializer.Deserialize<UserCode>(code_json);
            string userCode = currentuser.Code;

            string members_json = File.ReadAllText(@"../../../members.json");
            var currentMem = JsonConvert.DeserializeObject<List<MemberDetails>>(members_json);

            foreach (var item in currentMem)
            {
                Console.WriteLine($"{item.LoginCode} -- {userCode}");
                if (item.LoginCode == userCode)
                {
                    input_name = $"{item.Fname} {item.Lname}:";
                }
            }
            Winston.Log(2, $"naam: {input_name}");

            //Date--
            string input_date = DateTime.Now.ToString("dd/MM/yyyy");
            Winston.Log(2, $"datum: {input_date}");

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

                // base

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
            Winston.Log(2, $"tekst: {input_text}");


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
            Winston.Log(2, $"waardering: {input_rating}");

            //Console.Clear();
            //Console.WriteLine("Bedankt voor het achterlaten van een review!\nDruk op Enter om terug te keren naar het menu of druk op Backspace om opnieuw \nte beginnen");
            //while (true)
            //{

            //    ConsoleKey key = Console.ReadKey(true).Key;

            //    if (key.Equals(ConsoleKey.Enter))
            //    {
            //        break;
            //    }
            //    else if (key.Equals(ConsoleKey.Backspace))
            //    {
            //        Make_review();
            //    }
            //}

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

            Console.Clear();
            string greet_review = "Bedankt voor het achterlaten van een review!\nDruk op een willekeurige toets om terug te keren naar het menu";
            Console.WriteLine(greet_review);
            Winston.Log(1, greet_review);
            Console.ReadKey();

            //Toe te passen op volgende rekening
            return discount;
        }

        public void Delete_review()
        {
            //
        }
    }
}