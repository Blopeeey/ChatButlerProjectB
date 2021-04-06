
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
        }

        public Butler()
        {

        }

        public string Greet()
        {
            return "Hi";
        }

        public string Review_text()
        {
            return "";
        }
    }
}
