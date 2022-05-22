using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NewsParserConfigEntity : BaseEntity
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
