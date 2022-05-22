using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface INewsParserConfigsRepository
    {
        Task AddNewsParserConfigAsync(NewsParserConfigEntity parserConfigEntity);
        Task UpdateNewsParserConfigAsync(int id, NewsParserConfigEntity parserConfigEntity);
        Task<NewsParserConfigEntity> GetNewsParserConfigByIdAsync(int id);
        Task DeleteNewsParserConfigByIdAsync(int id);
    }
}
