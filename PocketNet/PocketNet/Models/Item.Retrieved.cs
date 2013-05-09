using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PocketNet.PocketNet.Models
{
    public class ItemRetrievedWrapper
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("complete")]
        public int Complete { get; set; }

        [JsonProperty("since")]
        public int Since { get; set; }

        [JsonProperty("list")]
        public Dictionary<string, ItemRetrieved> List { get; set; }
    }

    public class ItemRetrieved
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

        [JsonProperty("is_article")] private int _isArticle;
        public bool IsArticle
        {
            get { return _isArticle == 1; }
            set { _isArticle = value ? 1 : 0; }
        }

        [JsonProperty("has_image")] private int _hasImage;
        public bool HasImage
        {
            get { return _hasImage == 1; }
            set { _hasImage = value ? 1 : 0; }
        }

        [JsonProperty("has_video")] private int _hasVideo;
        public bool HasVideo
        {
            get { return _hasVideo == 1; }
            set { _hasVideo = value ? 1 : 0; }
        }

        [JsonProperty("word_count")]
        public int WordCount { get; set; }
    }
}