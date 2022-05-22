using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface INewsParserConfigsService
    {
        Task AddNewsParserConfigAsync(NewsParserConfig parserConfigEntity);
        Task UpdateNewsParserConfigAsync(int id, NewsParserConfig parserConfigEntity);
        Task<NewsParserConfig> GetNewsParserConfigByIdAsync(int id);
        Task DeleteNewsParserConfigByIdAsync(int id);
    }
}
