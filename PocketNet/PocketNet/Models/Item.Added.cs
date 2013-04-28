using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Models
{
    public class ItemAddedWrapper
    {
        [JsonProperty("item")]
        public Dictionary<string, ItemAdded> Item { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class ItemAdded
    {
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
        [JsonProperty("normal_url")]
        public string NormalUrl { get; set; }
        [JsonProperty("resolved_id")]
        public int ResolvedId { get; set; }
        [JsonProperty("resolved_url")]
        public string ResolvedUrl { get; set; }
        [JsonProperty("domain_id")]
        public int DomainId { get; set; }
        [JsonProperty("origin_domain_id")]
        public int OriginDomainId { get; set; }
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }
        [JsonProperty("content_length")]
        public int ContentLength { get; set; }
        [JsonProperty("encoding")]
        public string Encoding { get; set; }
        [JsonProperty("date_resolved")]
        public string DateResolved { get; set; }
        [JsonProperty("date_published")]
        public string DatePublished { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }
        [JsonProperty("word_count")]
        public int WordCount { get; set; }
        [JsonProperty("has_image")]
        public bool HasImage { get; set; }
        [JsonProperty("has_video")]
        public bool HasVideo { get; set; }
        [JsonProperty("is_index")]
        public bool IsIndex { get; set; }
        [JsonProperty("is_article")]
        public bool IsArticle { get; set; }
        // TODO: Add another Json object
    }
}
