using Data.Repositories;
using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NewsParserConfigsService : INewsParserConfigsService
    {
        private readonly INewsParserConfigsRepository _parsersConfigsRepository;
        public NewsParserConfigsService(INewsParserConfigsRepository parsersConfigsRepository)
        {
            _parsersConfigsRepository = parsersConfigsRepository;
        }

        public async Task AddNewsParserConfigAsync(NewsParserConfig parserConfig)
        {
            await _parsersConfigsRepository.AddNewsParserConfigAsync(parserConfig.ToEntity());
        }

        public async Task DeleteNewsParserConfigByIdAsync(int id)
        {
            await _parsersConfigsRepository.DeleteNewsParserConfigByIdAsync(id);
        }

        public async Task<NewsParserConfig> GetNewsParserConfigByIdAsync(int id)
        {
            var entity = await _parsersConfigsRepository.GetNewsParserConfigByIdAsync(id);

            return entity.ToDomain();
        }

        public async Task UpdateNewsParserConfigAsync(int id, NewsParserConfig parserConfig)
        {
            await _parsersConfigsRepository.UpdateNewsParserConfigAsync(id, parserConfig.ToEntity());
        }
    }
}
