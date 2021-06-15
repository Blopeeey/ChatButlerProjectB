namespace ChatButlerProjectB
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Nl
    {
        [JsonProperty("$id")]
        public string greeting { get; set; }
        public string choicemenu { get; set; }
    }

    public class En
    {
        [JsonProperty("$id")]
        public string greeting { get; set; }
        public string choicemenu { get; set; }
    }

    public class Languages
    {
        [JsonProperty("$id")]
        public Nl nl { get; set; }
        public En en { get; set; }
    }
}