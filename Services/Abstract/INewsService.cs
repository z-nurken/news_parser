using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface INewsService
    {
        Task AddNewsAsync(News news);
        Task UpdateNewsAsync(int id, News news);
        Task<News> GetNewsByIdAsync(int id);
        Task DeleteNewsByIdAsync(int id);
        Task AddNewsListAsync(List<News> news);
        Task<List<News>> GetNewsListAsync(DateTime from, DateTime to);
        Task<List<News>> GetNewsListAsync(string text);
        Task<List<NewsTopWord>> GetNewsTopWordsAsync(int count);
    }
}
