using System.IO;

namespace ChatButlerProjectB
{
    internal class Butler
    {
        private Greetings greetings;

        public Butler()
        {
            string json = File.ReadAllText("greetings.json");
        }

        public class Greetings
        {
            public string language { get; set; }

            class Sentences
            {
                public string nl { get; set; }
                public string en { get; set; }
            }
        }
    }
}