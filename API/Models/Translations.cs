using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public class Translations
    {
        [JsonProperty("de")]
        public string De { get; set; }

        [JsonProperty("es")]
        public string Es { get; set; }

        [JsonProperty("fr")]
        public string Fr { get; set; }

        [JsonProperty("ja")]
        public string Ja { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }
    }
}
