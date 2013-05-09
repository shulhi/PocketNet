using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Models
{
    public class ItemModified
    {
        [JsonProperty("action_results")]
        public List<bool> ActionResults { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
