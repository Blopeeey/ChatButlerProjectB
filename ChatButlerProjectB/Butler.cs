
using System;
using System.IO;
using System.Text.Json;

namespace ChatButlerProjectB
{
    internal class Butler
    {
        private Reviews _reviews;

        public class Reviews
        {
            public string language { get; set; }
            public string test1 { get; set; }
            public string test2 { get; set; }
        }

        public Butler()
        {
            string json = File.ReadAllText("reviews.json");
            _reviews = JsonSerializer.Deserialize<Reviews>(json);
        }

        public string Greet()
        {
            return "Hi";
        }

        public string Review_text()
        {
            Console.WriteLine("");
            if (_reviews.language.Equals("nl"))
            {
                return "-Recensies restaurant La Mouette-\n" + _reviews.test1 + "\nDruk op de spatiebalk voor een volgende review of Druk op <enter> om (...)";
            }
            else
            {
                return "~Engels niet ondersteund~";
            }
        }
    }
}
