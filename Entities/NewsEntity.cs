using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NewsEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }
    }
}
