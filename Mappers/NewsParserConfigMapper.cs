using Domain;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class NewsParserConfigMapper
    {
        public static NewsParserConfigEntity ToEntity(this NewsParserConfig parserConfig)
        {
            if (parserConfig is null) return null;

            return new NewsParserConfigEntity
            {
                SiteLink = parserConfig.SiteLink,
                XPathNews = parserConfig.XPathNews,
                XPathTitle = parserConfig.XPathTitle,
                XPathBody = parserConfig.XPathBody,
                XPathDateTime = parserConfig.XPathDateTime,
                DateTimeFormat = parserConfig.DateTimeFormat,
                DateTimeCultureInfo = parserConfig.DateTimeCultureInfo
            };
        }

        public static NewsParserConfigEntity ToDomain(this NewsParserConfigModel parserConfig)
        {
            if (parserConfig is null) return null;

            return new NewsParserConfigEntity
            {
                SiteLink = parserConfig.SiteLink,
                XPathNews = parserConfig.XPathNews,
                XPathTitle = parserConfig.XPathTitle,
                XPathBody = parserConfig.XPathBody,
                XPathDateTime = parserConfig.XPathDateTime,
                DateTimeFormat = parserConfig.DateTimeFormat,
                DateTimeCultureInfo = parserConfig.DateTimeCultureInfo
            };
        }

        public static NewsParserConfig ToDomain(this NewsParserConfigEntity parserConfig)
        {
            if (parserConfig is null) return null;

            return new NewsParserConfig
            {
                SiteLink = parserConfig.SiteLink,
                XPathNews = parserConfig.XPathNews,
                XPathTitle = parserConfig.XPathTitle,
                XPathBody = parserConfig.XPathBody,
                XPathDateTime = parserConfig.XPathDateTime,
                DateTimeFormat = parserConfig.DateTimeFormat,
                DateTimeCultureInfo = parserConfig.DateTimeCultureInfo,
            };
        }
    }
}
