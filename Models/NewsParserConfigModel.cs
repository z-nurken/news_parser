using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class NewsParserConfigModel
    {
        public string SiteLink { get; set; }
        public string XPathNews { get; set; }

        public string XPathTitle { get; set; }
        public string XPathBody { get; set; }
        public string XPathDateTime { get; set; }
        public string DateTimeFormat { get; set; }
        public string DateTimeCultureInfo { get; set; }
        
    }
}
