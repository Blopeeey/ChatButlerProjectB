using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChatButlerProjectB
{
    public class Review_data {
        public string Language { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string Rating { get; set; }
    }
    internal class Review
{
     
    public void Make_review()
    {
        Console.WriteLine("[NL]In welke taal gaat u een review schrijven?\n[En]In which language are you going to write a review?" +
            "\n[1] Nederlands\n" +
            "[2] English\n");
        string taalkeuze = Console.ReadLine();
        string input_language = taalkeuze == "1" ? "Nederlands" : "English";
        string input_date = DateTime.Now.ToString("dd/MM/yyyy");

        //naam moet uiteindelijk vanuit account komen
        string name_dutch = "Voer uw volledige naam in:";
        string name_english = "Enter your full name:";
        Console.WriteLine(input_language == "Nederlands" ? name_dutch : name_english);
        string input_name = Console.ReadLine();

        string review_dutch = "Schrijf uw recensie:";
        string review_english = "Write your review:";
        Console.WriteLine(input_language == "Nederlands" ? review_dutch : review_english);
        string input_text = Console.ReadLine();

        string rating_dutch = "Voer het aantal sterren in dat uw afgelopen bezoek waard was:";
        string rating_english = "Enter the number of stars your last visit was worth:";
        Console.WriteLine(input_language == "Nederlands" ? rating_dutch : rating_english);
        string input_rating = Console.ReadLine();

        //Lees door json heen
        var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
        var appRoot = appPathMatcher.Match(exePath).Value;

        var filePath = appRoot + @"\reviews.json";
        var readCurrentText = File.ReadAllText(filePath);
        var currentMembers = JsonConvert.DeserializeObject<List<Review_data>>(readCurrentText) ?? new List<Review_data>();
        //Haal oude gebruikers op en voeg nieuwe gebruiker daar aan
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
    }

}
}


//Main
//Butler Winston = new Butler();

//Console.WriteLine(Winston.Review_text());

//Review New = new Review()
//{
//    Language = "Dutch",
//    Name = "Rob",
//    Date = $"{23}/{03}/{2021}",
//    Text = @"We werden bij het entree welkom geheten door Max. Een jongeman die zijn vak verstaat.
//Wij hebben hier genoten van een 5-gangen diner in Restaurant Bougainville (3e etage)
//onder leiding van Tim Golsteijn (chef-kok). Het bij passende wijnarrangement,
//welke ons werd gepresenteerd door Lendl (beste sommelier van Nederland) en Goos,
//was verrassend lekker. De gerechten waren behalve heel erg lekker, elk afzonderlijk,
//Instagram-waardig. Ze werden uitgeserveerd door Max, Goos en Lendl. Dit aanvullend
//programma was mede door dit team en de gehele setting met uitzicht op de Dam subliem.
//Kortom, wij komen hier zeker nog een keer terug!",
//    Rating = 5
//};
//Console.WriteLine(New.format());
