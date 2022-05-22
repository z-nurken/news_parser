using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class News
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }
    }
}
