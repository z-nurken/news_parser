using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class AbsoluteUrlString
    {
        public static string Get(string baseUrl, string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
                uri = new Uri(new Uri(baseUrl), uri);
            return uri.ToString();
        }
    }
}
