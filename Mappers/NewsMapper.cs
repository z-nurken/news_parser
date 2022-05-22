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
    public static class NewsMapper
    {
        public static NewsEntity ToEntity(this News news)
        {
            if (news is null) return null;

            return new NewsEntity
            {
                Title = news.Title,
                Body = news.Body,
                PublicationDate = news.PublicationDate,
                Link = news.Link
            };
        }
        
        public static List<NewsEntity> ToEntities(this List<News> newsList)
        {
            return newsList.Select(news => new NewsEntity()
            {
                Title = news.Title,
                Body = news.Body,
                PublicationDate = news.PublicationDate,
                Link = news.Link
            }).ToList();
        }

        public static News ToDomain(this NewsModel news)
        {
            if (news is null) return null;

            return new News
            {
                Title = news.Title,
                Body = news.Body,
                PublicationDate = news.PublicationDate,
                Link = news.Link
            };
        }

        public static List<News> ToDomains(this List<NewsEntity> newsList)
        {
            return newsList.Select(news => new News()
            {
                Title = news.Title,
                Body = news.Body,
                PublicationDate = news.PublicationDate,
                Link = news.Link
            }).ToList();
        }

        public static News ToDomain(this NewsEntity news)
        {
            if (news is null) return null;

            return new News
            {
                Title = news.Title,
                Body = news.Body,
                PublicationDate = news.PublicationDate,
                Link = news.Link
            };
        }
    }
}
