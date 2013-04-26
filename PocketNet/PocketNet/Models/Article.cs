using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PocketNet.PocketNet.Models
{
    public class Article
    {
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
        [JsonProperty("resolved_id")]
        public int ResolvedId { get; set; }
        [JsonProperty("given_url")]
        public string GivenUrl { get; set; }
        [JsonProperty("resolved_url")]
        public string ResolvedUrl { get; set; }
        [JsonProperty("given_title")]
        public string GivenTitle { get; set; }
        [JsonProperty("resolved_title")]
        public string ResolvedTitle { get; set; }
        [JsonProperty("favorite")]
        public int Favorite { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }
        [JsonProperty("is_article")]
        public int IsArticle { get; set; }
        [JsonProperty("has_image")]
        public int HasImage { get; set; }
        [JsonProperty("has_video")]
        public int HasVideo { get; set; }
        [JsonProperty("word_count")]
        public int WordCount { get; set; }
    }
}
