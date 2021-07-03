using System.Collections.Generic;
using System.Threading.Tasks;
using BrainStormHackathon.Application.Models;
using BrainStormHackathon.Services.Interfaces;

namespace BrainStormHackathon.Infrastructure.Services
{
    public class ContentViewService : IContentViewService
    {
        private readonly IContentReader _contentReader;

        public ContentViewService(IContentReader contentReader)
        {
            _contentReader = contentReader;
        }

        public async Task<IEnumerable<ContentInfoDto>> SearchAsync(int userId, int videoId, string orderBy = "desc") 
            => await _contentReader.SearchAsync(userId, videoId, orderBy);

        public async Task<IEnumerable<ContentDto>> SearchByUserIdAsync(int userId, string orderBy = "desc") 
            => await _contentReader.SearchByUserIdAsync(userId, orderBy);
    }
}