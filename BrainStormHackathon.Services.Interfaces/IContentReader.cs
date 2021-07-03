using System.Collections.Generic;
using System.Threading.Tasks;
using BrainStormHackathon.Application.Models;

namespace BrainStormHackathon.Services.Interfaces
{
    public interface IContentReader
    {
        public Task<IEnumerable<ContentInfoDto>> SearchAsync(int userId, int videoId, string orderBy = "desc");

        public Task<IEnumerable<ContentDto>> SearchByUserIdAsync(int userId, string orderBy = "desc");
    }
}