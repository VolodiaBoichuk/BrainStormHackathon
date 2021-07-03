using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainStormHackathon.Application.Models;
using BrainStormHackathon.Services.Interfaces;

namespace BrainStormHackathon.Infrastructure.Services
{
    public class ContentViewService : IContentViewService
    {
        public async Task<IEnumerable<ContentInfoDto>> SearchAsync(int userId, int videoId, string orderBy = "desc")
        {
            return Enumerable.Empty<ContentInfoDto>();
        }

        public async Task<IEnumerable<ContentDto>> SearchByUserIdAsync(int userId, string orderBy = "desc")
        {
            return Enumerable.Empty<ContentDto>();
        }
    }
}