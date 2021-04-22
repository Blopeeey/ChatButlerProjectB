namespace ChatButlerProjectB
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Nl
    {
        public string greeting { get; set; }
        public string choicemenu { get; set; }
    }

    public class En
    {
        public string greeting { get; set; }
        public string choicemenu { get; set; }
    }

    public class Languages
    {
        public Nl nl { get; set; }
        public En en { get; set; }
    }
}
