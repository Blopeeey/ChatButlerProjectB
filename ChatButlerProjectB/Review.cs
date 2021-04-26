using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
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

    internal class Review
    {
        public void Get_reviews()
        {
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
                Console.WriteLine($"-Reviews La Mouette-\nreview {current_review + 1} van {count}\n");
                Console.WriteLine("{0}\n{1}\n{2}\n{3}", currentMembers[current_review].Date, currentMembers[current_review].Name, currentMembers[current_review].Text, currentMembers[current_review].Rating);
                Console.WriteLine("\nBlader door de reviews met de pijltjes of ~blabla~ door op enter te drukken.");

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key.Equals(ConsoleKey.RightArrow) && (current_review + 1) < count)
                {
                    current_review++;
                }
                else if (key.Equals(ConsoleKey.LeftArrow) && current_review > 0)
                {
                    current_review--;
                }
                else if (key.Equals(ConsoleKey.Enter))
                {
                    Program.Main();
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
            Console.WriteLine("[NL]In welke taal gaat u een review schrijven?\n[En]In which language are you going to write a review?" +
                "\n[1] Nederlands\n" +
                "[2] English");
            Console.Write("Keuze / Choice: ");
            string taalkeuze = Console.ReadLine();

            while (taalkeuze != "1" && taalkeuze != "2")
            {
                Console.WriteLine("Ongeldige invoer / Invalid input\n" +
                    "Kies / Choose [1] / [2]");
                taalkeuze = Console.ReadLine();
            }
            string input_language = taalkeuze == "1" ? "Nederlands" : "English";

            string input_date = DateTime.Now.ToString("dd/MM/yyyy");

            //naam moet uiteindelijk vanuit account komen
            string name_dutch = "\nVoer uw volledige naam in:";
            string name_english = "\nEnter your full name:";
            Console.WriteLine(input_language == "Nederlands" ? name_dutch : name_english);
            string input_name = Console.ReadLine() + ':';

            //string review_dutch = "\nSchrijf uw recensie:";
            //string review_english = "\nWrite your review:";
            //Console.WriteLine(input_language == "Nederlands" ? review_dutch : review_english);
            string input_text = "";
            while (input_text.Length < 512)
            {
                Console.Clear();
                Console.WriteLine($"Schrijf uw recensie\nTyp '-' om tekst te verwijderen\nTekens over: {512 - input_text.Length}");
                Console.WriteLine(input_text);
                char c = Console.ReadKey().KeyChar;
                if (c == 13)
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

            string rating_dutch = "\nVoer het aantal sterren '*' in dat uw afgelopen bezoek waard was:";
            string rating_english = "\nEnter the number of stars '*' your last visit was worth:";
            Console.WriteLine(input_language == "Nederlands" ? rating_dutch : rating_english);
            string input_rating = Console.ReadLine();
            bool valid_rating = check_rating(input_rating);

            while (valid_rating == false || input_rating.Length > 5 || input_rating.Length < 1)
            {
                Console.WriteLine("Ongeldige invoer / Invalid input\n" +
                "Kies / Choose [max. *****]");
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

            // korting en reactie ober
            input_text = input_text.ToLower();
            double discount = 0.0;
            string[] good_words = new string[] {
                "fantastisch", "geweldig", "heerlijk", "prachtig",
                "fantastic", "wonderful", "delicious", "beautiful",
            };
            foreach (string item in good_words)
            {
                if (input_text.Contains(item))
                {
                    discount = 0.10;
                    break;
                }
            }

            if (input_text.Contains("mieters") || input_text.Contains("super") || input_text.Contains("vet") || input_text.Contains("top"))
            {
                //frown
            }

            //toe te passen op volgende rekening
            return discount;
        }

    }
}