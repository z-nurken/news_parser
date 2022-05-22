using Domain;
using HtmlAgilityPack;
using Services.Abstract;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NewsParsersService : INewsParsersService
    {
        private NewsParserConfig _parserConfig;
        public async Task<List<News>> ParseByConfigurationAsync(NewsParserConfig parserConfig)
        {
            _parserConfig = parserConfig;

            HtmlDocument newsDoc = await LoadFromWebAsync(_parserConfig.SiteLink);

            IEnumerable<HtmlNode> newsNodes = newsDoc.DocumentNode.SelectNodes(_parserConfig.XPathNews)?.Take(30);

            List<News> newsList = new List<News>();

            if (newsNodes is not null)
                foreach (HtmlNode newsNode in newsNodes)
                {
                    string newsPath = newsNode?.GetAttributeValue("href", string.Empty);

                    var parsedNews = await ParseNewsAsync(newsPath);

                    newsList.Add(parsedNews);
                }

            return newsList;
        }

        private async Task<News> ParseNewsAsync(string newsPath)
        {
            News news = new News();
            
            string newsLink = AbsoluteUrlString.Get(_parserConfig.SiteLink, newsPath);

            HtmlDocument newsDoc = await LoadFromWebAsync(newsLink);

            news.Link = newsLink;
            news.Title = newsDoc?.DocumentNode?.SelectSingleNode(_parserConfig.XPathTitle)?.InnerText;
            news.Body = newsDoc?.DocumentNode?.SelectSingleNode(_parserConfig.XPathBody)?.InnerText;
            string dateTimeStr = newsDoc?.DocumentNode.SelectSingleNode(_parserConfig.XPathDateTime)?.InnerText;

            CultureInfo cultureInfo = CultureInfo.InvariantCulture;

            if (!string.IsNullOrEmpty(_parserConfig.DateTimeCultureInfo))
                cultureInfo = CultureInfo.GetCultureInfo(_parserConfig.DateTimeCultureInfo);

            if (!string.IsNullOrEmpty(dateTimeStr))
                news.PublicationDate = DateTimeFormatter.Format(dateTimeStr, _parserConfig.DateTimeFormat, cultureInfo);

            return news;
        }

        private async Task<HtmlDocument> LoadFromWebAsync(string siteLink)
        {
            try
            {
                HtmlWeb htmlWeb = new();

                HtmlDocument htmlDocument = await htmlWeb.LoadFromWebAsync(siteLink);

                return htmlDocument;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
