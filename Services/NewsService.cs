using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task AddNewsAsync(News news)
        {
            await _newsRepository.AddNewsAsync(news.ToEntity());
        }

        public async Task AddNewsListAsync(List<News> news)
        {
            await _newsRepository.AddNewsListAsync(news.ToEntities());
        }

        public async Task DeleteNewsByIdAsync(int id)
        {
            await _newsRepository.DeleteNewsByIdAsync(id);
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            var news = await _newsRepository.GetNewsByIdAsync(id);

            return news.ToDomain();
        }

        public async Task<List<News>> GetNewsListAsync(DateTime from, DateTime to)
        {
            var newsList = await _newsRepository.GetNewsListAsync(from, to);

            return newsList.ToDomains();
        }

        public async Task<List<News>> GetNewsListAsync(string text)
        {
            var newsList = await _newsRepository.GetNewsListAsync(text);

            return newsList.ToDomains();
        }

        public async Task<List<NewsTopWord>> GetNewsTopWordsAsync(int count)
        {
            StringBuilder builder = new StringBuilder();
            var news = await _newsRepository.GetNewsListAsync();
            var newsBody = news.Select(x => x.Body);

            foreach (string body in newsBody)
            {
                builder.Append(body);
            }
            
            string formattedString = Regex.Replace(builder.ToString(), @"[^0-9a-zA-Zа-яёА-ЯЁ]+", ";");
            string[] words = formattedString.Split(';');

            var topWords = words.GroupBy(x => x)
               .Select(x => new NewsTopWord(x.Key, x.Count()))
               .OrderByDescending(x => x.Count)
               .Take(count)
               .ToList();

            return topWords;
        }

        public async Task UpdateNewsAsync(int id, News news)
        {
            await _newsRepository.UpdateNewsAsync(id, news.ToEntity());
        }
    }
}
