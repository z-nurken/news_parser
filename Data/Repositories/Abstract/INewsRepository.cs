using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface INewsRepository
    {
        Task AddNewsAsync(NewsEntity newsEntity);
        Task UpdateNewsAsync(int id, NewsEntity newsEntity);
        Task<NewsEntity> GetNewsByIdAsync(int id);
        Task DeleteNewsByIdAsync(int id);
        Task AddNewsListAsync(List<NewsEntity> newsEntities);
        Task<List<NewsEntity>> GetNewsListAsync(DateTime from, DateTime to);
        Task<List<NewsEntity>> GetNewsListAsync(string text);
        Task<List<NewsEntity>> GetNewsListAsync();
    }
}
