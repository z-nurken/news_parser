using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Token
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RemoteIpAddress { get; set; }
        public string UserAgent { get; set; }
    }
}
