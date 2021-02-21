using System;
using Newtonsoft.Json;

namespace M2MCaller.Models
{
    public class Message
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
