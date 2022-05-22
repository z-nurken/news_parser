using Data.Repositories.Abstract;
using Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly DatabaseContext _databaseContext;
        public NewsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddNewsAsync(NewsEntity newsEntity)
        {
            await _databaseContext.News.AddAsync(newsEntity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task AddNewsListAsync(List<NewsEntity> newsEntities)
        {
            await _databaseContext.News.AddRangeAsync(newsEntities);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteNewsByIdAsync(int id)
        {
            NewsEntity news = await GetNewsByIdAsync(id);

            if (news is not null)
            {
                _databaseContext.News.Remove(news);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task<NewsEntity> GetNewsByIdAsync(int id)
        {
            NewsEntity news = await _databaseContext.News.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return news;
        }

        public async Task<List<NewsEntity>> GetNewsListAsync(DateTime from, DateTime to)
        {
            List<NewsEntity> newsList = await _databaseContext.News
                 .Where(x => x.PublicationDate >= from && x.PublicationDate <= to)
                 .ToListAsync();

            return newsList;
        }

        public async Task<List<NewsEntity>> GetNewsListAsync(string text)
        {
            List<NewsEntity> newsList = await _databaseContext.News
                 .Where(x => x.Body.Contains(text))
                 .ToListAsync();

            return newsList;
        }

        public async Task<List<NewsEntity>> GetNewsListAsync()
        {
            List<NewsEntity> newsList = await _databaseContext.News
                 .ToListAsync();

            return newsList;
        }

        public async Task UpdateNewsAsync(int id, NewsEntity newsEntity)
        {
            NewsEntity news = await GetNewsByIdAsync(id);

            if (news is not null)
            {
                news.Title = newsEntity.Title;
                news.Body = newsEntity.Body;
                news.PublicationDate = newsEntity.PublicationDate;
                news.UpdatedDate = DateTime.Now;

                await _databaseContext.SaveChangesAsync();
            }
        }
    }
}
