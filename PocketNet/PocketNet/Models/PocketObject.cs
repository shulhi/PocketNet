using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PocketNet.PocketNet.Models
{
    public class PocketObject
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("complete")]
        public int Complete { get; set; }

        [JsonProperty("since")]
        public int Since { get; set; }

        [JsonProperty("list")]
        public IDictionary<string, Article> List { get; set; }
    }
}