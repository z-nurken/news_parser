using Data.Repositories.Abstract;
using Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NewsParserConfigsRepository : INewsParserConfigsRepository
    {
        private readonly DatabaseContext _databaseContext;
        public NewsParserConfigsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddNewsParserConfigAsync(NewsParserConfigEntity parserConfigEntity)
        {
            await _databaseContext.NewsParserConfigs.AddAsync(parserConfigEntity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteNewsParserConfigByIdAsync(int id)
        {
            NewsParserConfigEntity parserConfig = await GetNewsParserConfigByIdAsync(id);

            if (parserConfig is not null)
            {
                _databaseContext.NewsParserConfigs.Remove(parserConfig);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task<NewsParserConfigEntity> GetNewsParserConfigByIdAsync(int id)
        {
            NewsParserConfigEntity parserConfig = await _databaseContext.NewsParserConfigs.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return parserConfig;
        }

        public async Task UpdateNewsParserConfigAsync(int id, NewsParserConfigEntity parserConfigEntity)
        {
            NewsParserConfigEntity parserConfig = await GetNewsParserConfigByIdAsync(id);

            if (parserConfig is not null)
            {
                parserConfig.SiteLink = parserConfigEntity.SiteLink;
                parserConfig.XPathNews = parserConfigEntity.XPathNews;
                parserConfig.XPathTitle = parserConfigEntity.XPathTitle;
                parserConfig.XPathBody = parserConfigEntity.XPathBody;
                parserConfig.XPathDateTime = parserConfigEntity.XPathDateTime;
                parserConfig.DateTimeCultureInfo = parserConfigEntity.DateTimeCultureInfo;

                parserConfig.UpdatedDate = DateTime.Now;

                await _databaseContext.SaveChangesAsync();
            }
        }
    }
}
