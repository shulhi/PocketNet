using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Models
{
    public class AddedArticle
    {
        public int ItemId { get; set; }
        public string NormalUrl { get; set; }
        public int ResolvedId { get; set; }
        public string ResolvedUrl { get; set; }
        public int DomainId { get; set; }
        public int OriginDomainId { get; set; }
        public int ResponseCode { get; set; }
        public string MimeType { get; set; }
        public int ContentLength { get; set; }
        public string Encoding { get; set; }
        public string DateResolved { get; set; }
        public string DatePublished { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public int WordCount { get; set; }
        public bool HasImage { get; set; }
        public bool HasVideo { get; set; }
        public bool IsIndex { get; set; }
        public bool IsArticle { get; set; }
    }
}
